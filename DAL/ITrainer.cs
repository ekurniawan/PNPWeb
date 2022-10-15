using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyASPApp.Models;

namespace MyASPApp.DAL
{
    public interface ITrainer
    {
        IEnumerable<Trainer> GetAll();
        Trainer Get(int id);
        void Add(Trainer trainer);
        void Update(int id,Trainer trainer);
        void Delete(int id);
    }
}