using AutoMapper;

namespace AspNetCoreStudies.Api.Features.Articles
{
    public class ArticlesMapper : Profile
    {
        public ArticlesMapper()
        {
            CreateMap<ArticleDto, Article>();
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleCreateDto, Article>();
        }
    }
}
