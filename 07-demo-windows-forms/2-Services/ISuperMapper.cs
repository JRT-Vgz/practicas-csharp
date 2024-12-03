
namespace _2_Services
{
    public interface ISuperMapper<TInput1, TInput2, TOutput>
    {
        public TOutput Map(TInput1 input1, TInput2 input2);
    }
}
