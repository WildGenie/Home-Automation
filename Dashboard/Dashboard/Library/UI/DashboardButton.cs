using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Dashboard.Library.UI
{
    /// <summary>
    /// Provides methods to easy operation of selection and deselection for Border button
    /// </summary>
    public static class DashboardButton
    {
        /// <summary>
        /// Maintains list of Borders to automate selection and deselection precess.
        /// </summary>
        private static List<Border> _Borders = new List<Border>();

        /// <summary>
        /// Adds border to list of borders to automate selection and deselection process by using RaiseBorder method
        /// </summary>
        /// <param name="_Border">Border to be add</param>
        public static void AddBorder(Border _Border)
        {
            // Add a border if it is not null
            if (_Border != null)
                _Borders.Add(_Border);
        }

        /// <summary>
        /// Removes boder from list
        /// </summary>
        /// <param name="_Border">Border to be remove</param>
        public static void RemoveBorder(Border _Border)
        {
            // Remove border if it is available in List: _Borders
            if (_Border != null && _Borders.Contains(_Border))
                _Borders.Remove(_Border);
        }

        /// <summary>
        /// Raises specified border and deselects others
        /// </summary>
        /// <param name="_Border">Border to be raised</param>
        public static void RaiseBorder(Border _Border)
        {
            // Iterate through all Borders
            foreach (Border _BorderItem in _Borders)
            {
                // Check if requested _Border is equals to _BorderItem
                if(_BorderItem.Equals(_Border))
                {
                    // Select or highlight requested _Border
                    SelectBorder(_Border);
                }
                else
                {
                    // Deselect _BorderItem
                    DeselectBorder(_BorderItem);
                }
            }
        }

        /// <summary>
        /// Selects specified border
        /// </summary>
        /// <param name="_Border">Border to be highlight</param>
        public static void SelectBorder(Border _Border)
        {
            // Create Image object
            Image _Image = new Image();
            _Image.Source = new BitmapImage(new Uri("ms-appx:///Resource/Images/Icon_Select.png"));

            // Create ImageBrush to set Backgroun of _Border
            ImageBrush _ImageBrush = new ImageBrush();
            _ImageBrush.ImageSource = _Image.Source;

            // Set Background
            _Border.Background = _ImageBrush;
            //_Border.Width = 160;    // Comment this line and see what happens
        }

        /// <summary>
        /// Deselects the border
        /// </summary>
        /// <param name="_Border">Border to be deselect</param>
        public static void DeselectBorder(Border _Border)
        {
            _Border.Background = null;  // Reset background
            //_Border.Width = double.NaN; // Equivalent to <Border Width="Auto">...</Border>
        }
    }
}
