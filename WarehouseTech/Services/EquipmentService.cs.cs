using Microsoft.EntityFrameworkCore;
using WarehouseTech.Data;
using WarehouseTech.Models;

namespace WarehouseTech.Services
{
    public class EquipmentService
    {
        private readonly IDbContextFactory<AppDbContext> _factory;

        public EquipmentService(IDbContextFactory<AppDbContext> factory) => _factory = factory;

        public async Task<List<Equipment>> GetAllAsync()
        {
            await using var db = await _factory.CreateDbContextAsync();
            return await db.Equipments
                .Include(e => e.EquipmentType)
                .Include(e => e.Manufacturer)
                .Include(e => e.Country)
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync();
        }

        public async Task<Equipment> AddAsync(Equipment e)
        {
            await using var db = await _factory.CreateDbContextAsync();
            e.CreatedAt = e.UpdatedAt = DateTime.UtcNow;
            db.Equipments.Add(e);
            await db.SaveChangesAsync();
            return e;
        }

        public async Task UpdateAsync(Equipment e)
        {
            await using var db = await _factory.CreateDbContextAsync();
            e.UpdatedAt = DateTime.UtcNow;
            db.Equipments.Update(e);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await using var db = await _factory.CreateDbContextAsync();
            var e = await db.Equipments.FindAsync(id);
            if (e != null)
            {
                db.Equipments.Remove(e);
                await db.SaveChangesAsync();
            }
        }
    }
}
