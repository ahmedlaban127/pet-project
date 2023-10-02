using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperHeroes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuperheroController : ControllerBase
    {
        private static List<Superhero> heroes = new List<Superhero>
            {
                new Superhero {Id = 1, Name = "jay", Age = 12, Location = "Philly"},
                new Superhero {Id = 3, Name = "brad", Age = 22, Location = "NYC"}
            };
        [HttpGet]
        public async Task<ActionResult<List<Superhero>>> Get()
        {
            return Ok(heroes);
        }
        [HttpPost("/addHero")]
        public async Task<ActionResult<List<Superhero>>> AddNewHero(Superhero superhero)
        {
            heroes.Add(superhero);
            return Ok(heroes);
        }
        [HttpGet("/{id}")]
        public async Task<ActionResult<List<Superhero>>> GetById(int id)
        {
            var hero = heroes.Find(hero => hero.Id == id);
            if (hero == null)
            {
                return BadRequest("No hero by this id");
            }
            return Ok(hero);
        }
        [HttpPut]
        public async Task<ActionResult<List<Superhero>>> UpdateHero(Superhero request)
        {
            var hero = heroes.Find(hero => hero.Id == request.Id);
            if (hero == null)
            {
                return BadRequest("No hero by this id");
            }
            hero.Name = request.Name;
            return Ok(heroes);
        }
        [HttpDelete("/{id}")]
        public async Task<ActionResult<List<Superhero>>> DeleteHero(int id)
        {
            var hero = heroes.Find(hero => hero.Id == id);
            if (hero == null)
            {
                return BadRequest("No hero by this id");
            }
            heroes.Remove(hero);
            return Ok(heroes);
        }
    }
}

