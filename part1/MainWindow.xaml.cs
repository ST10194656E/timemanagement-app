using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace part1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Module> modules;

        public MainWindow()
        {
            InitializeComponent();
            modules = new List<Module>();
        }

        private void AddModule_Click(object sender, RoutedEventArgs e, TimeManagementApp module, TimeManagementApp timeManagementApp)
        {
            string code = moduleCodeTextBox.Text;
            string name = moduleNameTextBox.Text;
            int credits = int.Parse(creditsTextBox.Text);
            int classHours = int.Parse(classHoursTextBox.Text);
            _ = new TimeManagementApp(code, name, credits, classHours);
            modules.Add(timeManagementApp);
            modulesListBox.Items.Add(timeManagementApp);
        }

        private void CalculateSelfStudyHours_Click(object sender, RoutedEventArgs e)
        {
            int weeks = int.Parse(weeksTextBox.Text);
            DateTime startDate = startDatePicker.SelectedDate.Value;

            foreach (Module module in modules)
            {
                module.SelfStudyHoursPerWeek = module.CalculateSelfStudyHoursPerWeek(weeks);
            }

            // Display the self-study hours for each module
            modulesListBox.Items.Refresh();
        }
    }
}

