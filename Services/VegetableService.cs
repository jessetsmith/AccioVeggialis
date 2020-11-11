using AccioVegialis.Data;
using AccioVegialis.Data.Models;
using AccioVegialis.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class VegetableService
    {
        //private readonly int _veggieID;

        public VegetableService()
        {
            //_veggieID = veggieID;
        }

        public bool CreateVegetable(VegetableCreate model)
        {
            var entity =
                new Vegetables()
                {
                    Title = model.Title,
                    Description = model.Description,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Vegetables.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VegetableListItem> GetVegetables()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Vegetables
                    //.Where(e => e.VegetableID == _veggieID)
                    .Select(
                        e =>
                        new VegetableListItem
                        {
                            VegetableID = e.VegetableID,
                            Title = e.Title                        
                        });
                return query.ToArray();
            }
        }

        public VegetableDetail GetVeggiesByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Vegetables
                    .Single(e => e.VegetableID == id);
                return
                    new VegetableDetail
                    {
                        VegetableID = entity.VegetableID,
                        Title = entity.Title,
                        Description = entity.Description,
                        //RelatedRecipes = entity.RelatedRecipes,
                        CreatedUTC = entity.CreatedUTC
                    };
            }
        }

        public bool UpdateVeggie(VegetableEdit model, int veggieID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Vegetables
                    .Single(e => e.VegetableID == veggieID);

                entity.Title = model.Title;
                entity.Description = model.Description;
                //entity.RelatedRecipes = model.RelatedRecipes;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteVegetable(int veggieID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Vegetables
                    .Single(e => e.VegetableID == veggieID);

                ctx.Vegetables.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }

    }

}
