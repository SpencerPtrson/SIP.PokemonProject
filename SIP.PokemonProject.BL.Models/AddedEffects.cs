namespace SIP.PokemonProject.BL.Models
{
    public class AddedEffect
    {
        public Guid Id { get; set; }
        public Guid MoveId { get; set; }
        public string Effect { get; set; }
        public int Chance { get; set; }
    }
}