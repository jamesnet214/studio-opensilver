using Studio.Support.Local.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Studio.Support.Local.Managers
{
    public class ArticleManager
    {
        public event Action<MenuResponse> OnMenuSelected;

        public void SelectMenu(MenuResponse currentMenu)
        {
            OnMenuSelected?.Invoke(currentMenu);
        }
    }
}
