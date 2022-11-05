using MediatR;

namespace Musicfy.Application.Query.Album.GetAlbum
{
    /// <summary>
    /// Object request for Get Album
    /// </summary>
    public class GetAlbumRequest : IRequest<GetAlbumResponse>
    {
        /// <summary>
        /// Album Id
        /// </summary>
        public int Id { get; set; }
    }
}
