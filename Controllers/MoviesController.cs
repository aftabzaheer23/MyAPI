using Microsoft.AspNetCore.Mvc;
using MyAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // GET: api/<MoviesController>
        //static List<Movie> movies = new List<Movie>();
        static List<Movie> movies()
        {
            return new List<Movie>
            {
                new() {Id=10, Name="Iron Man 1", MainLead="Robert Downey Jr."},
                new() {Id=11, Name="Thor: God of Thunder", MainLead="Chris Hemsworth"},
                new() {Id=12, Name="Captain America: The First Avenger", MainLead="Chris Evans"},
                new() {Id=13, Name="The Incredible Hulk", MainLead="Mark Ruffalo"},
                new() {Id=14, Name="Iron Man 2", MainLead="Robert Downey Jr."}
            };
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return movies();
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return movies().FirstOrDefault(m => m.Id == id);
        }

        // POST api/<MoviesController>
        [HttpPost]
        public void Post([FromBody] Movie value)
        {
            movies().Add(value);
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Movie value)
        {
            int loc = movies().FindIndex(m => m.Id == id);

            if (loc >= 0) { 
                movies().Insert(loc, value);
            }
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            movies().RemoveAll(m => m.Id == id);

        }
    }
}
