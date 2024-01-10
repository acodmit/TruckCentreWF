using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TruckCentreWF.Service
{
    public static class ThemeService
    {
        private static AppTheme _currentTheme;

        public static AppTheme CurrentTheme
        {
            get { return _currentTheme; }
            set { _currentTheme = value; }
        }

        public static void ApplyTheme(Form form)
        {
            switch (_currentTheme)
            {
                case AppTheme.ModernGreen:
                    ApplyModernGreenTheme(form);
                    break;                
                case AppTheme.BlueRed:
                    ApplyBlueRedTheme(form);
                    break;
                case AppTheme.Dark:
                    ApplyDarkTheme(form);
                    break;
            }
        }

        private static void ApplyModernGreenTheme(Form form)
        {
            form.BackColor = Color.FromArgb(234, 244, 244);
            form.ForeColor = Color.Black;

            // Apply to other controls as needed
            ApplyControlTheme(form.Controls);
        }

        private static void ApplyDarkTheme(Form form)
        {
            form.BackColor = Color.Black;
            form.ForeColor = Color.White;

            // Apply to other controls as needed
            ApplyControlTheme(form.Controls);
        }

        private static void ApplyBlueRedTheme(Form form)
        {
            form.BackColor = Color.LightBlue;
            form.ForeColor = Color.DarkBlue;

            // Apply to other controls as needed
            ApplyControlTheme(form.Controls);
        }

        private static void ApplyControlTheme(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Apply theme to specific control types
                if (control is Panel)
                {
                    control.BackColor = Color.LightGray;
                    control.ForeColor = Color.Black;
                }
                else if (control is Button)
                {
                    control.BackColor = Color.LightSalmon;
                    control.ForeColor = Color.DarkRed;
                }
                else if (control is TextBox)
                {
                    control.BackColor = Color.LightYellow;
                }
                else if (control is MenuStrip || control is ToolStrip)
                {
                    control.BackColor = Color.LightSteelBlue;
                }

                // Recursively apply theme to child controls
                ApplyControlTheme(control.Controls);
            }
        }

        public static void SwitchTheme(AppTheme newTheme, Form form)
        {
            _currentTheme = newTheme;
            ApplyTheme(form);
        }
    }

    public enum AppTheme
    {
        ModernGreen,
        BlueRed,
        Dark,
    }

}
