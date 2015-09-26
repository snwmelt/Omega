using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Omega.View.Control
{
    /// <summary>
    /// Interaction logic for ModernTextBox.xaml
    /// </summary>
    public partial class ModernTextBox : TextBox
    {
        #region Private_Variables

        private String _PlaceholderText;

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
                Text = String.Empty;
        }
    }
}
