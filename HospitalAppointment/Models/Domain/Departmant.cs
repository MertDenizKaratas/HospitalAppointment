using System.ComponentModel.DataAnnotations;

namespace HospitalAppointment.Models.Domain
{
    public class Departmant
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
