using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace JamesStudio
{
    public sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

            // Enter construction logic here...
            JamesStudioBootstrapper jamesStudioBootstrapper = new JamesStudioBootstrapper();
            jamesStudioBootstrapper.Run();

            var mainPage = new MainPage();
            Window.Current.Content = mainPage;
        }
    }
}
