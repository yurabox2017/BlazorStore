using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int AppointmentId { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey(nameof(AppointmentId))]
        public Appointment Appointment { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser Customer { get; set; }
    }
}
