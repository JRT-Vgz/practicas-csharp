
namespace DesignPattern._3_DependencyInjection
{
    public class Beer
    {
        private string _name;
        private string _brand;
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public Beer(string name, string brand)
        {
            _name = name;
            _brand = brand;
        }  
    }
}
