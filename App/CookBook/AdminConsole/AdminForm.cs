using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CookBook.recipes;
using CookBook.Recipes;

namespace AdminConsole
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            var recipe = new Recipe();
            recipe.Name = TextBox_RecipeName.Text;
            recipe.Creator = TextBox_Creator.Text;
            recipe.Description = TextBox_Description.Text;
            var stepDataSet = DataGrid_Steps;
            foreach(DataRow row in stepDataSet.Rows)
            {
                String stepDescription = (String)row.ItemArray.GetValue(0);
                String ingredientString = (String)row.ItemArray.GetValue(1);
                int timer = Int32.Parse((String)row.ItemArray.GetValue(2));
                String timeUnit = row.ItemArray.GetValue(3).ToString();

                Step newStep = new Step();
                newStep.Description = stepDescription;
                newStep.SetTimer(timer, GetTimeUnit(timeUnit));
                ProcessIngredient(ref newStep, ingredientString);
                recipe.AddStep(newStep);
            }
            var rm = new RecipeManager();
            rm.StoreRecipe(recipe);
        }

        private TimeUnits GetTimeUnit(String timeUnitString)
        {
            TimeUnits selectedTimeUnit;
            switch(timeUnitString.ToLower())
            {
                case "seconds": selectedTimeUnit = TimeUnits.Seconds;
                    break;
                case "minutes": selectedTimeUnit = TimeUnits.Minutes;
                    break;
                case "hours": selectedTimeUnit = TimeUnits.Hours;
                    break;
                default: throw new Exception();
            }
            return selectedTimeUnit;
        }

        private void ProcessIngredient(ref Step step, String ingredientString)
        {
            String[] ingredients = ingredientString.Split(';');
            foreach (String ingredient in ingredients)
            {
                var newIngredient = new Ingredient();
                String[] splitIngredient = ingredient.Split(',');
                if (splitIngredient != null && splitIngredient.Length == 2)
                {
                    newIngredient.Name = splitIngredient[0];
                    newIngredient.Unit = splitIngredient[1];
                }
                step.AddIngredient(newIngredient);
            }
        }
    }
}
