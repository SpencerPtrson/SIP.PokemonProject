using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SIP.PokemonProject.PL;

public partial class PokemonEntities : DbContext
{
    public PokemonEntities()
    {
    }

    public PokemonEntities(DbContextOptions<PokemonEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<tblAbility> tblAbilities { get; set; }

    public virtual DbSet<tblAddedAffect> tblAddedAffects { get; set; }

    public virtual DbSet<tblItem> tblItems { get; set; }

    public virtual DbSet<tblMajorStatus> tblMajorStatuses { get; set; }

    public virtual DbSet<tblMove> tblMoves { get; set; }

    public virtual DbSet<tblNature> tblNatures { get; set; }

    public virtual DbSet<tblPokedex> tblPokedices { get; set; }

    public virtual DbSet<tblPokemon> tblPokemons { get; set; }

    public virtual DbSet<tblPokemonTeam> tblPokemonTeams { get; set; }

    public virtual DbSet<tblSpeciesAbility> tblSpeciesAbilities { get; set; }

    public virtual DbSet<tblTrainer> tblTrainers { get; set; }

    public virtual DbSet<tblType> tblTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SIP.PokemonProject.DB;Integrated Security=true");
        optionsBuilder.UseLazyLoadingProxies();
    }
    // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tblAbility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblAbili__3214EC075D09A386");

            entity.ToTable("tblAbility");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblAddedAffect>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblAdded__3214EC079207C527");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Effect)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblItem__3214EC07882DAE18");

            entity.ToTable("tblItem");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblMajorStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblMajor__3214EC07C83122F5");

            entity.ToTable("tblMajorStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.StatusIcon).HasColumnType("image");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblMove>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblMove__3214EC07CC28CF2A");

            entity.ToTable("tblMove");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Target)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Type).WithMany(p => p.tblMoves)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tblMove_TypeId");
        });

        modelBuilder.Entity<tblNature>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblNatur__3214EC07B8075370");

            entity.ToTable("tblNature");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatDecreased)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.StatIncreased)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblPokedex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblPoked__3214EC077331EE46");

            entity.ToTable("tblPokedex");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.SpeciesName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SpriteName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Type1).WithMany(p => p.tblPokedexType1s)
                .HasForeignKey(d => d.Type1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tblPokedex_Type1Id");

            entity.HasOne(d => d.Type2).WithMany(p => p.tblPokedexType2s)
                .HasForeignKey(d => d.Type2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tblPokedex_Type2Id");
        });

        modelBuilder.Entity<tblPokemon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblPokem__3214EC079E7EF408");

            entity.ToTable("tblPokemon");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nickname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Ability).WithMany(p => p.tblPokemons)
                .HasForeignKey(d => d.AbilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tblPokemon_AbilityId");

            entity.HasOne(d => d.Item).WithMany(p => p.tblPokemons)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("fk_tblPokemon_ItemId");

            entity.HasOne(d => d.Nature).WithMany(p => p.tblPokemons)
                .HasForeignKey(d => d.NatureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tblPokemon_NatureId");

            entity.HasOne(d => d.Species).WithMany(p => p.tblPokemons)
                .HasForeignKey(d => d.SpeciesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tblPokemon_SpeciesId");

            entity.HasOne(d => d.Type1).WithMany(p => p.tblPokemonType1s)
                .HasForeignKey(d => d.Type1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tblPokemon_Type1Id");

            entity.HasOne(d => d.Type2).WithMany(p => p.tblPokemonType2s)
                .HasForeignKey(d => d.Type2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tblPokemon_Type2Id");
        });

        modelBuilder.Entity<tblPokemonTeam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblPokem__3214EC0763838CA5");

            entity.ToTable("tblPokemonTeam");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Pokemon).WithMany(p => p.tblPokemonTeams)
                .HasForeignKey(d => d.PokemonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tblPokemonTeam_PokemonId");

            entity.HasOne(d => d.Trainer).WithMany(p => p.tblPokemonTeams)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tblPokemonTeam_TrainerId");
        });

        modelBuilder.Entity<tblSpeciesAbility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblSpeci__3214EC079C49C5DF");

            entity.ToTable("tblSpeciesAbility");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<tblTrainer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblTrain__3214EC076BF33CED");

            entity.ToTable("tblTrainer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblType__3214EC077F2BD52F");

            entity.ToTable("tblType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TypeIcon).HasColumnType("image");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
