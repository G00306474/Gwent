using System.Collections.Generic;
using System.Runtime.Serialization;


public class Card
{
   // internal static object card;

    public int Id { get; set; }
    public string art { get; set; }
    public string faction { get; set; }
    public string name { get; set; }
    public string positions { get; set; }
    public int strength { get; set; }
}

public class RootObject
{
    public List<Card> Cards { get; set; }
}