using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDblv.Models
{
    [Table("Contato")]
    public class Contato
    {
        [Key]
        [Column("contato_id")]
        public int ContatoId { get; set; }

        [Column("nome")]
        [Display(Name = "Nome")]
        [StringLength(100, ErrorMessage = "Tem de ter no máximo {1} e no mínimo {4} carácter!")]
        public string Nome { get; set; }

        [Column("email")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "Tem de ter no máximo {1} e no mínimo {2} carácter!")]
        public string Email { get; set; }

        [Column("fone")]
        [Display(Name = "Fone")]
        [StringLength(11, ErrorMessage = "O campo {0} pode ter no máximo 11 e no mínimo 10 carácteres!")]
        public string Fone { get; set; }

        [Column("assunto")]
        [Display(Name = "Assunto")]
        [StringLength(50, ErrorMessage = "O campo {0} pode ter no máximo {1} e no mínimo {2} carácter!")]
        public string Assunto { get; set; }

        [Column("mensagem")]
        [Display(Name = "Mensagem")]
        [StringLength(1000, ErrorMessage = "O campo {0} pode ter no máximo 100 carácter!")]
        public string Mensagem { get; set; }

        [Column("dt_mensagem")]
        [Display(Name = "Data da Mensagem")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataMensagem { get; set; }

        [Column("origem")]
        [Display(Name = "Origem")]
        public int Origem { get; set; }

        [Column("tipo_mensagem")]
        [Display(Name = "Tipo da Mensagem")]
        public int TipoMensagem { get; set; }

    }
}
