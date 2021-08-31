
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using petshop.Models;
using petshop.Services;

namespace petshop.Controllers
{
    // Attributes
    //  ApiController tells Dotnet register this class as a controller
    [ApiController]

    [Route("/api/[controller]")]
    public class CatsController : ControllerBase
    {

        private readonly CatsService catsService;

        // NOTE make sure you add the transient servicer in the Startup File so this constructer passes
        public CatsController(CatsService catsService)
        {
            this.catsService = catsService;
        }

    // GetAll throw GET request
    [HttpGet]
        // ActionResult is a http responce type with data in an array collection<CAT>
        // returns HTTPResult (ok, badRequest, forbidden) of type collection (aka IEnumerable) of type Cat
        public ActionResult <IEnumerable<Cat>> Get()
        {
            try
            {
                IEnumerable<Cat> cats = catsService.Get();
                return FakeDB.Cats;
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
            Cat found = catsService.Get(id);
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
    public ActionResult<Cat> Create([FromBody] Cat newCat)
    {
        try
        {

            return Ok(newCat);
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    [HttpPost("{id}")]
    public ActionResult<string> Delete(string id)
    {
        try
        {
            catsService.Delete(id);
            return Ok("Deleted Cat");
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    }
}