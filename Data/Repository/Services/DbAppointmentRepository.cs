using BlazorStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Repository.Services
{
    public class DbAppointmentRepository : IRepositoryAppointment
    {
        private readonly ApplicationDbContext _db;
        public DbAppointmentRepository(ApplicationDbContext db) => _db = db;

        public async Task<bool> CreateAppointmentAsync(Appointment appointment)
        {
            if (appointment is null)
                return false;
            await _db.Appointments.AddAsync(appointment);
            await _db.SaveChangesAsync();
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

        public async Task<List<Appointment>> GetAllAppointmentsAsync() => await _db.Appointments.Include(x => x.Product).ToListAsync();

        public async Task<Appointment> GetSingleAppointmentAsync(int id) => await _db.Appointments.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id.Equals(id));

        public async Task<bool> UpdateAppointmentAsync(Appointment appointment)
        {
            var appointmentFromDb = await _db.Products.FindAsync(appointment.Id);
            if (appointmentFromDb is null)
                return false;

            _db.Appointments.Update(appointment);

            await _db.SaveChangesAsync();
            return true;
        }
    }
}
