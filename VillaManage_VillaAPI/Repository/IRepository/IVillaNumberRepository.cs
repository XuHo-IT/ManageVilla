using System.Linq.Expressions;
using VillaManage_VillaAPI.Model;

namespace VillaManage_VillaAPI.Repository.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber entity);
    }
}
