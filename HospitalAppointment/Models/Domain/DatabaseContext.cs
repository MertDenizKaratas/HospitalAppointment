using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Departmant> Departmant { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<DoctorTime> DoctorTime { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<ReservationDoctorTime> ReservationDoctorTime { get; set; }
        public DbSet<Time> Times { get; set; }
    }
}
