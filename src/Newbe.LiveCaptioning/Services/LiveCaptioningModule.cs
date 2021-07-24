using Autofac;

namespace Newbe.LiveCaptioning.Services
{
    public class LiveCaptioningModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<AzureLiveCaptioningProvider>()
                .AsSelf()
                .InstancePerDependency();
            builder.RegisterType<LiveCaptioningProviderFactory>()
                .As<ILiveCaptioningProviderFactory>()
                .SingleInstance();
        }
    }
}