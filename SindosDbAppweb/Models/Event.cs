using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace SindosDbAppweb.Models
{
    public class Event
    {
        

        [Key]
        public int Id { get; set; }
        [DisplayName("Ημερομηνία")]
        public DateTime Hmnia { get; set; } = DateTime.UtcNow;
        [DisplayName("Περιγραφή")]
        public string Description { get; set; }
        [DisplayName("Περιοχή")]
        public string Region { get; set; }
        [DisplayName("Στο Εξωτερικό")]
        
        public int Abroad { get; set; }
        [DisplayName("Διέυθυνση Ιστοσελίδας")]
        public string Url { get ; set; }
        [DisplayName("Σχόλια")]
        public string Sxolia { get; set; }

    }
}
