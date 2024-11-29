using Jamesnet.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Studio.Main.Local.ViewModels
{
    public class MainContentViewModel : ViewModelBase
    {
        private readonly IContainer _container;
        private readonly ILayerManager _layer;

        public ICommand MenuCommand { get; private set; }

        public MainContentViewModel(IContainer container, ILayerManager layer)
        {
            _container = container;
            _layer = layer;

            MenuCommand = new RelayCommand<string>(OnMenu);
        }

        private void OnMenu(string MenuName)
        {
            try
            {
                // Retrieve the view from the container based on the menu name.
                // MenuName serves as the identifier for the view.
                IView content = _container.Resolve<IView>(MenuName);

                // Display the retrieved view in the 'CONTENT' layer.
                // In the OpenSilver environment, this view does not appear immediately on the screen.
                // Initially, resizing the browser window is required to make the view visible.
                // However, for subsequent view changes, resizing the browser does not make the new view visible.
                _layer.Show("CONTENT", content);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
