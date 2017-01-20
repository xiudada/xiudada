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
using XH.Commands.Categories.Configs;
using XH.Commands.Categories.CommandHandlers;
using XH.Commands.Categories.Commands;
using XH.Commands.Shared.Configs;

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

            #region Category
            builder.RegisterType<CategoriesCommandHandler>().As<ICommandHandler<CreateCategoryCommand>>()
                                                            .As<ICommandHandler<UpdateCategoryCommand>>();

            builder.RegisterType<CategoriesMapperRegistrar>();
            #endregion
            builder.RegisterType<SharedMapperRegistrar>();
        }
    }
}
