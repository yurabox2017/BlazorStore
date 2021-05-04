using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [Required]
        [MinLength(5), MaxLength(200)]
        public string Address { get; set; }
        [NotMapped]
        public string FullName => ToString();
        public override string ToString() => $"{LastName} {FirstName}";

    }
}
