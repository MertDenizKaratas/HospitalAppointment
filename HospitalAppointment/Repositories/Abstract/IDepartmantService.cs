using HospitalAppointment.Models.Domain;

namespace HospitalAppointment.Repositories.Abstract
{
    public interface IDepartmantService
    {
        bool Add(Departmant model);
        bool Update(Departmant model);
        Departmant GetById(int id);
        bool Delete(int id);
        IQueryable<Departmant> List();

    }
}
