using System.Windows;
using System.Windows.Controls;

namespace Studio.Support.UI.Units
{
    public class ArticleListBox : ListBox
    {
        public ArticleListBox()
        {
            DefaultStyleKey = typeof(ArticleListBox);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ArticleListBoxItem();
        }
    }
}
