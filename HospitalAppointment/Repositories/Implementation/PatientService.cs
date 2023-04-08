using HospitalAppointment.Models.Domain;
using HospitalAppointment.Repositories.Abstract;

namespace HospitalAppointment.Repositories.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly DatabaseContext ctx;
        public PatientService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Patient model)
        {
            try
            {
                ctx.Patient.Add(model);
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
                ctx.Patient.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Patient GetById(int id)
        {
            return ctx.Patient.Find(id);
        }

        public IQueryable<Patient> List()
        {
            var data = ctx.Patient.AsQueryable();
            return data;
        }



        public bool Update(Patient model)
        {
            try
            {
                ctx.Patient.Update(model);
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
