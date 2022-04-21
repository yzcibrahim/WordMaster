using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class WordDefinition
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public int LangId { get; set; }

        [ForeignKey("LangId")]
        public virtual Language Lang { get; set; }

        public virtual List<WordMeaning> WordMeanings { get; set; }
    }

}
