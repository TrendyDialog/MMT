using AutoMapper;
using MMT.Domain.Models;
using MMT.Service.ViewModels;

namespace MMT.Service.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CellViewModel, Cell>();
        }
    }
}
