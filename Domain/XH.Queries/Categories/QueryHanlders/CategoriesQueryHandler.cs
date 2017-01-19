using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using XH.Domain.Catalogs.Models;
using XH.Infrastructure.Domain.Repositories;
using XH.Infrastructure.Extensions;
using XH.Infrastructure.Paging;
using XH.Infrastructure.Query;
using XH.Queries.Categories.Dtos;
using XH.Queries.Categories.Queries;

namespace XH.Queries.Categories.QueryHanlders
{
    public class CategoriesQueryHandler :
        IQueryHandler<ListCategoriesQuery, PagedList<CategoryOverviewDto>>,
        IQueryHandler<GetCategoriesTreeQuery, IEnumerable<CategoriesTreeNode>>,
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

        public PagedList<CategoryOverviewDto> Handle(ListCategoriesQuery query)
        {
            var categories = _categoryRepository.GetAll();

            if (query.ParentId.IsNotNullOrEmpty())
            {
                categories = categories.Where(it => it.ParentId == query.ParentId);
            }

            return categories.Select(it => _mapper.Map<CategoryOverviewDto>(it)).ToPagedList(query.Page, query.PageSize);
        }

        public IEnumerable<CategoriesTreeNode> Handle(GetCategoriesTreeQuery query)
        {
            var allCategories = _mapper.Map<IEnumerable<CategoryOverviewDto>>(_categoryRepository.GetAllList().ToList());
            var allNodes = _mapper.Map<IEnumerable<CategoriesTreeNode>>(allCategories);
            return GetCategoryTreeNodes(query.RootNodeId, allNodes);
        }

        public CategoryDto Handle(GetCategoryQuery query)
        {
            var item = _categoryRepository.Get(query.Id);
            return _mapper.Map<CategoryDto>(item);
        }

        private IEnumerable<CategoriesTreeNode> GetCategoryTreeNodes(string rootId, IEnumerable<CategoriesTreeNode> categories)
        {
            IEnumerable<CategoriesTreeNode> rootNodes = null;

            if (rootId.IsNotNullOrEmpty())
            {
                rootNodes = categories.Where(it => it.ParentId == rootId);
            }
            else
            {
                rootNodes = categories.Where(it => it.ParentId == null || it.ParentId == "");
            }

            foreach (var node in rootNodes)
            {
                node.ChildNodes = GetCategoryChildNodes(node, categories);
            }

            return rootNodes;
        }

        private IEnumerable<CategoriesTreeNode> GetCategoryChildNodes(CategoriesTreeNode node, IEnumerable<CategoriesTreeNode> categories)
        {
            IEnumerable<CategoriesTreeNode> childNodes = categories.Where(it => it.ParentId == node.Id);

            foreach (var childNode in childNodes)
            {
                childNode.ChildNodes = GetCategoryChildNodes(childNode, categories);
            }

            return childNodes;
        }
    }
}
