using System;
using Xamarin.Forms;

namespace recipeFinder.Classes
{
    public class Ingredient
    {
        //Properties of the image class
        public string name
        {
            get;
            set;
        }

        public string expirationDate
        {
            get;
            set;
        }

        public ImageSource image
        {
            get;
            set;
        }

        //Constructor
        public Ingredient(string _name, string _expirationDate, ImageSource _image)
        {
            name = _name;
            expirationDate = _expirationDate;
            image = _image;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
