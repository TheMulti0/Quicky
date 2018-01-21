using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using QuickyApp.Annotations;

namespace QuickyApp.ViewModels
{
    internal class WindowButtonViewModel : INotifyPropertyChanged
    {
        public readonly Brush DownRectangleCloseBrush = (SolidColorBrush) new BrushConverter().ConvertFrom("#A40000");
        public readonly Brush DownRectangleDarkBrush = (SolidColorBrush) new BrushConverter().ConvertFrom("#2FFFFFFF");
        public readonly Brush DownRectangleLightBrush = (SolidColorBrush) new BrushConverter().ConvertFrom("#2F000000");
        public readonly Brush OverRectangleCloseBrush = (SolidColorBrush) new BrushConverter().ConvertFrom("#E81123");
        public readonly Brush OverRectangleDarkBrush = (SolidColorBrush) new BrushConverter().ConvertFrom("#1FFFFFFF");
        public readonly Brush OverRectangleLightBrush = (SolidColorBrush) new BrushConverter().ConvertFrom("#1F000000");
        public readonly Brush IconBlackBrush = Brushes.Black;
        public readonly Brush IconWhiteBrush = Brushes.White;

        private Brush _downRectangleFill;
        private Visibility _downRectangleVisibilty;

        private Brush _overRectangleFill;
        private Visibility _overRectangleVisibility;
        private Brush _iconForeground;

        public Visibility DownRectangleVisibilty
        {
            get => _downRectangleVisibilty;
            set
            {
                if (_downRectangleVisibilty == value)
                {
                    return;
                }

                _downRectangleVisibilty = value;
                OnPropertyChanged();
            }
        }

        public Visibility OverRectangleVisibility
        {
            get => _overRectangleVisibility;
            set
            {
                if (_overRectangleVisibility == value)
                {
                    return;
                }

                _overRectangleVisibility = value;
                OnPropertyChanged();
            }
        }

        public Brush OverRectangleFill
        {
            get => _overRectangleFill;
            set
            {
                if (Equals(_overRectangleFill, value))
                {
                    return;
                }

                _overRectangleFill = value;
                OnPropertyChanged();
            }
        }

        public Brush DownRectangleFill
        {
            get => _overRectangleFill;
            set
            {
                if (Equals(_downRectangleFill, value))
                {
                    return;
                }

                _downRectangleFill = value;
                OnPropertyChanged();
            }
        }

        public Brush IconForeground
        {
            get => _iconForeground;
            set
            {
                if (Equals(_iconForeground, value))
                {
                    return;
                }

                _iconForeground = value;
                OnPropertyChanged();
            }
        }

        public WindowButtonViewModel()
        {
            DownRectangleVisibilty = Visibility.Hidden;
            OverRectangleVisibility = Visibility.Hidden;

            IconForeground = IconBlackBrush;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}