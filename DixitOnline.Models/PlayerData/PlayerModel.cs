using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DixitOnline.Models.PlayerData
{
    [Table("Players")]
    public class PlayerModel
    {
        [Key]
        public int PlayerId { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }
    }
}
