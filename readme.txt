## Inspiration
Each week when our parents would shop at local grocery stores, we were never organized enough to make an exact shopping list of what we need. It was tedious work, and we typically never followed a list. However, each time we would go shopping, there was always this one item that we’ve completely forgotten about, and with no one home, we always forget if we have the item or if we don’t. This usually ends up in buying an excess amount of not buying it at all. Therefore, we have decided to create this easy-to-use app that allows you to simply take a picture of your item and store it onto an Inventory Control List. This will allow you to easily view all of the groceries in your home just by looking at a phone on your app. 

Adding on, as young teenagers, we’ve the type of people to always have snacks loaded up in our pantry. However, more times than one may think, we’ve found expired bags of Chips, Cookies, and other items. Therefore, this app also includes a simple Expiry Date management system in addition to the Inventory Management System. 

Finally, with the Coronavirus forcing us to stay at home, many of us have decided to explore the world of cooking and baking. But oftentimes many of us are missing those key ingredients that we need for cooking and baking, or we don’t know what we have! So, we thought to ourselves, How can we make keeping track of Groceries easier, while also making it easier for people to make what they love using only what they have?

## What it does

Easy and intuitive inventory management utility: 
Allows users to store ingredients(items), their images, and expiry dates into the app and it acts as a virtual storage shelf in which the user can easily see what they have available and when it expires. We have integrated the camera into our application so that the user can easily take a photo for each ingredient.

Generates Lists of Recipes Based on the Ingredients the User has and what Category the User Chooses.
Has a page in which the user can select what type of meal they would like to prepare(breakfast, lunch, dinner, or dessert) and only recommends recipes based on what the user has stored in their inventory so that the user doesn’t need to go out to buy new items. They can make things with the ingredients they have.

Platform to find the latest and greatest Recommended Recipes:
Contains a selection of hand curated recommended recipes that users can use to make delicious culinary dishes.

Displays Recipes with Instructions, ingredients(with pictures), and steps to make all in one easy to use simple view.
Each recipe given by the app can be viewed in our easy to use Recipe Viewer. The Recipe Viewer consists of an image, a list of ingredients(list view) each with preview icons for each ingredient. The user will be sure to know what each item is and the easy-to-understand instructions allow them to make what they desire with simplicity.



## How we built it
We used a platform known as Xamarin on VisualStudios to develop our app. The great part about this is that instead of having to develop our app to one specific platform, Xamarin allows us to build native iOS and Android apps using one program. 

We used Xamarin native code called XAML in order to create the User Interface with our app. This includes all the images, the buttons, the layouts, pages, etc. In addition to XAML, we also used C# to incorporate all of our logic into the code. Here, you will find the database for all of our recipes, as well as the various algorithms we have created in order to suit the user’s needs based on the inventory they input into the app. 

## Challenges we ran into
- Optimizing UI for multiple platforms(IOS and Android).
- Adjusting our code for devices with different aspect ratios. 
- Creating the algorithm for displaying recommended recipes based on the user input.
- Transferring data between different content pages (ie. getting the image from the inventory page to display on the recipe page). 

## Accomplishments that we're proud of
We are proud of:
- Creating all of our pages of our app
- Creating our algorithm that displays our recommended recipes based on user input.
- Making an easy to use UI and creating our first app on the iOS platform. 
- Making the app actually look good and user friendly. 
- It functions exactly the way we want it to - there are no malfunctions. We were able to overcome our challenges. 

## What we learned
We really dived deeper into using the Xamarin.Forms platform and learned the core principles of Cross-Platform App Development. Additionally, we learned how to separate our UI from our backend so we could work on different parts of the app simultaneously whilst still allowing the two parts to be integrated together(half our team worked on designing the app, while the other worked on programming the logic). Furthermore, we learned how to use the camera from the user’s device and to store those images that the user selected. Finally, we learned how to store items with different data types on iOS and Android(such as ObservableCollections). 



## What's next for Bag To Food?
While we love the way that Bag To Food has turned out, we have high hopes for this application. We would like to improve our data storage system by utilizing better storage solutions such as different types of local databases or even the cloud. Furthermore, we want to create a more intuitive user experience by recognizing the image the user inputs. We would do this by applying Machine Learning to detect the grocery that the user takes an image of it. This would not only make our programming much more advanced, but the ease of use automatically increases if the user has to fill in one less field in the app. Finally, we would also like to improve our recipe collection by using third party data sources as opposed to our own recipes. We want to make our recipe collection much more profound so that the user has even more options to select what they desire to make. Overall, Bag To Food is a great app for almost all audiences - those who need an easy way to manage their groceries and those who desire easy to make recipes will love our app!

