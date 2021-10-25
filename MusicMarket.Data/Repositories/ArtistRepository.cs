
using Microsoft.EntityFrameworkCore;
using MusicMarket.Core.Models;
using MusicMarket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(MusicMarketDbContext context)
            : base(context)
        { }
        private MusicMarketDbContext _dbContext
        {
            get { return Context as MusicMarketDbContext; }
        }

        public async Task<IEnumerable<Artist>> GetAllWithMusicsAsync()
        {
            return await _dbContext.Artists
                .Include(a => a.Musics)
                .ToListAsync();
        }

        public Task<Artist> GetWithMusicsByIdAsync(int id)
        {
            return _dbContext.Artists
                .Include(a => a.Musics)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

       
    }
}