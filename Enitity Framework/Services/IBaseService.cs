namespace Enitity_Framework.Services
{
    public interface IBaseService<T, K> where T : class where K : class
    {
        T Create(K createModel);
    }
}