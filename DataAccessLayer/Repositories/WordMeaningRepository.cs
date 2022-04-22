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
    public class WordMeaningRepository: RepositoryBase<WordMeaning>,IWordMeaningRepository
    {
        public WordMeaningRepository(WordMasterDbContext context) : base(context)
        {
        }
        public override WordMeaning GetById(int id)
        {
            return _context.Set<WordMeaning>().Include(c => c.WordDef).Include(c => c.Lang).First(c=>c.Id==id);
        }

        public override List<WordMeaning> List()
        {
            return _context.Set<WordMeaning>().Include(c => c.WordDef).Include(c => c.Lang).ToList();
        }

    }
}
