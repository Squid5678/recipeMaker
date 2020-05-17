using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using recipeFinder.Classes;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Collections.ObjectModel;
using System.IO;

using Xamarin.Forms;

namespace recipeFinder
{
    

    public partial class DisplayRecipePage : ContentPage
    {
        string stepsToMake = "";
        public DisplayRecipePage(Recipe recipeToDisplay, string type)
        {
            InitializeComponent();
            RecipeNameLabel.Text = recipeToDisplay.name;
            RecipeImage.Source = recipeToDisplay.image;

            for(int i = 0; i < recipeToDisplay.instructions.Count; i++)
            {
                stepsToMake = stepsToMake + recipeToDisplay.instructions[i] + System.Environment.NewLine;


            }

            StepsToMakeLabel.Text = stepsToMake;
            if (type == "recommended")
            {
                IngredientsListView.ItemTemplate = null;
                IngredientsListView.ItemsSource = recipeToDisplay.ingredientNames;


            }
            else
            {

                IngredientsListView.ItemsSource = recipeToDisplay.ingredients;
            }
        }
    }
}
