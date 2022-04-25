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
    public class WordDefinitionRepository :RepositoryBase<WordDefinition>,IWordDefinitionRepository
    {
        public WordDefinitionRepository(WordMasterDbContext context):base(context)
        {
        }

        public override List<WordDefinition> List()
        {
            var liste = _context.Set<WordDefinition>().Include(c=>c.Lang)
                .Include(c=>c.WordMeanings).ThenInclude(c=>c.Lang).ToList();
            return liste;
        }

        public List<WordDefinition> List(string searchKeyword)
        {
            var liste = _context.Set<WordDefinition>().Include(c => c.Lang)
                .Include(c => c.WordMeanings).ThenInclude(c => c.Lang)
                .Where(c=>c.Word.ToUpper()==searchKeyword.ToUpper() 
                || String.IsNullOrEmpty(searchKeyword))
                .ToList();
            return liste;
        }

    }
}
