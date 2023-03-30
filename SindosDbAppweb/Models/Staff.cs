using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Drawing;

namespace SindosDbAppweb.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        [DisplayName ("Ημερομηνία Έναρξης")]
        public DateTime HmniaStart { get; set;} = DateTime.Now;
        [DisplayName("Ονοματεπώνυμο")]
        public string Onomateponimo { get; set;}    
        public int TypeId { get; set; }
        [DisplayName("Αριθμός Δελτίου Ταυτότητας")]
        public string ADT { get; set; }
        [DisplayName("ΑΜΚΑ")]
        public string AMKA { get; set; }
        [DisplayName("Αριθμός φορολογικού μητρώου")]
        public string AFM { get; set; }
        [DisplayName("Σταθερό Τηλέφωνο")]
        public string PhoneHome { get; set; }
        [DisplayName("Τηλέφωνο Εργασίας")]
        public string PhoneJob { get; set; }
        [DisplayName("Κινητό Τηλέφωνο")]
        public string MobilePhone { get; set; }
        [DisplayName("Ιστοσελίδα")]
        public string Web { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Δεύτερο Email")]
        public string Email2 { get; set; }
        [DisplayName("Διεύθυνση")]
        public string Address { get; set; }
        [DisplayName("Πόλη")]
        public string Town { get; set; }
        [DisplayName("Ταχυδρομικός Κώδικας")]
        public string ZipCode { get; set; }
        [DisplayName("Ημερομηνία Έναρξης ΦΕΚ")]
        public DateTime Fek_Start { get; set; } = DateTime.Now;
        [DisplayName("Επιστημονικό Αντικείμενο")]
        public string Scientific_Object { get; set; }
        [DisplayName("Αντικείμενο ΦΕΚ")]
        public string Fek_Object { get; set; }
        [DisplayName("ΙΒΑΝ")]
        public string IBAN { get; set; }
        [DisplayName("Σημείωση HTML")]
        public string HtmlNote { get; set; }
        [DisplayName("Σχόλια")]
        public string Sxolia { get; set; }

    }
}
