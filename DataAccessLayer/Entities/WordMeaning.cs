using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class WordMeaning
    {
        public int Id { get; set; }
        public string Meaning { get; set; }
        public int LangId { get; set; }
        public int? WordDefinitionId { get; set; }
        [ForeignKey("LangId")]
        public virtual Language Lang { get; set; }
        [ForeignKey("WordDefinitionId")]
        public virtual WordDefinition WordDef { get; set; }
    }

}
