using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using recipes.Models;
using Recipes.Services;

namespace burgers.Controllers
{
    [ApiController]
    [Route("api/{controller}")]

    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _bs;
        public RecipesController(RecipesService bs)
        {
            _bs = bs;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RecipesController>> Get()
        {
            try
            {
                return Ok(_bs.GetRecipes());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> GetRecipeById(int id)
        {
            try
            {
                Recipe Recipe = _bs.GetRecipeById(id);
                return Ok(Recipe);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Recipe> Create([FromBody] Recipe newRecipe)
        {
            try
            {
                Recipe Recipe = _bs.Create(newRecipe);
                return Ok(Recipe);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Recipe> Edit([FromBody] Recipe updated, int id)
        {
            try
            {
                updated.Id = id;
                Recipe Recipe = _bs.Edit(updated);
                return Ok(Recipe);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpDelete("{RecipeId}")]
        public ActionResult<string> Purchased(int RecipeId)
        {
            try
            {
                _bs.Delete(RecipeId);
                return Ok("Deleted");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }

}