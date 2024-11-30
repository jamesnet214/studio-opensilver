using System.Windows;
using System.Windows.Controls;

namespace Studio.Support.UI.Units
{
    public class ArticleMenuListBox : ListBox
    {
        public ArticleMenuListBox()
        {
            DefaultStyleKey = typeof(ArticleMenuListBox);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ArticleMenuListBoxItem();
        }
    }
}
