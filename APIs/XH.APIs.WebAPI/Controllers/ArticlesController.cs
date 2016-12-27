using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XH.Infrastructure.Bus;
using XH.Queries.Articles.Queries;
using XH.Queries.Articles.Dtos;
using Swashbuckle.Swagger.Annotations;
using XH.APIs.WebAPI.Models.Articles;
using AutoMapper;
using XH.Commands.Articles.Commands;

namespace XH.APIs.WebAPI.Controllers
{
    /// <summary>
    /// Articles controller
    /// </summary>
    [RoutePrefix("articles")]
    public class ArticlesController : ApiControllerBase
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryBus"></param>
        /// <param name="commandBus"></param>
        public ArticlesController(IQueryBus queryBus, ICommandBus commandBus, IMapper mapper)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
            _mapper = mapper;
        }

        /// <summary>
        /// Get article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(200, "Success", typeof(ArticleDto))]
        public IHttpActionResult GetArticle(string id)
        {
            var query = new GetArticleQuery
            {
                Id = id
            };

            var dto = _queryBus.Send<GetArticleQuery, ArticleDto>(query);
            return Ok(dto);
        }

        /// <summary>
        /// Create article
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [SwaggerResponse(200, "Success")]
        public IHttpActionResult CreateArticle(CreateArticleRequest request)
        {
            var command = _mapper.Map<CreateArticleCommand>(request);
            _commandBus.Send(command);

            return Ok();
        }

        /// <summary>
        /// Create article
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        [SwaggerResponse(200, "Success")]
        public IHttpActionResult CreateArticle(UpdateArticleRequest request)
        {
            var command = _mapper.Map<CreateArticleCommand>(request);
            _commandBus.Send(command);

            return Ok();
        }
    }
}
