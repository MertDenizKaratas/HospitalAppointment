using HospitalAppointment.Models.Domain;

namespace HospitalAppointment.Repositories.Abstract
{
    public interface ITimeService
    {
        bool Add(Time model);
        bool Update(Time model);
        Time GetById(int id);
        bool Delete(int id);
        IQueryable<Time> List();
        IQueryable<Time> GetDoctorFreeTime(int doctorId);
        IQueryable<Time> SelectedList
        
    }
}
