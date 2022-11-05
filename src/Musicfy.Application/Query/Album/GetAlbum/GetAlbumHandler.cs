using AutoMapper;
using Musicfy.Domain.Repository;
using MediatR;

namespace Musicfy.Application.Query.Album.GetAlbum
{
    /// <summary>
    /// Get Album Handler
    /// </summary>
    public class GetAlbumHandler : IRequestHandler<GetAlbumRequest, GetAlbumResponse>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="albumRepository">Album repository instance</param>
        /// <param name="mapper">Automapper instance</param>
        public GetAlbumHandler(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handle method
        /// </summary>
        /// <param name="request">object request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Album</returns>
        public async Task<GetAlbumResponse> Handle(GetAlbumRequest request, CancellationToken cancellationToken)
        {
            Domain.Entity.Album? album = await _albumRepository.GetByIdAsync(request.Id, cancellationToken);
            return _mapper.Map<GetAlbumResponse>(album);
        }
    }
}
