using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PessoaCore.ViewModel
{
    public class Cidade
    {        
        [Key]
        public int cod_cidade { get; set; }
        [Required]
        public string txt_cidade { get; set; }
        [Required]
        public int cod_estado { get; set; }         
        public Estado Estado { get; set; }
        [NotMapped]
        public string status { get; set; }
        [NotMapped]
        public string mensagem { get; set; }
    }
}
