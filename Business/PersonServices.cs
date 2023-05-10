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
    public class PersonServices
    {
        private AppDbContext db;
        public PersonServices(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<Person> GetByIdAsync(Guid id)
        {
            return await db.Persons.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Person>> GetListAsync()
        {
            return await db.Persons.ToListAsync();
        }
        public async Task<Person> DeleteAsync(Guid id)
        {
            var resultOld = await GetByIdAsync(id);

            db.Remove(resultOld);
            db.SaveChanges();
            return resultOld;
        }
        public async Task<Person> AddAsync(Person newData)
        {
            await db.AddAsync(newData);
            db.SaveChanges();
            return newData;
        }
        public async Task<Person> EditAsync(Person newData)
        {
            var resultOld = await GetByIdAsync(newData.Id);
            resultOld.Name = newData.Name;
            resultOld.Surname1 = newData.Surname1;
            resultOld.Surname2 = newData.Surname2;
            resultOld.Age = newData.Age;
            resultOld.Status = newData.Status;
            db.SaveChanges();
            return resultOld;
        }
        public async Task<Person> AddEditAsync(Person data)
        {
            if (await GetByIdAsync(data.Id) != null)
            {
                return await EditAsync(data);
            }
            return await AddAsync(data);
        }
    }
}
