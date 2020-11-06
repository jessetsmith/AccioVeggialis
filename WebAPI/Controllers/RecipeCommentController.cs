using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [Authorize]
    public class RecipeCommentController : ApiController
    {
        private RecipeCommentService CreateRecipeCommentService()
        {
            //var userID = Guid.Parse(User.Identity.GetUserId());
            //var UserID = int.Parse(User.Identity.GetUserId());
            var UserID = User.Identity.GetUserId();
            var recipeCommentService = new RecipeCommentService(UserID);
            return recipeCommentService;
        }

        public IHttpActionResult Get()
        {
            CreateRecipeCommentService recipeCommentService = CreateRecipeCommentService();
            var recipeComments = recipeCommentService.GetRecipeComments();
            return Ok(recipeComments);
        }

        public IHttpActionResult Post(RecipeCommentService recipeComment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRecipeCommentService();

            if (!service.CreateRecipeCommentService(recipeComment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            RecipeCommentService recipeCommentService = CreateRecipeCommentService();
            var recipeComment = recipeCommentService.GetRecipeById(id);
            return Ok(recipeComment);
        }
        public IHttpActionResult Put(RecipeCommentEdit recipeComment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRecipeCommentService();

            if (!service.UpdateRecipeComment(recipeComment))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateRecipeCommentService();

            if (!service.DeleteRecipeComment(id))
                return InternalServerError();

            return Ok();
        }
    }
}
