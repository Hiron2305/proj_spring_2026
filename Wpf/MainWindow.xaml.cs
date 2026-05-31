using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Model.Core;
using Model.Data;

namespace petchelterWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadShelters();

            ShelterComboBoxPetName.Items.Add("Все");
            ShelterComboBoxPetName.Items.Add("Котя");
            ShelterComboBoxPetName.Items.Add("Песя");
            ShelterComboBoxPetName.Items.Add("Зайка");
            ShelterComboBoxPetName.SelectedIndex = 0;
        }

        private void LoadShelters()
        {
            var shelters = DataManager.LoadData();
            var allOption = new Shelter("Все приюты", 0, false);
            var list = new List<Shelter> { allOption };
            list.AddRange(shelters);

            ShelterComboBox.ItemsSource = list;
            ShelterComboBox.DisplayMemberPath = "Name";
            ShelterComboBox.SelectedIndex = 0;
        }

        private void FormatComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ShelterComboBox == null) return;

            if (FormatComboBox.SelectedItem is ComboBoxItem item)
            {
                string format = item.Content.ToString();
                DataManager.ChangeFormat(format);
                LoadShelters();
            }
        }

        private void ShowPets_Click(object sender, RoutedEventArgs e)
        {
            var selectedShelter = ShelterComboBox.SelectedItem as Shelter;
            int typeIndex = ShelterComboBoxPetName.SelectedIndex;

            bool onlyOpenTerritory = OpenTerritoryCheckBox.IsChecked ?? false;
            bool onlyClaustrophobic = ClaustrophobiaCheckBox.IsChecked ?? false;

            Type targetType = typeIndex switch
            {
                1 => typeof(Cat),
                2 => typeof(Dog),
                3 => typeof(Rabbit),
                _ => null
            };

            var allShelters = DataManager.LoadData();
            var sheltersToSearch = selectedShelter.Name != "Все приюты"
                ? allShelters.Where(s => s.Name == selectedShelter.Name).ToList()
                : allShelters;

            if (onlyOpenTerritory)
                sheltersToSearch = sheltersToSearch.Where(s => s.Openterritory).ToList();

            List<Pet> filteredPets = new List<Pet>();
            foreach (var shelter in sheltersToSearch)
            {
                filteredPets.AddRange(shelter.Filter(targetType, onlyClaustrophobic));
            }

            if (filteredPets.Count == 0)
            {
                File.WriteAllText("EmptyReport.json", "[]");
                File.WriteAllText("EmptyReport.xml", "<Empty/>");
                MessageBox.Show("Животных с такими параметрами нет. Созданы пустые файлы-отчеты.", "Инфо", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            PetsWindow petsWindow = new PetsWindow(filteredPets, selectedShelter.Name != "Все приюты" ? allShelters.First(s => s.Name == selectedShelter.Name) : null);
            petsWindow.Owner = this;
            petsWindow.ShowDialog();

            LoadShelters();
        }
    }
}