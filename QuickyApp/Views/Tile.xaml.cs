using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace QuickyApp.Views
{
    /// <summary>
    ///     Interaction logic for Tile.xaml
    /// </summary>
    public partial class Tile : UserControl
    {
        public static readonly DependencyProperty AccentColorProperty = DependencyProperty.Register(
            "AccentColor", typeof(Brush), typeof(Tile), new PropertyMetadata(Brushes.Black));

        public Tile()
        {
            InitializeComponent();
            DataContext = this;
        }

        public Brush AccentColor
        {
            get => (Brush) GetValue(AccentColorProperty);
            set => SetValue(AccentColorProperty, value);
        }

        public string Icon { get; set; }

        public string Text { get; set; }

        public string Description { get; set; }
    }
}