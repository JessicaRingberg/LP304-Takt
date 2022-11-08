using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Shared;
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

        public async Task<ServiceResponse<Config>> Add(Config config, int areaId)
        {
            var area = await _context.Areas.FindAsync(areaId);
            var found = await _context.Configs.FirstOrDefaultAsync(c => c.AreaId.Equals(areaId));
            if (area is null)
            {
                return new ServiceResponse<Config>()
                {
                    Success = false,
                    Message = $"Config must belong to an area"
                };
            }
            if (found is not null)
            {
                return new ServiceResponse<Config>()
                {
                    Success = false,
                    Message = $"Area {area.Name} already has a config!"
                };
            }

            config.AreaId = areaId;
            await _context.Configs.AddAsync(config);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Config>()
            {
                Data = config,
                Success = true,
                Message = $"Config added!"
            };

        }

        public async Task<ServiceResponse<int>> DeleteEntity(int configId)
        {
            var config = await _context.Configs
                .FirstOrDefaultAsync(c => c.Id == configId);
            if (config is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Config with id {configId} was not found"
                };
            }
            _context.Configs.Remove(config);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Config with id {configId} deleted"
            };
        }

        public async Task<ICollection<Config>> GetEntities()
        {
            return await _context.Configs
                .Include(c => c.Area)
                .ToListAsync();
        }

        public async Task<Config?> GetEntity(int configId)
        {
            return await _context.Configs
                .Include(c => c.Area)
                .FirstOrDefaultAsync(c => c.Id == configId);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(Config config, int configId)
        {
            var configToUpdate = await _context.Configs
                .FindAsync(configId);
            if (configToUpdate is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Config with id {configId} was not found"
                };
            }

            configToUpdate.MacBidisp = config.MacBidisp;
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Config with id {configId} updated"
            };
        }
    }
}
