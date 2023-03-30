using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace SindosDbAppweb.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Κωδικός")]
        public string Kod { get; set; }
        [DisplayName("Ονοματεπώνυμο")]
        public string Onomateponimo { get; set; }
        public int TypeId { get; set; }
        [DisplayName("Επώνυμο")]
        public string Eponimo { get; set; }
        [DisplayName("Όνομα")]
        public string Onoma { get; set; }
        [DisplayName("Πατρώνυμο")]
        public string Patronimo { get; set; }
        [DisplayName("Μητρώνυμο")]
        public string Mitronimo { get; set; }
        [DisplayName("Ημερομηνία Γέννησης")]
        public DateTime BirthYear { get; set; } = DateTime.Now;
        [DisplayName("Φύλο")]
        public string Sex {get; set;}
        [DisplayName("Αριθμός Ταυτότητας")]
        public string IdCart { get; set;}
        [DisplayName("Αριθμός φορολογικού μητρώου")]
        public string AFM { get; set; }
        [DisplayName("Πόλη")]
        public string Town { get; set; }
        [DisplayName("Ταχυδρομικός κώδικας")]
        public string ZipCode { get; set; }
        [DisplayName("Σταθερό Τηλέφωνο")]
        public string PhoneHome { get; set; }
        [DisplayName("Τηλέφωνο Εργασίας")]
        public string PhoneJob { get; set; }
        [DisplayName("Κινητό Τηλέφωνο")]
        public string MobilePhone { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Από Σχολείο")]
        public string FromSchool { get; set; }
        [DisplayName("Προσανατολισμός")]
        public string Orientation { get; set; }
        [DisplayName("Αριθμός Επιλογής")]
        public int ChoiceNumber { get; set; }
        [DisplayName("Αριθμός Κατάταξης")]
        public int RankNumber { get; set; }
        [DisplayName("ID Πανελλαδικών")]
        public string IdPaneladikes { get; set; }
        [DisplayName("Μόρια")]
        public int Moria { get; set; }
        [DisplayName("Ημερομηνία Εγγραφής")]
        public DateTime YearRegistry { get; set; } = DateTime.Now;
        [DisplayName("ΙΒΑΝ")]
        public string IBAN { get; set; }
        [DisplayName("Σημειώσεις HTML")]
        public string HtmlNote { get; set; }
        [DisplayName("Σχόλια")]
        public string Sxolia { get; set; }


    }
}
