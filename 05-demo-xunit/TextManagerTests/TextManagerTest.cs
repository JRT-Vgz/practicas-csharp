using System.Text.RegularExpressions;
using TextManagement;

namespace TextManagerTests
{
    public class TextManagerTest
    {
        [Fact]
        public void CountWords()
        {
            var textmanager = new TextManager("Texto Prueba");   

            var result = textmanager.CountWords();

            Assert.True(result > 1);
            Assert.Equal(2, result);
        }

        [Fact]
        public void CountWords_NotZero()
        {
            var textmanager = new TextManager("Texto Prueba");

            var result = textmanager.CountWords();

            Assert.NotEqual(0, result);
        }

        [Fact]
        public void FindWord()
        {
            var textmanager = new TextManager("hola hola desde xunit");

            var result = textmanager.FindWord("hola", true);

            Assert.NotEmpty(result);
            Assert.Contains(0, result);
            Assert.Contains(5, result);
        }

        [Fact]
        public void FindWord_Empty()
        {
            var textmanager = new TextManager("hola hola desde xunit");

            var result = textmanager.FindWord("mundo", true);

            Assert.Empty(result);
        }

        [Fact]
        public void FindExactWord()
        {
            var textmanager = new TextManager("hola hola desde xunit");

            var result = textmanager.FindExactWord("mundo", true);

            Assert.IsType<List<Match>>(result);
        }

        [Fact]
        public void FindExactWord_Exception()
        {
            var textmanager = new TextManager("hola hola desde xunit");

            Assert.ThrowsAny<Exception>(() => textmanager.FindExactWord(null, true));
        }

    }
}