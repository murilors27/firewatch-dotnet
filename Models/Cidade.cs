using System.ComponentModel.DataAnnotations.Schema;

namespace Firewatch.Abrigos.Models
{
    [Table("Cidades")]
    public class Cidade
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        public ICollection<Abrigo> Abrigos { get; set; }
    }
}
