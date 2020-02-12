using Xamarin.Forms;

namespace CustomEntries
{
    public partial class FloatingLabelBase : ContentView
    {
        #region bindable properties
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(BorerlessFloatingLabelEntry), string.Empty);
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(BorerlessFloatingLabelEntry), string.Empty);
        public static readonly BindableProperty DefaultTextColorProperty = BindableProperty.Create(nameof(DefaultTextColor), typeof(Color), typeof(BorerlessFloatingLabelEntry), Color.Gray);
        public static readonly BindableProperty TitleColorProperty = BindableProperty.Create(nameof(TitleColor), typeof(Color), typeof(BorerlessFloatingLabelEntry), Color.Gray);
        public static readonly BindableProperty AnimatedProperty = BindableProperty.Create(nameof(Animated), typeof(bool), typeof(BorerlessFloatingLabelEntry), true);
        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(BorerlessFloatingLabelEntry), Keyboard.Default);
        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(BorerlessFloatingLabelEntry), false);
        #endregion

        #region properties
        /// <summary>
        /// The content of the entry
        /// </summary>
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        /// <summary>
        /// The placeholder text of the entry
        /// </summary>
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        /// <summary>
        /// The default color of the entry text color
        /// </summary>
        public Color DefaultTextColor
        {
            get => (Color)GetValue(DefaultTextColorProperty);
            set => SetValue(DefaultTextColorProperty, value);
        }

        /// <summary>
        /// The color of the title
        /// </summary>
        public Color TitleColor
        {
            get => (Color)GetValue(TitleColorProperty);
            set => SetValue(TitleColorProperty, value);
        }

        /// <summary>
        /// Specifies if the transformation is animated
        /// </summary>
        public bool Animated
        {
            get => (bool)GetValue(AnimatedProperty);
            set => SetValue(AnimatedProperty, value);
        }

        /// <summary>
        /// Specifies the keyboard for the entry
        /// </summary>
        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }

        /// <summary>
        /// Specifies if the entry contains a password
        /// </summary>
        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }
        #endregion
    }
}
