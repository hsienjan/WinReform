<!-- Markdown doesnt like aligning stuff -->
<div align="center">
    <a href="https://github.com/AKruimink/WinReform">
        <img alt="WinReform" height="200" width="200" src="./docs/logo.png">
    </a>
    <h1>WinReform</h1>
    <p>
        A simple tool to help resize and relocate stubborn windows.
    </p>
    <!-- Project Info Badges -->
    <a href="https://github.com/nblockchain/AKruimink/WinReform/develop/LICENCE.md">
        <img src="https://img.shields.io/github/license/AKruimink/WinReform.svg?label=license&style=flat-square">
    </a>
    <a href="https://github.com/AKruimink/WinReform/releases/latest">
        <img src="https://img.shields.io/github/release/AKruimink/WinReform.svg?label=release&style=flat-square">
    </a>
    <br>
    <!-- CD/CI Badges-->
    <a href="https://github.com/AKruimink/WinReform/actions?query=workflow%3Abuild-project">
        <img src="https://img.shields.io/github/workflow/status/AKruimink/WinReform/build-project/master?label=master&style=flat-square">
    </a>
    <a href="https://github.com/AKruimink/WinReform/actions?query=workflow%3Abuild-project">
        <img src="https://img.shields.io/github/workflow/status/AKruimink/WinReform/build-project/develop?label=develop&style=flat-square">
    </a>
    <a href="https://github.com/AKruimink/WinReform/actions?query=workflow%3Atest-project">
        <img src="https://img.shields.io/github/workflow/status/AKruimink/WinReform/test-project/develop?label=tests&style=flat-square">
    </a>
    <br>
    <!--Issues and Pull Request Badges -->
    <a href="https://github.com/AKruimink/WinReform/issues">
        <img src="https://img.shields.io/github/issues-raw/AKruimink/WinReform.svg?label=open%20issues&style=flat-square">
    </a>
    <a href="https://github.com/AKruimink/WinReform/issues">
        <img src="https://img.shields.io/github/issues-closed-raw/AKruimink/WinReform.svg?label=closed%20issues&style=flat-square">
    </a>
    <a href="https://github.com/AKruimink/WinReform/pulls">
        <img src="https://img.shields.io/github/issues-pr-raw/AKruimink/WinReform.svg?label=open%20pull%20requests&style=flat-square">
    </a>
    <a href="https://github.com/AKruimink/WinReform/pulls">
        <img src="https://img.shields.io/github/issues-pr-closed-raw/AKruimink/WinReform.svg?label=closed%20pull%20requests&style=flat-square">
    </a>
  </a>
</div>


## About
WinReform is a utility tool that exists to solve resolution issues with older applications.
Many old games/applications were not designed with today's bigger screens in mind. 
Often this results into extremely large or small windows with no possibility to resize them.

WinReform is here to help with these kind of applications. 
By utilizing the Windows API it allows for non resizable windows to be resized to your resolution of choice or move windows that have mysteriously disappeared outside of your screen bounds.
No matter the application, as long as it contains a window, WinReform will be able to help!


## Roll Call
This application wouldn't exist without the help of several amazing open source project that I love. If you like this app I recommend checking out the following.

 - [MahApps](https://github.com/MahApps/MahApps.Metro) which helped modernize the application by providing amazing tools and visuals.
 - [Autofac](https://github.com/autofac/Autofac) which helped manage all the dependencies that the application relied on.
 - [Moq](https://github.com/moq/moq4) which allowed for a simpler time writing tests by taking the mocking out of our hands.
 - [DotNet](https://github.com/dotnet/core) which provided the possibility to create this application to begin with.

## License
WinReform is provided as-is under the Apache License Version 2.0. For more information see [LICENSE](./LICENSE.md).

## ShowRoom
<div align="center">
    <img alt="Settings" src="./docs/Settings.gif" style="display:block">
    <img alt="Resizer" src="./docs/Resizer.gif" style="display:block">
    <img alt="Locator" src="./docs/Locator.gif" style="display:block">
</div>
