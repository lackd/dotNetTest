using Microsoft.EntityFrameworkCore;
using Musicfy.Domain.Entity;
using Musicfy.Domain.Repository;
using Musicfy.Persistance.Data;

namespace Musicfy.Persistance.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicfyContext _context;

        public AlbumRepository(MusicfyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Album>> GetAll(CancellationToken cancellationToken)
        {
            IQueryable<Album> albums = from album in _context.Albums where !album.IsDeleted select album;
            return await albums.ToArrayAsync(cancellationToken);
        }

        public async Task<Album?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            IQueryable<Album?> albums = from album in _context.Albums
                                     where album.Id.Equals(id)
                                     select album;
            return await albums.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Album?> PostAsync(Album album, CancellationToken cancellationToken)
        {
            await _context.Albums.AddAsync(album, cancellationToken);
            _context.SaveChanges();
            return album;
        }

        public Task<Album?> DeleteAsync(Album album, CancellationToken cancellationToken)
        {
            album.IsDeleted = true;
            _context.Albums.Update(album);
            _context.SaveChanges();
            return Task.FromResult(album);
        }
    }
}
