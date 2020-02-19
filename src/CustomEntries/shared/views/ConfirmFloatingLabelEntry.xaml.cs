using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CustomEntries
{
    public partial class ConfirmFloatingLabelEntry : FloatingLabelBase
    {
        #region instances
        public AsyncEvent<EventArgs> TextChangedHandlerAsync;
        #endregion

        #region bindable properties
        public readonly BindableProperty ButtonTextProperty = BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(MaterialFloatingLabelEntry), "");
        public readonly BindableProperty ConfirmTextProperty = BindableProperty.Create(nameof(ConfirmText), typeof(string), typeof(MaterialFloatingLabelEntry), "");
        public readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(MaterialFloatingLabelEntry), 0);
        public readonly BindableProperty ViewBackgroundColorProperty = BindableProperty.Create(nameof(ViewBackgroundColor), typeof(Color), typeof(MaterialFloatingLabelEntry), Color.Gray);
        public readonly BindableProperty ButtonBackgroundColorProperty = BindableProperty.Create(nameof(ButtonBackgroundColor), typeof(Color), typeof(MaterialFloatingLabelEntry), Color.LightGray);
        public readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(ConfirmFloatingLabelEntry), false, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var confirmEntry = (ConfirmFloatingLabelEntry)bindable;
            confirmEntry.UpdateValidation();
        });
        #endregion

        #region constructor
        public ConfirmFloatingLabelEntry() : base()
        {
            InitializeComponent();

            floatingLabelEntry.PlaceholderToTitleAsync += (sender, e) => PlaceholderToTitle();

            floatingLabelEntry.TitleToPlaceholderAsync += (sender, e) => TitleToPlaceholder();

            floatingLabelEntry.TextChangedHandlerAsync += async (sender, e) => await (TextChangedHandlerAsync?.InvokeAsync(sender, e) ?? Task.CompletedTask);
            UpdateValidation();

        }
        #endregion

        #region privates
        /// <summary>
        /// set the button style to the correct validation status
        /// </summary>
        private void UpdateValidation()
        {
            if (IsValid)
            {
                Confirm.BackgroundColor = ButtonBackgroundColor;
                Confirm.TextColor = TextColor;
            }
            else
            {
                Confirm.BackgroundColor = ButtonBackgroundColor.WithLuminosity(0.45);
                Confirm.TextColor = ViewBackgroundColor;
            }
        }

        /// <summary>
        /// change the button style when the user starts to enter a text
        /// </summary>
        /// <returns></returns>
        async Task PlaceholderToTitle()
        {
            Confirm.HeightRequest = Frame.Height;

            if (!IsValid)
            {
                Confirm.BackgroundColor = ButtonBackgroundColor.WithLuminosity(0.45);
                Confirm.TextColor = ViewBackgroundColor;
            }

            var buttonWidth = CalculateBounds.GetTextWidth(Confirm.Text, Convert.ToSingle(Confirm.FontSize));
#if __IOS__
#endif

#if __ANDROID__
            buttonWidth *= DeviceDisplay.MainDisplayInfo.Density;
#endif
            Confirm.WidthRequest = buttonWidth;

            await Task.WhenAll(Confirm.OpacityTo(0, 1, (o) => Confirm.Opacity = o, 300),
                         Task.Run(() => floatingLabelEntry.VerticalOptions = LayoutOptions.End));

            Confirm.HeightRequest = Frame.Height;
            Confirm.WidthRequest = buttonWidth;
        }

        /// <summary>
        /// change the button style when the title transform back to placeholder
        /// </summary>
        /// <returns></returns>
        async Task TitleToPlaceholder()
        {
            await Task.WhenAll(Confirm.OpacityTo(1, 0, (o) => Confirm.Opacity = o, 300),
                         Task.Run(() => floatingLabelEntry.VerticalOptions = LayoutOptions.Center));
            Confirm.WidthRequest = 0;
        }

        /// <summary>
        /// set the button style when the user taps the confirm button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirm_Clicked(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Confirm.Text = ConfirmText;
                Confirm.HeightRequest = Frame.Height;
                Task.WhenAll(
                    Confirm.LayoutTo(new Rectangle(Frame.X - 1, Frame.Y, Frame.Width + 1, Frame.Height), 700, Easing.SinOut),
                    Confirm.ColorTo(Color.FromRgba(Confirm.TextColor.R, Confirm.TextColor.G, Confirm.TextColor.B, 0), Confirm.TextColor, (c) => Confirm.TextColor = c, 700, Easing.Linear));
                Confirm.WidthRequest = Frame.Width + 1;
            }
        }

        #endregion

        #region properties
        /// <summary>
        /// the background color of the view
        /// </summary>
        public Color ViewBackgroundColor
        {
            get => (Color)GetValue(ViewBackgroundColorProperty);
            set => SetValue(ViewBackgroundColorProperty, value);
        }

        /// <summary>
        /// the background color of the confirm button
        /// </summary>
        public Color ButtonBackgroundColor
        {
            get => (Color)GetValue(ButtonBackgroundColorProperty);
            set => SetValue(ButtonBackgroundColorProperty, value);
        }

        /// <summary>
        /// specifiy if the current entered text is valid (use a validation behaviour)
        /// </summary>
        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            set => SetValue(IsValidProperty, value);
        }

        /// <summary>
        /// the corner radius of the view
        /// </summary>
        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// the text of the confirm button
        /// </summary>
        public string ButtonText
        {
            get => (string)GetValue(ButtonTextProperty);
            set => SetValue(ButtonTextProperty, value);
        }

        /// <summary>
        /// the final string of the confirm button
        /// </summary>
        public string ConfirmText
        {
            get => (string)GetValue(ConfirmTextProperty);
            set => SetValue(ConfirmTextProperty, value);
        }
        #endregion
    }
}