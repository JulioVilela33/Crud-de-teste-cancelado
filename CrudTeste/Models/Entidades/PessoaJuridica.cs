using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTeste.Models.Entidades
{
    public class PessoaJuridica : Pessoa
    {
        
        [Required]
        [MaxLength(100)]
        public String NomeFantasia { get; set; }
        
    }
}
