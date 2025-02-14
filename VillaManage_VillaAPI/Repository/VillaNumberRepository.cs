using VillaManage_VillaAPI.Data;
using VillaManage_VillaAPI.Model;
using VillaManage_VillaAPI.Repository.IRepository;

namespace VillaManage_VillaAPI.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _context;
        public VillaNumberRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<VillaNumber> UpdateAsync(VillaNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _context.villaNumbers.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
