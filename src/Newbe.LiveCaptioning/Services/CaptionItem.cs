namespace Newbe.LiveCaptioning.Services
{
    public record CaptionItem
    {
        public string Text { get; set; }
        public bool LineEnd { get; set; }
    }
}