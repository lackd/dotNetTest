using AutoMapper;
using Musicfy.Domain.Repository;
using MediatR;

namespace Musicfy.Application.Command
    .Album.PostAlbum
{
    /// <summary>
    /// Post Album Handler
    /// </summary>
    public class PostAlbumHandler : IRequestHandler<PostAlbumRequest, PostAlbumResponse>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="albumRepository">Album repository instance</param>
        /// <param name="mapper">Automapper instance</param>
        public PostAlbumHandler(IAlbumRepository albumRepository, IMapper mapper)
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
        public async Task<PostAlbumResponse> Handle(PostAlbumRequest request, CancellationToken cancellationToken)
        {
            Domain.Entity.Album album = _mapper.Map<Domain.Entity.Album>(request);
            IEnumerable<Domain.Entity.Album> albums = await _albumRepository.GetAll(cancellationToken);
            if (albums.Count() < 20 )
            {
                Domain.Entity.Album? albumId = await _albumRepository.PostAsync(album, cancellationToken);
                return _mapper.Map<PostAlbumResponse>(albumId);
            }
            return null;
        }
    }
}
