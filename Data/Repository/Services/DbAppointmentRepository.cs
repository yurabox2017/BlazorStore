using BlazorStore.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorStore.Data.Repository.Services
{
    public class DbAppointmentRepository : IRepositoryAppointment
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DbAppointmentRepository(ApplicationDbContext db,
                                       IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateAppointmentAsync(Appointment appointment, List<Product> productsList)
        {

            if (appointment is null)
                return false;

            await _db.Appointments.AddAsync(appointment);
            await _db.SaveChangesAsync();


            // var currentUser = _httpContextAccessor.HttpContext.User;

            var claimsIdentity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;

            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            var orderId = 0;

            Order order = new() { AppointmentId = appointment.Id, UserId = userId, CreatedAt = DateTime.Now };

            await _db.Orders.AddAsync(order);

            await _db.SaveChangesAsync();

            orderId = order.Id;

            OrderDetails orderDetails = new();

            foreach (var item in productsList)
            {
                orderDetails.OrderId = orderId;
                orderDetails.UserId = userId;
                orderDetails.Quantity = item.Quantity;
                orderDetails.ProductId = item.Id;
                await _db.OrderDetails.AddAsync(orderDetails);
                await _db.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            var appointmentFromDb = await _db.Appointments.FindAsync(id);
            if (appointmentFromDb is null)
                return false;
            _db.Appointments.Remove(appointmentFromDb);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Appointment>> GetAllAppointmentsAsync() => await _db.Appointments.ToListAsync();

        public async Task<Appointment> GetSingleAppointmentAsync(int id) => await _db.Appointments.FirstOrDefaultAsync(x => x.Id.Equals(id));

        public async Task<bool> UpdateAppointmentAsync(Appointment appointment)
        {
            var appointmentFromDb = await _db.Appointments.FindAsync(appointment.Id);
            if (appointmentFromDb is null)
                return false;

            _db.Appointments.Update(appointment);

            await _db.SaveChangesAsync();
            return true;
        }
    }
}
