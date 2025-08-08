# Functions

Below are several included static functions that can be called within your own App that's using the ADVTheme to aide in making on the fly changes to your application.


## Setting a Theme
```c#
bool SetTheme(string key)
```

Using this function allows you to set the theme (the accent colors) for the entire App using this theme. It will search the internal Dictionary for a matching name (key) of the theme to be used, and if a matching key is found, it will set the theme and return `True`. If the key is not found in the Dictionary, it will return `False` and set the theme to the Dark theme.


## Adding a Theme
```c#
void AddTheme(string name, ThemeVariant theme)
```

This allows adding a custom ThemeVariant to the internal Dictionary for use in your specific App that's using the ADVTheme. 


## Setting a Language
```c#
bool SetLanguage(string key)
```

This function is a simple way for handling language resources in the App. Languages will need to be included in your App's axaml file using `ResourceInclude` and with a defined key. When attempting to set the language resource for the App, this function will use the **always use** the first slot in the App's `MergedDictionaries`, so please keep this in mind when setting up your merged resources. 

This function also checks to ensure the supplied key is valid within the App's set languages 

Below is an example setup for both how to setup your resources within your `App.axaml` file. 
```xml
	<Application.Resources>
		<ResourceDictionary>
			<ResourceDictionary.MergedDictionaries>
				<!-- This ResourceInclude allows the language to be loaded while editing the Avalonia xml in your IDE. -->
				<!-- It also ensures the Language is set to the first index in the MergedDictionaries as required by the in-built function. -->
				<ResourceInclude Source="avares://ADVTheme/Language/en-US.axaml"/>
			</ResourceDictionary.MergedDictionaries>
		</ResourceDictionary>
		<!-- Language resources to be included should be setup as this one is. This one would be pulled using "en-US" as the key. -->
		<ResourceInclude x:Key="en-US" Source="avares://ADVTheme/Language/en-US.axaml"/>
	</Application.Resources>
```

For reference on setting up a Language resource, [check the languages included in this theme](../ADVTheme/Language).

As most applications will need their own language files external to the ones included in the ADVTheme, please make sure you include the corresponding ADVTheme language in your local language resources to ensure you have access to the included common languages and use the local language file as your `Source`.


## Getting an object from loaded Resources
```c#
T GetResource<T>(string key)
```

Gets a resource of T using the provided key from the loaded resources. It will return a default for T if the resource is not found by the provided key, so be sure to validate your results if you use this function.


## Getting a string from the loaded Resources
```c#
string GetString(string key)
```

Gets a string from the loaded resources. This is provided for ease of use with the in-built language support. If the key is not found, it will return the provided key. This is to make it easier to locate missing language resources.


## Changing the Font Size
```c#
void ChangeFontSize(double size)
```

Font size using the ADVTheme Controls are set from their parent, the Window control. Using this function will update the underlying resource used to set the Font size. If you use a specific font size in an element of your application, this function will not make changes to that.

If you want to ensure a preset font size can be updated with this function, please refer to the [DoubleIncrementConverter](converters.md#DoubleIncrementConverter) included in the ADVTheme and bind your `FontSize` to `ADVTheme.FontSize`.


## Changing the Corner Radius
```c#
void ChangeCornerRadius(CornerRadius cornerRadius)
```

All Corner Radius settings for the Controls shared a single binded resource which can be updated to set the Corner Radius across  whole app using this. Any custom controls with a custom Corner Radius will not be updated with this function.

If you want to ensure that they can be updated when this function is run, bind your control's `CornerRadius` to `ADVTheme.CornerRadius`. Please check [here](https://github.com/AvaloniaUI/Avalonia/tree/master/src/Avalonia.Controls/Converters) for Avalonia's build in Corner converters.