using Autofac;
using Microsoft.Extensions.Options;

namespace Newbe.LiveCaptioning.Services
{
    public class LiveCaptioningProviderFactory : ILiveCaptioningProviderFactory
    {
        private readonly ILifetimeScope _lifetimeScope;
        private readonly IOptions<LiveCaptionOptions> _options;

        public LiveCaptioningProviderFactory(
            ILifetimeScope lifetimeScope,
            IOptions<LiveCaptionOptions> options)
        {
            _lifetimeScope = lifetimeScope;
            _options = options;
        }

        public ILiveCaptioningProvider Create()
        {
            var liveCaptionProviderType = _options.Value.Provider;
            switch (liveCaptionProviderType)
            {
                case LiveCaptionProviderType.Azure:
                    var liveCaptioningProvider = _lifetimeScope.Resolve<AzureLiveCaptioningProvider>();
                    return liveCaptioningProvider;
                default:
                    throw new ProviderNotFoundException();
            }
        }
    }
}