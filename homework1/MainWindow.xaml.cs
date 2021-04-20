using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace homework1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public List<Person> people = new List<Person>();

        public object FullName { get; private set; }

        public MainWindow()
		{
			InitializeComponent();
			people.Add(new Person { FirstName = "Kevin", LastName = "Steyer" });
			people.Add(new Person { FirstName = "Brian", LastName = "Carrigan" });
			people.Add(new Person { FirstName = "John", LastName = "Burnett" });			
		}

		private void firstNameChangedEventHandler(object sender, EventArgs e)
		{			
			EnableButton();
		}

		private void lastNameChangedEventHandler(object sender, EventArgs e)
		{
			EnableButton();
		}

		private void EnableButton()
		{
			if (firstNameText.Text == "" || lastNameText.Text == "")
			{
				submitButton.IsEnabled = false;
			}
			else
			{				
				submitButton.IsEnabled = true;
			}			
		}
		private void submitButton_Click(object sender, RoutedEventArgs e)
		{
			new SoundPlayer(@"E:\Users\shawn\source\repos\CSHP320A\CSHP-320A-Assignments-Homework_1\homework1\sounds\energy_gone.wav").Play();
			MessageBox.Show($"Hello { firstNameText.Text } {lastNameText.Text}");
			people.Add(new Person { FirstName = (firstNameText.Text), LastName = lastNameText.Text });
			myComboBox.ItemsSource = people;
		}

	} // end of partial class MainWindow

	public class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string FullName // created a new property for Full Name (e.g. FirstName space LastName) 
		{
			get
			{
				return $"{ FirstName } { LastName }";
			}
		}

	} // end of class Person
}
