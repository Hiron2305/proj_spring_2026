using System;
using System.Windows;
using System.Windows.Controls;
using Model.Core;

namespace petchelterWPF
{
    public partial class AddPetWindow : Window
    {
        public Pet CreatedPet { get; private set; }

        public AddPetWindow()
        {
            InitializeComponent();
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ExtraLabel1 == null) return;

            if (TypeComboBox.SelectedIndex == 2)
            {
                ExtraLabel1.Content = "Окрас:";
                ExtraCheckBox.Visibility = Visibility.Collapsed;
                ExtraLabel2.Visibility = Visibility.Visible;
                ExtraTextBox2.Visibility = Visibility.Visible;
            }
            else
            {
                ExtraLabel1.Content = "Порода:";
                ExtraCheckBox.Visibility = Visibility.Visible;
                ExtraLabel2.Visibility = Visibility.Collapsed;
                ExtraTextBox2.Visibility = Visibility.Collapsed;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text;
                int age = int.Parse(AgeTextBox.Text);
                double weight = double.Parse(WeightTextBox.Text.Replace(".", ","));
                string gender = (GenderComboBox.SelectedItem as ComboBoxItem).Content.ToString();
                bool claustrophobia = ClaustrophobiaCheckBox.IsChecked ?? false;

                if (TypeComboBox.SelectedIndex == 0)
                {
                    string breed = ExtraTextBox1.Text;
                    bool castrate = ExtraCheckBox.IsChecked ?? false;
                    CreatedPet = new Cat(name, age, weight, gender, breed, castrate, claustrophobia);
                }
                else if (TypeComboBox.SelectedIndex == 1)
                {
                    string breed = ExtraTextBox1.Text;
                    bool castrate = ExtraCheckBox.IsChecked ?? false;
                    CreatedPet = new Dog(name, age, weight, gender, breed, castrate, claustrophobia);
                }
                else if (TypeComboBox.SelectedIndex == 2)
                {
                    string color = ExtraTextBox1.Text;
                    int children = int.Parse(ExtraTextBox2.Text);
                    CreatedPet = new Rabbit(name, age, weight, gender, children, color, claustrophobia);
                }

                DialogResult = true;
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Пожалуйста, проверьте правильность введенных данных (особенно числа).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}