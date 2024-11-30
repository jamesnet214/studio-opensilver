using Jamesnet.Core;
using Studio.Proxy;
using Studio.Support.Local.Managers;
using Studio.Support.Local.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Studio.Main.Local.ViewModels
{
    public class ArticleContentViewModel : ViewModelBase, IViewLoadable, IViewActivated, IViewClosed
    {
        private readonly IContainer _container;
        private readonly ILayerManager _layer;
        private readonly ArticleProxy _articleProxy;
        private readonly ArticleManager _articleManager;
        private List<ArticleResponse> _articles;
        private bool _isLoading;
        private string _message;

        public ArticleContentViewModel(ArticleProxy articleProxy, ArticleManager articleManager, IContainer container, ILayerManager layer)
        {
            _articleProxy = articleProxy;
            _articleManager = articleManager;
            _container = container;
            _layer = layer;

            articleManager.OnMenuSelected += ArticleManager_OnMenuSelected;
        }

        public List<ArticleResponse> Articles
        {
            get => _articles;
            set => SetProperty(ref _articles, value);
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ICommand LoadArticlesCommand { get; }

        public void Loaded(object view)
        {
        }

        public void ViewActivated(object view)
        {
            IView ArticleMenuContent = _container.Resolve<IView>("ARTICLE_MENU");
            _layer.Show("LEFT_SIDE", ArticleMenuContent);
        }

        public void ViewClosed(object view)
        {
            _layer.Hide("LEFT_SIDE");
        }

        private async void ArticleManager_OnMenuSelected(MenuResponse menu)
        {
            IsLoading = true;
            Articles = await _articleProxy.GetArticles(menu.MenuID.ToString(), "recent");
            IsLoading = false;
        }
    }
}