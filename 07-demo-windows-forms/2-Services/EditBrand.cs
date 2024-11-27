
using _1_Entities;

namespace _2_Services
{
    public class EditBrand
    {
        private readonly IRepository<Brand> _repository;
        public EditBrand(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Brand brand)
        {
            if (string.IsNullOrEmpty(brand.Name))
            {
                throw new Exception("El nombre de la marca es obligatorio.");
            }
            Console.WriteLine(brand.Id);
            if (await _repository.GetByIdAsync(brand.Id) == null) 
            {
                throw new Exception("La marca no existe.");
            }

            await _repository.EditAsync(brand);
        }
    }
}
