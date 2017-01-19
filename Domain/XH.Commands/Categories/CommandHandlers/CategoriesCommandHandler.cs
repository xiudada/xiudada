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
            var category=
        }

        public void Handle(UpdateCategoryCommand command)
        {

        }
    }
}
