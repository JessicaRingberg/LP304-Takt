using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class ConfigRepository : IConfigRepository
    {

        private readonly DataContext _context;

        public ConfigRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Config config, int areaId)
        {
            var area = await _context.Areas.FindAsync(areaId);

            if (area != null)
            {
                config.AreaId = areaId;
                await _context.Configs.AddAsync(config);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEntity(int id)
        {
            var config = await _context.Configs
                .FirstOrDefaultAsync(c => c.Id == id);
            if (config is null)
            {
                return;
            }
            _context.Configs.Remove(config);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Config>> GetEntities()
        {
            return await _context.Configs
                .Include(c => c.Area)
                .ToListAsync();
        }

        public async Task<Config?> GetEntity(int id)
        {
            return await _context.Configs
                .Include(c => c.Area)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateEntity(Config config, int configId)
        {
            var configToUpdate = await _context.Configs
                .FindAsync(configId);
            if (configToUpdate is null)
            {
                return;
            }

            MapConfig(configToUpdate, config);

            await _context.SaveChangesAsync();
        }

        private static Config MapConfig(Config newConfig, Config oldConfig)
        {
            newConfig.MacBidisp = oldConfig.MacBidisp;
            return newConfig;
        }
    }
}
