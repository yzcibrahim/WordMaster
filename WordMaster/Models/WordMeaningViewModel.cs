using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordMaster.Models
{
    public class WordMeaningViewModel
    {
        public int Id { get; set; }
        public string Meaning { get; set; }
        public int LangId { get; set; }
        public int? WordDefinitionId { get; set; }
    }
}
