using James.Proxy;
using Jamesnet.Core;
using Studio.Main.Local.ViewModels;
using Studio.Main.UI.Views;
using Studio.Proxy;
using Studio.Support.Local.Managers;

namespace JamesStudio
{
    internal class JamesStudioBootstrapper : AppBootstrapper
    {
        protected override void RegisterDependencies(IContainer container)
        {
            container.RegisterSingleton<ArticleProxy, ArticleProxy>();
            container.RegisterSingleton<MenuService, MenuService>();

            container.RegisterSingleton<ArticleManager, ArticleManager>();

            container.RegisterSingleton<IView, MainContent>();
            container.RegisterSingleton<IView, ArticleMenuContent>("ARTICLE_MENU");
            container.RegisterSingleton<IView, ArticleContent>("ARTICLE");
            container.RegisterSingleton<IView, BookContent>("BOOK");
        }

        protected override void RegisterViewModels()
        {
            ViewModelMapper.Register<ArticleMenuContent, ArticleMenuContentViewModel>();
            ViewModelMapper.Register<ArticleContent, ArticleContentViewModel>();
            ViewModelMapper.Register<MainContent, MainContentViewModel>();
        }

        protected override void SettingsLayer(ILayerManager layer, IContainer container)
        {
            IView main = container.Resolve<MainContent>();

            layer.Mapping("MAIN", main);
        }
    }
}
