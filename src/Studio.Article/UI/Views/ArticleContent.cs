using Jamesnet.Core;
using System.Windows.Controls;

namespace Studio.Main.UI.Views
{
    public class ArticleContent : ContentControl, IView
    {
        public ArticleContent()
        {
            this.DefaultStyleKey = typeof(ArticleContent);
        }
    }
}
