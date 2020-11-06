using AccioVegialis.Data;
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
    public class VegetableController : ApiController
    {
        private VegetableService CreateVegetableService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var vegetableService = new VegetableService(userId);
            return vegetableService;
        }
        public IHttpActionResult Get()
        {
            VegetableService vegetableService = CreateVegetableService();
            var vegetables = vegetableService.GetVegetables();
            return Ok(vegetables);
        }
        public IHttpActionResult Post(VegetableCreate vegetable)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVegetableService();

            if (!service.CreateVegetable(vegetable))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(VegetableEdit vegetable)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVegetableService();

            if (!service.UpdateVegetable(vegetable))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateVegetableService();

            if (!service.DeleteVegetable(id))
                return InternalServerError();

            return Ok();
        }
    }
}
