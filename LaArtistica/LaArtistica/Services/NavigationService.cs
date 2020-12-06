﻿using LaArtistica.ViewModel;
using LaArtistica.ViewModel.Base;
using LaArtistica.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LaArtistica.Services
{
    public class NavigationService
    {
        private static NavigationService _instance;

        public static NavigationService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NavigationService();
                return _instance;
            }
        }

        protected readonly Dictionary<Type, Type> mappings;

        protected Application CurrentApplication => Application.Current;

        public NavigationService()
        {
            mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        public async Task InitializeAsync()
        {
            await NavigateToAsync<ProductViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase => InternalNavigateToAsync(typeof(TViewModel), null);

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase => InternalNavigateToAsync(typeof(TViewModel), parameter);

        public async Task NavigateBackAsync()
        {
            await CurrentApplication.MainPage.Navigation.PopAsync();
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            var page = CreateAndBindPage(viewModelType, parameter);

            if (page is ArtisticaView)
            {
                CurrentApplication.MainPage = new NavigationPage(page);
            }
            else
            {
                if (CurrentApplication.MainPage is NavigationPage navigationPage)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    CurrentApplication.MainPage = new NavigationPage(page);
                }
            }

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            var pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            var page = Activator.CreateInstance(pageType) as Page;
            var viewModel = Activator.CreateInstance(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            return page;
        }

        void CreatePageViewModelMappings()
        {
            mappings.Add(typeof(ProductViewModel), typeof(ArtisticaView));
            mappings.Add(typeof(ProductDetailViewModel), typeof(ProductDetailView));
        }
    }
}

