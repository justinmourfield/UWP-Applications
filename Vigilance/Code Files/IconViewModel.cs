using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;
using Windows.Storage.Streams;
using Windows.Foundation;

namespace Vigilance
{
    public class IconViewModel
    {
        public ObservableCollection<MapLayer> LayerCollection { get; } = new ObservableCollection<MapLayer>();
        public List<MapElement> MapElementsCollection { get; set; } = new List<MapElement>();

        public IconViewModel(IEnumerable<Report> reports)//establishes a default view
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                foreach (Report crimeReport in reports) //Need to optimize, ParallelForEach=called an interface marshalled by another thread 
                {
                    string rep =
                        $"Case Number: {crimeReport.CaseNo},\n" +
                        $"\n" +
                        $"Date of Arrest: {crimeReport.OccurredOn},\n" +
                        $"\n" +
                        $"Reason for arrest: {crimeReport.CrimeName},\n" +
                        $"\n" +
                        $"Reporting Department: {crimeReport.District},\n" +
                        $"\n" +
                        $"Location of arrest: {crimeReport.Location},\n" +
                        $"\n" +
                        $"Neighborhood: {crimeReport.Neighborhood},\n" +
                        $"\n" +
                        $"City: {crimeReport.City}";

                    MapIcon crimeIcon = new MapIcon
                    {
                        Location = crimeReport.Position
                    };
                    crimeIcon.Tag = rep;
                    crimeIcon.Image = crimeReport.Image;
                    crimeIcon.NormalizedAnchorPoint = new Point(0.5, 0.5);
                    crimeIcon.CollisionBehaviorDesired = 0;
                    crimeIcon.Visible = true;
                    MapElementsCollection.Add(crimeIcon);
                };

                var crimeLayer = new MapElementsLayer//creates the map layer to display Icons
                {
                    MapElements = MapElementsCollection
                };

                LayerCollection.Add(crimeLayer);
                watch.Stop();
                Debug.WriteLine($"iconviewmodel {watch.ElapsedMilliseconds.ToString()}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "iconviewmodel");
            }
        }
    }
}
