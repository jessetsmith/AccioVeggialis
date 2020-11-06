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
    public class RecipeCommentsService
    {

        private readonly string _userID;

        public RecipeCommentsService(string userID)
        {
            _userID = userID;
        }

        public bool CreateComment(RecipeCommentsCreate model)
        {
            var entity =
                new RecipeComments()
                {
                    UserID = _userID,
                    CommentText = model.CommentText,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
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
                    .Where(e => e.UserID == _userID)
                    .Select(
                        e =>
                        new RecipeCommentsListItem
                        {
                            CommentID = e.CommentID,
                            CommentText = e.CommentText,
                            CreatedUtc = e.CreatedUTC
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
                    .Single(e => e.CommentID == id && e.UserID == _userID);
                return
                    new RecipeCommentsDetail
                    {
                        CommentID = entity.CommentID,
                        CommentText = entity.CommentText,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool UpdateComment(RecipeCommentsEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RecipeComments
                    .Single(e => e.RecipeID == model.CommentID && e.UserID == _userID);

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
