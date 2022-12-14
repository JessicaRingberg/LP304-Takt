using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.ReadDto;
using LP304_Takt.DTO.UpdateDTO;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPost]
        public async Task<IActionResult> AddArticle([FromBody] ArticleCreateDto article)
        {
            var response = await _articleService.Add(article.AsEntity());
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ArticleDto>>> GetArticles()
        {
            return Ok((await _articleService.GetEntities()).Select(a => a.AsDto()));
        }

        [HttpGet("{articleId}")]
        public async Task<ActionResult<ArticleDto>> GetArticle(int articleId)
        {
            var article = await _articleService.GetEntity(articleId);
            if(article is null)
            {
                return NotFound($"Article with id: {articleId} was not found");
            }
            return Ok(article.AsDto());
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpDelete("{articleId}")]
        public async Task<IActionResult> DeleteArticle(int articleId)
        {
            var response = await _articleService.DeleteEntity(articleId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPut]
        public async Task<IActionResult> UpdateArticle([FromBody] ArticleUpdateDto article, [FromQuery] int articleId)
        {
            var response = await _articleService.UpdateEntity(article.AsUpdated(), articleId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
