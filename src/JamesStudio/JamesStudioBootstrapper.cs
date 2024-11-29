using Jamesnet.Core;
using Studio.Main.Local.ViewModels;
using Studio.Main.UI.Views;

namespace JamesStudio
{
    internal class JamesStudioBootstrapper : AppBootstrapper
    {
        protected override void RegisterDependencies(IContainer container)
        {
            container.RegisterSingleton<IView, MainContent>();
            container.RegisterSingleton<IView, ArticleContent>("ARTICLE");
            container.RegisterSingleton<IView, BookContent>("STORE");
        }

        protected override void RegisterViewModels()
        {
            ViewModelMapper.Register<MainContent, MainContentViewModel>();
        }

        protected override void SettingsLayer(ILayerManager layer, IContainer container)
        {
            IView main = container.Resolve<MainContent>();

            layer.Mapping("MAIN", main);
        }
    }
}
