using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.resources
{
    static class SqlResources
    {
        public static readonly String RECIPES_INSERT_RETURN = "INSERT INTO RECIPES (recipes_name, recipes_description, recipes_creator, fk_image) "
                                                     + "VALUES (@name, @desc, @creator, @imageId); "
                                                     + "SELECT LAST_INSERT_ID()";
        public static readonly String RECIPES_UPDATE = "UPDATE RECIPES "
                                                     + "SET recipes_name=@name, recipes_description=@desc, creator=@creator, fk_image=@imageId "
                                                     + "WHERE id_recipes=@id";
        public static readonly String RECIPESTEP_INSERT = "INSERT INTO RECIPES_STEPS (fk_recipes, fk_steps, step_order) "
                                                     + "VALUES (@recipeId, @stepId, @order)";
        public static readonly String RECIPESTEP_UPDATE = "UPDATE RECIPES_STEPS "
                                                     + "SET fk_recipes=@recipeId, fk_steps=@stepId, step_order=@order "
                                                     + "WHERE id_recipes_stesp=@id";
        public static readonly String RECIPETAG_INSERT = "INSERT INTO RECIPES_TAGS (fk_recipes, fk_tags) "
                                                     + "VALUES (@recipeId, @tagId)";
        public static readonly String RECIPETAG_UPDATE = "UPDATE RECIPES_TAGS "
                                                     + "SET fk_recipes=@recipeId, fk_tags=@tagId "
                                                     + "WHERE id_recipes_tags=@id";
        public static readonly String IMAGES_INSERT_RETURN = "INSERT INTO IMAGES (storage_path) "
                                                     + "VALUES (@storagePath) "
                                                     + "SELECT LAST_INSERT_ID()";
        public static readonly String IMAGES_UPDATE = "UPDATE IMAGES "
                                                     + "SET storage_path=@storagePath " 
                                                     + "WHERE id_images=@id";
        public static readonly String STEPS_INSERT_RETURN = "INSERT INTO STEPS (steps_description, steps_timer, fk_image) "
                                                     + "VALUES (@steps_description, @steps_timer, @fk_image) "
                                                     + "SELECT LAST_INSERT_ID()";
        public static readonly String STEPS_UPDATE = "UPDATE STEPS "
                                                     + "SET steps_description=@desc, steps_timer=@timer, fk_image=@imageId "
                                                     + "WHERE id_steps=@id";
        public static readonly String STEPINGREDIENT_INSERT = "INSERT INTO STEPS_INGREDIENTS (fk_steps, fk_ingredients, fk_quantityunits, quantity "
                                                     + "VALUES (@stepId, @ingredientId, @unitId, @quantity)";
        public static readonly String STEPINGREDIENT_UPDATE = "UPDATE STEPS_INGREDIENTS "
                                                     + "SET fk_steps=@stepId, fk_ingredients=@ingredientId, fk_quantityunits=@unitId, quantity=@quantity "
                                                     + "WHERE id_steps_ingredients=@id";
        public static readonly String TAGS_INSERT_RETURN = "INSERT INTO TAGS (tags_name) "
                                                     + "VALUES (@name) "
                                                     + "SELECT LAST_INSERT_ID()";
        public static readonly String TAGS_UPDATE = "UPDATE TAGS " 
                                                     + "SET tags_name=@name "
                                                     + "WHERE id_tags=@id";
        public static readonly String INGREDIENT_INSERT_RETURN = "INSERT INTO INGREDIENTS (ingredients_name, fk_image) "
                                                     + "VALUES (@name, @imageId) "
                                                     + "SELECT LAST_INSERT_ID()";
        public static readonly String INGREDIENT_UPDATE = "UPDATE INGREDIENTS "
                                                     + "SET ingredients_name=@name, fk_image=@image "
                                                     + "WHERE id_ingredients=@id";
        public static readonly String QUANTITYUNITS_INSERT_RETURN = "INSERT INTO QUANITYUNITS (quantityunits_name) "
                                                     + "VALUES (quantityunits_name=@name) "
                                                     + "SELECT LAST_INSERT_ID()";
        public static readonly String QUANTITYUNITS_UPDATE = "UPDATE QUANTITYUNITS "
                                                     + "SET quantityunits_name=@name "
                                                     + "WHERE id_quantityunits=@id";



    }
}
