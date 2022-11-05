
using Musicfy.Domain.Entity;

namespace Musicfy.Domain.Repository
{
    /// <summary>
    /// User repository
    /// </summary>
    public interface IAlbumRepository
    {
        /// <summary>
        /// Return an Album List
        /// </summary>
        /// <returns>Albums</returns>
        Task<IEnumerable<Album>?> GetAll(CancellationToken cancellationToken);

        /// <summary>
        /// Return an Album by id
        /// </summary>
        /// <param name="id">Id of the Album</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Album</returns>
        Task<Album?> GetByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Post an Album
        /// </summary>
        /// <param name="album">Album object to be saved</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Album Id</returns>
        Task<Album?> PostAsync(Album album, CancellationToken cancellationToken);

        /// <summary>
        /// Delete an Album
        /// </summary>
        /// <param name="album">Album object to be Deleted</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>album Id</returns>
        Task<Album?> DeleteAsync(Album album, CancellationToken cancellationToken);
    }
}
