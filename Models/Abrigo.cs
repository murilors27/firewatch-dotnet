using System.ComponentModel.DataAnnotations.Schema;

namespace Firewatch.Abrigos.Models
{
    [Table("Abrigos")]
    public class Abrigo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Capacidade")]
        public int Capacidade { get; set; }

        [Column("Recursos")]
        public string RecursosDisponiveis { get; set; }

        [Column("TipoAtendimento")]
        public string TipoAtendimento { get; set; }

        [Column("Latitude")]
        public string Latitude { get; set; }

        [Column("Longitude")]
        public string Longitude { get; set; }

        [Column("CidadeId")]
        public int CidadeId { get; set; }

        public Cidade Cidade { get; set; }
    }
}
