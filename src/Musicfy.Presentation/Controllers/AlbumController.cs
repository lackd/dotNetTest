using System.ComponentModel.DataAnnotations;
using System.Net;
using Musicfy.Core.Extension;
using Musicfy.Core.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Musicfy.Application.Query.Album.GetAlbum;
using Musicfy.Application.Command.Album.PostAlbum;
using Musicfy.Application.Query.Album.GetAlbums;
using Musicfy.Domain.Entity;
using Musicfy.Application.Command.Album.DeleteAlbum;

namespace Musicfy.Presentation.Controllers
{
    [Route("albums")]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlbumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get Albums List
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /albums
        /// 
        /// </remarks>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <response code="200">Returns OK</response>
        /// <response code="400">The request cannot resolve.</response>
        /// <response code="500">Internal server error</response>
        /// <returns>Get albums</returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetAlbumResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> GetAlbums(CancellationToken cancellationToken)
        {
            IEnumerable<Album> response =await _mediator.Send(new GetAlbumsRequest(), cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Get Album by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /albums/1
        /// 
        /// </remarks>
        /// <param name="id">Album id</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <response code="200">Returns OK</response>
        /// <response code="400">The request cannot resolve.</response>
        /// <response code="500">Internal server error</response>
        /// <returns>Get an album, by id specify.</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(GetAlbumResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> GetAlbum([FromRoute] [Required] int id, CancellationToken cancellationToken)
        {
            GetAlbumResponse response = await _mediator.Send(new GetAlbumRequest { Id = id }, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Post Album
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /albums
        /// 
        /// </remarks>
        /// <param name="album">Album</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <response code="200">Returns OK</response>
        /// <response code="400">The request cannot resolve.</response>
        /// <response code="500">Internal server error</response>
        /// <returns>Post an album.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(PostAlbumResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> PostAlbum([FromBody][Required] PostAlbumRequest album, CancellationToken cancellationToken)
        {
            PostAlbumResponse response = await _mediator.Send(album, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Post Album
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /albums
        /// 
        /// </remarks>
        /// <param name="album">Album</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <response code="200">Returns OK</response>
        /// <response code="400">The request cannot resolve.</response>
        /// <response code="500">Internal server error</response>
        /// <returns>Delete an album.</returns>
        [HttpDelete]
        [ProducesResponseType(typeof(DeleteAlbumResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeleteAlbum([FromBody][Required] DeleteAlbumRequest album, CancellationToken cancellationToken)
        {
            DeleteAlbumResponse response = await _mediator.Send(album, cancellationToken);
            return Ok(response);
        }
    }
}
