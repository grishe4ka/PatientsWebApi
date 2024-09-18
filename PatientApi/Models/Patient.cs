using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientApi.Models
{
    public class Patient
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Family { get; set; }

        //[Unicode(true)]
        [Column(TypeName = "nvarchar(200)")]
        public string[] Given { get; set; }

        public string Use { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public bool Active { get; set; }
    }
}