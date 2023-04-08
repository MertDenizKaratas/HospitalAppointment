using HospitalAppointment.Models.Domain;
using HospitalAppointment.Repositories.Abstract;

namespace HospitalAppointment.Repositories.Implementation
{
    public class DepartmantService : IDepartmantService
    {
        private readonly DatabaseContext ctx;
        public DepartmantService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Departmant model)
        {
            try
            {
                ctx.Departmant.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                ctx.Departmant.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Departmant GetById(int id)
        {
            return ctx.Departmant.Find(id);
        }

        public IQueryable<Departmant> List()
        {
            var data = ctx.Departmant.AsQueryable();
            return data;
        }


        public bool Update(Departmant model)
        {
            try
            {
                ctx.Departmant.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
