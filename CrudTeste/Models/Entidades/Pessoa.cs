using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace CrudTeste.Models.Entidades
{
        [Table("Pessoas")]
        public class Pessoa
        {
            [Key]
            public Guid PessoaId { get; set; }

            
            [Required]
            [MaxLength(50)]
            [Display(Name = "Nome")]
            public String Nome { get; set; }


            [Required]
            [Display(Name = "Data de Nascimento")]
            [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
            public DateTime Data { get; set; }

            [Required]
            [MaxLength(14)]
            [Display(Name = "CPF/CNPJ")]
            public String Documento { get; set; }

            [Required]
            public String TelNumero { get; set; }

            [Required]
            public TipoTelefone TelTipo { get; set; }

        
        
            [Display(Name = "E-Mail")]
            public String Email { get; set; }



             public virtual ICollection<Endereco> Endereco { get; set; }
        }

  

}
