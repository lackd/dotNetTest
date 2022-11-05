
using System.Runtime.Serialization;

namespace Musicfy.Core.Exceptions
{

    [Serializable]
    public class ChallengeException : System.Exception
    {
        public ChallengeException() : base() { }
        public ChallengeException(string message) : base(message, null) { }
        public ChallengeException(string? message, Exception? exception) : base(message, exception) { }
        protected ChallengeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public virtual int Code { get; set; }

    }
}
