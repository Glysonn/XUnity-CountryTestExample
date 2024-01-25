namespace CRUDTests
{
    public class MyMathTest
    {
        [Fact]
        public void Add_ThreeAndTwo_ShouldReturnFive()
        {
            // Arrange
            var myMath = new MyMath();

            var firstNumber = 2;
            var secondNumber = 3;
            var expectedResult = 5;

            // Act
            var actualResult = myMath.Add(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}