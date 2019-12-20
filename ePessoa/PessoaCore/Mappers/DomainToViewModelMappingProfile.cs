using AutoMapper;
using PessoaCore.ViewModel;
using PessoaCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoaCore.Mappers
{
    class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<tbl_estado, Estado>();
            CreateMap<tbl_cidade, Cidade>();
        }
    }
}
