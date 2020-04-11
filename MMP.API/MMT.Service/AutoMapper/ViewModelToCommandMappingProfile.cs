using AutoMapper;
using MMT.Domain.Commands.Cell;
using MMT.Domain.Models;
using MMT.Service.ViewModels;

namespace MMT.Service.AutoMapper
{
    public class ViewModelToCommandMappingProfile : Profile
    {
        public ViewModelToCommandMappingProfile()
        {
            CreateMap<CellViewModel, AddCellCommand>();
            CreateMap<CellViewModel, UpdateCellCommand>();
            CreateMap<UpdateCellCommand, Cell>();
            CreateMap<AddCellCommand, CellChanges>();
        }
    }
}
