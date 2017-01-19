using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Swashbuckle.Swagger.Annotations;
using XH.APIs.WebAPI.Models;
using XH.Infrastructure.Bus;
using XH.Infrastructure.Paging;

namespace XH.APIs.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("articles")]
    public class CategoriesController : ApiControllerBase
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryBus"></param>
        /// <param name="commandBus"></param>
        public CategoriesController(IQueryBus queryBus, ICommandBus commandBus, IMapper mapper)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
            _mapper = mapper;
        }

        /// <summary>
        /// List
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("list")]
        [SwaggerResponse(200, "Success", typeof(PagedList<ArticleOverviewDto>))]
        public IHttpActionResult ListArticles(ListRequestBase request)
        {
            var query = _mapper.Map<ListArticlesQuery>(request);

            var pagedList = _queryBus.Send<ListArticlesQuery, PagedList<ArticleOverviewDto>>(query);

            return Ok(pagedList);
        }

        /// <summary>
        /// Create article
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [SwaggerResponse(200, "Success")]
        public IHttpActionResult CreateCategory(CreateCategoryRequest request)
        {
            var command = _mapper.Map<CreateArticleCommand>(request);
            _commandBus.Send(command);

            return Ok();
        }
    }
}