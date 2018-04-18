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
        private static string JsonFile = "test.json";
        private string defaultImage = "ms-appx:///Images/cardcover.jpg";
        private List<Card> myList = new List<Card>();
        private List<Card> p1Hand = new List<Card>();
        private List<Card> p2Hand = new List<Card>();
        private Random rnd = new Random();

        public MainPage()
        {
            this.InitializeComponent();
            collection = new ObservableCollection<Card>();
            this.DataContext = this;

        }
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            //text1.Text = "Click event occurs on Hover.";
            Deal();
        }

        public void Deal()
        {
            int p1 = 0;
            int p2 = 0;
            int[] p1Cards = new int[5];
            int[] p2Cards = new int[5];

            
            

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
        List<Card> CreateCardList()
        {
            using (StreamReader r = File.OpenText("test.json"))
            {
                string json = r.ReadToEnd();
                myList = JsonConvert.DeserializeObject<List<Card>>(json);
               // Debug.WriteLine(json);
            }


            return myList;
        }

        #endregion
        #region PlayersTurn
        private void Round1(int[] p1Cards, int[] p2Cards, List<Card> myList)
        {
            int p1Score;
            int p2Score;
            int turn = 0;
            int t = 0;
            int i = 0;
            Debug.WriteLine("size"  + myList.Count);
            #region Display cards in myList
            Debug.WriteLine("  ");
            Debug.WriteLine("Cards Read in From Json ");
            foreach (Card card in myList)
             {
                 Debug.WriteLine("  " );
                 Debug.WriteLine("Card: " + t);
                 Debug.WriteLine("ID: " + card.Id );
                 Debug.WriteLine("Art: " + card.art);
                 Debug.WriteLine("Faction: " + card.faction);
                 Debug.WriteLine("Name: " + card.name);
                 Debug.WriteLine("Positions: " + card.positions);
                 Debug.WriteLine("Strength: " + card.strength);
                t++;

             }
            #endregion
            /*while runs 5 times and adds 5 cards from the lsit to each players hand*/
            while (i != 5)
            {
                foreach (Card card in myList)
                {
                    if (card.Id == p1Cards[i])
                    {
                        var moveCard = myList[i];
                        // myList.RemoveAt(i);
                        p1Hand.Add(card);
                        
                    }

                }
                foreach (Card card in myList)
                {
                    if (card.Id == p2Cards[i])
                    {
                        var moveCard = myList[i];
                        // myList.RemoveAt(i);
                        p2Hand.Add(card);

                    }

                }
                i++;
            }
            #region Print Hands to Debug
            Debug.WriteLine("  ");
            Debug.WriteLine("P1 Hand  ");
            foreach (Card card in p1Hand)
            {

                Debug.WriteLine("  ");
                Debug.WriteLine("Card: " + t);
                Debug.WriteLine("ID: " + card.Id);
                Debug.WriteLine("Art: " + card.art);
                Debug.WriteLine("Faction: " + card.faction);
                Debug.WriteLine("Name: " + card.name);
                Debug.WriteLine("Positions: " + card.positions);
                Debug.WriteLine("Strength: " + card.strength);
                t++;
            }
            Debug.WriteLine("  ");
            Debug.WriteLine("P2 Hand  ");
            foreach (Card card in p2Hand)
            {

                Debug.WriteLine("  ");
                Debug.WriteLine("Card: " + t);
                Debug.WriteLine("ID: " + card.Id);
                Debug.WriteLine("Art: " + card.art);
                Debug.WriteLine("Faction: " + card.faction);
                Debug.WriteLine("Name: " + card.name);
                Debug.WriteLine("Positions: " + card.positions);
                Debug.WriteLine("Strength: " + card.strength);
                t++;
            }
            #endregion
            DisplayHand(p1Hand,p2Hand);
            if (turn == 0)
            {
                for ( i = 0; i == 5; i++)
                {



                }//for end

                turn = 1;

            }//p1Turn end
            if (turn == 1)
            {
                //p2turn goes here
                turn = 0;
            }//p2turn
        }
        public ObservableCollection<Card> collection { get; set; }
        private void DisplayHand(List<Card> p1Hand, List<Card> p2Hand)
        {

            foreach (Card card in p1Hand)
            {
                //var source = card.art;
                
                collection.Add(card);
               
            }

            cardArt.ItemsSource = collection;
        }
        private void Card_Tapped(object sender, TappedRoutedEventArgs e)
        {
            String postion = "test";
            if (postion.Equals("Siege"))
            {

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
