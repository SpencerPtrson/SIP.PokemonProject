namespace SIP.PokemonProject.BL.Models
{
    public class PokedexData
    {
        public Guid SpeciesId { get; set; }
        public int PokedexNum { get; set; }
        public string SpeciesName { get; set; }
        public Guid Type1Id { get; set; }
        public Guid Type2Id { get; set; }

        public int BaseHP { get; set; }
        public int BaseAttack { get; set; }
        public int BaseDefense { get; set; }
        public int BaseSpecialAttack { get; set; }
        public int BaseSpecialDefense { get; set; }
        public int BaseSpeed { get; set; }

        public string SpritePath { get; set; }
    }
}