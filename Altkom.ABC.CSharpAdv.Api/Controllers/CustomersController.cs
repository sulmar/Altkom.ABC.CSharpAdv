using Altkom.ABC.CSharpAdv.ConsoleClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Altkom.ABC.CSharpAdv.Api.Controllers
{
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

        // [HttpGet]
        public IHttpActionResult Get()
        {

        }
    }
}