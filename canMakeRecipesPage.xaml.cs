using System;
using System.Collections.Generic;
using recipeFinder.Classes;

using Xamarin.Forms;

namespace recipeFinder
{
    public partial class canMakeRecipesPage : ContentPage
    {


        List<Recipe> recipesToDisplay;
        public canMakeRecipesPage(string _type, List<Recipe> _recipesToDisplay)
        {
            InitializeComponent();
            TitleLabel.Text = _type;
            CanMakeRecipesListView.ItemsSource = _recipesToDisplay;

            recipesToDisplay = _recipesToDisplay;
            
        }

        void CanMakeRecipesListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new DisplayRecipePage(recipesToDisplay[e.ItemIndex], "normal"));

        }
    }
}
