using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using XH.Commands.Articles.Commands;
using XH.Domain.Catalogs.Models;
using XH.Infrastructure.Command;
using XH.Infrastructure.Domain.Repositories;

namespace XH.Commands.Articles.CommandHandlers
{
    public class ArticleCommandHandler :
        ICommandHandler<CreateArticleCommand>,
        ICommandHandler<UpdateArticleCommand>
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly IMapper _mapper;

        public ArticleCommandHandler(IRepository<Article> articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public void Handle(UpdateArticleCommand command)
        {
            throw new NotImplementedException();
        }

        public void Handle(CreateArticleCommand command)
        {
            var article = _mapper.Map<Article>(command);
            _articleRepository.Insert(article);
        }
    }
}
