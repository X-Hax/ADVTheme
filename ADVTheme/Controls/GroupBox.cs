using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVTheme.Controls
{
	public class GroupBox : HeaderedContentControl
	{
		public static readonly StyledProperty<IBrush?> HeaderBackgroundProperty =
			AvaloniaProperty.Register<GroupBox, IBrush>(nameof(HeaderBackground));

		public IBrush? HeaderBackground
		{
			get { return (IBrush)GetValue(HeaderBackgroundProperty); }
			set { SetValue(HeaderBackgroundProperty, value); }
		}

		public GroupBox() 
		{
			
		}
	}
}
