using James.Proxy;
using Jamesnet.Core;
using Studio.Proxy;
using Studio.Support.Local.Managers;
using Studio.Support.Local.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Studio.Main.Local.ViewModels
{
    public class ArticleMenuContentViewModel : ViewModelBase, IViewLoadable
    {
        private readonly ArticleManager _articleManager;
        private readonly MenuService _menuService;
        private List<MenuResponse> _menus;
        private MenuResponse _currentMenu;

        public List<MenuResponse> Menus
        {
            get=> _menus;
            set=> SetProperty(ref _menus, value);
        }

        public MenuResponse CurrentMenu
        {
            get => _currentMenu;
            set => SetProperty(ref _currentMenu, value, OnMenuSelected);
        }

        public ArticleMenuContentViewModel(ArticleManager articleManager, MenuService menuService)
        {
            _articleManager = articleManager;
            _menuService = menuService;
        }

        public async void Loaded(object view)
        {
            Menus = await _menuService.GetMenusAsync(1);
            CurrentMenu = Menus.FirstOrDefault();
        }

        private void OnMenuSelected()
        {
            _articleManager.SelectMenu(CurrentMenu);
        }
    }
}