using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppointment.Models.Domain
{
    public class ReservationDoctorTime
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int TimeId { get; set; }
    }
}
