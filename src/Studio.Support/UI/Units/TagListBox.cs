using System.Windows;
using System.Windows.Controls;

namespace Studio.Support.UI.Units
{
    public class TagListBox : ListBox
    {
        public TagListBox()
        {
            DefaultStyleKey = typeof(TagListBox);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TagListBoxItem();
        }
    }
}
