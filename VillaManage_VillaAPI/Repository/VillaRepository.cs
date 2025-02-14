﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VillaManage_VillaAPI.Data;
using VillaManage_VillaAPI.Model;
using VillaManage_VillaAPI.Repository.IRepository;

namespace VillaManage_VillaAPI.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _context;
        public VillaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _context.Villas.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
