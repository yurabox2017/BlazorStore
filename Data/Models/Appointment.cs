using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2), MaxLength(20)]
        public string CustomerName { get; set; }
        [Phone]
        public string CustomerPhone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsConfirmed { get; set; }
        //public int ProductId { get; set; }
        //[ForeignKey(nameof(ProductId))]
        public virtual ICollection<Product> Products { get; set; }
        //userId
    }
}
