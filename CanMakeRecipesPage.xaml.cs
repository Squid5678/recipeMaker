using System;
using System.Collections.Generic;
using recipefinder.Classes;
using Xamarin.Forms;

namespace recipefinder
{
    public partial class CanMakeRecipesPage : ContentPage
    {
        List<Recipe> recipesToDisplay;

        public CanMakeRecipesPage(string _type, List<Recipe> _recipesToDisplay)
        {
            InitializeComponent();
            //Change UI according to List of Recipes passed in
            TitleLabel.Text = _type;
            CanMakeRecipesListView.ItemsSource = _recipesToDisplay;


            recipesToDisplay = _recipesToDisplay;
        }


        //Add an event when the ListView is Tapped
        void CanMakeRecipesListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {

            Navigation.PushAsync(new DisplayRecipePage(recipesToDisplay[e.ItemIndex], "normal"));
        }
    }
}
