using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;

namespace SindosDbAppweb.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Τυπος")]
        public int Type { get; set; }
        [Required]
        [DisplayName("Τίτλος")]
        public string? Title { get; set; }
        [DisplayName("Ημερομηνία 'Εναρξης")]
        public DateTime Apo { get; set; } = DateTime.Now;
        [DisplayName("Ημερομηνία Λήξης")]
        public DateTime Eos { get; set; } = DateTime.Today;
        [DisplayName("Ποσό Χρηματοδότησης")]
        [Range(0,20000)]
        public int Amount { get; set; }
        [DisplayName("Όνομα Χρηματοδότη")]
        public string WhoFund { get; set; }
        [DisplayName("Περιοχή")]
        public int Abroad { get; set; }
        [DisplayName("Url Ιστοσελίδας")]
        public string url { get; set; }
        [DisplayName("Σχόλια")]
        public string Sxolia { get; set; }

    }
}
