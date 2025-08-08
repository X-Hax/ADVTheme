using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace ADVTheme.UserControls;

public partial class MessageWindow : Window
{
	#region Internal Classes
	/// <summary>
	/// Stores an Icon's <see cref="StreamGeometry"/> key and its <see cref="SolidColorBrush"/> key to be loaded from the Style resources.
	/// </summary>
	private class IconAndColor
	{
		public string IconKey { get; set; } = string.Empty;
		public string ColorKey { get; set; } = string.Empty;

		public IconAndColor(string icon, string color) { IconKey = icon; ColorKey = color; }
	}

	#endregion

	#region Enums
	/// <summary>
	/// Available icons for use in the Message Window.
	/// </summary>
	public enum MessageIcons
	{
		Information = 0,
		Caution = 1,
		Warning = 3,
		Error = 4,
	}

	/// <summary>
	/// Available button options for use in the Message Window.
	/// </summary>
	public enum MessageButtons
	{
		OK,
		OKCancel,
		YesNo,
		Retry,

	}

	#endregion

	#region Variables
	/// <summary>
	/// Reference dictionary for the Icon Keys.
	/// </summary>
	private Dictionary<MessageIcons, IconAndColor> iconKeys = new Dictionary<MessageIcons, IconAndColor>
	{
		{ MessageIcons.Information, new IconAndColor("ADVTheme.Icon.Information", "ADVTheme.Brush.Gray.Base") },
		{ MessageIcons.Caution, new IconAndColor("ADVTheme.Icon.Caution", "ADVTheme.Brush.Yellow.Base") },
		{ MessageIcons.Warning, new IconAndColor("ADVTheme.Icon.Caution", "ADVTheme.Brush.Red.Base") },
		{ MessageIcons.Error, new IconAndColor("ADVTheme.Icon.Error", "ADVTheme.Brush.Red.Base") },
	};

	/// <summary>
	/// Stores the type of buttons assigned to be used in the Window.
	/// </summary>
	private MessageButtons messageButtons = MessageButtons.OK;

	/// <summary>
	/// Boolean defining if an OK or Retry button has been pressed.
	/// </summary>
	private bool isOK = false;

	/// <summary>
	/// Returns True if the OK button was pressed.
	/// </summary>
	public bool IsOK { get { return isOK; } }

	/// <summary>
	/// Returns True if the Retry button was pressed.
	/// </summary>
	public bool IsRetry { get { return isOK; } }

	/// <summary>
	/// Custom control to be displayed in the window.
	/// </summary>
	public Control? CustomControl { get; set; }

	#endregion

	#region Constructors
	/// <summary>
	/// Default constructor.
	/// </summary>
	public MessageWindow() { InitializeComponent(); }

	/// <summary>
	/// Constructs a message window.
	/// </summary>
	/// <param name="title"></param>
	/// <param name="header"></param>
	/// <param name="message"></param>
	/// <param name="messageIcon"></param>
	/// <param name="buttons"></param>
	public MessageWindow(string title, string header, string message,
		MessageIcons messageIcon = MessageIcons.Information, MessageButtons buttons = MessageButtons.OK)
    {
        InitializeComponent();

		SetupWindow(title, header, message, messageIcon, buttons);
	}

	/// <summary>
	/// Constructs a Message Window with a custom control.
	/// </summary>
	/// <param name="title"></param>
	/// <param name="header"></param>
	/// <param name="message"></param>
	/// <param name="customControl"></param>
	/// <param name="messageIcon"></param>
	/// <param name="buttons"></param>
	public MessageWindow(string title, string header, string message, Control customControl,
		MessageIcons messageIcon = MessageIcons.Information, MessageButtons buttons = MessageButtons.OK)
	{
		InitializeComponent();

		SetupWindow(title, header, message, messageIcon, buttons);

		if (customControl != null)
		{
			CustomControl = customControl;
			PART_CustomControlHolder.Children.Add(CustomControl);
		}
	}

	#endregion

	#region Functions
	private void SetupWindow(string title, string header, string message,
		MessageIcons messageIcon = MessageIcons.Information, MessageButtons buttons = MessageButtons.OK)
	{
		Title = title;
		PART_Title.Content = header;
		PART_Message.Text = message;

		var icon = GetIcon(messageIcon);
		PART_Icon.Data = icon.Data;
		PART_Icon.Fill = icon.Fill;
		Resources.Add("WindowIcon", icon);

		messageButtons = buttons;
		SetupButtons();

		PART_LeftButton.Click += LeftButtonClick;
		PART_RightButton.Click += RightButtonClick;
	}

	private Avalonia.Controls.Shapes.Path GetIcon(MessageIcons icon)
	{
		Avalonia.Controls.Shapes.Path path = new Avalonia.Controls.Shapes.Path();
		IconAndColor key = iconKeys[icon];
		if (Application.Current.TryGetResource(key.IconKey, Application.Current.ActualThemeVariant, out var geometry) &&
			Application.Current.TryGetResource(key.ColorKey, Application.Current.ActualThemeVariant, out var color))
		{
			path.Data = (Geometry)geometry;
			path.Fill = (SolidColorBrush)color;
		}

		return path;
	}

	private void SetupButtons()
	{
		string rightkey = string.Empty;
		string leftkey = string.Empty;
		switch (messageButtons)
		{
			case MessageButtons.OK:
			default:
				PART_LeftButton.IsVisible = false;
				rightkey = "Common.OK";
				break;
			case MessageButtons.OKCancel:
				rightkey = "Common.Cancel";
				leftkey = "Common.OK";
				break;
			case MessageButtons.YesNo:
				rightkey = "Common.No";
				leftkey = "Common.Yes";
				break;
			case MessageButtons.Retry:
				break;
		}

		Application.Current.TryGetResource(rightkey, out var righttext);
		PART_RightButton.Content = righttext;
		Application.Current.TryGetResource(leftkey, out var lefttext);
		PART_LeftButton.Content = lefttext;
	}

	private void LeftButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
		isOK = true;
		Close();
	}

	private void RightButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
		if (messageButtons == MessageButtons.OK || messageButtons == MessageButtons.Retry)
			isOK = true;

		Close();
	}
	#endregion
}