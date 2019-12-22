using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoaCore.BO.Response
{
    public class ResponseErro
    {
        public static string ErroOperacao(Exception ex)
        {
            return ex.Source + " - " + ex.Message + " - " + ex.StackTrace;
        }
    }
}
