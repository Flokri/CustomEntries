using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomEntries
{
    public partial class BorderlessFloatingLabelEntry : FloatingLabelBase
    {
        #region BindablePropeties
        public readonly BindableProperty DefaultBorderColorProperty = BindableProperty.Create(nameof(DefaultBorderColor), typeof(Color), typeof(BorderlessFloatingLabelEntry), Color.Gray);
        public readonly BindableProperty ActiveBorderColorProperty = BindableProperty.Create(nameof(ActiveBorderColor), typeof(Color), typeof(BorderlessFloatingLabelEntry), Color.Gray);
        #endregion

        #region constructor
        public BorderlessFloatingLabelEntry()
        {
            InitializeComponent();

            floatingLabelEntry.PlaceholderToTitleAsync += (sender, e) =>
                HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, BottomBorder.Width, BottomBorder.Height), 200);

            floatingLabelEntry.TitleToPlaceholderAsync += (sender, e) =>
                HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, 0, BottomBorder.Height), 200);
        }
        #endregion

        #region properties
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

        public FloatingLabelEntry FloatingLabelEntry { get => floatingLabelEntry; }
        #endregion
    }
}