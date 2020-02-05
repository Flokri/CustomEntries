using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomEntries
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloatingLabelEntry : ContentView
    {
        #region instances
        const int TITLE_FONT_SIZE = 14;
        const int PLACEHOLDER_FONT_SIZE = 18;

        public event EventHandler Completed;
        #endregion

        #region BindablePropeties
        public readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(FloatingLabelEntry), string.Empty);
        public readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(FloatingLabelEntry), string.Empty);
        public readonly BindableProperty DefaultTextColorProperty = BindableProperty.Create(nameof(DefaultTextColor), typeof(Color), typeof(FloatingLabelEntry), Color.Gray);
        public readonly BindableProperty ActiveTextColorProperty = BindableProperty.Create(nameof(ActiveTextColor), typeof(string), typeof(FloatingLabelEntry), Color.Gray);
        public readonly BindableProperty DefaultBorderColorProperty = BindableProperty.Create(nameof(DefaultBorderColor), typeof(string), typeof(FloatingLabelEntry), Color.Gray);
        public readonly BindableProperty ActiveBorderColorProperty = BindableProperty.Create(nameof(ActiveBorderColor), typeof(string), typeof(FloatingLabelEntry), Color.Gray);
        public readonly BindableProperty AnimatedProperty = BindableProperty.Create(nameof(Animated), typeof(bool), typeof(FloatingLabelEntry), true);

        #endregion

        #region constructor
        public FloatingLabelEntry()
        {
            InitializeComponent();

            PlaceholderLabel.TranslationX = 10;
            PlaceholderLabel.FontSize = PLACEHOLDER_FONT_SIZE;
        }
        #endregion

        #region event handler
        async void HandleFocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                await PlaceholderToTitle();
            }
        }

        async void HandleUnfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                await TitleToPlaceholder();
            }
        }

        async void HandleTapped(object sender, EventArgs e)
        {
            if (IsEnabled)
                BorderlessEntry.Focus();
        }

        void HandleCompleted(object sender, EventArgs e)
        {
            Completed?.Invoke(this, e);
        }
        #endregion

        #region privates
        async Task PlaceholderToTitle()
        {
            if (Animated)
            {
                await Task.WhenAll(
                    PlaceholderLabel.TranslateTo(0, BorderlessEntry.Y - PlaceholderLabel.Height, 100),
                    PlaceholderLabel.SizeTo(PlaceholderLabel.FontSize, TITLE_FONT_SIZE, (t) => PlaceholderLabel.FontSize = t, 100, Easing.BounceIn),
                    PlaceholderLabel.ColorTo(DefaultTextColor, ActiveTextColor, (c)=>PlaceholderLabel.TextColor = c,100),
                    HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, BottomBorder.Width, BottomBorder.Height), 100));
            }
        }

        async Task TitleToPlaceholder()
        {
            if (Animated)
            {
                await Task.WhenAll(
                    PlaceholderLabel.TranslateTo(10, 0, 100),
                    PlaceholderLabel.SizeTo(PlaceholderLabel.FontSize, PLACEHOLDER_FONT_SIZE, (t) => PlaceholderLabel.FontSize = t, 100, Easing.BounceIn),
                    PlaceholderLabel.ColorTo(ActiveTextColor, DefaultTextColor, (c) => PlaceholderLabel.TextColor = c, 100),
                    HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, 0, BottomBorder.Height), 100));
            }
        }
        #endregion

        #region properties
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public Color DefaultTextColor
        {
            get => (Color)GetValue(DefaultTextColorProperty);
            set => SetValue(DefaultTextColorProperty, value);
        }

        public Color ActiveTextColor
        {
            get => (Color)GetValue(ActiveTextColorProperty);
            set => SetValue(ActiveTextColorProperty, value);
        }

        public Color DefaultBorderColor
        {
            get => (Color)GetValue(DefaultBorderColorProperty);
            set => SetValue(DefaultBorderColorProperty, value);
        }

        public Color ActiveBorderColor
        {
            get => (Color)GetValue(ActiveBorderColorProperty);
            set => SetValue(ActiveBorderColorProperty, value);
        }

        public bool Animated
        {
            get => (bool)GetValue(AnimatedProperty);
            set => SetValue(AnimatedProperty, value);
        }
        #endregion
    }
}