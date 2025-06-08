using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firewatch.Abrigos.Models
{
    [Table("Abrigos")]
    public class Abrigo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Column("Capacidade")]
        [Required(ErrorMessage = "A capacidade é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A capacidade deve ser maior que zero")]
        public int Capacidade { get; set; }

        [Column("Recursos")]
        [Required(ErrorMessage = "Os recursos são obrigatórios")]
        public string RecursosDisponiveis { get; set; }

        [Column("TipoAtendimento")]
        [Required(ErrorMessage = "O tipo de atendimento é obrigatório")]
        public string TipoAtendimento { get; set; }

        [Column("Latitude")]
        [Required(ErrorMessage = "A latitude é obrigatória")]
        public double Latitude { get; set; }

        [Column("Longitude")]
        [Required(ErrorMessage = "A longitude é obrigatória")]
        public double Longitude { get; set; }

        [Column("CidadeId")]
        [Required(ErrorMessage = "A cidade é obrigatória")]
        public int CidadeId { get; set; }

        public Cidade Cidade { get; set; }
    }
}
