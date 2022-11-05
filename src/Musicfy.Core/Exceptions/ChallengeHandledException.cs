using System.Runtime.Serialization;

namespace Musicfy.Core.Exceptions
{
    [Serializable]
    public class ChallengeHandledException : ChallengeException
    {
        public Exception? HandledException { get; set; }

        public ChallengeHandledException(Exception? innerEx) : base(innerEx?.Message, innerEx)
        {
            HandledException = innerEx;
        }

        public ChallengeHandledException() { }

        public ChallengeHandledException(string message) : base(message) { }

        public ChallengeHandledException(string? message, Exception? exception) : base(message, exception) { }

        private ChallengeHandledException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
