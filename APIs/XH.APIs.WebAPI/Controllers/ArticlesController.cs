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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryBus"></param>
        /// <param name="commandBus"></param>
        public ArticlesController(IQueryBus queryBus, ICommandBus commandBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
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
    }
}
