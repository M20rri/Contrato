using Contrato.Models;
using System.Threading.Tasks;

namespace Contrato.Service
{
    public interface IPayMob
    {
        Task<GenerateTokenVM> GenerateToken();
        Task<OrderRegistryResVM> ProductRegistration(OrderRegistryReqVM model);
        Task<PaymentKeyResVM> PaymentKey(PaymentKeyReqVM model);
    }
}
