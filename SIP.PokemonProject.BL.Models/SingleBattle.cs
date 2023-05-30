namespace SIP.PokemonProject.BL.Models
{
    public class SingleBattle
    {
        public Guid Id { get; set; }
        public Trainer Player { get; set; }
        public Trainer Opponent { get; set; }
        public int TurnCount { get; set; }
        public Weather? currentWeather { get; set; }
        public Field? currentField { get; set; }
        public Pokemon playerActivePokemon { get; set; }
        public Pokemon opponentActivePokemon { get; set; }
    }
}