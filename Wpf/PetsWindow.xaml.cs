using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Model.Core;
using Model.Data;

namespace petchelterWPF
{
    public partial class PetsWindow : Window
    {
        private List<Pet> _pets;
        private Shelter _contextShelter;
        private static int _reportCounter = 1;

        public PetsWindow(List<Pet> pets, Shelter contextShelter)
        {
            InitializeComponent();
            _pets = pets;
            _contextShelter = contextShelter;
            RefreshGrid();

            if (_contextShelter != null)
            {
                AddPetBtn.Visibility = Visibility.Visible;
                RemovePetBtn.Visibility = Visibility.Visible;
            }
        }

        private void RefreshGrid()
        {
            PetsDataGrid.ItemsSource = null;
            PetsDataGrid.ItemsSource = _pets;
        }

        private void AddPet_Click(object sender, RoutedEventArgs e)
        {
            AddPetWindow addWindow = new AddPetWindow();
            addWindow.Owner = this;

            if (addWindow.ShowDialog() == true && addWindow.CreatedPet != null)
            {
                try
                {
                    _contextShelter += addWindow.CreatedPet;

                    _pets.Add(addWindow.CreatedPet);
                    UpdateDatabase();
                    RefreshGrid();
                    MessageBox.Show($"Питомец «{addWindow.CreatedPet.Name}» успешно добавлен в приют!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Отклонено", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RemovePet_Click(object sender, RoutedEventArgs e)
        {
            if (PetsDataGrid.SelectedItem is Pet selectedPet)
            {
                try
                {
                    _contextShelter.RemovePet(selectedPet);
                    _pets.Remove(selectedPet);
                    UpdateDatabase();
                    RefreshGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Выберите питомца в таблице для удаления.");
            }
        }

        private void UpdateDatabase()
        {
            var allShelters = DataManager.LoadData();
            var target = allShelters.Find(s => s.Name == _contextShelter.Name);
            target.Pets = _contextShelter.Pets;
            DataManager.SaveData(allShelters);
        }

        private void SaveReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string dateStr = DateTime.Now.ToString("dd-MM-yyyy");
                string ext = DataManager.CurrentFormat == "JSON" ? "json" : "xml";
                string fileName = $"Подборка_№{_reportCounter}_от_{dateStr}.{ext}";

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine($"ПОДБОРКА ПИТОМЦЕВ №{_reportCounter}");
                    foreach (var pet in _pets)
                    {
                        writer.WriteLine($"- {pet.Name} | {pet.PetDetails}");
                    }
                }

                MessageBox.Show($"Отчет сохранен:\n{fileName}", "Успех!");
                _reportCounter++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}