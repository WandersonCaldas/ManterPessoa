using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoaCore.BO.Response
{
    public class ResponseMensagem
    {
        public static readonly ResponseMensagem MN001 = new ResponseMensagem("MN001", "OPERAÇÃO REALIZADA COM SUCESSO.");
        public static readonly ResponseMensagem MN002 = new ResponseMensagem("MN002", "{0} NÃO ENCONTRADO.");
        public static readonly ResponseMensagem MN003 = new ResponseMensagem("MN003", "{0} JÁ SE ENCONTRADA NA BASE DE DADOS.");

        private string _codigo, _txt;
        private ResponseMensagem(string codigo, string txt)
        {
            _codigo = codigo;
            _txt = txt;
        }

        public string Codigo
        {
            get
            {
                return _codigo;
            }
        }

        public string Texto
        {
            get
            {
                return _txt;
            }
        }

        public string TextoFormatado(params string[] Args)
        {
            return string.Format(_txt, Args);
        }
    }
}
