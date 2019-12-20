using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoaCore.ViewModel
{
    public class Estado
    {
        [Key]
        public int cod_estado { get; set; }
        [Required]        
        public string txt_estado { get; set; }
        [Required]           
        public string txt_sigla { get; set; }
        [NotMapped]
        public string status { get; set; }
        [NotMapped]
        public string mensagem { get; set; }
    }
}
