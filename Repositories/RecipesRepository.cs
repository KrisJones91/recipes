using System.Collections.Generic;
using System.Data;
using Dapper;
using recipes.Models;

namespace Recipes.Repositories
{
    public class RecipesRepository
    {
        public readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Recipe> GetAll()
        {
            string sql = "SELECT * FROM Recipes;";
            return _db.Query<Recipe>(sql);
        }

        internal Recipe GetById(int id)
        {
            string sql = "SELECT * FROM Recipes WHERE id = @id;";
            return _db.QueryFirstOrDefault<Recipe>(sql, new { id });
        }

        internal Recipe Create(Recipe newRecipe)
        {
            string sql = @"
                INSERT INTO Recipes
                (title, description)
                VALUES
                (@Title, @Description);
                SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newRecipe);
            newRecipe.Id = id;
            return newRecipe;
        }

        internal Recipe Edit(Recipe original)
        {
            string sql = @"
                UPDATE Recipes
                SET
                    title = @Title
                    description = @Description,
                WHERE id = @Id;
                SELECT * FROM Recipes WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Recipe>(sql, original);
        }

        internal void Delete(Recipe Recipe)
        {
            string sql = "DELETE FROM Recipes WHERE id = @Id";
            _db.Execute(sql, Recipe);
        }


    }
}