using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyASPApp.Models;

namespace MyASPApp.DAL
{
    public class TrainerDAL : ITrainer
    {
        private readonly AppDbContext _dbContext;
        public TrainerDAL(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Trainer trainer)
        {
            try
            {
                _dbContext.Add(trainer);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            var delTrainer = Get(id);
            if(delTrainer!=null)
            {
                _dbContext.Remove(delTrainer);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Id {id} tidak ditemukan");
            }
        }

        public Trainer Get(int id)
        {
           var result = _dbContext.Trainers.FirstOrDefault(t=>t.Id==id);
           if(result==null) throw new Exception($"Id {id} tidak ditemukan");
           return result;
        }

        public IEnumerable<Trainer> GetAll()
        {
            var results = _dbContext.Trainers.OrderBy(t=>t.Name);
            return results;
        }

        public void Update(int id, Trainer trainer)
        {
            var updateTrainer = Get(id);
            if(updateTrainer!=null)
            {
                updateTrainer.Name = trainer.Name;
                updateTrainer.Expertise = trainer.Expertise;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Data Id:{id} tidak ditemukan");
            }
        }
    }
}