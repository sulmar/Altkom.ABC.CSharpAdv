﻿using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Altkom.ABC.CSharpAdv.WPFClient.Views
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : Page
    {
        IDictionary<string, string> properties = new Dictionary<string, string>
        {
            {  "Model", "Model" },
            {  "Color", "Kolor" },
            {  "ProductionYear", "Rok produkcji" },
            {  "RegistrationDate", "Data rejestracji" },
        };

        public CustomersView()
        {
            InitializeComponent();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = properties[e.PropertyName];
        }
    }
}
