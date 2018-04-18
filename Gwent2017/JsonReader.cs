using System.Collections.Generic;
using System.Runtime.Serialization;

class clsCards
{
    public class Card
    {
        public int Id { get; set; }
        public string art { get; set; }
        public string faction { get; set; }
        public string name { get; set; }
        public string positions { get; set; }
        public int strength { get; set; }
    }

    public class RootObject
    {
        public List<Card> cards { get; set; }
    }
}