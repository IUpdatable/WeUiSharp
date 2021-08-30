
<p align="center">
    <h1 align="center" style="border-bottom: none">WeUiSharp</h1>
</p>

<p  align="center">
    <a href="https://github.com/IUpdatable/WeUiSharp/blob/master/README.md">中文</a> | English
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
* Multi-language dynamic switching
* Dynamic theme switching (TODO: dark theme)
* MIT license, open source and free for commercial use


## Overview

![Overview](https://raw.githubusercontent.com/IUpdatable/WeUiSharp/master/Resources/Overview.png)


## Getting Started

1. Create a WPF project based on .NET Framework 4.7.2+（Recommended Use: [Prism](https://github.com/PrismLibrary/Prism) ，use [Prism Template](https://marketplace.visualstudio.com/items?itemName=BrianLagunas.PrismTemplatePack) create project）；
2. NuGet install `WeUiSharp`
3. Modify `App.xaml` and add the following resources:
```xml
<Application.Resources>
    <!-- add part -->
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
4. Modify the file `MainWindow.xaml`, change `Window` to `weui:Window`, and add a reference to `weui`: 

```xml
<weui:Window xmlns:weui="https://github.com/IUpdatable/WeUiSharp" Title="Hello WeUiSharp"
        ...
        >
    <Grid>
        
    </Grid>

</weui:Window>
```

5. Modify `MainWindow.xaml.cs` to cancel the inheritance relationship from `Window`

```CSharp
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }
}
```
6. Compile and run, you should be able to see the following effect interface: 

![Hello Wrorld](https://raw.githubusercontent.com/IUpdatable/WeUiSharp/master/Resources/HelloWeUiSharp.png)

Complete code: [WeUiSharp.HelloWorld](https://github.com/IUpdatable/WeUiSharp/tree/master/Src/WeUiSharp.HelloWorld)

Complete code of Hello Wrorld project based on Prism framework:  [WeUiSharp.HelloWorldWithPrism](https://github.com/IUpdatable/WeUiSharp/tree/master/Src/WeUiSharp.HelloWorldWithPrism)

## Components

* [Window](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#Window)
* [Button](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#Button)
* [ToggleButton](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#ToggleButton)
* [PathButton](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#PathButton)
* [IconButton](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#IconButton)
* [Field](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#Field)
* [CheckBox](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#CheckBox)
* [ComboBox](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#ComboBox)
* [MessageBox](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#MessageBox)
* [ContextMenu](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#ContextMenu)
* [Toast](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#Toast)
* [Alert](https://github.com/IUpdatable/WeUiSharp/wiki/2.-Components#Alert)

## Feedback

* E-mail: IUpdatable@163.com

* WeChat Official Account: 

<p align="center">
    <img height="300" src="https://raw.githubusercontent.com/IUpdatable/WeUiSharp/master/Resources/公众号.jpg"/>
</p>

## License

MIT

