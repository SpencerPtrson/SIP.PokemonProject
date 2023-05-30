namespace SIP.PokemonProject.BL.Models
{
    public class Move
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TypeId { get; set; }
        public string TypeName { get; set; }
        public string Category { get; set; }
        public int normalPP { get; set; }
        public int maxPP { get; set; }
        public int? BasePower { get; set; }
        public int? Accuracy { get; set; }
        public int Priority { get; set; }
        public string Target { get; set; }
        public float CritRate { get; set; }
    }
}