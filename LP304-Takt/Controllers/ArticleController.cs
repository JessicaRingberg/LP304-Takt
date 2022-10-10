using LP304_Takt.DTO;
using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.UpdateDTO;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

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

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDto>> GetArticle(int id)
        {
            var article = await _articleService.GetEntity(id);
            if(article is null)
            {
                return NotFound($"Article with id: {id} was not found");
            }
            return Ok(article.AsDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            await _articleService.DeleteEntity(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArticle([FromBody] ArticleUpdateDto article, [FromQuery] int articleId)
        {
            await _articleService.UpdateEntity(article.AsUpdated(), articleId);

            return Ok();
        }
    }
}
