![AccioVeggialisCover](https://github.com/jessetsmith/AccioVeggialis/blob/main/accio-veggialis-cover.png?raw=true)

# Accio Vegialis
Accio Vegialis is a web api designed to help the user find recipes for their favorite vegetables. Users can also add a recipe and comment. An upcoming version will allow a user to share and favorite their recipes.

The name "Accio Vegialis" is derived from the Harry Potter movie series meaning "Reaching for the vegetables".

## Files
Data
- Vegetables
- Recipes
- Recipe Comments

## Setup
Identity Models

Models
- VegetableCreate
- VegetableListItem
- VegetableEdit
- VegetableDetail
- RecipeCreate
- RecipeListItem
- RecipeEdit
- RecipeDetail
- RecipeCommentCreate
- RecipeCommentListItem
- RecipeCommentEdit
- RecipeCommentDetail

Services 
- VegetableService  
- RecipeService
- RecipeCommentService

Controllers
- VegetableController
- RecipeController
- RecipeCommentController

## Resources utilized
https://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx

## How to utilize
**The dev team will have pre-built the vegetable database and recipes. The user will not have access to create or need to create the vegetable. Once the front end is developed, the user will input a vegetable and be presented with recipes that include that vegetable. They will also have the ability to add a recipe for that vegetable. ICollections are utilized to attach recipes to ingredients.

Open Visual Community and run the program. Utilizing https://localhost:44368/ the following functions can be executed in Postman. Data tables will populate and can be crosschecked in Visual Community.

#### CREATE USER ACCOUNT
 POST api/Account/Register
 {
  "Email": "sample string 1",
  "Password": "sample string 2",
  "ConfirmPassword": "sample string 3"
}

#### CREATE VEGETABLE
 POST api/Vegetable
 {
  "Title": "sample string 1" (Max length: 50, Min length: 5)
  "Description": "sample string 2" (Max length: 1000)
 }
Additional options:

 - Edit Vegetable
	 - PUT api/Vegetable/{id}
- Get vegetable by ID
	- GET api/Vegetable/{id}
- Get All Vegetables 
	- GET api/Vegetable
 - Delete Vegetable
	 - DELETE api/Vegetable/{id}

#### CREATE RECIPE
POST api/Recipe
{
  "Title": "sample string 1",
  "Ingredients": [
    {
      "VegetableID": 1,
      "Title": "sample string 2",
      "Description": "sample string 3",
      "CreatedUTC": "2020-11-15T13:25:39.9527096-05:00",
      "ModifiedUTC": "2020-11-15T13:25:39.9527096-05:00"
    },
  ],
  "RecipeText": "sample string 2"
}

Additional Options:
- Edit Recipe
	- PUT api/Recipe/{id}
- Get Recipe by ID
	- GET api/Recipe/{id}
- Get All Recipes
	- GET api/Recipe
- Delete Recipe
	- DELETE api/Recipe/{id}

#### CREATE RECIPE COMMENT
POST api/RecipeComment
{
  "CommentText": "sample string 1"
}
Additional Options:
- Get All Recipe Comments
	- GET api/RecipeComment
- Get Recipe Comment by ID
	- GET api/RecipeComment/{id}
- Edit Recipe Comment 
	- PUT api/RecipeComment
- Delete Recipe Comment
	- DELETE api/RecipeComment/{id}


## Upcoming Features

Upcoming features include but are not limited to:

-   Ability to share recipes on the app and social media
- Adding nutrition information to vegetables
    
    

## Status

Project is: in progress. 


## Contributors

Jesse Smith -https://github.com/jessetsmith, jesse.t.smith@icloud.com
Nathena Dodd - https://github.com/Nathenadodd, nathenadodd@gmail.com
Julia Charfauros - [https://github.com/jcharfauros](https://github.com/jcharfauros), julia.charfauros@gmail.com
Erica Terkhorn - https://github.com/ericaterkhorn, erica.terkhorn@gmail.com


