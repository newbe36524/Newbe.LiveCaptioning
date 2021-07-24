using System;
using System.Threading.Tasks;

namespace Newbe.LiveCaptioning.Services
{
    public interface ILiveCaptioningProvider : IAsyncDisposable
    {
        Task StartAsync();

        void AddCallBack(Func<CaptionItem, Task> captionCallBack);
    }
}