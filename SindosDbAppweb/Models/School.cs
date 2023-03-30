using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SindosDbAppweb.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Είδος")]

        public string Name { get; set; }
        [DisplayName("Περιοχή")]
        public string Region { get; set; }
    }
}
