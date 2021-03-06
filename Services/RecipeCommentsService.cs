﻿using AccioVegialis.Data;
using AccioVegialis.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RecipeCommentsService
    {

        private readonly string _userID;
        private ApplicationUser _user;

        public RecipeCommentsService(string userID)
        {
            _userID = userID;
        }

        //private ApplicationUser GetUser(string idValue)
        //{
        //    var ctx = new ApplicationDbContext();
        //    var userID = idValue;
        //    var user = ctx.Users.Find(userID);
        //    return _user = user;
        //}


        public bool CreateComment(RecipeCommentsCreate model, int recipeID)
        {
            var ctx = new ApplicationDbContext();
            var user = ctx.Users.Find(_userID);
            _user = user;

            var entity =
                new RecipeComments()
                {
                    UserID = _userID,
                    Author = _user,
                    RecipeID = recipeID,
                    CommentText = model.CommentText,
                    CreatedUTC = DateTimeOffset.Now
                };

            //var recipeService = new RecipeService(_userID);
            //recipeService.GetRecipeByID(recipeID).Comments.Add(entity);

            using (ctx)
            {
                ctx.RecipeComments.Add(entity);
                
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeCommentsListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .RecipeComments
                    //.Where(e => e.UserID == _userID)
                    .Select(
                        e =>
                        new RecipeCommentsListItem
                        {
                            CommentID = e.CommentID,
                            Author = e.Author,
                            CreatedUTC = e.CreatedUTC
                        });
                return query.ToArray();
            }
        }

        public RecipeComments GetCommentsByRecipeID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                     ctx
                     .RecipeComments
                     .Single(e => e.RecipeID == id);

                return entity;
            }
        }

        public ICollection<RecipeCommentsDetail> GetCommentDetailsByRecipeID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .RecipeComments
                   .Where(e => e.RecipeID == id)
                   .Select(
                        e =>
                        new RecipeCommentsDetail
                        {
                            CommentID = e.CommentID,
                            Author = e.Author.UserName,
                            CommentText = e.CommentText,
                            CreatedUTC = e.CreatedUTC,
                            ModifiedUTC = e.ModifiedUTC
                        });
                return query.ToArray();

            }
        }

        public RecipeCommentsDetail GetCommentByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RecipeComments
                    .Single(e => e.CommentID == id);
                return
                    new RecipeCommentsDetail
                    {
                        CommentID = entity.CommentID,
                        Author = entity.Author.UserName,
                        CommentText = entity.CommentText,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool UpdateComment(RecipeCommentsEdit model, int commentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RecipeComments
                    .Single(e => e.CommentID == commentID && e.UserID == _userID);

                entity.CommentText = model.CommentText;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int commentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RecipeComments
                    .Single(e => e.CommentID == commentID && e.UserID == _userID);

                ctx.RecipeComments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }
    }
}
