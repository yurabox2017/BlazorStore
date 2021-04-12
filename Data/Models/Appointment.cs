using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        // [ForeignKey(nameof(ProductId))] нельзя делать вторичный ключ
        public virtual List<Product> Products { get; set; }
        //userId
    }
}
