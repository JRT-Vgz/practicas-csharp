
namespace Tools.Generator
{
    public enum TypeFormat
    {
        Json,
        Pipes
    }
    public enum TypeCharacter
    {
        Normal,
        Uppercase,
        Lowercase
    }

    public interface IBuilderGenerator
    {
        public void Reset();
        public void SetContent(List<string> content);
        public void SetPath(string path);
        public void SetFormat(TypeFormat format);
        public void SetCharacter(TypeCharacter character = TypeCharacter.Normal);
    }
}
