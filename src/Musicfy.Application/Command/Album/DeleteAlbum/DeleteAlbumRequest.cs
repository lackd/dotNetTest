using MediatR;

namespace Musicfy.Application.Command.Album.DeleteAlbum
{
    /// <summary>
    /// Object request for Get Album
    /// </summary>
    public class DeleteAlbumRequest : IRequest<DeleteAlbumResponse>
    {
        /// <summary>
        /// Album id
        /// </summary>
        public int Id { get; set; }

        ///<summary>
        ///Album Name
        /// </summary>
        public string? Name { get; set; }

        ///<summary>
        ///Artist name
        /// </summary>
        public string? ArtistName { get; set; }

        ///<summary>
        ///Date of release
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
