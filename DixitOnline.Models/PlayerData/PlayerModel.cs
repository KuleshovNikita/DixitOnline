﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DixitOnline.Models.PlayerData
{
    [Table("Players")]
    public class PlayerModel
    {
        public int PlayerId { get; set; }

        public string Name { get; set; }

        public string Room { get; set; }

        public int GameScore { get; set; }
    }
}
