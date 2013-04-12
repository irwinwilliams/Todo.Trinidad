using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;



using GART;
using GART.Controls;
using GART.Data;

using System.Collections.ObjectModel;

using System.Device.Location;
using ServiceStack.Text;



namespace Todo.TnT
{

    public partial class MainPage : PhoneApplicationPage
    {

        private ObservableCollection<ARItem> locationsTvrda;
        private string poiurl = "http://samples.anandcsingh.com/todotnt/data/tntpois.js";
        public WebClient poisService { get; set; }


        public MainPage()
        {

            InitializeComponent();
            locationsTvrda = new ObservableCollection<ARItem>();
            poisService = new WebClient();
            poisService.DownloadStringCompleted += poisService_DownloadStringCompleted;
            poisService.DownloadStringAsync(new System.Uri(poiurl));
        }

        void poisService_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            locationsTvrda.Add(new InterestingPlace()

            {

                GeoLocation = new GeoCoordinate(10.525764, -61.361553),

                Content = "Wild Horses",

                Description = "There are wild horses here"

            });
            var fromJson = JsonSerializer.DeserializeFromString<List<ItemDescription>>(e.Result);
            var results = (from item in fromJson
                           where item != null
                           select new InterestingPlace()
                           {
                               Content = item.name,
                               Description= item.description,
                               GeoLocation = new GeoCoordinate(item.lat, item.@long, 0)
                               
                           });
            foreach (var item in results)
            {
                locationsTvrda.Add(item);
            }
        }



        private void GetData()
        {

            locationsTvrda.Add(new InterestingPlace()

            {

                GeoLocation = new GeoCoordinate(10.525764, -61.361553),

                Content = "Wild Horses",

                Description = "There are wild horses here"

            });





            ardisplay.ARItems = locationsTvrda;

        }



        private void threeDButton_Click(object sender, EventArgs e)
        {

            UIHelper.ToggleVisibility(worldView);

        }



        private void headingButton_Click(object sender, EventArgs e)
        {

            UIHelper.ToggleVisibility(headingIndicator);

        }



        private void mapButton_Click(object sender, EventArgs e)
        {

            //  UIHelper.ToggleVisibility(overheadMap);

        }



        private void rotateDButton_Click(object sender, EventArgs e)
        {

            SwitchHeadingMode();

        }



        private void SwitchHeadingMode()
        {

            if (headingIndicator.RotationSource == RotationSource.AttitudeHeading)
            {

                headingIndicator.RotationSource = RotationSource.North;

                //overheadMap.RotationSource = RotationSource.AttitudeHeading;

            }

            else
            {

                //overheadMap.RotationSource = RotationSource.North;

                headingIndicator.RotationSource = RotationSource.AttitudeHeading;

            }

        }



        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {

            ardisplay.StartServices();

            base.OnNavigatedTo(e);

        }



        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {

            ardisplay.StopServices();

            base.OnNavigatedFrom(e);

        }

    }

}