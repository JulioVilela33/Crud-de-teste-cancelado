using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTeste.Models.Entidades
{
    public class PessoaFisica : Pessoa
    {

        public String sexo { get; set; }
    }
}
