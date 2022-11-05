namespace Musicfy.Application.Query.Album.GetAlbum
{
    /// <summary>
    /// Get album object response
    /// </summary>
    public class GetAlbumResponse
    {
        /// <summary>
        /// Album id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Album's name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Name of the artist
        /// </summary>
        public string? ArtistName { get; set; }

        /// <summary>
        /// The date when was released the Album
        /// </summary>
        public DateTime CreateAt { get; set; }
    }
}
