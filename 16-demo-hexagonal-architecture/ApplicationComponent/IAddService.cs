
namespace ApplicationComponent
{
    public interface IAddService<TDTO, TModel>
    {
        Task AddAsync(TDTO dto);
    }
}
