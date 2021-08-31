// using Microsoft.AspNetCore.MVC

namespace petshop.Controllers
{
    // Attributes
    //  ApiController tells Dotnet register this class as a controller
    [ApiController]

    [Route("/api/[controller]")]
    public class CatsController : ControllerBase
    {
        // GetAll throw GET request
        [HttpGet]
        // ActionResult is a http responce type with data in an array collection<CAT>
        // returns HTTPResult (ok, badRequest, forbidden) of type collection (aka IEnumerable) of type Cat
        public ActionResult <IEnumerable<Cat>> Get()
        {
            try
            {
                return fakeDB.Cats;
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
                throw;
            }
        }

    // NOTE these two id terms are tied together:
    // Example if it was a number you would say int id instead
    [HttpGet("{id}")]
    // req.params.id : value caputured in parameters
    public ActionResult<CatsController> Get(string id)
    {
        try
        {
            CatsController found = fakeDB.Cats.Find(c => c.Id == id);
            if(found == null) {
                throw new System.Exception("Invalid Id");
            }
            return Ok(found);
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    [HttpPost]
    // req.body : [fromBody]
    // C# will take the body and try to convert it into the type provided
    public ActionResult<Cat> Create([FromBody] CatsController newCat)
    {
        try
        {
            fakeDB.Cats.Add(newCat);
            return Ok(newCat);
        }
        catch (System.Exception)
        {
            return BadRequest(err.Mesage);
        }
    }

    [HttpPost("{id}")]
    public ActionResult<String> Delete(string id)
    {
        try
        {
            int deleted = fakeDB.Cats.RemoveAll(c => c.Id == id);
            if(deleted == 0){
                throw new System.Exception("Invalid Id");
            }
            return Ok("Successfully Deleted Cat");
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    }
}