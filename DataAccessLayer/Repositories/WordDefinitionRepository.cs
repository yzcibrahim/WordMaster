using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class WordDefinitionRepository : IWordDefinitionRepository
    {
        WordMasterDbContext _context;
        public WordDefinitionRepository(WordMasterDbContext context)
        {
            _context = context;
        }

        public List<WordDefinition> List()
        {
            return _context.Set<WordDefinition>().ToList();
        }

        public WordDefinition GetById(int id)
        {
            return _context.Set<WordDefinition>().Find(id);
        }

        public void Add(WordDefinition entity)
        {
            _context.Set<WordDefinition>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(WordDefinition entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var silinecek = GetById(id);
            _context.Set<WordDefinition>().Remove(silinecek);
            _context.SaveChanges();
        }
    }
}
