using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using recipefinder.Classes;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Collections.ObjectModel;
using System.IO;

namespace recipefinder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {


        /*
         * This ObservableCollection is like a list that will be used to store what the user has in their inventory
        ObservableCollection is used instead of List as we are going be setting this as the source of a ListView
        and the ListView's itemsSource needs to keep getting updated
        */
        ObservableCollection<Ingredient> myIngredients = new ObservableCollection<Ingredient>();
        

        //List of recipes for different types
        List<Recipe> breakfastRecipes = new List<Recipe>();
        List<Recipe> lunchRecipes = new List<Recipe>();
        List<Recipe> dinnerRecipes = new List<Recipe>();
        List<Recipe> dessertRecipes = new List<Recipe>();



        //This is a variable that will be used around as temporary storage variable to store the image the user took
        ImageSource imageSelected;

        //This is a List to store the Recipes a user can make
        List<Recipe> canMakeRecipes = new List<Recipe>();


        


    public void checkIfCanMake(List<Recipe> recipes)
        {


            //For every recipe in the recipes list
            for (int i = 0; i < recipes.Count; i++)
            {
                //For every ingredient in each recipe

                int correctIngredientCount = 0;


                for(int a = 0; a < recipes[i].ingredientNames.Count; a++)
                {


                    //Convert Ingredient list into string list
                    List<string> myIngredientsNames = new List<string>();
                    for(int b = 0; b < myIngredients.Count; b++)
                    {

                        myIngredientsNames.Add(myIngredients[b].name.ToLower());

                    }


                    //if myIngredientsNames Contains add to counter
                    if(myIngredientsNames.Contains(recipes[i].ingredientNames[a].ToLower()))
                    {


                        correctIngredientCount++;
                    }
                    


                    //if counter == amount of ingredients in the recipe

                    if(correctIngredientCount == recipes[i].ingredientNames.Count)
                    {

                        canMakeRecipes.Add(recipes[i]);

                    }

                    
                    //add to canMakeRecipes list

                }









            }



            

            
        }



        public MainPage()
        {
            InitializeComponent();


            NavigationPage.SetHasNavigationBar(this, false);

            IngredientDisplayListView.ItemsSource = myIngredients;



            imageSelected = "Grocery.png";
            IngredientImageButton.Source = "Grocery.png";

            //AddRecipes
            addBreakfastRecipes();
            addLunchRecipes();
            addDinnerRecipes();
            addDessertRecipes();

            //Add water
            Ingredient ing = new Ingredient("water", "none", "Grocery.png");
            myIngredients.Add(ing);
            //Breakfast Water
            for (int i = 0; i < breakfastRecipes.Count; i++)
            {
                if (breakfastRecipes[i].ingredientNames.Contains(ing.ToString().ToLower()))
                {

                    breakfastRecipes[i].ingredients.Add(ing);
                }


            }

            //Lunch Water
            for (int i = 0; i < lunchRecipes.Count; i++)
            {
                if (lunchRecipes[i].ingredientNames.Contains(ing.ToString().ToLower()))
                {

                    lunchRecipes[i].ingredients.Add(ing);
                }


            }


            //Dinner Water
            for (int i = 0; i < dinnerRecipes.Count; i++)
            {
                if (dinnerRecipes[i].ingredientNames.Contains(ing.ToString().ToLower()))
                {

                    dinnerRecipes[i].ingredients.Add(ing);
                }


            }
            //Dessert Water
            for (int i = 0; i < dessertRecipes.Count; i++)
            {
                if (dessertRecipes[i].ingredientNames.Contains(ing.ToString().ToLower()))
                {

                    dessertRecipes[i].ingredients.Add(ing);
                }


            }
        }

        //This function will be used to set the image of the ingredient added
        async void IngredientImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            //Initialize Camera
            await CrossMedia.Current.Initialize();

