using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomEntries
{
    public partial class ConfirmFloatingLabelEntry : FloatingLabelBase
    {
        #region instances
        public AsyncEvent<EventArgs> TextChangedHandlerAsync;
        #endregion

        #region bindable properties
        public readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(BorderlessFloatingLabelEntry), 0);
        public readonly BindableProperty ViewBackgroundColorProperty = BindableProperty.Create(nameof(ViewBackgroundColor), typeof(Color), typeof(BorderlessFloatingLabelEntry), Color.Gray);
        public readonly BindableProperty ButtonBackgroundColorProperty = BindableProperty.Create(nameof(ButtonBackgroundColor), typeof(Color), typeof(BorderlessFloatingLabelEntry), Color.LightGray);
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

            floatingLabelEntry.PlaceholderToTitleAsync += (sender, e) => Confirm.OpacityTo(0, 1, (o) => Confirm.Opacity = o, 300);
            floatingLabelEntry.TitleToPlaceholderAsync += (sender, e) => Confirm.OpacityTo(1, 0, (o) => Confirm.Opacity = o, 300);

            floatingLabelEntry.TextChangedHandlerAsync += async (sender, e) => await (TextChangedHandlerAsync?.InvokeAsync(sender, e) ?? Task.CompletedTask);
            UpdateValidation();
        }
        #endregion

        #region privates
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

        //async Task PlaceholderToTitle()
        //{
        //    Confirm.HeightRequest = Frame.Height;
        //    if (Animated)
        //    {
        //        if (!IsValid)
        //        {
        //            Confirm.BackgroundColor = ButtonBackgroundColor.WithLuminosity(0.45);
        //            Confirm.TextColor = ViewBackgroundColor;
        //        }
        //        var buttonWidth = CalculateBounds.GetTextWidth(Confirm.Text, Convert.ToSingle(Confirm.FontSize));
        //        Confirm.WidthRequest = CalculateBounds.GetTextWidth(Confirm.Text, Convert.ToSingle(Confirm.FontSize));
        //        await Task.WhenAll(
        //            PlaceholderLabel.TranslateTo(0, (Frame.Height * (-1) + PlaceholderLabel.Height) + CalculateBounds.GetTextHeight(PlaceholderLabel.Text, TITLE_FONT_SIZE) + 7, 200),
        //            PlaceholderLabel.SizeTo(PlaceholderLabel.FontSize, TITLE_FONT_SIZE, (t) => PlaceholderLabel.FontSize = t, 200, Easing.BounceIn),
        //            PlaceholderLabel.ColorTo(DefaultTextColor, ActiveTextColor, (c) => PlaceholderLabel.TextColor = c, 200),
        //            Confirm.OpacityTo(0, 1, (o) => Confirm.Opacity = o, 300));

        //        Confirm.HeightRequest = Frame.Height;
        //        Confirm.WidthRequest = buttonWidth;
        //    }
        //    else
        //    {
        //        PlaceholderLabel.TranslationX = 0;
        //        PlaceholderLabel.TranslationY = BorderlessEntry.Y - PlaceholderLabel.Height;
        //        PlaceholderLabel.FontSize = TITLE_FONT_SIZE;
        //    }
        //}

        //async Task TitleToPlaceholder()
        //{
        //    if (Animated)
        //    {
        //        await Task.WhenAll(
        //            PlaceholderLabel.TranslateTo(10, 0, 100),
        //            PlaceholderLabel.SizeTo(PlaceholderLabel.FontSize, PLACEHOLDER_FONT_SIZE, (t) => PlaceholderLabel.FontSize = t, 100),
        //            PlaceholderLabel.ColorTo(ActiveTextColor, DefaultTextColor, (c) => PlaceholderLabel.TextColor = c, 100),
        //            Confirm.OpacityTo(1, 0, (o) => Confirm.Opacity = o, 300));

        //        Confirm.WidthRequest = 0;
        //    }
        //    else
        //    {
        //        PlaceholderLabel.TranslationX = 10;
        //        PlaceholderLabel.TranslationY = 0;
        //        PlaceholderLabel.FontSize = PLACEHOLDER_FONT_SIZE;
        //    }
        //}

        async Task ResizeConfirm()
        {
            if (IsValid)
            {
                Confirm.ImageSource = ImageSource.FromResource("CustomEntries.shared.resources.refresh_light.png");

                Confirm.Text = "Thanks! Check your email.";
                Confirm.HeightRequest = Frame.Height;
                await Task.WhenAll(
                    Confirm.LayoutTo(new Rectangle(Frame.X - 1, Frame.Y, Frame.Width + 1, Frame.Height), 700, Easing.SinOut),
                    Confirm.ColorTo(Color.FromRgba(Confirm.TextColor.R, Confirm.TextColor.G, Confirm.TextColor.B, 0), Confirm.TextColor, (c) => Confirm.TextColor = c, 700, Easing.Linear));
                Confirm.WidthRequest = Frame.Width + 1;
            }
        }
        #endregion

        #region properties
        public Color ViewBackgroundColor
        {
            get => (Color)GetValue(ViewBackgroundColorProperty);
            set => SetValue(ViewBackgroundColorProperty, value);
        }

        public Color ButtonBackgroundColor
        {
            get => (Color)GetValue(ButtonBackgroundColorProperty);
            set => SetValue(ButtonBackgroundColorProperty, value);
        }

        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            set => SetValue(IsValidProperty, value);
        }

        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        #endregion
    }
}