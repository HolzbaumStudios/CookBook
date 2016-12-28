using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.resources
{
    static class SqlResources
    {
        public static readonly String RECIPES_INSERT_RETURN = "INSERT INTO RECIPES (recipes_name, recipes_description, creator, fk_image) "
                                                     + "VALUES (@name, @desc, @creator, @imageId) "
                                                     + "SELECT LAST_INSERT_ID()";
        public static readonly String RECIPES_UPDATE = "UPDATE RECIPES "
                                                     + "SET recipes_name=@name, recipes_description=@desc, creator=@creator, fk_image=@imageId) "
                                                     + "WHERE id_recipes=@id";
        public static readonly String IMAGES_INSERT_RETURN = "INSERT INTO IMAGES (storage_path) VALUES (@storagePath) "
                                                     + "SELECT LAST_INSERT_ID()";
        public static readonly String IMAGES_UPDATE = "UPDATE IMAGES SET storage_path=@storagePath WHERE id_images=@id";
    }
}
