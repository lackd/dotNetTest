using AutoMapper;

namespace Musicfy.Application.Query.Album.GetAlbum
{
    /// <summary>
    /// Mapper profile class for Get Album
    /// </summary>
    public class GetAlbumMapper : Profile
    {
        /// <summary>
        /// constructor
        /// </summary>
        public GetAlbumMapper()
        {
            CreateMap<Domain.Entity.Album, GetAlbumResponse>();
        }
    }
}
