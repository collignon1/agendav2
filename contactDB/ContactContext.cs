using System;
using System.Collections.Generic;
using agendav2.model;
using Microsoft.EntityFrameworkCore;

namespace agendav2.contactDB;

public partial class ContactContext : DbContext
{
    private readonly string _connectionString;
    private readonly ConnectionString_Manager _connectionStringManager;
    public ContactContext()
    {
        _connectionStringManager = new ConnectionString_Manager();
    }

    public ContactContext(DbContextOptions<ContactContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<RéseauxSociaux> RéseauxSociauxes { get; set; }

    public virtual DbSet<Tache> Taches { get; set; }

    public virtual DbSet<ToDoList> ToDoLists { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySql("server=172.31.254.148;port=3306;user=su;password=1;database=contact", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.23-mariadb"));

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(_connectionStringManager.ConString, ServerVersion.AutoDetect(_connectionStringManager.ConString));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Idcontact).HasName("PRIMARY");

            entity.ToTable("contact");

            entity.Property(e => e.Idcontact)
                .HasColumnType("int(11)")
                .HasColumnName("idcontact");
            entity.Property(e => e.Birth).HasColumnName("birth");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("last name");
            entity.Property(e => e.Mail)
                .HasMaxLength(45)
                .HasColumnName("mail");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(45)
                .HasColumnName("phone_number");
            entity.Property(e => e.Sex)
                .HasColumnType("enum('H','F')")
                .HasColumnName("sex");
            entity.Property(e => e.Status)
                .HasColumnType("enum('AMI','COLLEGUE','FAMILLE','AUTRE')")
                .HasColumnName("status");

            entity.HasMany(d => d.RéseauxSociauxIdréseauxSociauxes).WithMany(p => p.ContactIdcontacts)
                .UsingEntity<Dictionary<string, object>>(
                    "ContactHasRéseauxSociaux",
                    r => r.HasOne<RéseauxSociaux>().WithMany()
                        .HasForeignKey("RéseauxSociauxIdréseauxSociaux")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_contact_has_réseaux sociaux_réseaux sociaux1"),
                    l => l.HasOne<Contact>().WithMany()
                        .HasForeignKey("ContactIdcontact")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_contact_has_réseaux sociaux_contact1"),
                    j =>
                    {
                        j.HasKey("ContactIdcontact", "RéseauxSociauxIdréseauxSociaux")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("contact_has_réseaux sociaux");
                        j.HasIndex(new[] { "ContactIdcontact" }, "fk_contact_has_réseaux sociaux_contact1_idx");
                        j.HasIndex(new[] { "RéseauxSociauxIdréseauxSociaux" }, "fk_contact_has_réseaux sociaux_réseaux sociaux1_idx");
                        j.IndexerProperty<int>("ContactIdcontact")
                            .HasColumnType("int(11)")
                            .HasColumnName("contact_idcontact");
                        j.IndexerProperty<int>("RéseauxSociauxIdréseauxSociaux")
                            .HasColumnType("int(11)")
                            .HasColumnName("réseaux sociaux_idréseaux sociaux");
                    });
        });

        modelBuilder.Entity<RéseauxSociaux>(entity =>
        {
            entity.HasKey(e => e.IdréseauxSociaux).HasName("PRIMARY");

            entity.ToTable("réseaux sociaux");

            entity.Property(e => e.IdréseauxSociaux)
                .HasColumnType("int(11)")
                .HasColumnName("idréseaux sociaux");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(45)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<Tache>(entity =>
        {
            entity.HasKey(e => e.Idtache).HasName("PRIMARY");

            entity.ToTable("tache");

            entity.HasIndex(e => e.ToDoListIdtoDo, "fk_task_to do list1_idx");

            entity.Property(e => e.Idtache)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("idtache");
            entity.Property(e => e.Check)
                .HasColumnType("enum('YES','NO')")
                .HasColumnName("check");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.ToDoListIdtoDo)
                .HasColumnType("int(11)")
                .HasColumnName("to do list_idto do");

            entity.HasOne(d => d.ToDoListIdtoDoNavigation).WithMany(p => p.Taches)
                .HasForeignKey(d => d.ToDoListIdtoDo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_task_to do list1");
        });

        modelBuilder.Entity<ToDoList>(entity =>
        {
            entity.HasKey(e => e.IdtoDo).HasName("PRIMARY");

            entity.ToTable("to do list");

            entity.Property(e => e.IdtoDo)
                .HasColumnType("int(11)")
                .HasColumnName("idto do");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end date");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
