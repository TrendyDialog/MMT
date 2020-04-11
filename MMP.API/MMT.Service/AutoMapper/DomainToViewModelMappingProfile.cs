using AutoMapper;
using MMT.Domain.Models;
using MMT.Service.ViewModels;

namespace MMT.Service.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cell, CellViewModel>();
        }
    }
}
