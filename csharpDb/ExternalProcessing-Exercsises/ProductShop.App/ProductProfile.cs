namespace ProductShop.App
{
    using AutoMapper;
    using ProductShop.App.Dtos.Exported;
    using ProductShop.Models;

    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDtoExported>()
                .ForMember(dto => dto.Seller, config =>
                    config.MapFrom(p => p.Seller.FirstName + ' ' + p.Seller.LastName ));
        }
    }
}
