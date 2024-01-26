using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using TruckCentreWF.Model.Dto;

namespace TruckCentreWF.Service
{
    internal static class ApplicationService
    {
        public static int languageIndex = 0;
        public static int themeIndex = 0;
        public static Employee CurrEmployee { get; set; }

        public static int CurrEmployeeIdEmployee { get { return CurrEmployee.IdEmployee; } }

        public static void SetLanguage(int index)
        {
            // Set language index
            languageIndex = index;

            switch(index)
            {
                case 0:
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en");
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");
                    Application.CurrentCulture = new CultureInfo("en");
                    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en");
                    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
                    break;
                case 1:
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("de");
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("de");
                    Application.CurrentCulture = new CultureInfo("de");
                    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de");
                    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("de");
                    break;
                case 2:
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("sr-Latn");
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("sr-Latn");
                    Application.CurrentCulture = new CultureInfo("sr-Latn");
                    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("sr-Latn");
                    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("sr-Latn");
                    break;
            }
        }

        /*public static void SetTheme()
        {
            int themeNum = CurrEmployee.Theme;
            ResourceDictionary resourceDictionary = new ResourceDictionary();

            if (themeNum == 0)
            {
                resourceDictionary.Source = new Uri("pack://application:,,,/Resources/Themes/LightTheme.xaml");
            }
            else if (themeNum == 1)
            {
                resourceDictionary.Source = new Uri("pack://application:,,,/Resources/Themes/DarkTheme.xaml");
            }

            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }*/

        /*public async static void ChangeTheme(string theme)
        {
            if ("LightTheme".Equals(theme))
            {
                CurrEmployee.Theme = 0;

            }
            else
            {
                CurrEmployee.Theme = 1;
            }

            SetTheme();
            await EmployeeService.UpdateEmployee(CurrEmployee);

        }*/

    }
}
