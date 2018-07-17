using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using Windows.Devices.Geolocation;
using Windows.Storage.Streams;
using Microsoft.Data.Sqlite;
using DataAccessLibrary;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Vigilance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public IconViewModel ViewModel { get; set; }
        private static IEnumerable<Report> ClassCollection { get; set; }
        private GeolocationAccessStatus AccessStatus { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            ClassCollection = Report.GetReports();
            myMap.Loaded += MyMap_Loaded;
            ViewModel = new IconViewModel(ClassCollection);
        }
        private async void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                AccessStatus = await Geolocator.RequestAccessAsync();
                if (AccessStatus == GeolocationAccessStatus.Allowed)//Get the user location
                {
                    Geolocator geoLocator = new Geolocator();
                    Geoposition pos = await geoLocator.GetGeopositionAsync();
                    Geopoint userLocation = pos.Coordinate.Point;
                    await myMap.TrySetViewAsync(userLocation, 16);//assign the map center to user's location 
                }
                else
                {   //Default map center is Puyallup, Wa Municipal Court
                    var defaultCenter = new Geopoint(new BasicGeoposition()
                    {
                        Latitude = 47.192298,
                        Longitude = -122.281621
                    });
                    await myMap.TrySetViewAsync(defaultCenter, 16);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "Maploaded");
            }
        }

        private async void myMap_MapElementClick_1(MapControl sender, MapElementClickEventArgs args)
        {
            try
            {
                foreach (MapElement me in args.MapElements)
                {
                    if (this.ViewModel.MapElementsCollection.Contains(me))
                    {
                        ContentDialog CrimeDetails = new ContentDialog()
                        {
                            Title = "Crime Details",
                            Content = me.Tag.ToString(),
                            CloseButtonText = "Done"
                        };
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                        {
                            try
                            {
                                await CrimeDetails.ShowAsync();
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex.Message);
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        private async void Update_Button_Click(object sender, RoutedEventArgs e)
        {

            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                UpdateMapAsync();
            });
        }

        private async void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                ResetMapAsync();
            });
        }

        private void UpdateMapAsync()
        {
            CheckBox[] boxes = new CheckBox[] { Arson, Assault, Burglary, CriminalTraffic,
                DrugPossession, DrugSaleAndManufacture, FraudOrForgery, Homicide, Intimidation,
                LiquorLawViolation, MotorVehicleTheft, PossesionOfStolenProperty, Robbery,
                TelephoneHarrassment, Theft, TraffickingStolenProperty, Vandalism, WarrantArrests};
            foreach (CheckBox box in boxes)
            {
                if (box.IsChecked == true)
                {
                    var checkedIcons = from icons in ViewModel.MapElementsCollection
                                       where icons.Tag.ToString().Contains(box.Content.ToString())
                                       select icons;
                    foreach (MapIcon checkedIcon in checkedIcons)
                    {
                        checkedIcon.Visible = true;
                    };
                }
                if (box.IsChecked == false)
                {
                    var uncheckedIcons = from icons in ViewModel.MapElementsCollection
                                         where icons.Tag.ToString().Contains(box.Content.ToString())
                                         select icons;
                    foreach (MapIcon element in uncheckedIcons)
                    {
                        element.Visible = false;
                    }
                }
            }
        }
        private void ResetMapAsync()
        {
            CheckBox[] boxes = new CheckBox[] {Arson, Assault, Burglary, CriminalTraffic,
                DrugPossession, DrugSaleAndManufacture, FraudOrForgery, Homicide, Intimidation,
                LiquorLawViolation, MotorVehicleTheft, PossesionOfStolenProperty, Robbery,
                TelephoneHarrassment, Theft, TraffickingStolenProperty, Vandalism, WarrantArrests};

            foreach (CheckBox box in boxes)
            {
                if (box.IsChecked == true)
                {
                    box.IsChecked = false;
                }
            }
            foreach (MapElement icons in ViewModel.MapElementsCollection)
            {
                icons.Visible = true;
            }
        }
    }
}
