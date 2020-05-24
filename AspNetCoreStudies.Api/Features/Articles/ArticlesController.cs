using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreStudies.Api.Features.Articles
{
    [ApiController]
    [Route("api/articles")]
    public class ArticlesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ArticlesController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetArticles()
        {
            var articles = await _dbContext.Articles.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ArticleDto>>(articles));
        }

        [HttpGet("{articleId}", Name = "GetArticle")]
        public async Task<ActionResult<ArticleDto>> GetArticle(int articleId)
        {
            var article = await _dbContext.Articles.FirstOrDefaultAsync(article => article.Id == articleId);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ArticleDto>(article));
        }

        [HttpPost]
        public async Task<ActionResult<ArticleDto>> CreateArticle(ArticleCreateDto articleDto)
        {
            var articleEntity = _mapper.Map<Article>(articleDto);
            articleEntity.CreatedAt = DateTimeOffset.Now;

            _dbContext.Articles.Add(articleEntity);
            var save = await _dbContext.SaveChangesAsync() > 0;

            var article = _mapper.Map<ArticleDto>(articleEntity);

            if (save)
            {
                return CreatedAtRoute("GetArticle", new { articleId = article.Id }, article);
            }

            return BadRequest();
        }
    }
}
