# Newbe.LiveCaptioning

通过这个工具，可以为你的直播添加语音实时字幕，为你的观众带来更好的体验。

## 下载与安装

首先，你可以从 Release 页面下载和你操作系统对应的版本:

<https://github.com/newbe36524/Newbe.LiveCaptioning/releases>

![release](/assets/20210725-001.png)

然后，将这个软件包解压到预先创建好的文件夹。

![unzip](/assets/20210725-002.png)

接着，在 Azure Portal 中创建一个 Cognitive Services。

提示 1：语音转文字每个月有 5 个小时的免费额度,可以参见 <https://azure.microsoft.com/pricing/details/cognitive-services/speech-services/?WT.mc_id=DX-MVP-5003606>

提示 2：你可以通过这个帮助来创建一个免费的 Azure 账号，新账号包含有 12 个月的免费大礼包，参见 <https://docs.microsoft.com/en-us/dynamics-nav/how-to--sign-up-for-a-microsoft-azure-subscription?WT.mc_id=DX-MVP-5003606>

![create service](/assets/20210725-003.gif)

![region and key](/assets/20210725-004.png)

随后，将生成好的 region 和 key 填入到 `appsettings.Production.json` 中。

记得同时修改 Language 选项，例如美式英语为 en-us，简体中文为 zh-cn。你可以通过以下链接来查看所有支持的语言:

<https://docs.microsoft.com/azure/cognitive-services/speech-service/language-support?WT.mc_id=DX-MVP-5003606>

![update appsettings.Production.json](/assets/20210725-005.png)

继而，启动 `Newbe.LiveCaptioning.exe`，你可以看到如下这样的提示信息，就说明一切已经正常。

![region and key](/assets/20210725-006.gif)

最后，你可以使用浏览器打开`http://localhost:5000`，并对着你的话筒说话，这样便可以实时产生字幕了。

![live caption](/assets/20210725-007.gif)

## 在 OBS 中加入字幕

首先，打开你的 OBS，并添加一个 browser 组件。

![add browser](/assets/20210725-008.png)

在组件的 url 中填入 `http://localhost:5000`，并设置一个合适的宽度和高度。

![add browser](/assets/20210725-009.png)

对着你的话筒话说，字幕就出来了。

![test](/assets/20210725-010.gif)

一切已经准备就绪！如果你有任何的疑问或者建议，欢迎通过以下链接进行反馈：

<https://github.com/newbe36524/Newbe.LiveCaptioning/issues>

## 常见问题

### 我对话筒说话了，但是字幕没有出来？

- 请确保你的 speech 服务的 region 和 key 都是正确的
- 请确保你填写了 Language 选项
- 请确保你的话筒可以正常工作，你可以通过托管菜单中的小图标来确认话筒的工作状态。并且确认话筒隐私设置已经正确设置。

![mic](/assets/20210725-011.png)

![mic privacy](/assets/20210725-012.png)

### 我不想使用我的默认话筒作为输入源，我想使用别的话筒

目前我们还不支持，而且因为我们还没有收到类似的反馈，如果您确认有这种需求，请通过 issue 告诉我们。

## 编译源代码

这是一个常规的 Blazor Server 项目，因此编译非常简单：

- 安装 .net sdk 6
- 使用你熟悉的 Rider，VS 或者 VSC 打开即可编译。
