﻿using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.ReadDto;
using LP304_Takt.DTO.UpdateDTO;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Shared;
using Microsoft.AspNetCore.Authorization;
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

        //[Authorize(Roles = nameof(Role.Admin))]
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

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<List<ArticleDto>>> GetArticles()
        {
            return Ok((await _articleService.GetEntities()).Select(a => a.AsDto()));
        }

        //[Authorize]
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

        //[Authorize(Roles = nameof(Role.Admin))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var response = await _articleService.DeleteEntity(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //[Authorize(Roles = nameof(Role.Admin))]
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
