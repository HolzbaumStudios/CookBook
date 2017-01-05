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
        public static Recipe activeRecipeInstance;

        private readonly int MAX_CHAR_NAMES = 45;
        private readonly int MAX_CHAR_RECIPE_DESC = 500;

        /// <summary>
        /// Store all recipe information in the database.
        /// </summary>
        /// <param name="recipe">The recipe.</param>
        public void StoreRecipe(Recipe recipe)
        {
            bool newEntry = recipe.Id == 0;

            //Save tags and get tag ids
            var tagIds = new List<int>();
            foreach(String tag in recipe.Tags)
            {
                int tagId = CreateTagEntry(tag);
            }

            //Save recipe and get recipe id
            int recipeId;
            if (!newEntry)
            {
                recipeId = recipe.Id;
                UpdateRecipeEntry(recipe);
            }
            else
            {
                recipeId = CreateRecipeEntry(recipe);
            }
            //Save steps and get ids
            var stepIds = new List<int>();
            foreach(Step step in recipe.Steps)
            {
                int stepId;
                if(step.Id != 0)
                {
                    stepId = step.Id;
                    UpdateStepEntry(step);
                }
                else
                {
                    stepId = CreateStepEntry(step);
                }
                stepIds.Add(stepId);
            }

            //Save steps - recipe
            if (newEntry) //TODO -> Check if value is already present (should only be the case, when steps are added afterwards)
            {
                foreach (int stepId in stepIds)
                {
                    CreateRecipeStepsEntry(recipeId, stepId);
                }
                
            }

            //Save tag - recipe

        }

        /// <summary>
        /// Creates a new Recipe entry in the database.
        /// </summary>
        /// <param name="recipe">The recipe to store, containing all necessary values</param>
        private int CreateRecipeEntry(Recipe recipe)
        {
            int returnId = 0;
            using (SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);
                
                               // Create and prepare an SQL statement.
                command.CommandText = SqlResources.RECIPES_INSERT_RETURN;
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
                returnId = Convert.ToInt32(command.ExecuteScalar());
            }

            return returnId;
        }

        /// <summary>
        /// Creates a new database entry for a single recipe step.
        /// </summary>
        /// <param name="step">The step to store, containing all necessary values</param>
        private int CreateStepEntry(Step step)
        {
            int stepId = 0;

            return stepId;
        }

        /// <summary>
        /// Creates the recipe steps entry.
        /// </summary>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <param name="stepId">The step identifier.</param>
        private void CreateRecipeStepsEntry(int recipeId, int stepId)
        {

        }

        /// <summary>
        /// Creates the tag entry.
        /// </summary>
        /// <param name="tag">The tag.</param>
        private int CreateTagEntry(String tag)
        {
            int tagId = 0;

            return tagId;
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

        /// <summary>
        /// Updates the recipe steps entry.
        /// </summary>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <param name="stepId">The step identifier.</param>
        private void UpdateRecipeStepsEntry(int recipeId, int stepId)
        {

        }
    }
}
