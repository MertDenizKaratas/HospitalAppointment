using HospitalAppointment.Models.Domain;

namespace HospitalAppointment.Repositories.Abstract
{
    public interface IPatientService
    {
        bool Add(Patient model);
        bool Update(Patient model);
        Patient GetById(int id);
        bool Delete(int id);
        IQueryable<Patient> List();
    }
}
