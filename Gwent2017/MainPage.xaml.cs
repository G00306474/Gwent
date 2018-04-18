using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Data.Json;
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
using System.Diagnostics;
using Windows.UI;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Gwent2017
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string defaultImage = "ms-appx:///Images/cardcover.jpg";
        private List<clsCards> myList = new List<clsCards>();

        public MainPage()
        {
            this.InitializeComponent();
           
        }
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("TEST");
            
            //text1.Text = "Click event occurs on Hover.";
            Deal();
        }
        public void Deal()
        {
            int p1 = 0;
            int p2 = 0;
            int[] p1Cards = new int[5];
            int[] p2Cards = new int[5];
            
            Random rnd = new Random();
            
            while (p1 != 5)
            {
                p1Cards[p1] = rnd.Next(1, 5);
                p1++;
            }

            while (p2 != 5)
            {
                p2Cards[p2] = rnd.Next(1, 5);
                p2++;
            }

            CreateCardList();

            Round1(p1Cards, p2Cards, myList);
        }

   
        #region Json array
        private List<clsCards>  CreateCardList()
        {


            string FilePath = Path.Combine(Package.Current.InstalledLocation.Path, "test.json");

            using (StreamReader file = File.OpenText(FilePath))
            {


                var json = file.ReadToEnd();
                var result = JsonConvert.DeserializeObject<RootObject>(json);
                Debug.WriteLine(result.ToString());//wirte json to console 

               //var teseter= result.
            }

            return myList;
        }
        #endregion
        #region PlayersTurn
        private void Round1(int[] p1Cards, int[] p2Cards,List<clsCards> myList)
        {
            int p1Score;
            int p2Score;
            int turn = 0;
            Debug.WriteLine(myList.Count);
            foreach (clsCards card in myList) {
              //  Debug.WriteLine("Tester"+card.name);
            }
            
           // P1Hand = myList[3];
            //int id = 101;
           // var cardToFind = myList.FirstOrDefault(card => card.Id.Any(id => id.P1Hand[i] == idToFind));

            if (turn == 0)
            {
                for (int i = 0; i == 5; i++)
                {

                    

                }//for end

                turn = 1;
               
            }//p1Turn end
            if (turn == 1) {
            //p2turn goes here
                turn = 0;
            }//p2turn
        }
        private void Card_Tapped(object sender, TappedRoutedEventArgs e)
        {
            String postion="test";
            if (postion.Equals("Siege")) {

                P1RowRange.Background = new SolidColorBrush(Colors.Yellow);
                //P1RowRange.Tapped = 
            }
            if (postion.Equals("Range"))
            {
                P1RowRange.Background = new SolidColorBrush(Colors.Yellow); 
            }
            if (postion.Equals("Combat"))
            {
                P1RowRange.Background = new SolidColorBrush(Colors.Yellow); 
            }
        }
        #endregion
    }//close mainpage
}
