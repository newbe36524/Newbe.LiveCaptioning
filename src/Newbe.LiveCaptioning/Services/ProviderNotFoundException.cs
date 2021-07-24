using System;

namespace Newbe.LiveCaptioning.Services
{
    public class ProviderNotFoundException : Exception
    {
        public ProviderNotFoundException() :
            this("Live captioning provider not found")
        {
        }

        public ProviderNotFoundException(string? message) : base(message)
        {
        }

        public ProviderNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}