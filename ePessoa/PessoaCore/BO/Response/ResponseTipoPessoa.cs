using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoaCore.BO.Response
{
    public class ResponseTipoPessoa
    {
        public static readonly ResponseTipoPessoa FISICA = new ResponseTipoPessoa(1, "PESSOA FÍSICA");
        public static readonly ResponseTipoPessoa JURIDICA = new ResponseTipoPessoa(2, "PESSOA JÚRDICA");

        private int _codigo;
        private string _txt;

        private ResponseTipoPessoa(int codigo, string txt)
        {
            _codigo = codigo;
            _txt = txt;
        }

        public ResponseTipoPessoa()
        {
        }

        public int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;
            }
        }

        public string Texto
        {
            get
            {
                return _txt;
            }

            set
            {
                _txt = value;
            }
        }
    }
}
