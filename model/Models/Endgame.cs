using System.ComponentModel.DataAnnotations;

namespace model.Models
{
    public class Endgame
    {  [Key]
        public int Id { get; set; } 
        public string Name { get; set; }   
        public int NoOfKills { get; set; }
    }
}
