using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using System.Collections.ObjectModel;

namespace ADVTheme
{
	public class ADVTheme : Styles
	{
		public static ThemeVariant Telegram { get; } = new("Telegram", ThemeVariant.Dark);

		private static Dictionary<string, ThemeVariant> themeVariants = new Dictionary<string, ThemeVariant>
		{
			{ "Dark", ThemeVariant.Dark },
			{ "Light", ThemeVariant.Light },
			{ "Telegram", Telegram },
		};
		public static Dictionary<string, string> ThemeVariants = new Dictionary<string, string>()
		{
			{ "Dark", "Dark Theme" },
			{ "Light", "Light Theme" },
			{ "Telegram", "Telegram Night Theme" },
		};

		public ADVTheme()
		{ 
			AvaloniaXamlLoader.Load(this);
		}

		/// <summary>
		/// Adds a <see cref="ThemeVariant"/> with a specified name (key) that can then be selected from the available themes. 
		/// </summary>
		/// <param name="name">Key to retrieve the theme.</param>
		/// <param name="theme">The <see cref="ThemeVariant"/> to be added.</param>
		public static void AddTheme(string name, ThemeVariant theme, string dispName = "")
		{
			themeVariants.Add(name, theme);
			if (dispName == null || dispName.Length <= 0)
				dispName = $"{name} Theme";

			ThemeVariants.Add(name, dispName);
		}

		/// <summary>
		/// Sets the Theme for the current Application that's running. It will verify that the theme exists in the list before switching.
		/// 
		/// If the provided Theme key is invalid, it will default to the Dark theme.
		/// </summary>
		/// <param name="key">Name of the Theme to be used.</param>
		/// <returns>True when the provided key exists, False if it does not.</returns>
		public static bool SetTheme(string key)
		{
			if (themeVariants.ContainsKey(key))
			{
				Application.Current.RequestedThemeVariant = themeVariants[key];
				return true;
			}
			else
			{ 
				Application.Current.RequestedThemeVariant = themeVariants["Dark"];
				return false;
			}
		}

		/// <summary>
		/// Sets the Language for the current Application. It will verify that the requested Language exists before updating.
		/// </summary>
		/// <param name="key">Name of the Language to be used.</param>
		/// <returns>True when the provided key exists, False if it does not.</returns>
		public static bool SetLanguage(string key)
		{
			if (Application.Current.Resources.ContainsKey(key))
			{
				ResourceDictionary resource = Application.Current.Resources[key] as ResourceDictionary;

				if (Application.Current.Resources.MergedDictionaries.Count > 0)
					Application.Current.Resources.MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries[0]);
				Application.Current.Resources.MergedDictionaries.Insert(0, resource);

				return true;
			}
			else
				return false;
		}

		/// <summary>
		/// Gets a resource from the currently loaded <see cref="ResourceDictionary"/>s.
		/// </summary>
		/// <typeparam name="T">object type</typeparam>
		/// <param name="key">key for the resource</param>
		/// <returns>An object of Type T.</returns>
		public static T GetResource<T>(string key)
		{
			T? output = default(T);
			if (Application.Current.Resources.ContainsKey(key))
				output = (T)Application.Current.Resources[key];

			return output;
		}

		/// <summary>
		/// Gets a string from the currently loaded resources.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string GetString(string key)
		{
			string output = GetResource<string>(key);
			if (output.Length > 0)
				return output;
			else
				return key;
		}

		/// <summary>
		/// Updates the font size used by the Window. 
		/// 
		/// All controls will inherent their font size from their owning Window.
		/// </summary>
		/// <param name="size">Requested font size</param>
		public static void ChangeFontSize(double size)
		{
			Application.Current.Resources["ADVTheme.FontSize"] = size;
		}

		/// <summary>
		/// Updates the corner radius used across all controls set to use the ADVTheme.CornerRadius theme property.
		/// </summary>
		/// <param name="cornerRadius">Requested corner radius.</param>
		public static void ChangeCornerRadius(CornerRadius cornerRadius)
		{
			Application.Current.Resources["ADVTheme.CornerRadius"] = cornerRadius;
		}
	}
}
