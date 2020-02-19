using Xamarin.Forms;

namespace CustomEntries
{
    public partial class MaterialFloatingLabelEntry : FloatingLabelBase
    {
        #region BindablePropeties
        public readonly BindableProperty DefaultBorderColorProperty = BindableProperty.Create(nameof(DefaultBorderColor), typeof(Color), typeof(MaterialFloatingLabelEntry), Color.Gray);
        public readonly BindableProperty ActiveBorderColorProperty = BindableProperty.Create(nameof(ActiveBorderColor), typeof(Color), typeof(MaterialFloatingLabelEntry), Color.Gray);
        #endregion

        #region constructor
        public MaterialFloatingLabelEntry()
        {
            InitializeComponent();

            floatingLabelEntry.PlaceholderToTitleAsync += (sender, e) =>
                HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, BottomBorder.Width, BottomBorder.Height), 200);

            floatingLabelEntry.TitleToPlaceholderAsync += (sender, e) =>
                HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, 0, BottomBorder.Height), 200);
        }
        #endregion

        #region properties
        /// <summary>
        /// the default border color
        /// </summary>
        public Color DefaultBorderColor
        {
            get => (Color)GetValue(DefaultBorderColorProperty);
            set => SetValue(DefaultBorderColorProperty, value);
        }

        /// <summary>
        /// the border color when the user taps the entry
        /// </summary>
        public Color ActiveBorderColor
        {
            get => (Color)GetValue(ActiveBorderColorProperty);
            set => SetValue(ActiveBorderColorProperty, value);
        }

        /// <summary>
        /// the floating label entry
        /// </summary>
        public FloatingLabelEntry FloatingLabelEntry { get => floatingLabelEntry; }
        #endregion
    }
}