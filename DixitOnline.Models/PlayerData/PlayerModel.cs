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
        [MinLength(1)]
        public string Name { get; set; }

        public int Room { get; set; }

        public int GameScore { get; set; }
    }
}
