using CookBook.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CookBook.resources;
using System.Data;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using CookBook.Recipes;

namespace CookBook.recipes
{
    public class RecipeManager
    {
        public static Recipe activeRecipeInstance;

        private readonly int MAX_CHAR_NAMES = 45;
        private readonly int MAX_CHAR_RECIPE_DESC = 500;
        private readonly int MAX_CHAR_STEP_DESC = 1000;
        private readonly int MAX_CHAR_PATH = 255;


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
                tagIds.Add(CreateTagEntry(tag));
            }

            //Save recipe (starting by the recipe image) and get recipe id
            if(recipe.ImageId == 0 && recipe.ImagePath != null)
            {
                recipe.ImageId = SaveImage(); //Might need to change logic
            }

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
                    UpdateStepEntry(step, 0); //Add imageId
                }
                else
                {
                    stepId = CreateStepEntry(step);
                }
                stepIds.Add(stepId);

                foreach (Ingredient ingredient in step.Ingredients)
                {
                    if (ingredient.UnitId == 0 || ingredient.Id == 0)
                    {
                        if (ingredient.UnitId == 0)
                        {
                            ingredient.UnitId = SelectQuantityUnitId(ingredient.Unit);
                        }
                        if (ingredient.Id == 0)
                        {
                            ingredient.Id = CreateIngredientsEntry(ingredient.Name);
                        }
                        CreateStepsIngredientsEntry(step.Id, ingredient);
                    }
                    else
                    {
                        //TODO: Finish implementation after assignment
                        int id = 1;
                        UpdateStepsIngredientsEntry(id, step.Id, ingredient);
                    }
                    
                }
            }

            
            if (newEntry) //TODO -> Check if value is already present (should only be the case, when steps are added afterwards)
            {
                //Save steps - recipe
                for (int i = 0; i < stepIds.Count; i++)
                {
                    CreateRecipeStepsEntry(recipeId, stepIds[i], i + 1);
                }
                //Save tag - recipe
                foreach (int tagId in tagIds)
                {
                    CreateRecipeTagEntry(recipeId, tagId);
                }
            }
        }

        /// <summary>
        /// Returns a list of recipes, where the name contains the searchstring
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public List<Recipe> GetListOfRecipesByName(String searchString)
        {
            return SelectRecipesByName(searchString);
        }

        /// <summary>
        /// Gets all necessary data for the recipe from the database.
        /// </summary>
        /// <param name="recipeId"></param>
        public Recipe SelectRecipe(int recipeId)
        {
            //Get Recipe from the database
            Recipe recipe = SelectRecipeById(recipeId);
            
            //Get all corresponding step ids
            List<int> stepIds = SelectStepIdsByRecipeId(recipeId);
            //Get all steps from the database
            foreach(int stepId in stepIds)
            {
                recipe.AddStep(SelectStepByStepId(stepId));      
            }
            //Fill all step values
            for (int i = 0; i < recipe.Steps.Count; i++) //Can't use foreach, because overwriting the iterator in the loop is not possible
            {
                recipe.Steps[i] = GetStepValues(recipe.Steps[i]);
            }

            //Get all tag ids
            List<int> tagIds = SelectTagIdsByRecipeId(recipeId);
            //Get all tags from the database
            foreach(int tagId in tagIds)
            {
                String tag = SelectTagByTagId(tagId);
                if(!String.IsNullOrEmpty(tag))
                {
                    recipe.AddTag(tag);
                }
            }
            

            return recipe;
        }

        /// <summary>
        /// Fill in all values for a step and return it to the recipe.
        /// </summary>
        private Step GetStepValues(Step step)
        {
            Step updatedStep = step;
            //Set up the ingredients
            var ingredients = SelecteIngredientIdsByStepId(step.Id);
            foreach(var ingredient in ingredients)
            {
                //Get the name for the ingredients
                ingredient.Name = SelectIngredientNameById(ingredient.Id);
                //Get the name of the quanity units
                ingredient.Unit = SelectQuanityUnitNameById(ingredient.UnitId);
                //add to the step
                updatedStep.AddIngredient(ingredient);
            }


            return updatedStep;
        }

        private int SaveImage()
        {
            string path = "";
            //string path = StoreImage();
            return CreateImageEntry(path);
        }

        private String GetImage(int imageId)
        {
            String imagePath = String.Empty;

            return imagePath;
        }

        //----DATABASE QUERIES BEGIN------------------

        #region Create Queries
        /// <summary>
        /// Creates a new Recipe entry in the database.
        /// </summary>
        /// <param name="recipe">The recipe to store, containing all necessary values</param>
        private int CreateRecipeEntry(Recipe recipe)
        {
            int returnId = 0;
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.RECIPES_INSERT_RETURN;
                    var nameParam = new MySqlParameter("@name", MySqlDbType.VarChar, MAX_CHAR_NAMES);
                    var descParam = new MySqlParameter("@desc", MySqlDbType.VarChar, MAX_CHAR_RECIPE_DESC);
                    var creatorParam = new MySqlParameter("@creator", MySqlDbType.VarChar, MAX_CHAR_NAMES);
                    var imageParam = new MySqlParameter("@imageId", MySqlDbType.Int32);
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
                    command.Parameters[3].Value = recipe.ImageId; //TODO: Change value
                    returnId = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
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
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.STEPS_INSERT_RETURN;
                    var descParam = new MySqlParameter("@desc", MySqlDbType.VarChar, MAX_CHAR_STEP_DESC);
                    var timerParam = new MySqlParameter("@timer", MySqlDbType.Int16);
                    var imageParam = new MySqlParameter("@imageId", MySqlDbType.Int32);
                    command.Parameters.Add(descParam);
                    command.Parameters.Add(timerParam);
                    command.Parameters.Add(imageParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteNonQuery.
                    command.Parameters[0].Value = step.Description;
                    command.Parameters[1].Value = step.Timer;
                    command.Parameters[2].Value = 1; //TODO: Change value
                    stepId = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
            return stepId;
        }

        /// <summary>
        /// Creates the recipe steps entry.
        /// </summary>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <param name="stepId">The step identifier.</param>
        private void CreateRecipeStepsEntry(int recipeId, int stepId, int order)
        {
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.RECIPESTEP_INSERT;
                    var recipeIdParam = new MySqlParameter("@recipeId", MySqlDbType.Int32);
                    var stepIdParam = new MySqlParameter("@stepId", MySqlDbType.Int32);
                    var orderParam = new MySqlParameter("@order", MySqlDbType.Int16);
                    command.Parameters.Add(recipeIdParam);
                    command.Parameters.Add(stepIdParam);
                    command.Parameters.Add(orderParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteNonQuery.
                    command.Parameters[0].Value = recipeId;
                    command.Parameters[1].Value = stepId;
                    command.Parameters[2].Value = order;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
        }

        /// <summary>
        /// Creates the tag entry.
        /// </summary>
        /// <param name="tag">The tag.</param>
        private int CreateTagEntry(String tag)
        {
            int tagId = 0;
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.TAGS_INSERT_RETURN;
                    var nameParam = new MySqlParameter("@name", MySqlDbType.VarChar, MAX_CHAR_NAMES);
                    command.Parameters.Add(nameParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteNonQuery.
                    command.Parameters[0].Value = tag;
                    tagId = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
            return tagId;
        }

        /// <summary>
        /// Creates the recipe tag entry.
        /// </summary>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <param name="tagId">The tag identifier.</param>
        private void CreateRecipeTagEntry(int recipeId, int tagId)
        {
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.RECIPETAG_INSERT;
                    var recipeIdParam = new MySqlParameter("@recipeId", MySqlDbType.Int32);
                    var tagIdParam = new MySqlParameter("@tagId", MySqlDbType.Int32);            
                    command.Parameters.Add(recipeIdParam);
                    command.Parameters.Add(tagIdParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteNonQuery.
                    command.Parameters[0].Value = recipeId;
                    command.Parameters[1].Value = tagId;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
        }

        /// <summary>
        /// Creates the image entry.
        /// </summary>
        /// <param name="imagePath">The image path.</param>
        /// <returns></returns>
        private int CreateImageEntry(String imagePath)
        {
            int imageId = 0;
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.IMAGES_INSERT_RETURN;
                    var pathParam = new MySqlParameter("@storagePath", MySqlDbType.VarChar, MAX_CHAR_PATH);
                    command.Parameters.Add(pathParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteNonQuery.
                    command.Parameters[0].Value = imagePath;
                    imageId = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
            return imageId;
        }

        /// <summary>
        /// Creates the ingredients entry.
        /// </summary>
        /// <param name="ingredient">The ingredient.</param>
        /// <returns></returns>
        private int CreateIngredientsEntry(String ingredient)
        {
            int ingredientId = 0;
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.INGREDIENT_INSERT_RETURN;
                    var nameParam = new MySqlParameter("@name", MySqlDbType.VarChar, MAX_CHAR_NAMES);
                    command.Parameters.Add(nameParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteNonQuery.
                    command.Parameters[0].Value = ingredient;
                    ingredientId = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
            return ingredientId;
        }

        /// <summary>
        /// Creates the steps ingredients entry.
        /// </summary>
        /// <param name="step_id">The step identifier.</param>
        /// <param name="ingredients_id">The ingredients identifier.</param>
        /// <param name="unit_id">The unit identifier.</param>
        private void CreateStepsIngredientsEntry(int stepId, Ingredient ingredient)
        {
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.STEPINGREDIENT_INSERT;
                    var stepIdParam = new MySqlParameter("@stepId", MySqlDbType.Int32);
                    var ingredientIdParam = new MySqlParameter("@ingredientId", MySqlDbType.Int32);
                    var unitIdParam = new MySqlParameter("@unitId", MySqlDbType.Int32);
                    var quantityParam = new MySqlParameter("@quantity", MySqlDbType.Int16);
                    command.Parameters.Add(stepIdParam);
                    command.Parameters.Add(ingredientIdParam);
                    command.Parameters.Add(unitIdParam);
                    command.Parameters.Add(quantityParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteNonQuery.
                    command.Parameters[0].Value = stepId;
                    command.Parameters[1].Value = ingredient.Id;
                    command.Parameters[2].Value = ingredient.UnitId;
                    command.Parameters[3].Value = ingredient.Quantity;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
        }
        #endregion

        #region Update Queries
        /// <summary>
        /// Updates an existing recipe entry in the database.
        /// </summary>
        /// <param name="recipe">The updated recipe</param>
        private void UpdateRecipeEntry(Recipe recipe)
        {
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.RECIPES_INSERT_RETURN;
                    var nameParam = new MySqlParameter("@name", MySqlDbType.VarChar, MAX_CHAR_NAMES);
                    var descParam = new MySqlParameter("@desc", MySqlDbType.VarChar, MAX_CHAR_RECIPE_DESC);
                    var creatorParam = new MySqlParameter("@creator", MySqlDbType.VarChar, MAX_CHAR_NAMES);
                    var imageParam = new MySqlParameter("@imageId", MySqlDbType.Int32);
                    var idParam = new MySqlParameter("@id", MySqlDbType.Int32);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(descParam);
                    command.Parameters.Add(creatorParam);
                    command.Parameters.Add(imageParam);
                    command.Parameters.Add(idParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteNonQuery.
                    command.Parameters[0].Value = recipe.Name;
                    command.Parameters[1].Value = recipe.Description;
                    command.Parameters[2].Value = recipe.Creator;
                    command.Parameters[3].Value = recipe.ImageId; //TODO: Change value
                    command.Parameters[4].Value = recipe.Id;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
        }

        /// <summary>
        /// Update an existing recipe step in the database.
        /// </summary>
        /// <param name="step">The updated step.</param>
        private void UpdateStepEntry(Step step, int imageId)
        {
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.STEPS_INSERT_RETURN;
                    var descParam = new MySqlParameter("@desc", MySqlDbType.VarChar, MAX_CHAR_STEP_DESC);
                    var timerParam = new MySqlParameter("@timer", MySqlDbType.Int16);
                    var imageParam = new MySqlParameter("@imageId", MySqlDbType.Int32);
                    var idParam = new MySqlParameter("@id", MySqlDbType.Int32);

                    command.Parameters.Add(descParam);
                    command.Parameters.Add(timerParam);
                    command.Parameters.Add(imageParam);
                    command.Parameters.Add(idParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteNonQuery.
                    command.Parameters[0].Value = step.Description;
                    command.Parameters[1].Value = step.Timer;
                    command.Parameters[2].Value = imageId; //TODO: Change value
                    command.Parameters[3].Value = step.Id;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
        }

        /// <summary>
        /// Updates the recipe steps entry.
        /// </summary>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <param name="stepId">The step identifier.</param>
        private void UpdateRecipeStepsEntry(int recipeStepId, int recipeId, int stepId, int order)
        {
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.RECIPESTEP_INSERT;
                    var recipeIdParam = new MySqlParameter("@recipeId", MySqlDbType.Int32);
                    var stepIdParam = new MySqlParameter("@stepId", MySqlDbType.Int32);
                    var orderParam = new MySqlParameter("@order", MySqlDbType.Int16);
                    var idParam = new MySqlParameter("@id", MySqlDbType.Int32);
                    command.Parameters.Add(recipeIdParam);
                    command.Parameters.Add(stepIdParam);
                    command.Parameters.Add(orderParam);
                    command.Parameters.Add(idParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteNonQuery.
                    command.Parameters[0].Value = recipeId;
                    command.Parameters[1].Value = stepId;
                    command.Parameters[2].Value = order;
                    command.Parameters[3].Value = recipeStepId;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
        }

        /// <summary>
        /// Updates the steps ingredients entry.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="stepId">The step identifier.</param>
        /// <param name="ingredientID">The ingredient identifier.</param>
        /// <param name="unitId">The unit identifier.</param>
        /// <param name="quantity">The quantity.</param>
        private void UpdateStepsIngredientsEntry(int id, int stepId, Ingredient ingredient)
        {
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.STEPINGREDIENT_INSERT;
                    var stepIdParam = new MySqlParameter("@stepId", MySqlDbType.Int32);
                    var ingredientIdParam = new MySqlParameter("@ingredientId", MySqlDbType.Int32);
                    var unitIdParam = new MySqlParameter("@unitId", MySqlDbType.Int32);
                    var quantityParam = new MySqlParameter("@quantity", MySqlDbType.Int16);
                    var idParam = new MySqlParameter("@id", MySqlDbType.Int32);
                    command.Parameters.Add(stepIdParam);
                    command.Parameters.Add(ingredientIdParam);
                    command.Parameters.Add(unitIdParam);
                    command.Parameters.Add(quantityParam);
                    command.Parameters.Add(idParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteNonQuery.
                    command.Parameters[0].Value = stepId;
                    command.Parameters[1].Value = ingredient.Id;
                    command.Parameters[2].Value = ingredient.UnitId;
                    command.Parameters[3].Value = ingredient.Quantity;
                    command.Parameters[4].Value = id;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
        }
        #endregion

        #region Select Queries
        /// <summary>
        /// Get a list of recipes based on the recipe name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private List<Recipe> SelectRecipesByName(String name)
        {
            List<Recipe> recipes = null;
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.RECIPES_SELECT_ALL_BYNAME;
                    var nameParam = new MySqlParameter("@name", MySqlDbType.VarChar, MAX_CHAR_NAMES);

                    command.Parameters.Add(nameParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteReader.
                    command.Parameters[0].Value = name;
                    MySqlDataReader reader = command.ExecuteReader();
                    int iterator = 0;
                    while (reader.Read() && reader[iterator] != DBNull.Value)
                    {
                        Recipe recipe = new Recipe();
                        recipe.Name = DBUtils.AsString(reader["recipes_name"]);
                        recipe.Description = DBUtils.AsString(reader["recipes_description"]);
                        recipe.Creator = DBUtils.AsString(reader["recipes_creator"]);
                        recipe.ImageId = DBUtils.AsInteger(reader["fk_image"]);
                        recipes.Add(recipe);
                        iterator++;
                    }
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
            return recipes;
        }

        /// <summary>
        /// Gets all values for a recipe based on the recipe id.
        /// </summary>
        /// <param name="id">The id of the recipe</param>
        /// <returns></returns>
        private Recipe SelectRecipeById(int id)
        {
            Recipe recipe = new Recipe();
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.RECIPES_SELECT_ALL_BYID;
                    var idParam = new MySqlParameter("@id", MySqlDbType.Int32);

                    command.Parameters.Add(idParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteReader.
                    command.Parameters[0].Value = id;
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() && reader[0] != DBNull.Value)
                    {
                        recipe.Id = id;
                        recipe.Name = DBUtils.AsString(reader["recipes_name"]);
                        recipe.Description = DBUtils.AsString(reader["recipes_description"]);
                        recipe.Creator = DBUtils.AsString(reader["recipes_creator"]);
                        recipe.ImageId = DBUtils.AsInteger(reader["fk_image"]);
                    }
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
            return recipe;
        }

        /// <summary>
        /// Get all step ids from the database belonging to the corresponding recipe id.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        private List<int> SelectStepIdsByRecipeId(int recipeId)
        {
            var ids = new List<int>();
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.RECIPESTEP_SELECT_ALL_BYRECID;
                    var idParam = new MySqlParameter("@recipeId", MySqlDbType.Int32);

                    command.Parameters.Add(idParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteReader.
                    command.Parameters[0].Value = recipeId;
                    MySqlDataReader reader = command.ExecuteReader();
                    int iterator = 0;
                    while (reader.Read() && reader[iterator] != DBNull.Value)
                    {
                        int stepId = DBUtils.AsInteger(reader["fk_steps"]);
                        if (stepId != 0)
                        {
                            ids.Add(stepId);
                        }
                        iterator++;
                    }
                    
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
            return ids;
        }

        /// <summary>
        /// Get step based on step id
        /// </summary>
        /// <param name="stepId"></param>
        /// <returns></returns>
        private Step SelectStepByStepId(int stepId)
        {
            var step = new Step();
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.STEPS_SELECT_ALL_BYID;
                    var idParam = new MySqlParameter("@id", MySqlDbType.Int32);

                    command.Parameters.Add(idParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteReader.
                    command.Parameters[0].Value = stepId;
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() && reader[0] != DBNull.Value)
                    {
                        step.Id = stepId;
                        step.Description = DBUtils.AsString(reader["steps_description"]);
                        step.SetTimer(DBUtils.AsInteger(reader["steps_timer"]), TimeUnits.Seconds);
                        step.ImageId = DBUtils.AsInteger(reader["fk_image"]);
                    }
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
            return step;
        }

        /// <summary>
        /// Get all tag ids from the dataaase belonging to the corresponding recipe id.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        private List<int> SelectTagIdsByRecipeId(int recipeId)
        {
            var ids = new List<int>();
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.RECIPETAG_SELECT_ALL_BYRECID;
                    var idParam = new MySqlParameter("@recipeId", MySqlDbType.Int32);

                    command.Parameters.Add(idParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteReader.
                    command.Parameters[0].Value = recipeId;
                    MySqlDataReader reader = command.ExecuteReader();
                    int iterator = 0;
                    while (reader.Read() && reader[iterator] != DBNull.Value)
                    {
                        int tagId = DBUtils.AsInteger(reader["fk_tags"]);
                        if (tagId != 0)
                        {
                            ids.Add(tagId);
                        }
                        iterator++;
                    }

                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
            return ids;
        }

        /// <summary>
        /// Get tag based on tag id
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        private String SelectTagByTagId(int tagId)
        {
            String tag = String.Empty;
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.TAGS_SELECT_NAME_BYID;
                    var idParam = new MySqlParameter("@id", MySqlDbType.Int32);

                    command.Parameters.Add(idParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteReader.
                    command.Parameters[0].Value = tagId;
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() && reader[0] != DBNull.Value)
                    {
                        tag = DBUtils.AsString(reader["tags_name"]);
                    }
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
            return tag;
        }

        /// <summary>
        /// Selectes the ingredient id, unit id and quantity of the ingredient.
        /// </summary>
        /// <param name="stepId">The step identifier.</param>
        /// <returns></returns>
        private List<Ingredient> SelecteIngredientIdsByStepId(int stepId)
        {
            var ingredients = new List<Ingredient>();
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.STEPINGREDIENT_SELECT_ALL_BYSTEPID;
                    var idParam = new MySqlParameter("@stepId", MySqlDbType.Int32);

                    command.Parameters.Add(idParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteReader.
                    command.Parameters[0].Value = stepId;
                    MySqlDataReader reader = command.ExecuteReader();
                    int iterator = 0;
                    while (reader.Read() && reader[iterator] != DBNull.Value)
                    {
                        var ingredient = new Ingredient();
                        ingredient.Id = DBUtils.AsInteger(reader["fk_ingredients"]);
                        ingredient.UnitId = DBUtils.AsInteger(reader["fk_quantityunits"]);
                        ingredient.Quantity = DBUtils.AsInteger(reader["quantity"]);
                        ingredients.Add(ingredient);
                        iterator++;            
                    }
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
            return ingredients;
        }

        /// <summary>
        /// Get the ingredient name based on the ingredient id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private String SelectIngredientNameById(int id)
        {
            String name = String.Empty;
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.INGREDIENT_SELECT_NAME_BYID;
                    var idParam = new MySqlParameter("@id", MySqlDbType.Int32);

                    command.Parameters.Add(idParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteReader.
                    command.Parameters[0].Value = id;
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() && reader[0] != DBNull.Value)
                    {
                        name = DBUtils.AsString(reader["ingredients_name"]);
                    }
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
            return name;
        }

        /// <summary>
        /// Selects the quantity unit identifier.
        /// </summary>
        /// <param name="unitName">Name of the unit.</param>
        /// <returns></returns>
        private int SelectQuantityUnitId(string unitName)
        {
            int id = 0;
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.QUANTITYUNITS_SELECT_ID;
                    var descParam = new MySqlParameter("@name", MySqlDbType.VarChar, MAX_CHAR_NAMES);

                    command.Parameters.Add(descParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteReader.
                    command.Parameters[0].Value = unitName;
                    MySqlDataReader reader = command.ExecuteReader();
                    if(reader.Read() && reader[0] != DBNull.Value)
                    {
                        try
                        {
                            id = Int32.Parse(reader.GetString(0));
                        }
                        catch (FormatException ex)
                        {
                            //TODO: LOG ERROR
                        }
                    } 
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
            return id;
        }

        private String SelectQuanityUnitNameById(int id)
        {
            String name = String.Empty;
            using (MySqlConnection connection = new MySqlConnection(DBUtils.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(null, connection);

                    // Create and prepare an SQL statement.
                    command.CommandText = SqlResources.QUANTITYUNITS_SELECT_NAME;
                    var idParam = new MySqlParameter("@id", MySqlDbType.Int32);

                    command.Parameters.Add(idParam);

                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    // Change parameter values and call ExecuteReader.
                    command.Parameters[0].Value = id;
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() && reader[0] != DBNull.Value)
                    {
                        name = DBUtils.AsString(reader["quantityunits_name"]);
                    }
                }
                catch (Exception ex)
                {
                    //TODO: Log error
                    if (ex.GetType() == typeof(MySqlException))
                    {
                        Debug.Print("Coulnd't establish SQL Connection: " + ex);
                    }
                }
            }
            return name;
        }
        #endregion

    }
}
