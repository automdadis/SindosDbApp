using System.ComponentModel;

namespace SindosDbAppweb.Models
{
    public class Sex
    {
        public int Id { get; set; }
        [DisplayName("Φύλο")]
        public string Name { get; set; }
    }
}
