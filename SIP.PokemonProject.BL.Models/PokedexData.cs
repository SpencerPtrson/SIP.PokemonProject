using System.ComponentModel;

namespace SIP.PokemonProject.BL.Models
{
    public class PokedexData
    {
        public Guid SpeciesId { get; set; }
        public int PokedexNum { get; set; }
        [DisplayName("Species")]
        public string SpeciesName { get; set; }
        public string SpritePath { get; set; }

        public int BaseHP { get; set; }
        public int BaseAttack { get; set; }
        public int BaseDefense { get; set; }
        public int BaseSpecialAttack { get; set; }
        public int BaseSpecialDefense { get; set; }
        public int BaseSpeed { get; set; }

        public Guid Type1Id { get; set; }
        public Guid Type2Id { get; set; }

        [DisplayName("Type 1")]
        public string Type1Name { get; set; }
        [DisplayName("Type 2")]
        public string Type2Name { get; set;}

        public string FlavorText { get; set; }
    }
}