using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICartaoVirtualRepository
    {
        void AdicionarCartaoVirtual(CartaoVirtual cartaoVirtual);
        IEnumerable<CartaoVirtual> ListarCartaoVirtual(string email);
    }
}