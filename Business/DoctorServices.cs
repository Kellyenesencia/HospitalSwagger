using Data;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DoctorServices
    {
        private AppDbContext db;
        public DoctorServices(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<Doctor> GetByIdAsync(Guid id)
        {
            return await db.Doctors.Where(x => x.Id == id).Include(x=> x.Person).Include(x => x.Hospital).FirstOrDefaultAsync();
        }
        public async Task<List<Doctor>> GetListAsync()
        {
            return await db.Doctors.Include(x => x.Person).Include(x => x.Hospital).ToListAsync();
        }
        public async Task<Doctor> DeleteAsync(Guid id)
        {
            var resultOld = await GetByIdAsync(id);

            db.Remove(resultOld);
            db.SaveChanges();
            return resultOld;
        }
        public async Task<bool> ConfirmCapacityDoctor(Doctor data)
        {
            var hospitalData = await db.Hospitals.Where(x => x.Id == data.HospitalId).FirstOrDefaultAsync();
            var doctorsInHospital = await db.Doctors.Where(x => x.HospitalId == hospitalData.Id).CountAsync();

            if (hospitalData.CantWorkers > doctorsInHospital)
            {
                return true;
            }
            return false;
        }
        public async Task<Doctor> AddAsync(Doctor newData)
        {
            if (await ConfirmCapacityDoctor(newData) == true)
            {
                await db.AddAsync(newData);
                db.SaveChanges();
                return newData;
            }
            return null;
        }
        public async Task<Doctor> EditAsync(Doctor newData)
        {
            var resultOld = await GetByIdAsync(newData.Id);
            resultOld.Area = newData.Area;
            resultOld.Function= newData.Function;
            resultOld.HoursDay = newData.HoursDay;
            resultOld.PersonId = newData.PersonId;
            resultOld.HospitalId = newData.HospitalId;
            db.SaveChanges();
            return resultOld;
        }
        public async Task<Doctor> AddEditAsync(Doctor data)
        {
            if (await GetByIdAsync(data.Id) != null)
            {
                return await EditAsync(data);
            }
            return await AddAsync(data);
        }
        public async Task<List<Doctor>> DoctorsWhoArePatients()
        {
            var listDoctors = from doctor in db.Doctors
                              join patient in db.Patients on doctor.PersonId equals patient.PersonId
                              where doctor.PersonId == patient.PersonId
                              select doctor;
            return await listDoctors.Include(x => x.Person).Include(x => x.Hospital).ToListAsync();
        }
    }
}
