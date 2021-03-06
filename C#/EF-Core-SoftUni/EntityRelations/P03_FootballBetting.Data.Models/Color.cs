using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        public Color()
        {
            PrimaryColorsTeams = new HashSet<Team>();
            SecondaryColorsTeams = new HashSet<Team>();

        }
        [Key]
        public int ColorId { get; set; }

        public string Name { get; set; }

        [InverseProperty(nameof(Team.PrimaryKitColor))]
        public ICollection<Team> PrimaryColorsTeams { get; set; }

        [InverseProperty(nameof(Team.SecondaryKitColor))]
        public ICollection<Team> SecondaryColorsTeams { get; set; }
    }
}
