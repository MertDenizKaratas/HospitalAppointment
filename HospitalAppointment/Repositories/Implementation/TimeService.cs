using HospitalAppointment.Models.Domain;
using HospitalAppointment.Repositories.Abstract;

namespace HospitalAppointment.Repositories.Implementation
{
    public class TimeService : ITimeService
    {
        private readonly DatabaseContext ctx;
        public TimeService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Time model)
        {
            try
            {
                ctx.Times.Add(model);
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
                ctx.Times.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Time GetById(int id)
        {
            return ctx.Times.Find(id);
        }

        public IQueryable<Time> GetDoctorFreeTime(int doctorId)
        {
            var d = ctx.DoctorTime.Where(a=>a.DoctorId== doctorId).Select(a=>a.TimeId).ToList();
            return ctx.Times.Where(a => d.Contains(a.Id));
        }

        public IQueryable<Time> List()
        {
            var data = ctx.Times.AsQueryable();
            return data;
        }

        public bool Update(Time model)
        {
            try
            {
                ctx.Times.Update(model);
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
