using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IWordDefinitionRepository:IRepositoryBase<WordDefinition>
    {
        List<WordDefinition> List(string searchKeyword, int? langId);
        //List<WordDefinition> List();
        //WordDefinition GetById(int id);
        //void Add(WordDefinition entity);
        //void Update(WordDefinition entity);
        //void Delete(int id);
    }
}
