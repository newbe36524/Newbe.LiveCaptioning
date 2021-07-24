using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Newbe.LiveCaptioning.Services
{
    public class AzureLiveCaptioningProvider : ILiveCaptioningProvider
    {
        private readonly ILogger<AzureLiveCaptioningProvider> _logger;
        private readonly IOptions<LiveCaptionOptions> _options;
        private AudioConfig _audioConfig;
        private SpeechRecognizer _recognizer;
        private readonly List<Func<CaptionItem, Task>> _callbacks = new();
        private Subject<CaptionItem> _sub;

        public AzureLiveCaptioningProvider(
            ILogger<AzureLiveCaptioningProvider> logger,
            IOptions<LiveCaptionOptions> options)
        {
            _logger = logger;
            _options = options;
        }

        public async Task StartAsync()
        {
            var azureProviderOptions = _options.Value.Azure;
            var speechConfig = SpeechConfig.FromSubscription(azureProviderOptions.Key, azureProviderOptions.Region);
            speechConfig.SpeechRecognitionLanguage = azureProviderOptions.Language;
            _audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            _recognizer = new SpeechRecognizer(speechConfig, _audioConfig);
            _sub = new Subject<CaptionItem>();
            _sub
                .Select(item => Observable.FromAsync(async () =>
                {
                    try
                    {
                        await Task.WhenAll(_callbacks.Select(f => f.Invoke(item)));
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e, "failed to recognize");
                    }
                }))
                .Merge()
                .Subscribe();


            _recognizer.Recognizing += (sender, args) =>
            {
                _sub.OnNext(new CaptionItem
                {
                    Text = args.Result.Text,
                    LineEnd = false
                });
            };
            _recognizer.Recognized += (sender, args) =>
            {
                _sub.OnNext(new CaptionItem
                {
                    Text = args.Result.Text,
                    LineEnd = true
                });
            };
            await _recognizer.StartContinuousRecognitionAsync();
        }

        public void AddCallBack(Func<CaptionItem, Task> captionCallBack)
        {
            _callbacks.Add(captionCallBack);
        }

        public ValueTask DisposeAsync()
        {
            _recognizer?.Dispose();
            _audioConfig?.Dispose();
            _sub?.Dispose();
            return ValueTask.CompletedTask;
        }
    }
}