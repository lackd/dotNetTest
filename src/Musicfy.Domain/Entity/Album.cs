namespace Musicfy.Domain.Entity
{
    public partial class Album
    {
        public Album(){
            Name=string.Empty;
            ArtistName=string.Empty;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }
    }
}
