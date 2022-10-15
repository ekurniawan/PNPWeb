using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyASPApp.Models;

namespace MyASPApp.DAL
{
    public class InMemoryTrainer : ITrainer
    {
        private List<Trainer> _trainers;
        public InMemoryTrainer()
        {
            _trainers = new List<Trainer>{
                new Trainer {Id=1,Name="Erick Kurniawan",Expertise="ASP.NET Core"},
                new Trainer {Id=2,Name="Scott Hanselment",Expertise="Microsoft Azure"},
                new Trainer {Id=3,Name="Donovan Brown",Expertise="Azure DevOps"}
            };
        }

        public void Add(Trainer trainer)
        {
            trainer.Id = _trainers.Max(r=>r.Id)+1;
            _trainers.Add(trainer);
        }

        public void Delete(int id)
        {
            var trainer = _trainers.FirstOrDefault(t=>t.Id==id);
            if(trainer==null) throw new Exception($"Data trainer id {id} tidak ditemukan");

            _trainers.Remove(trainer);
        }

        public Trainer Get(int id)
        {
            var result = _trainers.SingleOrDefault(r=>r.Id==id);
            /*var result = (from t in _trainers
                         where t.Id==id
                         select t).SingleOrDefault();*/
            return result;
        }

        public IEnumerable<Trainer> GetAll()
        {
            return _trainers.OrderBy(r=>r.Name);
        }

        public void Update(int id, Trainer trainer)
        {
            var editTrainer = _trainers.FirstOrDefault(t=>t.Id==id);
            editTrainer.Name = trainer.Name;
            editTrainer.Expertise = trainer.Expertise;
        }
    }
}