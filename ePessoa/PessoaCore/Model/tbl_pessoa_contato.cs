//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PessoaCore.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_pessoa_contato
    {
        public int id { get; set; }
        public int cod_pessoa_contato { get; set; }
        public string txt_telefone { get; set; }
    
        public virtual tbl_pessoa tbl_pessoa { get; set; }
    }
}
