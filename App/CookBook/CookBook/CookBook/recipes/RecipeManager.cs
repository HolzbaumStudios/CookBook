using CookBook.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace CookBook.recipes
{
    class RecipeManager
    {
        /// <summary>
        /// Creates a new Recipe entry in the database.
        /// </summary>
        /// <param name="recipe">The recipe to store, containing all necessary values</param>
        private void CreateRecipeEntry(Recipe recipe)
        {
            using (SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString()))
            {

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
