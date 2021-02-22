using System;
using System.Collections.Generic;
using recipes.Models;
using Recipes.Repositories;

namespace Recipes.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;
        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Recipe> GetRecipes()
        {
            return _repo.GetAll();
        }
        internal Recipe GetRecipeById(int id)
        {
            Recipe Recipe = _repo.GetById(id);
            if (Recipe == null)
            {
                throw new Exception("Invalid id");
            }
            return Recipe;
        }

        internal Recipe Create(Recipe newRecipe)
        {
            return _repo.Create(newRecipe);
        }

        internal Recipe Edit(Recipe updated)
        {
            Recipe original = GetRecipeById(updated.Id);

            original.title = updated.title != null ? updated.title : original.title;
            original.description = updated.description != null ? updated.description : original.description;


            return _repo.Edit(original);
        }
        internal Recipe Delete(int id)
        {
            Recipe Recipe = GetRecipeById(id);
            _repo.Delete(Recipe);
            return Recipe;
        }
    }

}