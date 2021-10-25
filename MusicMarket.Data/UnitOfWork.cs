using MusicMarket.Core;
using MusicMarket.Core.Repositories;
using MusicMarket.Data.Repositories;
using System.Threading.Tasks;

namespace MusicMarket.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicMarketDbContext _dbContext;
        private MusicRepository _musicRepository;
        private ArtistRepository _artistRepository;

        public UnitOfWork(MusicMarketDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IMusicRepository Musics => _musicRepository = _musicRepository ?? new MusicRepository(_dbContext);

        public IArtistRepository Artists => _artistRepository = _artistRepository ?? new ArtistRepository(_dbContext);
    
        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    
    
    }
}
