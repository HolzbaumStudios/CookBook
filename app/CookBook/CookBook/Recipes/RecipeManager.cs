using CookBook.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CookBook.resources;
using System.Data;

namespace CookBook.recipes
{
    class RecipeManager
    {
        private readonly int MAX_CHAR_NAMES = 45;
        private readonly int MAX_CHAR_RECIPE_DESC = 500;

        /// <summary>
        /// Creates a new Recipe entry in the database.
        /// </summary>
        /// <param name="recipe">The recipe to store, containing all necessary values</param>
        private void CreateRecipeEntry(Recipe recipe)
        {
            using (SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);

                // Create and prepare an SQL statement.
                command.CommandText = SqlResources.RECIPES_INSERT;
                //@name, @desc, @creator, @imageId
                SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar, MAX_CHAR_NAMES);
                SqlParameter descParam = new SqlParameter("@desc", SqlDbType.VarChar, MAX_CHAR_RECIPE_DESC);
                SqlParameter creatorParam = new SqlParameter("@creator", SqlDbType.VarChar, MAX_CHAR_NAMES);
                SqlParameter imageParam = new SqlParameter("imageId", SqlDbType.Int);
                command.Parameters.Add(nameParam);
                command.Parameters.Add(descParam);
                command.Parameters.Add(creatorParam);
                command.Parameters.Add(imageParam);

                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();

                // Change parameter values and call ExecuteNonQuery.
                command.Parameters[0].Value = recipe.Name;
                command.Parameters[1].Value = recipe.Description;
                command.Parameters[2].Value = recipe.Creator;
                command.Parameters[3].Value = 1; //TODO: Change value
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Creates a new database entry for a single recipe step.
        /// </summary>
        /// <param name="step">The step to store, containing all necessary values</param>
        private void CreateStepEntry(Step step)
        {

        }

        /// <summary>
        /// Updates an existing recipe entry in the database.
        /// </summary>
        /// <param name="recipe">The updated recipe</param>
        private void UpdateRecipeEntry(Recipe recipe)
        {

        }

        /// <summary>
        /// Update an existing recipe step in the database.
        /// </summary>
        /// <param name="step">The updated step.</param>
        private void UpdateStepEntry(Step step)
        {
        
        }
    }
}
