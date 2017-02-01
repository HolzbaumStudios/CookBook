using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.resources
{
    public static class SqlResources
    {
        #region Recipes
        public static readonly String RECIPES_INSERT_RETURN = "INSERT INTO RECIPES (recipes_name, recipes_description, recipes_creator, fk_image) "
                                                     + "VALUES (@name, @desc, @creator, @imageId); "
                                                     + "SELECT LAST_INSERT_ID()";
        public static readonly String RECIPES_UPDATE = "UPDATE RECIPES "
                                                     + "SET recipes_name=@name, recipes_description=@desc, creator=@creator, fk_image=@imageId "
                                                     + "WHERE id_recipes=@id";
        public static readonly String RECIPES_SELECT_ALL_BYNAME = "SELECT * FROM RECIPES "
                                                     + "WHERE recipes_name LIKE %@name%";
        public static readonly String RECIPES_SELECT_ALL_BYID = "SELECT * FROM RECIPES "
                                                     + "WHERE id_recipes=@id";
        public static readonly String RECIPES_SELECT_ALL = "SELECT * FROM RECIPES";
        #endregion
        #region Recipes_Steps
        public static readonly String RECIPESTEP_INSERT = "INSERT INTO RECIPES_STEPS (fk_recipes, fk_steps, step_order) "
                                                     + "VALUES (@recipeId, @stepId, @order)";
        public static readonly String RECIPESTEP_UPDATE = "UPDATE RECIPES_STEPS "
                                                     + "SET fk_recipes=@recipeId, fk_steps=@stepId, step_order=@order "
                                                     + "WHERE id_recipes_stesp=@id";
        public static readonly String RECIPESTEP_SELECT_ALL_BYRECID = "SELECT * FROM RECIPES_STEPS "
                                                     + "WHERE fk_recipes=@recipeId "
                                                     + "ORDER BY step_order ASC";
        #endregion
        #region Recipes_Tags
        public static readonly String RECIPETAG_INSERT = "INSERT INTO RECIPES_TAGS (fk_recipes, fk_tags) "
                                                     + "VALUES (@recipeId, @tagId)";
        public static readonly String RECIPETAG_UPDATE = "UPDATE RECIPES_TAGS "
                                                     + "SET fk_recipes=@recipeId, fk_tags=@tagId "
                                                     + "WHERE id_recipes_tags=@id";
        public static readonly String RECIPETAG_SELECT_ALL_BYRECID = "SELECT * FROM RECIPES_TAGS "
                                                     + "WHERE fk_recipes=@recipeId";
        #endregion
        #region Images
        public static readonly String IMAGES_INSERT_RETURN = "INSERT INTO IMAGES (storage_path) "
                                                     + "VALUES (@storagePath); "
                                                     + "SELECT LAST_INSERT_ID()";
        public static readonly String IMAGES_UPDATE = "UPDATE IMAGES "
                                                     + "SET storage_path=@storagePath " 
                                                     + "WHERE id_images=@id";
        public static readonly String IMAGES_SELECT_PATH_BYID = "SELECT storage_path FROM IMAGES "
                                                     + "WHERE id_images=@id";
        #endregion
        #region Steps
        public static readonly String STEPS_INSERT_RETURN = "INSERT INTO STEPS (steps_description, steps_timer, fk_image) "
                                                     + "VALUES (@desc, @timer, @imageId); "
                                                     + "SELECT LAST_INSERT_ID()";
        public static readonly String STEPS_UPDATE = "UPDATE STEPS "
                                                     + "SET steps_description=@desc, steps_timer=@timer, fk_image=@imageId "
                                                     + "WHERE id_steps=@id";
        public static readonly String STEPS_SELECT_ALL_BYID = "SELECT * FROM STEPS "
                                                     + "WHERE id_steps=@id";
        #endregion
        #region Steps_Ingredients
        public static readonly String STEPINGREDIENT_INSERT = "INSERT INTO STEPS_INGREDIENTS (fk_steps, fk_ingredients, fk_quantityunits, quantity) "
                                                     + "VALUES (@stepId, @ingredientId, @unitId, @quantity)";
        public static readonly String STEPINGREDIENT_UPDATE = "UPDATE STEPS_INGREDIENTS "
                                                     + "SET fk_steps=@stepId, fk_ingredients=@ingredientId, fk_quantityunits=@unitId, quantity=@quantity "
                                                     + "WHERE id_steps_ingredients=@id";
        public static readonly String STEPINGREDIENT_SELECT_ALL_BYSTEPID = "SELECT * FROM STEPS_INGREDIENTS "
                                                     + "WHERE fk_steps=@stepId";
        #endregion
        #region Tags
        public static readonly String TAGS_INSERT_RETURN = "INSERT INTO TAGS (tags_name) "
                                                     + "VALUES (@name); "
                                                     + "SELECT LAST_INSERT_ID()";
        public static readonly String TAGS_UPDATE = "UPDATE TAGS " 
                                                     + "SET tags_name=@name "
                                                     + "WHERE id_tags=@id";
        public static readonly String TAGS_SELECT_NAME_BYID = "SELECT tags_name FROM TAGS "
                                                     + "WHERE id_tags=@id";
        #endregion
        #region Ingredients
        public static readonly String INGREDIENT_INSERT_RETURN = "INSERT INTO INGREDIENTS (ingredients_name) "
                                                     + "VALUES (@name); "
                                                     + "SELECT LAST_INSERT_ID()";
        public static readonly String INGREDIENT_UPDATE = "UPDATE INGREDIENTS "
                                                     + "SET ingredients_name=@name "
                                                     + "WHERE id_ingredients=@id";
        public static readonly String INGREDIENT_SELECT_ID_BYNAME = "SELECT id_ingredients FROM INGREDIENTS "
                                                     + "WHERE ingredients_name=@name";
        public static readonly String INGREDIENT_SELECT_NAME_BYID = "SELECT ingredients_name FROM INGREDIENTS "
                                                     + "WHERE id_ingredients=@id";
        #endregion
        #region Quantityunits
        public static readonly String QUANTITYUNITS_INSERT_RETURN = "INSERT INTO QUANITYUNITS (quantityunits_name) "
                                                     + "VALUES (quantityunits_name=@name); "
                                                     + "SELECT LAST_INSERT_ID()";
        public static readonly String QUANTITYUNITS_UPDATE = "UPDATE QUANTITYUNITS "
                                                     + "SET quantityunits_name=@name "
                                                     + "WHERE id_quantityunits=@id";
        public static readonly String QUANTITYUNITS_SELECT_ID = "SELECT id_quantityunits FROM QUANTITYUNITS "
                                                     + "WHERE quantityunits_name=@name";
        public static readonly String QUANTITYUNITS_SELECT_NAME = "SELECT quantityunits_name FROM QUANTITYUNITS "
                                                     + "WHERE id_quantityunits=@id";
        #endregion


    }
}
