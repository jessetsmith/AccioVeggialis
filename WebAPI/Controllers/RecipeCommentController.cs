using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            var userID = User.Identity.GetUserId();

            var recipeCommentService = new RecipeCommentsService(userID);
            return recipeCommentService;
        }

        public IHttpActionResult Get()
        {
            RecipeCommentsService recipeCommentService = CreateRecipeCommentService();
            var recipeComments = recipeCommentService.GetComments();
            return Ok(recipeComments);
        }

        public IHttpActionResult Post(RecipeCommentsCreate recipeComment, int recipeID)
        {
            var userID = User.Identity.GetUserId();

            RecipeService recipeService = new RecipeService(userID);
            int id = recipeService.GetRecipeByID(recipeID).RecipeID;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var recipeID = recipeCommentService.GetCommentByID(id).Author;
            var service = CreateRecipeCommentService();

            if (!service.CreateComment(recipeComment, id))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            RecipeCommentsService recipeCommentService = CreateRecipeCommentService();
            var recipeComment = recipeCommentService.GetCommentByID(id);
            return Ok(recipeComment);
        }
        public IHttpActionResult Put(RecipeCommentsEdit recipeComment, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRecipeCommentService();

            if (!service.UpdateComment(recipeComment, id))
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
