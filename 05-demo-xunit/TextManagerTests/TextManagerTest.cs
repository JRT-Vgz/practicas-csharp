using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text.RegularExpressions;
using TextManagement;

namespace TextManagerTests
{
    public class TextManagerTest
    {
        TextManager textManagerGlobal;
        ILogger<TextManager> loggerTest;

        public TextManagerTest()
        {
            var mock = new Mock<ILogger<TextManager>>();
            loggerTest = mock.Object;
            textManagerGlobal = new TextManager("hola hola desde xunit", loggerTest);
        }


        [Theory]
        [InlineData("Texto Prueba",2)]
        [InlineData("",0)]
        [InlineData("El otro dia en clase",5)]
        public void CountWords_InlineData(string text, int expected)
        {
            var textmanager = new TextManager(text, loggerTest);   

            var result = textmanager.CountWords();

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(TextManagerClassData))]
        public void CountWords_ClassData(string text, int expected)
        {
            var textmanager = new TextManager(text, loggerTest);

            var result = textmanager.CountWords();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountWords_NotZero()
        {
            var textmanager = new TextManager("Texto Prueba", loggerTest);

            var result = textmanager.CountWords();

            Assert.NotEqual(0, result);
        }

        [Fact]
        public void CountWords_NotZero_Moq()
        {
            var mockTextManager = new Mock<TextManager>("Texto Prueba", loggerTest);
            mockTextManager.Setup(p => p.CountWords()).Returns(2);

            var result = mockTextManager.Object.CountWords();

            Assert.NotEqual(0, result);
        }


        [Fact]
        public void FindWord()
        {
            var result = textManagerGlobal.FindWord("hola", true);

            Assert.NotEmpty(result);
            Assert.Contains(0, result);
            Assert.Contains(5, result);
        }

        [Fact]
        public void FindWord_Empty()
        {
            var result = textManagerGlobal.FindWord("mundo", true);

            Assert.Empty(result);
        }

        [Fact]
        public void FindExactWord()
        {
            var result = textManagerGlobal.FindExactWord("mundo", true);

            Assert.IsType<List<System.Text.RegularExpressions.Match>>(result);
        }

        [Fact]
        public void FindExactWord_Exception()
        {
            Assert.ThrowsAny<Exception>(() => textManagerGlobal.FindExactWord(null, true));
        }

    }
}