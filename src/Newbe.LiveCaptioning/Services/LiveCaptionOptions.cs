namespace Newbe.LiveCaptioning.Services
{
    public record LiveCaptionOptions
    {
        public LiveCaptionProviderType Provider { get; set; }
        public AzureProviderOptions Azure { get; set; }
    }
}