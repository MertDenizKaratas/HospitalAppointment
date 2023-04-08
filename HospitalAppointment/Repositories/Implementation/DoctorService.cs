using HospitalAppointment.Models.Domain;
using HospitalAppointment.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace HospitalAppointment.Repositories.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly DatabaseContext ctx;
        public DoctorService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Doctor model)
        {
            try
            {
                ctx.Doctor.Add(model);
                ctx.SaveChanges();
                foreach (int timeId in model.AvailableTimes)
                {
                    var doctortime = new DoctorTime
                    {
                        DoctorId = model.Id,
                        TimeId = timeId,

                    };
                    ctx.DoctorTime.Add(doctortime);
                   
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddDoctorWithAvailableTime(Doctor doctor)
        {
            int id = doctor.Id;
            int Timeid = doctor.SingleTime;
            try
            {
                var d = new ReservationDoctorTime
                {
                    DoctorId = id,
                    TimeId = Timeid
                };
                ctx.ReservationDoctorTime.Add(d);
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
                ctx.Doctor.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Doctor GetById(int id)
        {
            return ctx.Doctor.Find(id);
        }

        public List<int> GetTimesByDoctorId(int doctorId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Doctor> List()
        {
            var data = ctx.Doctor.AsQueryable();
            return data;
        }



        public bool Update(Doctor model)
        {
            try
            {
                var timesToDeleted = ctx.DoctorTime.Where(a => a.DoctorId == model.Id && !model.AvailableTimes.Contains(a.TimeId)).ToList();
                foreach (var mGenre in timesToDeleted)
                {
                    ctx.DoctorTime.Remove(mGenre);
                }
                foreach (int genId in model.AvailableTimes)
                {
                    var movieGenre = ctx.DoctorTime.FirstOrDefault(a => a.DoctorId == model.Id && a.TimeId == genId);
                    if (movieGenre == null)
                    {
                        movieGenre = new DoctorTime { TimeId = genId, DoctorId = model.Id };
                        ctx.DoctorTime.Add(movieGenre);
                    }
                }

                ctx.Doctor.Update(model);

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
