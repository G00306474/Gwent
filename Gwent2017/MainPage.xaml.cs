using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Gwent2017
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        

        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name == "button") { Deal(); }
            if (Name == "button1") {  }
            if (Name == "button2") {  }
        }
        public void Deal()
        {

            string FilePath = Path.Combine(Package.Current.InstalledLocation.Path, "test.json");
            using (StreamReader file = File.OpenText(FilePath))
            {
                var json = file.ReadToEnd();
                Dictionary<string, object> result = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                string contacts = result["test"].ToString();
                List<GwentCards> objResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GwentCards>>(contacts);
                gwentJsonCardTester.ItemsSource = objResponse;
            }
        } 
    }//close mainpage
}
