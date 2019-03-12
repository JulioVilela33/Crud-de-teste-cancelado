using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudTeste.Models.Entidades
{
    
    public class Endereco
    {
        [Key]
        public Guid EnderecoId { get; set; }

        public Guid PessoaId { get; set; }

        [Required]
        public String Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        public String Complemento { get; set; }

        
        public String Bairro { get; set; }

        [Required]
        public String Cidade { get; set; }


        public int Cep { get; set; }

        public String Uf { get; set; }

        [Required]
        public TipoEndereco tipoEndereco { get; set; }

        
        public virtual Pessoa Pessoa { get; set; }

    }
        public enum TipoEndereco
        {
        Entrega = 1 ,
        Correspondencia = 2,
        Comercial = 3,
        Cobranca = 4,
        Residencial = 5
        }

}

