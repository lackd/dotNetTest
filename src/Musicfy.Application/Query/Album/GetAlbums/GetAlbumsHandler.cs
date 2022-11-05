using AutoMapper;
using Musicfy.Domain.Repository;
using MediatR;

namespace Musicfy.Application.Query.Album.GetAlbums
{
    /// <summary>
    /// Get Albums Handler
    /// </summary>
    public class GetAlbumsHandler : IRequestHandler<GetAlbumsRequest, IEnumerable<Domain.Entity.Album>> 
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="albumRepository">Album repository instance</param>
        /// <param name="mapper">Automapper instance</param>
        public GetAlbumsHandler(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handle method
        /// </summary>
        /// <param name="request">object request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Album List</returns>
        public async Task<IEnumerable<Domain.Entity.Album>> Handle(GetAlbumsRequest request, CancellationToken cancellationToken)
        {
             IEnumerable<Domain.Entity.Album> albums =await _albumRepository.GetAll(cancellationToken);
            return albums;
        }
    }
}
