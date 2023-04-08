namespace HospitalAppointment.Models.Domain
{
    public class DoctorTime
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int TimeId { get; set; }
    }
}
