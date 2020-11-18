using AccioVegialis.Data;
using AccioVegialis.Models;
using Microsoft.AspNet.Identity;
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
    public class VegetableController : ApiController
    {
        private VegetableService CreateVegetableService()
        {
           
            var vegetableService = new VegetableService();
            return vegetableService;
        }
        public IHttpActionResult Get()
        {
            VegetableService vegetableService = CreateVegetableService();
            var vegetables = vegetableService.GetVegetables();
            return Ok(vegetables);
        }

        public IHttpActionResult Get(int id)
        {
            VegetableService vegetableService = CreateVegetableService();
            var vegetables = vegetableService.GetVeggiesByID(id);
            return Ok(vegetables);
        }

        public IHttpActionResult Post(VegetableCreate vegetable)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVegetableService();

            if (!service.CreateVegetable(vegetable))
                return InternalServerError();

            return Ok(vegetable);
        }

        public IHttpActionResult Put(VegetableEdit vegetable, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVegetableService();

            if (!service.UpdateVeggie(vegetable, id))
                return InternalServerError();

            return Ok(vegetable);
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateVegetableService();

            if (!service.DeleteVegetable(id))
                return InternalServerError();

            return Ok(id);
        }
    }
}
