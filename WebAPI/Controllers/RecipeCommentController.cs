using Microsoft.Ajax.Utilities;
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
    public class RecipeCommentController : ApiController
    {
        private RecipeCommentsService CreateRecipeCommentService()
        {
            //var userID = Guid.Parse(User.Identity.GetUserId());
            //var UserID = int.Parse(User.Identity.GetUserId());
            var UserID = User.Identity.GetUserId();
                
            var recipeCommentService = new RecipeCommentsService(UserID);
            return recipeCommentService;
        }

        public IHttpActionResult Get()
        {
            RecipeCommentsService recipeCommentService = CreateRecipeCommentService();
            var recipeComments = recipeCommentService.GetComments();
            return Ok(recipeComments);
        }

        public IHttpActionResult Post(RecipeCommentsCreate recipeComment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRecipeCommentService();

            if (!service.CreateComment(recipeComment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            RecipeCommentsService recipeCommentService = CreateRecipeCommentService();
            var recipeComment = recipeCommentService.GetCommentByID(id);
            return Ok(recipeComment);
        }
        public IHttpActionResult Put(RecipeCommentsEdit recipeComment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRecipeCommentService();

            if (!service.UpdateComment(recipeComment))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateRecipeCommentService();

            if (!service.DeleteComment(id))
                return InternalServerError();

            return Ok();
        }
    }
}
