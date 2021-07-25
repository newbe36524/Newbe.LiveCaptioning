# Newbe.LiveCaptioning

[简体中文说明](README.zh.md)

With this tool, you can add voice live captioning to your live streams to bring a better experience to your viewers.

## Download and Installation

First, you can download the version that corresponds to your operating system from the Release page:

<https://github.com/newbe36524/Newbe.LiveCaptioning/releases>

![release](/assets/20210725-001.png)

Then, extract this package to a pre-created folder.

![unzip](/assets/20210725-002.png)

Next, create a Cognitive Services in Azure Portal.

Tip 1: Speech to Text service is free for 5 hours per month, see <https://azure.microsoft.com/pricing/details/cognitive-services/speech-services/?WT.mc_id=DX-MVP-5003606>

Tip 2: You can use this help to create a free Azure account including a 12-month free package, see <https://docs.microsoft.com/en-us/dynamics-nav/how-to--sign-up-for-a-microsoft-azure-subscription?WT.mc_id=DX-MVP-5003606>

![create service](/assets/20210725-003.gif)

![region and key](/assets/20210725-004.png)

Afterwards, fill in the generated region and key into `appsettings.Production.json`.

Remember to also change the Language option, e.g. en-us for American English and zh-cn for Simplified Chinese. You can see all supported languages by following this link:

<https://docs.microsoft.com/azure/cognitive-services/speech-service/language-support?WT.mc_id=DX-MVP-5003606>

![update appsettings.Production.json](/assets/20210725-005.png)

After that, start `Newbe.LiveCaptioning.exe` and you will see the following message, which means everything is working fine.

![region and key](/assets/20210725-006.gif)

Finally, you can use your browser to open `http://localhost:5000` and speak into your microphone to generate subtitles in real time.

![live caption](/assets/20210725-007.gif)

## Adding captions to OBS

First, open your OBS and add a browser component.

![add browser](/assets/20210725-008.png)

Fill in the url of the component with `http://localhost:5000` and set an appropriate width and height.

![add browser](/assets/20210725-009.png)

Speak into your microphone and the caption will come out.

![test](/assets/20210725-010.gif)

Everything is ready to go! If you have any questions or suggestions, feel free to give feedback via the following link.

<https://github.com/newbe36524/Newbe.LiveCaptioning/issues>

## Frequently Asked Questions

### I'm speaking into the microphone, but the captions aren't coming out?

- Please make sure your speech service has the correct region and key
- Make sure you have filled in the Language option
- Make sure your microphone is working properly, you can check the microphone's working status by using the small icon in the hosting menu. And make sure that the microphone privacy settings are set correctly.

![mic](/assets/20210725-011.png)

![mic privacy](/assets/20210725-012.png)

### I don't want to use my default microphone as input source, I want to use another microphone

We don't support this yet, and since we haven't received similar feedback, please let us know via issue if you have a confirmed need for this.

## Build from source code

This is a regular Blazor Server project, so it's very easy to build.

- Install .net sdk 6
- Open it with your Rider, VS or VSC to build.
