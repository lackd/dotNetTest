using System.Net;

namespace Musicfy.Core.Model
{
    public class ErrorResponseViewModel
    {
        public int HttpCode { get; set; }
        
        public string? HttpMessage { get; set; }
        
        public string InternalId { get; set; }
        
        public string? UserFriendlyError { get; set; }
        
        public string? MoreInformation { get; set; }
        public ErrorResponseViewModel()
        {
            HttpCode = (int)HttpStatusCode.OK;
            HttpMessage = HttpStatusCode.OK.ToString();
            UserFriendlyError = "";
            MoreInformation = "";
            InternalId = "-";
        }
    }
}
