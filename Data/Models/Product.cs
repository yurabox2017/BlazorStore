using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2), MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(1, 1000000)]
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public string ShadeColor { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
        public int GoodsMarkerId { get; set; }
        [ForeignKey(nameof(GoodsMarkerId))]
        public virtual GoodsMarker GoodsMarker { get; set; }
        public int AppointmentsId { get; set; }
        public virtual List<Appointment>  Appointments { get; set; }
    }
}
