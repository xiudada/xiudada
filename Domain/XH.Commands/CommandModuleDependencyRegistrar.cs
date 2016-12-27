using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Dependency;
using XH.Commands.Articles.Commands;
using XH.Commands.Articles.CommandHandlers;
using XH.Infrastructure.Command;
using XH.Commands.Articles.Configs;

namespace XH.Commands
{
    public class CommandModuleDependencyRegistrar : IDependencyRegistrar
    {
        public int Priority
        {
            get { return 1; }
        }

        public void Register(ContainerBuilder builder, IDependencyRegistrarContext context)
        {
            #region Articles

            builder.RegisterType<ArticleCommandHandler>().As<ICommandHandler<CreateArticleCommand>>();
            builder.RegisterType<ArticleCommandHandler>().As<ICommandHandler<UpdateArticleCommand>>();

            builder.RegisterType<AritclesMapperRegistrar>();
            #endregion
        }
    }
}
