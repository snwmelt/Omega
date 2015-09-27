using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Omega.View.Control
{
    /// <summary>
    /// Interaction logic for ModernTextBox.xaml
    /// </summary>
    public partial class ModernTextBox : TextBox
    {
        #region Private_Variables

        private String _PlaceholderText;
        private Brush  _ForegroundBrush;
        private Brush  _PlaceholderTextBrush;

        #endregion

        public ModernTextBox()
        {
            InitializeComponent();
        }

        private void DisplayPlaceholderText()
        {
            if (!String.IsNullOrEmpty(PlaceholderText) &&
                String.IsNullOrWhiteSpace(Text))
            {
                SwapTextBrush();

                Text = PlaceholderText;
            }
        }

        protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnGotKeyboardFocus(e);

            RemovePlaceholderText();
        }

        protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnLostKeyboardFocus(e);

            DisplayPlaceholderText();
        }

        public Brush PlaceholderTextBrush
        {
            set
            {
                _PlaceholderTextBrush = value;

                SwapTextBrush();
            }
            get
            {
                return _PlaceholderTextBrush;
            }
        }

        public String PlaceholderText
        {
            get
            {
                return _PlaceholderText;
            }
            set
            {
                _PlaceholderText = value;

                DisplayPlaceholderText();
            }
        }

        private void RemovePlaceholderText()
        {
            if (Text.Equals(PlaceholderText))
            {
                Text = String.Empty;
                SwapTextBrush();
            }
        }

        private void SwapTextBrush()
        {
            if (PlaceholderTextBrush != null)
            {
                if (!Foreground.Equals(_PlaceholderTextBrush))
                {
                    _ForegroundBrush = Foreground;
                    Foreground  = PlaceholderTextBrush;
                }
                else
                {
                    Foreground = _ForegroundBrush;
                }
            }
        }
    }
}
