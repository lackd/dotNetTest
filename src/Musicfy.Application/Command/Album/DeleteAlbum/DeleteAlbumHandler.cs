using AutoMapper;
using Musicfy.Domain.Repository;
using MediatR;

namespace Musicfy.Application.Command
    .Album.DeleteAlbum
{
    /// <summary>
    /// Post Album Handler
    /// </summary>
    public class DeleteAlbumHandler : IRequestHandler<DeleteAlbumRequest, DeleteAlbumResponse>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="albumRepository">Album repository instance</param>
        /// <param name="mapper">Automapper instance</param>
        public DeleteAlbumHandler(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handle method
        /// </summary>
        /// <param name="request">object request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Album id</returns>
        public async Task<DeleteAlbumResponse> Handle(DeleteAlbumRequest request, CancellationToken cancellationToken)
        {
            Domain.Entity.Album? album = await _albumRepository.GetByIdAsync(request.Id, cancellationToken);
            if (album != null)
            {
                Domain.Entity.Album? albumId = await _albumRepository.DeleteAsync(album, cancellationToken);
                return _mapper.Map<DeleteAlbumResponse>(albumId);
            }
            return _mapper.Map<DeleteAlbumResponse>(album);
        }
    }
}
