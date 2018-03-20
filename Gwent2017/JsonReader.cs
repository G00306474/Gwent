using System.Runtime.Serialization;

namespace Gwent2017
{
    [DataContract]
    public class GwentCards
    {
        private string _code = string.Empty;
        [DataMember]
        public string name
        {
            get;
            set;
        }
        [DataMember]
        public string faction
        {
            get;
            set;
        }
        [DataMember]
        public string positions
        {
            get;
            set;
        }
        [DataMember]
        public int strength
        {
            get;
            set;
        }
        [DataMember]
        public string art
        {
            get;
            set;
        }
    }
}