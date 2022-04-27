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

        public List<WordDefinition> List(string searchKeyword,int? langId)
        {
            #region alt1
            //var liste = _context.Set<WordDefinition>().Include(c => c.Lang)
            //    .Include(c => c.WordMeanings).ThenInclude(c => c.Lang)
            //    .Where(c=>
            //    (String.IsNullOrEmpty(searchKeyword) || c.Word.ToUpper()==searchKeyword.ToUpper())
            //    && (c.LangId==langId || langId.Value==0))
            //    .ToList();
            //return liste;
            #endregion

            #region alt2
            var query = _context.Set<WordDefinition>().Include(c => c.Lang)
                .Include(c => c.WordMeanings).ThenInclude(c => c.Lang)
                .Where(c => true);

            if (!String.IsNullOrEmpty(searchKeyword))
                query = query.Where(c => c.Word == searchKeyword);
            if (langId.HasValue && langId > 0)
                query = query.Where(c => c.LangId == langId.Value);
            return query.ToList();
            #endregion


        }

    }
}
