// using AutoMapper;

// public class MappingProfiles : Profile {
//     public MappingProfiles() {
//         CreateMap<Product, ProductResponseDto>()
//             .ForMember(x => x.ProductType, o => o.MapFrom(s => s.ProductType.Name))
//             .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name));    
//     }
// }


using AutoMapper;

public class MappingProfiles : Profile {
    public MappingProfiles() {
        CreateMap<Product, ProductResponseDto>()
            .ForMember(s => s.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<PictureUrlResolver>());
    }
}