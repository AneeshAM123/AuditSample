using Xamarin.Forms;

namespace Datarynx.CustomControls
{
    public partial class RoundedLabel : ContentView
    {
        public RoundedLabel()
        {
            InitializeComponent();
        }

        #region ContentText
        public static readonly BindableProperty ContentTextProperty =
            BindableProperty.Create(nameof(ContentText),
                typeof(string),
                typeof(RoundedLabel),
                null,
                propertyChanged: ContentTextPropertyChanged);

        public string ContentText
        {
            get { return (string)GetValue(ContentTextProperty); }
            set { SetValue(ContentTextProperty, value); }
        }
        private static void ContentTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (RoundedLabel)bindable;
            view.content.Text = (string)newValue;
        }
        #endregion

        #region ContenColor
        public static readonly BindableProperty ContentColorProperty =
            BindableProperty.Create(nameof(ContentColor),
                typeof(Color),
                typeof(RoundedLabel),
                Color.Black,
                propertyChanged: ContentColorPropertyChanged);

        public Color ContentColor
        {
            get { return (Color)GetValue(ContentTextProperty); }
            set { SetValue(ContentTextProperty, value); }
        }
        private static void ContentColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (RoundedLabel)bindable;
            view.content.TextColor = (Color)newValue;
            view.borderFrame.BorderColor = (Color)newValue;
        }
        #endregion
    }
}
