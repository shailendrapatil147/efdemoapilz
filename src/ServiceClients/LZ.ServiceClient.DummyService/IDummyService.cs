using System.Threading.Tasks;

namespace LZ.ServiceClient.DummyService
{
    public interface IDummyService
    {
        Task<bool> GetResponse();
    }
}
