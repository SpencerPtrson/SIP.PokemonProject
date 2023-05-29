namespace SIP.PokemonProject.BL.Models
{
    public class Type
    {
        public Guid Id { get; set; }
        public string TypeName { get; set; }
        public byte[]? TypeIcon { get; set; }
    }
}