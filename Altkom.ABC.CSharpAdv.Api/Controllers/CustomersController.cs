using Altkom.ABC.CSharpAdv.ConsoleClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;

namespace Altkom.ABC.CSharpAdv.Api.Controllers
{
    [RoutePrefix("api/customers")]
 //   [Authorize]
    public class CustomersController : ApiController
    {
        private readonly ICustomersService customersService;

        public CustomersController()
            : this(new FakeCustomersService())
        {

        }

        public CustomersController(ICustomersService customersService)
        {
            this.customersService = customersService;

           
        }


        [HttpHead]
        [Route("{id}")]
        [AllowAnonymous]
        public IHttpActionResult Head(int id)
        {
            var customer = customersService.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok();

        }

        // [HttpGet]
        public IHttpActionResult Get()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return BadRequest();
            }

            var customers = customersService.Get();

            return Ok(customers);
        }

        [Route("{id}")]        
        public IHttpActionResult Get(int id)
        {
            var customer = customersService.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        public IHttpActionResult Post(Customer customer)
        {
            customersService.Add(customer);

            return CreatedAtRoute("DefaultApi", new { Id = customer.Id }, customer);
        }

        [Route("{id}")]
        public IHttpActionResult Put(int id, Customer customer)
        {
            if (customer.Id != id)
            {
                return BadRequest();
            }

            customersService.Update(customer);

            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            customersService.Remove(id);

            return Ok();
        }


        [Route("{id}/orders/{orderId}")]
        public IHttpActionResult GetOrdersByCustomer(int id, int orderId)
        {
            return Ok();
        }
    }
}