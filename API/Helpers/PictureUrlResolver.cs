using AutoMapper;

public class PictureUrlResolver : IValueResolver<Product, ProductResponseDto, string>
{
    private readonly IConfiguration _configuration;

    public PictureUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Resolve(Product source, ProductResponseDto destination, string destMember, ResolutionContext context)
    {
        if (source.PictureUrl != null) 
        {
            return _configuration["ApiUrl"] + source.PictureUrl;
        }
        return null;
    }
}
