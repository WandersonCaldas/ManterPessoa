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
    class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Estado, tbl_estado>();
            CreateMap<Cidade, tbl_cidade>();
        }
    }
}
