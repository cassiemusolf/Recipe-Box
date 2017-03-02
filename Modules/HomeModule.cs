using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace RecipeBox
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] =_=> {
                return View ["index.cshtml"];
            };

            Get["/recipes"] = _ => {
                List<Recipe> AllRecipes = Recipe.GetAll();
                return View["recipes.cshtml", AllRecipes];
            };

            Get["/categories"] = _ => {
                List<Category> AllCategories = Category.GetAll();
                return View["categories.cshtml", AllCategories];
            };

            Get["/recipe/new"] = _ => {
                List<Category> AllCategories = Category.GetAll();
                return View["recipe_form.cshtml",AllCategories];
            };

            Post["/recipes"] = _ => {
                Recipe newRecipe = new Recipe(Request.Form["recipe-name"], Request.Form["ingredients"], Request.Form["instructions"], Request.Form["cook-time"], Request.Form["rating"],Request.Form["category-id"]);
                newRecipe.Save();
                List<Recipe> AllRecipes = Recipe.GetAll();
                return View["recipes.cshtml", AllRecipes];
            };

            Get["/category/new"] = _ => {
                return View["category_form.cshtml"];
            };

            Post["/categories"] = _ => {
                Category newCategory = new Category(Request.Form["category-name"]);
                newCategory.Save();
                List<Category> AllCategories = Category.GetAll();
                return View["categories.cshtml", AllCategories];
            };

            Get["/recipe/{id}"] = parameters => {
              Recipe recipe = Recipe.Find(parameters.id);
              return View["recipe_details.cshtml", recipe];
            };

            Get["/recipe/edit/{id}"] = parameters => {
                Recipe SelectedRecipe = Recipe.Find(parameters.id);
                return View["recipe_edit.cshtml", SelectedRecipe];
            };
            Patch["/recipe/edit/{id}"] = parameters => {
                Recipe SelectedRecipe = Recipe.Find(parameters.id);
                SelectedRecipe.Update(Request.Form["recipe-name"], Request.Form["ingredients"], Request.Form["instructions"], Request.Form["cook-time"], Request.Form["rating"]);
                List<Recipe> AllRecipes = Recipe.GetAll();
                return View["recipes.cshtml", AllRecipes];
            };

            Post["/recipes/delete"] = _ => {
                Recipe.DeleteAll();
                List<Recipe> AllRecipes = Recipe.GetAll();
                return View["recipes.cshtml",AllRecipes];
            };

            Get["recipe/delete/{id}"] = parameters => {
                Recipe SelectedRecipe = Recipe.Find(parameters.id);
                return View["recipe_delete.cshtml", SelectedRecipe];
            };
            Delete["recipe/delete/{id}"] = parameters => {
                Recipe SelectedRecipe = Recipe.Find(parameters.id);
                SelectedRecipe.DeleteRecipe();
                List<Recipe> AllRecipes = Recipe.GetAll();
                return View["recipes.cshtml",AllRecipes];
            };

            Get["/category/edit/{id}"] = parameters => {
                Category SelectedCategory = Category.Find(parameters.id);
                return View["category_edit.cshtml", SelectedCategory];
            };
            Patch["/category/edit/{id}"] = parameters => {
                Category SelectedCategory = Category.Find(parameters.id);
                SelectedCategory.Update(Request.Form["category-name"]);
                List<Category> AllCategories = Category.GetAll();
                return View["categories.cshtml", AllCategories];
            };

            Post["/categories/delete"] = _ => {
                Category.DeleteAll();
                List<Category> AllCategories = Category.GetAll();
                return View["categories.cshtml", AllCategories];
            };

            Get["category/delete/{id}"] = parameters => {
                Category SelectedCategory = Category.Find(parameters.id);
                return View["category_delete.cshtml", SelectedCategory];
            };
            Delete["category/delete/{id}"] = parameters => {
                Category SelectedCategory = Category.Find(parameters.id);
                SelectedCategory.DeleteCategory();
                List<Category> AllCategories = Category.GetAll();
                return View["categories.cshtml", AllCategories];
            };

        }
    }
}
