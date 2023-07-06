namespace SIP.PokemonProject.BL.Models
{
    public class Trainer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
        public string TrainerClass { get; set; }
        public List<Pokemon> Team { get; set; }
    }
}