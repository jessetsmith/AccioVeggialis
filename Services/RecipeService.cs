using AccioVegialis.Data;
using AccioVegialis.Data.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RecipeService
    {
        private readonly string _userID;
        private ApplicationUser _user;

        public RecipeService(string userID)
        {
            _userID = userID;
        }

        public bool CreateRecipe(RecipeCreate model)
        {
            var ctx = new ApplicationDbContext();
            var user = ctx.Users.Find(_userID);
            _user = user;

            var entity =
                new Recipes()
                {
                    Title = model.Title,
                    UserID = _userID,
                    Author = _user,
                    Ingredients = model.Ingredients,
                    RecipeText = model.RecipeText,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (ctx)
            {
                ctx.Recipes.Add(entity);

                return ctx.SaveChanges() == 1;

            }
        }

        public IEnumerable<RecipeListItem> GetRecipes()
        {
            using (var ctx= new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Recipes
                    //.Where(e => e.UserID == _userID)
                    .Select(
                        e =>
                        new RecipeListItem
                        {
                            RecipeID = e.RecipeID,
                            Title = e.Title,
                            Author = e.Author.UserName,
                            Ingredients = e.Ingredients,
                            CreatedUTC = e.CreatedUTC
                        });
                return query.ToArray();
            }
        }

        public RecipeDetail GetRecipeByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var recipeCommentService = new RecipeCommentsService(_userID);
                var comments = recipeCommentService.GetCommentDetailsByRecipeID(id);

                var entity =
                    ctx
                    .Recipes
                    .Single(e => e.RecipeID == id);
                return
                    new RecipeDetail
                    {
                        RecipeID = entity.RecipeID,
                        Title = entity.Title,
                        Author = entity.Author.UserName,
                        RecipeText = entity.RecipeText,
                        Ingredients = entity.Ingredients,
                        Comments = comments,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool UpdateRecipe(RecipeEdit model, int recipeID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recipes
                    .Single(e => e.RecipeID == recipeID && e.UserID == _userID);

                entity.Title = model.Title;
                entity.RecipeText = model.RecipeText;
                entity.Ingredients.Clear();
                entity.Ingredients = model.Ingredients;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCommentsOnRecipe(int recipeID)
        {
            var ctx = new ApplicationDbContext();
            var recipeCommentService = new RecipeCommentsService(_userID);
            var comments = recipeCommentService.GetCommentsByRecipeID(recipeID);


            ctx.RecipeComments.Remove(comments);
            return ctx.SaveChanges() == 1;
           
        }

        public bool DeleteRecipe(int recipeID)
        {
            var ctx = new ApplicationDbContext();



            using (ctx)
            {
                var entity =
                    ctx
                    .Recipes
                    .Single(e => e.RecipeID == recipeID && e.UserID == _userID);

             
                    entity.Ingredients.Clear();
                    entity.Comments.Clear();
                    
                    ctx.Recipes.Remove(entity);
                    return ctx.SaveChanges() == 1;
            }

        }
    }
}
