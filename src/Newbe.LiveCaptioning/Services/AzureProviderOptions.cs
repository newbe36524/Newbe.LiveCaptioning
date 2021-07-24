namespace Newbe.LiveCaptioning.Services
{
    public record AzureProviderOptions
    {
        public string Key { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
    }
}