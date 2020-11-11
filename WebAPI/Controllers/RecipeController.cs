using Microsoft.AspNet.Identity;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [Authorize]
    public class RecipeController : ApiController
    {
        private RecipeService CreateRecipeService()
        {
            var userId = User.Identity.GetUserId();
            var recipeService = new RecipeService(userId);
            return recipeService;
        }

        
        public IHttpActionResult Post(RecipeCreate recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRecipeService();

            if (!service.CreateRecipe(recipe))
                return InternalServerError();

            return Ok();
        }


        public IHttpActionResult Get(int id)
        {
            RecipeService RecipeService = CreateRecipeService();
            var recipes = RecipeService.GetRecipeByID(id);
            return Ok(recipes);
        }
        public IHttpActionResult Put(RecipeEdit recipe, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRecipeService();

            if (!service.UpdateRecipe(recipe, id))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateRecipeService();

            if (!service.DeleteRecipe(id))
                return InternalServerError();

            return Ok();
        }
    }
}
