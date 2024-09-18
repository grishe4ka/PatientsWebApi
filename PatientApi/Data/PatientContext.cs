using Microsoft.EntityFrameworkCore;
using PatientApi.Models;
using System.Collections.Generic;

namespace PatientApi.Data
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
    }
}
