using MediatR;

namespace Musicfy.Application.Command.Album.PostAlbum
{
    /// <summary>
    /// Object request for Get Album
    /// </summary>
    public class PostAlbumRequest : IRequest<PostAlbumResponse>
    {
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
