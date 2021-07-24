using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Newbe.LiveCaptioning.Services;

namespace Newbe.LiveCaptioning.Pages
{
    public partial class Index : IAsyncDisposable
    {
        [Inject] public ILiveCaptioningProviderFactory LiveCaptioningProviderFactory { get; set; }
        [Inject] public ILogger<Index> Logger { get; set; }
        private ILiveCaptioningProvider _liveCaptioningProvider;

        private readonly List<CaptionDisplayItem> _captionList = new();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                _liveCaptioningProvider = LiveCaptioningProviderFactory.Create();
                _liveCaptioningProvider.AddCallBack(CaptionCallBack);
                await _liveCaptioningProvider.StartAsync();
            }
        }

        private int maxCount = 20;

        private Task CaptionCallBack(CaptionItem arg)
        {
            return InvokeAsync(() =>
            {
                Logger.LogDebug("Received: {Text}", arg.Text);
                var last = _captionList.FirstOrDefault();
                var newLine = false;
                var text = arg.Text;
                var skipPage = 0;
                if (arg.Text.Length > maxCount)
                {
                    skipPage = (int) Math.Floor(text.Length * 1.0 / maxCount);
                    text = arg.Text[(skipPage * maxCount)..];
                }

                if (last == null || skipPage > last.TagCount)
                {
                    newLine = true;
                }

                if (newLine || _captionList.Count == 0)
                {
                    _captionList.Insert(0, new CaptionDisplayItem
                    {
                        Text = text,
                        TagCount = arg.LineEnd ? -1 : skipPage
                    });
                }
                else
                {
                    _captionList[0].Text = text;
                    if (arg.LineEnd)
                    {
                        _captionList[0].TagCount = -1;
                    }
                }


                if (_captionList.Count > 4)
                {
                    _captionList.RemoveRange(4, _captionList.Count - 4);
                }

                StateHasChanged();
            });
        }

        private record CaptionDisplayItem
        {
            public string Text { get; set; }
            public int TagCount { get; set; }
        }

        public async ValueTask DisposeAsync()
        {
            if (_liveCaptioningProvider != null)
            {
                await _liveCaptioningProvider.DisposeAsync();
            }
        }
    }
}