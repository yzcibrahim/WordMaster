using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IWordMeaningRepository:IRepositoryBase<WordMeaning>
    {
        List<WordMeaning> ListByDefId(int defId);
        //List<WordMeaning> List();
        //WordMeaning GetById(int id);
        //void Add(WordMeaning entity);
        //void Update(WordMeaning entity);
        //void Delete(int id);
    }
}
