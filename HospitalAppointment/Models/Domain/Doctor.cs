using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppointment.Models.Domain
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Departmant { get; set; }
        [NotMapped]
        public string? MovieImage { get; set; }
        [Required]
        public string? Title { get; set; }

        [Required]
        [NotMapped]
        public List<int>? AvailableTimes { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? TimeList { get; set; }
        [NotMapped] 
        public IEnumerable<SelectListItem>? DepartmantList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? TimeListWithSelectedTimeGap { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? DoctorList { get; set; }
        [NotMapped]
        public int SingleTime { get; set; }

    }
}
