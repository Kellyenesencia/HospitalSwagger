using Data;
using Infrastructure.DTO.HospitalDTOs;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PatientServices
    {
        private AppDbContext db;
        public PatientServices(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<Patient> GetByIdAsync(Guid id)
        {
            return await db.Patients.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Patient>> GetListAsync()
        {
            return await db.Patients.Include(x => x.Person).Include(x => x.Hospital).ToListAsync();
        }
        public async Task<Patient> DeleteAsync(Guid id)
        {
            var resultOld = await GetByIdAsync(id);

            db.Remove(resultOld);
            db.SaveChanges();
            return resultOld;
        }
        public async Task<bool> ConfirmCapacityPatient(Patient data)
        {
            var hospitalData = await db.Hospitals.Where(x => x.Id == data.HospitalId).FirstOrDefaultAsync();
            var pacientsInHospital = await db.Patients.Where(x => x.HospitalId == hospitalData.Id).CountAsync();

            if (hospitalData.PatientCapacity > pacientsInHospital)
            {
                return true;
            }
            return false;
        }
        public async Task<Patient> AddAsync(Patient newData)
        {
            if (await ConfirmCapacityPatient(newData) == true)
            {
                await db.AddAsync(newData);
                db.SaveChanges();
                return newData;
            }
            return null;
        }
        public async Task<Patient> EditAsync(Patient newData)
        {
            var resultOld = await GetByIdAsync(newData.Id);
            resultOld.Date = newData.Date;
            resultOld.Reason = newData.Reason;
            resultOld.PersonId = newData.PersonId;
            resultOld.HospitalId = newData.HospitalId;
            db.SaveChanges();
            return resultOld;
        }
        public async Task<Patient> AddEditAsync(Patient data)
        {
            if (await GetByIdAsync(data.Id) != null)
            {
                return await EditAsync(data);
            }
            return await AddAsync(data);
        }
        public async Task<Patient> RandomPatient(Guid idDoctor)
        {
            var doctorData = await db.Doctors.Where(x => x.Id == idDoctor).FirstOrDefaultAsync();
            var patientList = await db.Patients.Where(x => x.HospitalId == doctorData.HospitalId).Include(x => x.Person).Include(x => x.Hospital).ToListAsync();

            return patientList[new Random().Next(patientList.Count - 1)];
        }
    }
}
