namespace SIP.PokemonProject.BL.Models
{
    public struct StatChanges
    {
        public const double Neg6 = 1 / 4;
        public const double Neg5 = 2 / 7;
        public const double Neg4 = 1 / 3;
        public const double Neg3 = 2 / 5;
        public const double Neg2 = 1 / 2;
        public const double Neg1 = 2 / 3;
        public const double Neutral = 0;
        public const double Pos1 = 3 / 2;
        public const double Pos2 = 2;
        public const double Pos3 = 5 / 2;
        public const double Pos4 = 3;
        public const double Pos5 = 7 / 2;
        public const double Pos6 = 4;
    }


    public class Pokemon
    {
        public Guid Id { get; set; }
        public Guid Type1 { get; set; }
        public Guid Type2 { get; set; }
        public Guid SpeciesId { get; set; }
        public Guid NatureId { get; set; }
        public Guid AbilityId { get; set; }
        public Guid? ItemId { get; set; }
        public bool IsShiny { get; set; }
        public string? Nickname { get; set; }
        public int Level { get; set; }
        public string? MajorStatus { get; set; }

        public List<Move> Moves { get; set; }


        // Get Base-Stats from Database then add modifiers
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }

        public int HPIV { get; set; }
        public int AttackIV { get; set; }
        public int DefenseIV { get; set; }
        public int SpecialAttackIV { get; set; }
        public int SpecialDefenseIV { get; set; }
        public int SpeedIV { get; set; }

        public int HPEV { get; set; }
        public int AttackEV { get; set; }
        public int DefenseEV { get; set; }
        public int SpecialAttackEV { get; set; }
        public int SpecialDefenseEV { get; set; }
        public int SpeedEV { get; set; }
    }
}