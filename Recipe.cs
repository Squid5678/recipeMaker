using System;
using Xamarin.Forms;
using System.Collections.Generic;
namespace recipeFinder.Classes
    
{
    public class Recipe
    {

        public string name
        {
            get;
            set;
        }

        public string description
        {
            get;
            set;
        }

        public List<string> ingredientNames = new List<string>();

        public List<Ingredient> ingredients = new List<Ingredient>();

        public List<string> instructions = new List<string>();

        public ImageSource image
        {
            get;
            set;


        }

        public Recipe(string _name, string _description, List<string> _ingredientNames,
            List<string> _instructions, ImageSource _image)
        {
            name = _name;
            description = _description;
            ingredientNames = _ingredientNames;
            instructions = _instructions;
            image = _image;


        }

        public override string ToString()
        {
            return name;
        }
    }
}
