using Microsoft.VisualStudio.TestTools.UnitTesting;
using CookBook.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Recipes.Tests
{
    [TestClass()]
    public class ListIngredientTests
    {
        [TestMethod()]
        public void GetAmountBasedOnPortionsTest()
        {
            ListIngredient ingredient = new ListIngredient("Name", 5, "l");
            ingredient.AddAmount(5);
            Assert.AreEqual(10, ingredient.ingredientAmount);
        }
    }
}