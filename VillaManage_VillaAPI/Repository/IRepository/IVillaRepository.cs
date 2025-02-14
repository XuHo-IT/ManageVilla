using System.Linq.Expressions;
using VillaManage_VillaAPI.Model;

namespace VillaManage_VillaAPI.Repository.IRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entity);

    }
}
