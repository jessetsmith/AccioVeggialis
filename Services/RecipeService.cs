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

        public RecipeService(string userID)
        {
            _userID = userID;
        }

        public bool CreateRecipe(RecipeCreate model)
        {
            var entity =
                new Recipes()
                {
                    Title = model.Title,
                    UserID = _userID,
                    Ingredients = model.Ingredients,
                    RecipeText = model.RecipeText,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
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
                    .Where(e => e.UserID == _userID)
                    .Select(
                        e =>
                        new RecipeListItem
                        {
                            RecipeID = e.RecipeID,
                            Title = e.Title,
                            CreatedUTC = e.CreatedUTC
                        });
                return query.ToArray();
            }
        }

        public RecipeDetail GetRecipeByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recipes
                    .Single(e => e.RecipeID == id && e.UserID == _userID);
                return
                    new RecipeDetail
                    {
                        RecipeID = entity.RecipeID,
                        Title = entity.Title,
                        RecipeText = entity.RecipeText,
                        Ingredients = entity.Ingredients,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool UpdateRecipe(RecipeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recipes
                    .Single(e => e.RecipeID == model.RecipeID && e.UserID == _userID);

                entity.Title = model.Title;
                entity.RecipeText = model.RecipeText;
                entity.Ingredients = model.Ingredients;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipe(int recipeID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recipes
                    .Single(e => e.RecipeID == recipeID && e.UserID == _userID);

                ctx.Recipes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }
    }
}
