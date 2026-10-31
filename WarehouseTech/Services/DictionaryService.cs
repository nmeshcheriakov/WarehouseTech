using Microsoft.EntityFrameworkCore;
using WarehouseTech.Data;
using WarehouseTech.Models;


namespace WarehouseTech.Services;

public class DictionaryService
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public DictionaryService(IDbContextFactory<AppDbContext> factory) => _factory = factory;

    public async Task<List<EquipmentType>> GetTypesAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.EquipmentTypes.OrderBy(x => x.Name).ToListAsync();
    }

    public async Task AddTypeAsync(EquipmentType item)
    {
        await using var db = await _factory.CreateDbContextAsync();
        item.Description ??= string.Empty;
        item.CreatedAt = item.UpdatedAt = DateTime.UtcNow;
        db.EquipmentTypes.Add(item);
        await db.SaveChangesAsync();
    }

    public async Task UpdateTypeAsync(EquipmentType item)
    {
        await using var db = await _factory.CreateDbContextAsync();
        item.Description ??= string.Empty;
        item.UpdatedAt = DateTime.UtcNow;
        db.EquipmentTypes.Update(item);
        await db.SaveChangesAsync();
    }

    public async Task DeleteTypeAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var e = await db.EquipmentTypes.FindAsync(id);
        if (e != null) { db.EquipmentTypes.Remove(e); await db.SaveChangesAsync(); }
    }

    public async Task<List<Manufacturer>> GetManufacturersAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Manufacturers.OrderBy(x => x.Name).ToListAsync();
    }

    public async Task AddManufacturerAsync(Manufacturer item)
    {
        await using var db = await _factory.CreateDbContextAsync();
        item.Description ??= string.Empty;
        item.CreatedAt = item.UpdatedAt = DateTime.UtcNow;
        db.Manufacturers.Add(item);
        await db.SaveChangesAsync();
    }

    public async Task UpdateManufacturerAsync(Manufacturer item)
    {
        await using var db = await _factory.CreateDbContextAsync();
        item.Description ??= string.Empty;
        item.UpdatedAt = DateTime.UtcNow;
        db.Manufacturers.Update(item);
        await db.SaveChangesAsync();
    }

    public async Task DeleteManufacturerAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var e = await db.Manufacturers.FindAsync(id);
        if (e != null) { db.Manufacturers.Remove(e); await db.SaveChangesAsync(); }
    }

    public async Task<List<Country>> GetCountriesAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Countries.OrderBy(x => x.Name).ToListAsync();
    }

    public async Task<Country> GetOrCreateCountryAsync(string name)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var existing = await db.Countries.FirstOrDefaultAsync(c => c.Name == name);
        if (existing != null) return existing;
        var c = new Country { Name = name };
        db.Countries.Add(c);
        await db.SaveChangesAsync();
        return c;
    }
}