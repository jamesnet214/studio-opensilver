using Jamesnet.Core;
using Studio.Main.UI.Views;

namespace JamesStudio
{
    internal class JamesStudioBootstrapper : AppBootstrapper
    {
        protected override void RegisterDependencies(IContainer container)
        {
            container.RegisterSingleton<IView, MainContent>();
        }

        protected override void RegisterViewModels()
        {
        }

        protected override void SettingsLayer(ILayerManager layer, IContainer container)
        {
            IView main = container.Resolve<MainContent>();

            layer.Mapping("MAIN", main);
        }
    }
}
