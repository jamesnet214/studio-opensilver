using Jamesnet.Core;
using System;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Studio.Main.Local.ViewModels
{
    public class MainContentViewModel : ViewModelBase
    {
        private readonly IContainer _container;
        private readonly ILayerManager _layer;
        private object _Content;

        public ICommand MenuCommand { get; private set; }

        public object Content
        {
            get => _Content;
            set => SetProperty(ref _Content, value);
        }

        public MainContentViewModel(IContainer container, ILayerManager layer)
        {
            _container = container;
            _layer = layer;

            MenuCommand = new RelayCommand<string>(OnMenu);
        }

        private void OnMenu(string MenuName)
        {
            if (MenuName != "ARTICLE" && MenuName != "BOOK") return;

            IView content = _container.Resolve<IView>(MenuName);
            _layer.Show("CONTENT", content);
        }
    }
}