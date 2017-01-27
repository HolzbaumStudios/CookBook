using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CookBook.recipes;
using CookBook.Recipes;
using AdminConsole;

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
            var tagStringWithoutSpace = RemoveWhiteSpace(TextBox_Tags.Text);
            var tags = tagStringWithoutSpace.Split(';');
            foreach(String tag in tags)
            {
                recipe.AddTag(tag);
            }
            foreach(DataGridViewRow row in stepDataSet.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    String stepDescription = (String)row.Cells[0].Value;
                    String ingredientString = (String)row.Cells[1].Value;
                    int timer = Int32.Parse((String)row.Cells[2].Value);
                    String timeUnit = row.Cells[3].Value.ToString();

                    Step newStep = new Step();
                    newStep.Description = stepDescription;
                    newStep.SetTimer(timer, GetTimeUnit(timeUnit));
                    if (ingredientString != null)
                    {
                        ProcessIngredient(ref newStep, ingredientString);
                    }
                    recipe.AddStep(newStep);
                }
            }
            var rm = new RecipeManagerAdmin();
            rm.StoreRecipe(recipe);
            MessageBox.Show("Recipe saved!");
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
                if (splitIngredient != null && splitIngredient.Length == 3)
                {
                    newIngredient.Name = splitIngredient[0];
                    newIngredient.Quantity = float.Parse(RemoveWhiteSpace(splitIngredient[1]));
                    newIngredient.Unit = RemoveWhiteSpace(splitIngredient[2]);
                }
                step.AddIngredient(newIngredient);
            }
        }

        private String RemoveWhiteSpace(String text)
        {
            return Regex.Replace(text, @"\s+", "");
        }
    }
}
