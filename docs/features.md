# Features

The ADVTheme also comes bundled with some additional features outside of just coloring and styling for the underlying controls. 

Follow the links below to read up on each of the included features.

- [Built-In Functions](functions.md)
- [Included Converters](converters.md)

## Misc Features

Some features or quirks are explained below, so be sure to read over these.

### Windows

When making a window, if the program is running on Windows, the TitleBar is extended on any Windows. Due to Avalonia's use of a special class for WindowIcons, this theme opts for using a custom resource for window icon images. All the user needs to do is add a resource to the Application or Window named `WindowIcon` that will be loaded for all windows except the MessageWindow.