            //Make sure there is an existing camera
            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {


                imageSelected = "Grocery.png";

                await DisplayAlert("Camera Not Supported", "Try Reload the App", "Done");



                return;
            }

            //Setup camera settings
            StoreCameraMediaOptions cameraSettings = new StoreCameraMediaOptions
            {

                Directory = "Sample",
                Name = DateTime.Now + "_image.jpg",
                

            };


            var file = await CrossMedia.Current.TakePhotoAsync(cameraSettings);

            if(file == null)
            {

                return;
            }


            imageSelected = ImageSource.FromStream(()=>
            {



                var stream = file.GetStream();
                return stream;

            });

            //Set Image Preview to the Image taken
            IngredientImageButton.Source = imageSelected;
            

        }

        //The function that will add an ingredient of type Ingredient to the myInventory ObeservableCollection
        void AddButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Ingredient ing = new Ingredient(NameOfIngredientEntry.Text, ExpiryDate.Date.ToString(), imageSelected);

            myIngredients.Add(ing);

            
            //Breakfast
            for(int i = 0; i < breakfastRecipes.Count; i++)
            {
               if( breakfastRecipes[i].ingredientNames.Contains(ing.ToString().ToLower()))
                {

                    breakfastRecipes[i].ingredients.Add(ing);
                }


            }

            //Lunch
            for (int i = 0; i < lunchRecipes.Count; i++)
            {
                if (lunchRecipes[i].ingredientNames.Contains(ing.ToString().ToLower()))
                {

                    lunchRecipes[i].ingredients.Add(ing);
                }


            }


            //Dinner
            for (int i = 0; i < dinnerRecipes.Count; i++)
            {
                if (dinnerRecipes[i].ingredientNames.Contains(ing.ToString().ToLower()))
                {

                    dinnerRecipes[i].ingredients.Add(ing);
                }


            }
            //Dessert
            for (int i = 0; i < dessertRecipes.Count; i++)
            {
                if (dessertRecipes[i].ingredientNames.Contains(ing.ToString().ToLower()))
                {

                    dessertRecipes[i].ingredients.Add(ing);
                }


            }




            //reset
            NameOfIngredientEntry.Text = "";
            ExpiryDate.Date = DateTime.Now;

            IngredientImageButton.Source = "Grocery.png";
            imageSelected = "Grocery.png";
        }


        //Generate a list of recipes based on the ingredients stored in your inventory
        //These recipes will be foods that can be eaten at Breakfast
        void BreakfastButton_Clicked(System.Object sender, System.EventArgs e)
        {

            //Remove any previous stored things here to avoid duplication in list view
            canMakeRecipes.Clear();

            checkIfCanMake(breakfastRecipes);



            Navigation.PushAsync(new CanMakeRecipesPage("Breakfast", canMakeRecipes));



        }

        //Generate a list of recipes based on the ingredients stored in your inventory
        //These recipes will be foods that can be eaten at Lunch
        void LunchButton_Clicked(System.Object sender, System.EventArgs e)
        {

            //Remove any previous stored things here to avoid duplication in list view
            canMakeRecipes.Clear();

            checkIfCanMake(lunchRecipes);

            Navigation.PushAsync(new CanMakeRecipesPage("Lunch", canMakeRecipes));
        }

        //Generate a list of recipes based on the ingredients stored in your inventory
        //These recipes will be foods that can be eaten at Dinner
        void DinnerButton_Clicked(System.Object sender, System.EventArgs e)
        {

            //Remove any previous stored things here to avoid duplication in list view
            canMakeRecipes.Clear();

            /*
             * Compare myIngredients ObservableCollection to a list based on the type of food selected(breakfast, lunch etc.)

                canMakeRecipes will now be populated with recipes that can be made
            */
            checkIfCanMake(dinnerRecipes);

            Navigation.PushAsync(new CanMakeRecipesPage("Dinner", canMakeRecipes));
        }

        //Generate a list of recipes based on the ingredients stored in your inventory
        //These recipes will be foods that can be eaten at Dessert
        void DessertButton_Clicked(System.Object sender, System.EventArgs e)
        {
            //Remove any previous stored things here to avoid duplication in list view
            canMakeRecipes.Clear();

            /*
             * Compare myIngredients ObservableCollection to a list based on the type of food selected(breakfast, lunch etc.)

                canMakeRecipes will now be populated with recipes that can be made
            */


            checkIfCanMake(dessertRecipes);

            Navigation.PushAsync(new CanMakeRecipesPage("Dessert", canMakeRecipes));
        }


        //Function displays our handpicked favorite recipes #1
        void Recommendation1_Clicked(System.Object sender, System.EventArgs e)
        {
            Recipe r = new Recipe("Double Stuffed Cheesy Pasta", "Creamy and Cheesy Pasta that all will love.",
                new List<string>() { "pasta", "onion", "garlic", "tomato", "mushroom", "spinach", "pepper", "cheese" },
                new List<string>() { "1. Fill a large pot of water and boil. Add 1 package of Pasta to water.", "2. Heat 2 tablespoons of oil in a skillet, and add ½ cup onion and 1 clove of garlic. Mix in 3 cups Tomatoes, 1 cup Mushrooms, and 2 cups Spinach.",
                    "3. Continue to cook Tomatoes for 2 minutes and stir contents and Cheese into Pasta.Cook until heated."}, "pasta.jpg");

            Navigation.PushAsync(new DisplayRecipePage(r, "recommended"));
        }
        //Function displays our handpicked favorite recipes #2
        void Recommendation2_Clicked(System.Object sender, System.EventArgs e)
        {
            Recipe r = new Recipe("Chocolate Fudge Brownies", "Brownies with a rich and indulgent chocolate flavor.",
                new List<string>() { "butter", "sugar", "cocoa", "vanilla", "baking powder", "eggs", "flour", "powder" },
                new List<string>() { "1. Preheat oven to 350 degrees F. Grease a 9x13 Pan.", "2. Combine 1 cup of Melted Butter, 2 cups Sugar, 1/2 cup Cocoa, 4 Eggs, 1 1/2 cup flour, 1/2 teaspoon baking powder, and 1/2 teaspoon Salt",
                    "3. Spread contents in pan. Bake for 20-30 minutes, and cool."}, "brownie.jpg");

            Navigation.PushAsync(new DisplayRecipePage(r, "recommended"));


        }
        //Function displays our handpicked favorite recipes #3
        void Recommendation3_Clicked(System.Object sender, System.EventArgs e)
        {
            Recipe r = new Recipe("Crispy Tater Tots", "Crispy and Crunchy Tater Tots with a satisfying Potato Flavor",
                new List<string>() { "potatoes", "flour", "pepper", "salt" },
                new List<string>() { "1. Place 2 potatoes in a pot and add water. Begin boiling, and simmer until potatoes are softened. " +
                "Drain water and cool for 15 minutes.", "2. Shred potatoes into thin strips and drain excess water. Stir 1 tablespoon flour, 1 tablespoon salt, 1 teaspoon pepper, and potatoes.",
                    "3.Heat oil in fryer and heat to 350 degrees F.Place potatoes into fryer and cook until brown and crispy."}, "tatertots.jpg");


            Navigation.PushAsync(new DisplayRecipePage(r, "recommended"));


        }


        //Setup all the breakfast Recipes
        void addBreakfastRecipes()
        {

            breakfastRecipes.Add(new Recipe("SpicyEggs", "Eggs with a taste of fire", new List<string>() { "eggs", "hotsauce" }, new List<string>() { "1. Boil eggs", "2. Add hotsauce" }, "Grocery.png"));
            breakfastRecipes.Add(new Recipe("CheeseSandwich", "Very Cheesy", new List<string>() { "bread", "cheese" }, new List<string>() { "1. Open bread", "2. Put cheese" }, "Grocery.png"));

            breakfastRecipes.Add(new Recipe("Mayo Sandwich", "Mayo dreams come true by eating this sandwich!", new List<string>() { "mayonnaise", "eggs", "bread" }, new List<string>() { "1.Cut up boiled eggs into thin slices", "2.Spread mayonnaise on bread", "3.Put slices of boiled eggs on bread", "4. Put bread on top of each other." }, "mayonnaise.jpg"));

            breakfastRecipes.Add(new Recipe("Yogurt Parfait ", "Not too healthy  and  not too junky", new List<string>() { "yogurt", "granola", "Black Berries" }, new List<string>() { "1. Put 1 cup yogurt in a bowl", "2. Add ¼ cup granola to yogurt, “3. Mix”, “4. Sprinkle 8 blackberries on top" }, "yogurt.jpg"));

            breakfastRecipes.Add(new Recipe("Nutella Chocolate Delight Waffles", "You like chocolate, then try this!", new List<string>() { "waffles", "nutella", "whipped cream”, “strawberries" }, new List<string>() { "1.Toast waffles for 1 minute each", "2.Spread 1.5 tbsp Nuttella on each waffle", "3. Spray whipped cream on top of waffle", "4. Put 2 strawberries on each waffle" }, "waffles.jpg"));

        }
        //Setup lunch Recipes
        void addLunchRecipes()
        {

            lunchRecipes.Add(new Recipe("Tomato Soup", "A hit of tomato", new List<string>() { "tomato", "water" }, new List<string>() { "1. Cut Tomato", "2. Add to boiling water" }, "Grocery.png"));

            lunchRecipes.Add(new Recipe("Crispy Tater Tots", "Crispy and Crunchy Tater Tots with a satisfying Potato Flavor", new List<string>() { "potatoes", "flour", "pepper", "salt" }, new List<string>() { "1. Place 2 potatoes in a pot and add water. Begin boiling, and simmer until potatoes are softened. Drain water and cool for 15 minutes.", "2. Shred potatoes into thin strips and drain excess water. Stir 1 tablespoon flour, 1 tablespoon salt, 1 teaspoon pepper, and potatoes.", "3.Heat oil in a fryer and heat to 350 degrees F.Place potatoes into fryer and cook until brown and crispy." }, "tatertots.jpg"));

            lunchRecipes.Add(new Recipe("Ham Sandwich", "Cool Ham", new List<string>() { "ham", "spinach", "lettuce", "onions", "tomatoes", "bread" }, new List<string>() { "1. Toast two pieces of bread in whichever way you like", "2. Cut the ham, spinach, lettuce, onions, and tomatoes to fit the bread", "3. Place all vegetables on one slice of bread.Make sure all of the vegetables are on the bread.", "4. Put the other piece of bread on the sandwich!" }, "ham.jpg"));

            lunchRecipes.Add(new Recipe("Chicken Caesar Salad", "Caesar's best", new List<string> { "oil", "Anchovies", "salt", "pepper", "bread", "lettuce", "cheese" }, new List<string>() { "1. Preheat a grill medium high.", "2. Make Dressing: Chop 2 garlic cloves, lemon juice, and puree with olive oil in a blender until smooth. Pound the chicken with a mallet or heavy skillet.", "3. Add 1 tablespoon of the Caesar dressing. Grill the chicken until golden and crisp”. 3 to 4 minutes per side. Brush the bread with olive oil. Rub with the remaining garlic clove.", "4. Brush the romaine with dressing and grill. Chop the lettuce, bread, and chicken. Toss with the remaining dressing, the parmesan, and pepper to taste. Garnish with more parmesan." }, "salad.jpg"));


        }
        //Setup dinner recipes
        void addDinnerRecipes()
        {

            dinnerRecipes.Add(new Recipe("Grilled Vegetables", "Nutritious", new List<string>() { "tomato", "lettuce", "green pepper", "onion" }, new List<string>() { "1. Wash vegetables", "2. Cut them", "3. Grill them" }, "Grocery.png"));


            dinnerRecipes.Add(new Recipe("Double Stuffed Cheesy Pasta", "Creamy and Cheesy Pasta that all will love.", new List<string>() { "pasta", "oil", "onion", "garlic", "tomato", "mushroom", "spinach", "salt", "pepper", "cheese" }, new List<string>() { "1. Fill a large pot of water and boil. Add 1 package of Pasta to water.", "2. Heat 2 tablespoons of oil in a skillet, and add ½ cup onion and 1 clove of garlic. Mix in 3 cups Tomatoes, 1 cup Mushrooms, and 2 cups Spinach.", "3.Continue to cook Tomatoes for 2 minutes and stir contents and Cheese into Pasta.Cook until heated." }, "pasta.jpg"));


            dinnerRecipes.Add(new Recipe("Tomato Soup", "Back to Basics", new List<string> { "butter", "tomatoes", "onion", "parsley" }, new List<string> { "1.Combine butter, onion, and tomatoes.", "2.Grab a pot, place it over medium heat and melt the butter.", "3.Add half an onion that’s been cut into large wedges and a large can of tomatoes." }, "soup.jpg"));
            dinnerRecipes.Add(new Recipe("Peanut Butter and Jelly Sandwich", "The Classic Childhood Lunch", new List<string> { "butter", "tomatoes", "onion", "parsley" }, new List<string> { "1. Spread 2 tablespoons peanut butter onto 1 slice of bread.", "2. Spread 1 tablespoon jelly onto another slice of bread.", "4. Place on top of peanut butter, jelly side down. Put the two bread pieces together." }, "pbj.jpg"));
        }
        //Set up dessert recipes
        void addDessertRecipes()
        {

            dinnerRecipes.Add(new Recipe("Cake", "Eggs with a taste of fire", new List<string>() { "eggs", "flour", "water", "oil" }, new List<string>() { "1. Combine all ingredients", "2. Bake them" }, "Grocery.png"));

            dessertRecipes.Add(new Recipe("Chocolate Fudge Brownies", "Brownies with a rich and indulgent chocolate flavor.", new List<string>() { "butter", "sugar", "cocoa", "vanilla", "baking powder", "eggs", "flour", "powder", "salt" }, new List<string>() { "1. Preheat the oven to 350 degrees F. Grease a 9x13 Pan.", "2. Combine 1 cup of Melted Butter, 2 cups Sugar, 1/2 cup Cocoa, 4 eggs, 1 1/2 cup flour, 1/2 teaspoon baking powder, and 1/2 teaspoon Salt", "3. Spread contents in pan. Bake for 20-30 minutes, and cool." }, "brownie.jpg"));


            dessertRecipes.Add(new Recipe("Peanut Butter Cookies", "Soft, crunchy, and indulgent Peanut Butter Cookies with a hint of Chocolate", new List<string>() { "peanut butter", "sugar", "eggs" }, new List<string>() { "1. Preheat the oven to 350 degrees F.", "2. Mix 1 cup Peanut Butter, 1 cup Sugar, and 1 egg into a bowl and mix until smooth and creamy. Roll mixture into Cookie Shapes and arrange on a Cookie Sheet.", "3.Bake in the oven for 10 minutes.Cool down for 2 minutes" }, "cookies.jpg"));

            dessertRecipes.Add(new Recipe("Chocolate Pudding", "A pool of chocolate for you to dive into!", new List<string>() { "corn starch", "milk", "vanilla extract", "sugar", "cocoa powder" }, new List<string>() { "1. In a small bowl, combine cornstarch and water to form a paste.", "2. In a large saucepan over medium heat, stir together soy milk, vanilla, sugar, cocoa and cornstarch mixture.", "3. Cook until mixture thickens and boils.", "4. Take the mixture off heat and cool it down" }, "pudding.jpg"));
        }
    }
}





        

    

