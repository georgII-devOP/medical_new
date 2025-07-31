using medical.DataBase;
using medical.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medical
{
    public class PatientRepository : IRepository<Patient>
    {
        private readonly AppDbContext appContext;

        public PatientRepository(AppDbContext appContext) => this.appContext = appContext;

        public int Add(Patient entity)
        {
            appContext.Add<Patient>(entity);
            return appContext.SaveChanges();
        }

        public int Delete(Patient entity)
        {
            appContext.Remove(entity);
            return appContext.SaveChanges();
        }
                
        public ObservableCollection<Patient> GetAll()
        {
            appContext.Patients.Load();
            return appContext.Patients.Local.ToObservableCollection();
        }

        public Patient? GetById(int id)
        {
            return appContext.Patients.FirstOrDefault(p => p.Id == id);
        }
        public int Update(Patient entity)
        {
            appContext.Update(entity);
            return appContext.SaveChanges();
        }
    }
}
