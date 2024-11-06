
using System.Collections;

namespace TextManagerTests
{
    public class TextManagerClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "", 0 };
            yield return new object[] { "Texto Prueba", 2 };
            yield return new object[] { "El otro dia en clase", 5 };
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
