using System;
using System.Collections.Generic;
using recipefinder.Classes;
using Xamarin.Forms;

namespace recipefinder
{
    public partial class DisplayRecipePage : ContentPage
    {

        string stepsToMake = "";

        public DisplayRecipePage(Recipe recipeToDisplay, string type)
        {
            InitializeComponent();

            //Change UI according to Recipe passed in, this a template page
            RecipeNameLabel.Text = recipeToDisplay.name;
            RecipeImage.Source = recipeToDisplay.image;



            //Go through every step in the recipe
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
