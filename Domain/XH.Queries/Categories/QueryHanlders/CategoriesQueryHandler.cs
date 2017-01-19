using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using XH.Domain.Catalogs.Models;
using XH.Infrastructure.Domain.Repositories;
using XH.Infrastructure.Query;
using XH.Queries.Categories.Dtos;
using XH.Queries.Categories.Queries;

namespace XH.Queries.Categories.QueryHanlders
{
    public class CategoriesQueryHandler :
        IQueryHandler<ListCategoriesQuery, IEnumerable<CategoryOverviewDto>>,
        IQueryHandler<GetCategoriesTreeQuery, CategoriesTree>,
        IQueryHandler<GetCategoryQuery, CategoryDto>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesQueryHandler(
            IRepository<Category> categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryOverviewDto> Handle(ListCategoriesQuery query)
        {
            return null;
        }

        public CategoriesTree Handle(GetCategoriesTreeQuery query)
        {
            return null;
        }

        public CategoryDto Handle(GetCategoryQuery query)
        {
            return null;
        }
    }
}
