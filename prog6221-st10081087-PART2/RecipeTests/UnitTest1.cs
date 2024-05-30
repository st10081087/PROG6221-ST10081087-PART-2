namespace prog6221_st10081087_st10081087.Tests
{
    [TestFixture]
    public class RecipeTests
    {
        [Test]
        public void TestCalculateTotalCalories()
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient("Sugar", 1, "tablespoon", 48, "Sweeteners"),
                new Ingredient("Butter", 2, "tablespoon", 102, "Dairy")
            };

            var steps = new List<Step>
            {
                new Step("Mix sugar with butter")
            };

            var recipe = new Recipe("Test Recipe", ingredients, steps);
            double totalCalories = recipe.CalculateTotalCalories();

            Assert.AreEqual(252, totalCalories); // 48 + (102 * 2)
        }
    }
}
