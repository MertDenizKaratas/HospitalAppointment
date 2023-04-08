using HospitalAppointment.Models.Domain;

namespace HospitalAppointment.Repositories.Abstract
{
    public interface IDoctorService
    {
        bool Add(Doctor model);
        bool Update(Doctor model);
        Doctor GetById(int id);
        bool Delete(int id);
        IQueryable<Doctor> List();
        List<int> GetTimesByDoctorId(int doctorId);
        bool AddDoctorWithAvailableTime(Doctor doctor);
       
    }
}
