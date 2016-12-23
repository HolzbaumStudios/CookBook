using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.resources
{
    static class SqlResources
    {
        public static readonly String RECIPES_INSERT = "INSERT INTO RECIPES (recipes_name, recipes_description, creator, fk_image) "
                                                     + "VALUES (@name, @desc, @creator, @imageId)";
        public static readonly String RECIPES_UPDATE = "UPDATE RECIPES "
                                                     + "SET recipes_name=@name, recipes_description=@desc, creator=@creator, fk_image=@imageId) "
                                                     + "WHERE id_recipes=@id";
    }
}
