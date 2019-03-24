using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Services
{
    class UserManager:IDisposable
    {
        IRepository<User> repository;
        IRepository<DailyCalories> calorieRepo;
        public UserManager(IRepository<User> repository, IRepository<DailyCalories> calorieRepo)
        {
            this.repository = repository;
            this.calorieRepo = calorieRepo;
        }

        public bool IsExists(string login)
        {
            return repository.Get().Any(u=>u.Login==login);
        }
        public bool Validate(string login, string password)
        {
            List<User> list = repository.Get().ToList();
            User us = list.FirstOrDefault(u => u.Login == login && u.Password == password);
            return us != null;
        }

        public void Create(User user)
        {
            if (user!=null)
            {
                if (user.Password.Length < 6)
                    throw new Exception("The password must contain at least 6 characters");
                if (user.Age < 17)
                    throw new Exception("This application is for adults only");
                repository.Create(user);
            }
        }
        
        public IEnumerable<User> GetAll()
        {
            return repository.Get();
        }

        public User FindByLogin(string login)
        {
            return repository.Get().FirstOrDefault(u=>u.Login==login);
        }
        public CalorieRange GetNorm(User user)
        {
            return calorieRepo.Get(c=>c.ActivityLevel==user.ActivityLevel&&user.Age>=c.MinAge&&user.Age<=c.MaxAge&&c.Sex==user.Sex).FirstOrDefault().CalorieRange;
        }

        public bool IsInRole(string role)
        {
            return false;
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    repository.Dispose();
                    calorieRepo.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
