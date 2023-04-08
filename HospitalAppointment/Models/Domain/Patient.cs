using System.ComponentModel.DataAnnotations;

namespace HospitalAppointment.Models.Domain
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
    }
}
