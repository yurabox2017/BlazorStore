using BlazorStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Repository.Services
{
    public interface IRepositoryAppointment
    {
        Task<List<Appointment>> GetAllAppointmentsAsync();
        Task<bool> CreateAppointmentAsync(Appointment appointment, List<Product> productsList);
        Task<bool> UpdateAppointmentAsync(Appointment appointment);
        Task<bool> DeleteAppointmentAsync(int id);
        Task<Appointment> GetSingleAppointmentAsync(int id);
    }
}
