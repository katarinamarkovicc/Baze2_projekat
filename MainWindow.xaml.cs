using Microsoft.EntityFrameworkCore;
using Projekat.Models;
using System;
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

namespace Projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RestoraniContext restoraniContext = new RestoraniContext();
        private CollectionViewSource vlasnikViewSource;
        private CollectionViewSource radnikViewSource;
        private CollectionViewSource restoranViewSource;
        private CollectionViewSource kuhinjaViewSource;
        private CollectionViewSource kuvarViewSource;
        private CollectionViewSource konobarViewSource;
        private CollectionViewSource gostViewSource;
        private CollectionViewSource stoViewSource;
        private CollectionViewSource meniViewSource;
        private CollectionViewSource stavkaMenijaViewSource;
        private CollectionViewSource jeloViewSource;
        private CollectionViewSource namirnicaViewSource;
        private CollectionViewSource narucujeViewSource;

        public MainWindow()
        {
            InitializeComponent();

            vlasnikViewSource = (CollectionViewSource)FindResource(nameof(vlasnikViewSource));
            radnikViewSource = (CollectionViewSource)FindResource(nameof(radnikViewSource));
            restoranViewSource = (CollectionViewSource)FindResource(nameof(restoranViewSource));
            kuhinjaViewSource = (CollectionViewSource)FindResource(nameof(kuhinjaViewSource));
            kuvarViewSource = (CollectionViewSource)FindResource(nameof(kuvarViewSource));
            konobarViewSource = (CollectionViewSource)FindResource(nameof(konobarViewSource));
            gostViewSource = (CollectionViewSource)FindResource(nameof(gostViewSource));
            stoViewSource = (CollectionViewSource)FindResource(nameof(stoViewSource));
            meniViewSource = (CollectionViewSource)FindResource(nameof(meniViewSource));
            stavkaMenijaViewSource = (CollectionViewSource)FindResource(nameof(stavkaMenijaViewSource));
            jeloViewSource = (CollectionViewSource)FindResource(nameof(jeloViewSource));
            namirnicaViewSource = (CollectionViewSource)FindResource(nameof(namirnicaViewSource));
            narucujeViewSource = (CollectionViewSource)FindResource(nameof(narucujeViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            restoraniContext.Vlasniks.Load();
            restoraniContext.Radniks.Load();
            restoraniContext.Restorans.Load();
            restoraniContext.Kuhinjas.Load();
            restoraniContext.Kuvars.Load();
            restoraniContext.Konobars.Load();
            restoraniContext.Gosts.Load();
            restoraniContext.Stos.Load();
            restoraniContext.Menis.Load();
            restoraniContext.StavkaMenijas.Load();
            restoraniContext.Jelos.Load();
            restoraniContext.Namirnicas.Load();
            restoraniContext.Narucujes.Load();

            vlasnikViewSource.Source = restoraniContext.Vlasniks.Local.ToObservableCollection();
            radnikViewSource.Source = restoraniContext.Radniks.Local.ToObservableCollection();
            restoranViewSource.Source = restoraniContext.Restorans.Local.ToObservableCollection();
            kuhinjaViewSource.Source = restoraniContext.Kuhinjas.Local.ToObservableCollection();
            kuvarViewSource.Source = restoraniContext.Kuvars.Local.ToObservableCollection();
            konobarViewSource.Source = restoraniContext.Konobars.Local.ToObservableCollection();
            gostViewSource.Source = restoraniContext.Gosts.Local.ToObservableCollection();
            stoViewSource.Source = restoraniContext.Stos.Local.ToObservableCollection();
            meniViewSource.Source = restoraniContext.Menis.Local.ToObservableCollection();
            stavkaMenijaViewSource.Source = restoraniContext.StavkaMenijas.Local.ToObservableCollection();
            jeloViewSource.Source = restoraniContext.Jelos.Local.ToObservableCollection();
            namirnicaViewSource.Source = restoraniContext.Namirnicas.Local.ToObservableCollection();
            narucujeViewSource.Source = restoraniContext.Narucujes.Local.ToObservableCollection();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            restoraniContext.Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int n = restoraniContext.SaveChanges();

            vlasnikDataGrid.Items.Refresh();
            radnikDataGrid.Items.Refresh();
            restoranDataGrid.Items.Refresh();
            kuhinjaDataGrid.Items.Refresh();
            kuvarDataGrid.Items.Refresh();
            konobarDataGrid.Items.Refresh();
            gostDataGrid.Items.Refresh();
            stoDataGrid.Items.Refresh();
            meniDataGrid.Items.Refresh();
            stavkaMenijaDataGrid.Items.Refresh();
            jeloDataGrid.Items.Refresh();
            namirnicaDataGrid.Items.Refresh();
            narucujeDataGrid.Items.Refresh();

            MessageBox.Show("Broj izvrsenih zapisa: " + n);

        }
    }
}
