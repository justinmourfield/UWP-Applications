using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage.Streams;
using Windows.Foundation;
using Microsoft.Data.Sqlite;

namespace Vigilance
{
    public class Report :INotifyPropertyChanged
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double CaseNo { get; set; }
        public string District { get; set; }
        public DateTime OccurredOn { get; set; }
        public string Location { get; set; }
        public string CrimeName { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public Geopoint Position { get; set; }
        public IRandomAccessStreamReference Image { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static IEnumerable<Report> GetReports()
        {

            const string GetReportsQuery = "select Longitude, Latitude, CaseNo, District, OccurredOn, Location, " +
                    "CrimeName, Neighborhood, City from crimedata";

            var crimeReports = new ObservableCollection<Report>();
            try
            {
                using (SqliteConnection db = new SqliteConnection("Filename=sqliteSample.db"))
                {

                    db.Open();
                    if (db.State == System.Data.ConnectionState.Open)
                    {
                        using (SqliteCommand cmd = db.CreateCommand())
                        {
                            cmd.CommandText = GetReportsQuery;
                            using (SqliteDataReader reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    var crimeReport = new Report();//following lines set properties obtained from SQLDB
                                    crimeReport.Longitude = reader.GetDouble(0);
                                    crimeReport.Latitude = reader.GetDouble(1);
                                    crimeReport.CaseNo = reader.GetDouble(2);
                                    crimeReport.District = reader.GetString(3);
                                    crimeReport.OccurredOn = reader.GetDateTime(4);
                                    crimeReport.Location = reader.GetString(5);
                                    crimeReport.CrimeName = reader.GetString(6);
                                    crimeReport.Neighborhood = reader.GetString(7);
                                    crimeReport.City = reader.GetString(8);
                                    crimeReport.Position = new Geopoint(new BasicGeoposition
                                    {
                                        Latitude = crimeReport.Latitude,
                                        Longitude = crimeReport.Longitude
                                    });
                                    crimeReports.Add(crimeReport);
                                }
                                //db.Close();
                                //db.Dispose();
                            }
                        }
                    }
                }
                Stopwatch watch = new Stopwatch();
                watch.Start();//Delegates?
                Parallel.ForEach(crimeReports, crimeReport =>
                {
                    if (crimeReport.CrimeName.Contains("Arson"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Arson Icon35px.png"));
                    else if (crimeReport.CrimeName.Contains("Assault"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Assault Icon35px.png"));
                    else if (crimeReport.CrimeName.Contains("Burglary"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Burglary Icon35px.png"));
                    else if (crimeReport.CrimeName.Contains("Criminal Traffic"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Criminal Traffic Icon35px.png"));
                    else if (crimeReport.CrimeName.Contains("Drug"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Drug Icon35px.png"));
                    else if (crimeReport.CrimeName.Contains("Fraud"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Fraud Icon35px.png"));
                    else if (crimeReport.CrimeName.Contains("Homicide"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Homicide Icon35px.png"));
                    else if (crimeReport.CrimeName.Contains("Intimidation"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Intimidation Icon35px.png"));
                    else if (crimeReport.CrimeName.Contains("Liquor"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Liquor Law Violation Icon35px.png"));
                    else if (crimeReport.CrimeName.Contains("Motor"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Motor Vehicle Theft Icon35px.png"));
                    else if (crimeReport.CrimeName.Contains("Stolen"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Stolen Property Icon35px.png"));
                    else if (crimeReport.CrimeName.Contains("Rob"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Robbery Icon35px.png"));
                    else if (crimeReport.CrimeName.Contains("Telephone"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Telephone Harassment Icon35px.png"));
                    else if (crimeReport.CrimeName.Contains("Theft"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Theft Icon35px.png"));
                    else if (crimeReport.CrimeName.Contains("Vandalism"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Vandalism Icon35px.png"));
                    else if (crimeReport.CrimeName.Contains("Warrant"))
                        crimeReport.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/Warrant Icon35px.png"));
                });
                watch.Stop();
                Debug.WriteLine($"report {watch.ElapsedMilliseconds.ToString()}");
                return crimeReports;
            }
            catch (SqlException eSql)
            {
                Debug.WriteLine(eSql.Message, "report message");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return crimeReports;
        }
    }
}

