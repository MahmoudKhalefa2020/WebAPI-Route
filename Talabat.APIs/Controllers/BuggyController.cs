using Microsoft.AspNetCore.Mvc;
using Talabat.Repository.Data;

namespace Talabat.APIs.Controllers
{

    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _dbContext;

        public BuggyController(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var Product = _dbContext.Products.Find(100);
            if (Product is null) return NotFound();
            return Ok(Product);


        }


        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var product = _dbContext.Products.Find(100);
            var productToReturn = product.ToString();

            return Ok(productToReturn);
        }


        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}
