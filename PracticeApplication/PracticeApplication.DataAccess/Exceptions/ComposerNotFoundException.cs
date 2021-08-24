using System;

namespace PracticeApplication.DataAccess.Exceptions
{
    [Serializable]
    public class ComposerNotFoundException : Exception
    {
        public ComposerNotFoundException() { }

        public ComposerNotFoundException(string message) : base(message) { }

        public ComposerNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
