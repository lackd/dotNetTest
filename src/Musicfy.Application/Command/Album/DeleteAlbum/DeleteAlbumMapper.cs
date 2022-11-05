using AutoMapper;

namespace Musicfy.Application.Command.Album.DeleteAlbum
{
    /// <summary>
    /// Mapper profile class for Post Album
    /// </summary>
    public class PostAlbumMapper : Profile
    {
        /// <summary>
        /// constructor
        /// </summary>
        public PostAlbumMapper()
        {
            CreateMap<DeleteAlbumRequest, Domain.Entity.Album>();
            CreateMap<Domain.Entity.Album, DeleteAlbumResponse>();
        }
    }
}
