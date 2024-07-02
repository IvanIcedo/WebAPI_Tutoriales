namespace API_Testing
{
    [TestClass]
    public class RandomNumber_Test
    {
        public static IEnumerable<object[]> GetTestData()
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string relativePath = Path.Combine(projectDirectory, "GetDayOfWeek_Data.txt");
            var lines = File.ReadAllLines(relativePath);
            foreach (var line in lines)
            {
                var values = line.Split(',');
                yield return new object[] { int.Parse(values[0]), values[1] };
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void GetDayOfWeekAccording_NumberDay_ReturnCorrectEquivalentDayStr(int numberDay, string expectedDayStr)
        {
            string dayGot = WebApi.Controllers.RandomNumberController.GetDayStrByNumber(numberDay);

            Assert.AreEqual(expectedDayStr, dayGot);
        }
    }
}