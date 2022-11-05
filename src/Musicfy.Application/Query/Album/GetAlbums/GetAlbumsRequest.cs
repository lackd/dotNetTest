using MediatR;

namespace Musicfy.Application.Query.Album.GetAlbums
{
    /// <summary>
    /// Get album List request
    /// </summary>
    public class GetAlbumsRequest : IRequest<IEnumerable<Domain.Entity.Album>>
    { 
    }
}
