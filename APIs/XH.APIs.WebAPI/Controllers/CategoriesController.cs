using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Swashbuckle.Swagger.Annotations;
using XH.APIs.WebAPI.Models;
using XH.APIs.WebAPI.Models.Categories;
using XH.Commands.Categories.Commands;
using XH.Infrastructure.Bus;
using XH.Infrastructure.Paging;
using XH.Queries.Categories.Dtos;
using XH.Queries.Categories.Queries;
using XH.Infrastructure.Web.Filters;

namespace XH.APIs.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("categories")]
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
        [SwaggerResponse(200, "Success", typeof(PagedList<CategoryOverviewDto>))]
        public IHttpActionResult ListArticles(ListCategoriesRequest request)
        {
            var query = _mapper.Map<ListCategoriesQuery>(request);

            var pagedList = _queryBus.Send<ListCategoriesQuery, PagedList<CategoryOverviewDto>>(query);

            return Ok(pagedList);
        }

        /// <summary>
        /// Tree
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("tree")]
        [SwaggerResponse(200, "Success", typeof(IEnumerable<CategoriesTreeNode>))]
        public IHttpActionResult GetCategoriesTree()
        {
            var query = new GetCategoriesTreeQuery { RootNodeId = null };
            var result = _queryBus.Send<GetCategoriesTreeQuery, IEnumerable<CategoriesTreeNode>>(query);

            return Ok(result);
        }

        /// <summary>
        /// Create article
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [SwaggerResponse(200, "Success")]
        [ValidateModelStateFilter]
        public IHttpActionResult CreateCategory(CreateCategoryRequest request)
        {
            var command = _mapper.Map<CreateCategoryCommand>(request);
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
        [ValidateModelStateFilter]
        public IHttpActionResult UpdateCategory(UpdateCategoryRequest request)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(request);
            _commandBus.Send(command);

            return Ok();
        }
    }
}