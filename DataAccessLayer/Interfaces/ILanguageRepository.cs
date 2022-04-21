using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ILanguageRepository
    {
        List<Language> List();
        Language GetById(int id);
        void Add(Language entity);
        void Update(Language entity);
        void Delete(int id);
    }
}
