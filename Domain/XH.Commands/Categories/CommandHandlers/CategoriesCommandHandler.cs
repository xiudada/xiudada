using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using XH.Commands.Categories.Commands;
using XH.Domain.Catalogs.Models;
using XH.Infrastructure.Command;
using XH.Infrastructure.Domain.Repositories;
using System.Diagnostics.Contracts;

namespace XH.Commands.Categories.CommandHandlers
{
    public class CategoriesCommandHandler :
        ICommandHandler<CreateCategoryCommand>,
        ICommandHandler<UpdateCategoryCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _categoryRepository;

        public CategoriesCommandHandler(
            IRepository<Category> categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public void Handle(CreateCategoryCommand command)
        {
            ValidateCreateCategoryCommand(command);
            var category = _mapper.Map<Category>(command);
            category.Id = Guid.NewGuid().ToString();

            // check unqiue code and slug
            _categoryRepository.Insert(category);
        }

        public void Handle(UpdateCategoryCommand command)
        {
            ValidateUpdateCategoryCommand(command);

            var category = _categoryRepository.Get(command.Id);
            Contract.Assert(category != null);

            category = _mapper.Map(command, category);
            _categoryRepository.Update(category);
        }

        private void ValidateCreateCategoryCommand(CreateCategoryCommand command)
        {
            // check unique code and slug
            ValidateCreateOrUpdateCategoryCommand(null, command);
        }

        private void ValidateUpdateCategoryCommand(UpdateCategoryCommand command)
        {
            ValidateCreateOrUpdateCategoryCommand(command.Id, command);
        }

        private void ValidateCreateOrUpdateCategoryCommand(string id, CreateOrUpdateCategoryCommand command)
        {
            var categoryBySlug = _categoryRepository.FirstOrDefault(it => it.Code == command.Code && id != it.Id);
            Contract.Assert(categoryBySlug == null);
            var categoryByCode = _categoryRepository.FirstOrDefault(it => it.Slug == command.Slug && id != it.Id);
            Contract.Assert(categoryByCode == null);
        }
    }
}
