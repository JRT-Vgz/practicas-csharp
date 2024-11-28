
namespace _2_Services
{
    public interface IMapper<TInput, TOutput>
    {
        TOutput Map(TInput input);
    }
}
