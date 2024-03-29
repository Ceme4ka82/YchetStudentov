﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
using System.Windows.Shapes;
using YchetStudentov.Model.DataBase;

namespace YchetStudentov.View.NewWin
{
    /// <summary>
    /// Логика взаимодействия для KartaStudenta.xaml
    /// </summary>
    public partial class KartaStudenta : Window
    {
        Model.DataBase.StudYchetEntities entities = new Model.DataBase.StudYchetEntities();
        public KartaStudenta(Model.DataBase.StudYchetEntities entities, Students students)
        {
            InitializeComponent();
            this.entities = entities;
            this.DataContext = students;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                entities.SaveChanges();
                this.Close();
            }
            catch(DbUpdateException ex)
            {
                MessageBox.Show("При добавлении/Изменении данных на сервере произошла ошибка." +
                         "\nДанные не были добавлены/Изменены." +
                         "\n Исключение: " + ex.InnerException.InnerException.Message,"Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
