using AutoMapper;

namespace Musicfy.Application.Command.Album.PostAlbum
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
            CreateMap<PostAlbumRequest, Domain.Entity.Album>();
            CreateMap<Domain.Entity.Album, PostAlbumResponse>();
        }
    }
}
