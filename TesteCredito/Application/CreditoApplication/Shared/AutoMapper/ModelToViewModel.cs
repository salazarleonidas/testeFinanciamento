using AutoMapper;
using CreditoApplication.Shared.Creditos.ViewModels;
using CreditoApplication.Shared.Helper;
using CreditoApplication.Shared.Users.ViewModels;
using Domain.Creditos;
using Domain.Enums;
using Domain.Users;

namespace CreditoApplication.Shared.AutoMapper
{
    public class ModelToViewModel : Profile
    {
        public ModelToViewModel()
        {
            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<FinanciamentoViewModel, Financiamento>()
                .ForPath(q => q.Tipo, opt => opt.MapFrom(q => EnumDescriptionHelper.GetValueFromDescription<TipoCredito>(q.Tipo)))
            .ReverseMap().ForPath(q => q.Tipo, opt => opt.MapFrom( q => q.Tipo.GetDescription()));
        }
    }
}
