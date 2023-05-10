using Data;
using Infrastructure.DTO.HospitalDTOs;
using Infrastructure.Entities;
using Infrastructure.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class HospitalServices
    {
        private AppDbContext db;
        public HospitalServices(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<Hospital> GetByIdAsync(Guid id)
        {
            return await db.Hospitals.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Hospital>> GetListAsync()
        {
            return await db.Hospitals.ToListAsync();
        }
        public async Task<Hospital> DeleteAsync(Guid id)
        {
            var resultOld = await GetByIdAsync(id);

            db.Remove(resultOld);
            db.SaveChanges();
            return resultOld;
        }
        public async Task<Hospital> AddAsync(Hospital newData)
        {
            await db.AddAsync(newData);
            db.SaveChanges();
            return newData;
        }
        public async Task<Hospital> EditAsync(Hospital newData)
        {
            var resultOld = await GetByIdAsync(newData.Id);
            resultOld.Name = newData.Name;
            resultOld.Location = newData.Location;
            resultOld.Specialty = newData.Specialty;
            resultOld.PatientCapacity = newData.PatientCapacity;
            resultOld.CantWorkers = newData.CantWorkers;
            db.SaveChanges();
            return resultOld;
        }
        public async Task<Hospital> AddEditAsync(Hospital data)
        {
            if (await GetByIdAsync(data.Id) != null)
            {
                return await EditAsync(data);
            }
            return await AddAsync(data);
        }
        public async Task<List<HospitalMiniDTO>> GetListHospitalsCapacityAsync()
        {
            var listHospitals = from hospital in db.Hospitals
                                select new HospitalMiniDTO
                                {
                                    Id = hospital.Id,
                                    Name = hospital.Name,
                                    Location = hospital.Location,
                                    Specialty = hospital.Specialty,
                                    PatientCapacity = hospital.PatientCapacity,
                                    CantWorkers = hospital.CantWorkers,
                                    CurrentCapacity = db.Patients.Where(x => x.HospitalId == hospital.Id).Count(),
                                    CurrentCantDoctors = db.Doctors.Where(x => x.HospitalId == hospital.Id).Count()
                                };
            return await listHospitals.ToListAsync();
        }
        public async Task<List<Hospital>> GetListHospitalByPatientReasonAsync(ReasonPatientEnum reason)
        {
            var listHospitals = from hospital in db.Hospitals
                                join patient in db.Patients on hospital.Id equals patient.HospitalId
                                where patient.Reason == reason
                                select hospital;
            return await listHospitals.ToListAsync();
        }
        
    }
}
