
using System.Text.Json;

namespace Tools.Generator
{
    public class Generator
    {
        public List<string> Content { get; set; }
        public string Path { get; set; }
        public TypeFormat Format { get; set; }
        public TypeCharacter Character { get; set; }

        public void Save()
        {
            string result = "";
            result = Format == TypeFormat.Json ? GetJson() : GetPipe();

            if (Character == TypeCharacter.Uppercase) { result = result.ToUpper(); }
            else if (Character == TypeCharacter.Lowercase) { result = result.ToLower(); }

            File.WriteAllText(Path, result);
        }

        private string GetJson() => JsonSerializer.Serialize(Content);
        private string GetPipe() => Content.Aggregate((accum, current) => accum + "|" + current);
    }
}
