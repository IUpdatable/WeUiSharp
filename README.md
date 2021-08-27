
<p align="center">
    <h1 align="center" style="border-bottom: none">WeUiSharp</h1>
</p>

<p  align="center">
    中文 | <a href="https://github.com/IUpdatable/WeUiSharp/blob/master/README-en.md">English</a>
</p>

<p align="center">
    基于 WPF 实现的仿 Windows 桌面版微信 UI 界面库<br>
An unofficial UI library for Windows WeChat based on WPF implementation
</p>




<p align="center">
    <img src="https://img.shields.io/badge/license-MIT-green"/>
    <img alt=".NET Framework Version" src="https://img.shields.io/badge/.NET%20Framework-%3E%3D4.7.2-blue.svg"></img>
    <a href="https://www.nuget.org/packages/WeUiSharp">
        <img alt="nuget-version" src="https://img.shields.io/nuget/v/WeUiSharp.svg"></img>
    </a>
    <a href="https://www.nuget.org/packages/WeUiSharp">
        <img alt="Nuget" src="https://img.shields.io/nuget/dt/WeUiSharp"></img>
    </a> 
</p>


## Features

* .NET Framework >= 4.7.2
* 多语言动态切换
* 主题动态切换（TODO：深色主题）
* MIT 协议，开源可商用


## Overview

![Overview](https://raw.githubusercontent.com/IUpdatable/WeUiSharp/master/Resources/Overview.png)


## Getting Started

1. 创建一个基于.NET Framework 4.7.2+ 的WPF项目（推荐使用：[Prism](https://github.com/PrismLibrary/Prism) 框架，直接使用 [Prism模板](https://marketplace.visualstudio.com/items?itemName=BrianLagunas.PrismTemplatePack) 创建项目）；
2. NuGet 安装 `WeUiSharp`
3. 修改文件 `App.xaml`，添加以下资源：
```xml
<Application.Resources>
    <!-- 下面部分为添加内容 -->
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/WeUiSharp;component/ControlsResources.xaml"/>
            <weui:ThemeResources RequestedTheme="Light">
                <weui:ThemeResources.ThemeDictionaries>
                    <ResourceDictionary x:Key="Light">
                        <ResourceDictionary.MergedDictionaries>
                            <ResourceDictionary Source="/WeUiSharp;component/ThemeResources/Light.xaml" />
                        </ResourceDictionary.MergedDictionaries>
                    </ResourceDictionary>
                    <ResourceDictionary x:Key="Dark">
                        <ResourceDictionary.MergedDictionaries>
                            <ResourceDictionary Source="/WeUiSharp;component/ThemeResources/Dark.xaml" />
                        </ResourceDictionary.MergedDictionaries>
                    </ResourceDictionary>
                </weui:ThemeResources.ThemeDictionaries>
            </weui:ThemeResources>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```
4. 修改文件 `MainWindow.xaml`，将 `Window` 改为 `weui:Window`，并添加 `weui` 的引用：

```xml
<weui:Window xmlns:weui="https://github.com/IUpdatable/WeUiSharp" Title="Hello WeUiSharp"
        ...
        >
    <Grid>
        
    </Grid>

</weui:Window>
```

5. 修改 `MainWindow.xaml.cs`，取消从 Window 的继承关系

```CSharp
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }
}
```
6. 编译运行，应该就可以看到下面效果的界面：

![Hello Wrorld](https://raw.githubusercontent.com/IUpdatable/WeUiSharp/master/Resources/HelloWeUiSharp.png)

完整代码：[WeUiSharp.HelloWorld](https://github.com/IUpdatable/WeUiSharp/tree/master/Src/WeUiSharp.HelloWorld)

基于 Prism 框架的 Hello Wrorld 项目完整代码： [WeUiSharp.HelloWorldWithPrism](https://github.com/IUpdatable/WeUiSharp/tree/master/Src/WeUiSharp.HelloWorldWithPrism)

## Components

* [Button]()
* [ToggleButton]()
* [PathButton]()
* [IconButton]()
* [Field]()
* [CheckBox]()
* [ComboBox]()
* [MessageBox](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#MessageBox)
* [ContextMenu](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#ContextMenu)
* [Toast](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#Toast)
* [Alert](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#Alert)



### License

MIT

