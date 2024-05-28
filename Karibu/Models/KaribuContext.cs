using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Karibu.Models
{
    public partial class KaribuContext : DbContext
    {
        public KaribuContext()
        {
        }

        public KaribuContext(DbContextOptions<KaribuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Affectation> Affectations { get; set; } = null!;
        public virtual DbSet<Categorie> Categories { get; set; } = null!;
        public virtual DbSet<Commune> Communes { get; set; } = null!;
        public virtual DbSet<Contributeur> Contributeurs { get; set; } = null!;
        public virtual DbSet<Cotation> Cotations { get; set; } = null!;
        public virtual DbSet<Demande> Demandes { get; set; } = null!;
        public virtual DbSet<Filiere> Filieres { get; set; } = null!;
        public virtual DbSet<Organe> Organes { get; set; } = null!;
        public virtual DbSet<Pay> Pays { get; set; } = null!;
        public virtual DbSet<Prolongement> Prolongements { get; set; } = null!;
        public virtual DbSet<Stage> Stages { get; set; } = null!;
        public virtual DbSet<Stagiaire> Stagiaires { get; set; } = null!;
        public virtual DbSet<StatutUniversite> StatutUniversites { get; set; } = null!;
        public virtual DbSet<Sujet> Sujets { get; set; } = null!;
        public virtual DbSet<TypeInstitut> TypeInstituts { get; set; } = null!;
        public virtual DbSet<TypeOrgane> TypeOrganes { get; set; } = null!;
        public virtual DbSet<Universite> Universites { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0SHHCUS\\SQLEXPRESS;Initial Catalog=Karibu;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Affectation>(entity =>
            {
                entity.HasKey(e => e.IdAffectation)
                    .HasName("PK__Affectat__4E1F7C0A915B62D5");

                entity.ToTable("Affectation");

                entity.Property(e => e.IdAffectation).HasColumnName("ID_AFFECTATION");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.DateAcceptation)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_ACCEPTATION");

                entity.Property(e => e.EstAccepte).HasColumnName("EST_ACCEPTE");

                entity.Property(e => e.IdDirection)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ID_DIRECTION")
                    .IsFixedLength();

                entity.Property(e => e.IdStagiaire).HasColumnName("ID_STAGIAIRE");

                entity.HasOne(d => d.IdDirectionNavigation)
                    .WithMany(p => p.Affectations)
                    .HasForeignKey(d => d.IdDirection)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Affectation_ORGANE");

                entity.HasOne(d => d.IdStagiaireNavigation)
                    .WithMany(p => p.Affectations)
                    .HasForeignKey(d => d.IdStagiaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Affectation_Stagiaire");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.IdCategorie)
                    .HasName("PK__Categori__4BD51FA1760596C5");

                entity.ToTable("Categorie");

                entity.Property(e => e.IdCategorie).HasColumnName("ID_CATEGORIE");

                entity.Property(e => e.Domaine)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("DOMAINE");
            });

            modelBuilder.Entity<Commune>(entity =>
            {
                entity.HasKey(e => e.IdCommune);

                entity.ToTable("Commune_");

                entity.Property(e => e.IdCommune).HasColumnName("ID_COMMUNE");

                entity.Property(e => e.NomCommune)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOM_COMMUNE");
            });

            modelBuilder.Entity<Contributeur>(entity =>
            {
                entity.ToTable("Contributeur");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Genre)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.NomComplet).HasMaxLength(75);

                entity.Property(e => e.Promotion).HasMaxLength(50);

                entity.Property(e => e.Surnom).HasMaxLength(10);

                entity.Property(e => e.Universite).HasMaxLength(75);
            });

            modelBuilder.Entity<Cotation>(entity =>
            {
                entity.HasKey(e => e.IdCotation)
                    .HasName("PK__Cotation__4F5BEEDA56BFFD82");

                entity.ToTable("Cotation");

                entity.Property(e => e.IdCotation).HasColumnName("ID_COTATION");

                entity.Property(e => e.Commentaire)
                    .HasMaxLength(450)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTAIRE");

                entity.Property(e => e.Cooperation)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("COOPERATION");

                entity.Property(e => e.DateEnregistrement)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_ENREGISTREMENT");

                entity.Property(e => e.Discipline)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("DISCIPLINE");

                entity.Property(e => e.Generale)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("GENERALE");

                entity.Property(e => e.IdStage).HasColumnName("ID_STAGE");

                entity.Property(e => e.Organisation)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("ORGANISATION");

                entity.Property(e => e.Perfectionnement)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PERFECTIONNEMENT");

                entity.Property(e => e.Presentation)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PRESENTATION");

                entity.Property(e => e.QualiteTravail)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("QUALITE_TRAVAIL");

                entity.Property(e => e.QuantiteTravail)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("QUANTITE_TRAVAIL");

                entity.Property(e => e.Regularite)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("REGULARITE");

                entity.HasOne(d => d.IdStageNavigation)
                    .WithMany(p => p.Cotations)
                    .HasForeignKey(d => d.IdStage)
                    .HasConstraintName("FK_Cotation_Stage");
            });

            modelBuilder.Entity<Demande>(entity =>
            {
                entity.HasKey(e => e.IdDemande)
                    .HasName("PK__Demande__1916219E1EB0118A");

                entity.ToTable("Demande");

                entity.Property(e => e.IdDemande).HasColumnName("ID_DEMANDE");

                entity.Property(e => e.AdresseDomicile)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ADRESSE_DOMICILE");

                entity.Property(e => e.AdresseUniversite)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ADRESSE_UNIVERSITE");

                entity.Property(e => e.DateNaissance)
                    .HasColumnType("date")
                    .HasColumnName("DATE_NAISSANCE");

                entity.Property(e => e.Filliere)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("FILLIERE");

                entity.Property(e => e.FonctionContact)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FONCTION_CONTACT");

                entity.Property(e => e.Genre)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GENRE")
                    .IsFixedLength();

                entity.Property(e => e.IdCommune).HasColumnName("ID_COMMUNE");

                entity.Property(e => e.IdDomaineSujet).HasColumnName("ID_DOMAINE_SUJET");

                entity.Property(e => e.IdFilliere).HasColumnName("ID_FILLIERE");

                entity.Property(e => e.IdNationalite)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ID_NATIONALITE")
                    .IsFixedLength();

                entity.Property(e => e.IdUniversite).HasColumnName("ID_UNIVERSITE");

                entity.Property(e => e.LettreStage).HasColumnName("LETTRE_STAGE");

                entity.Property(e => e.LieuNaissance).HasColumnName("LIEU_NAISSANCE");

                entity.Property(e => e.Nom)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NOM");

                entity.Property(e => e.NomRecteur)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("NOM_RECTEUR");

                entity.Property(e => e.NomUniversite)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("NOM_UNIVERSITE");

                entity.Property(e => e.NumeroPieceIdentite)
                    .HasMaxLength(24)
                    .HasColumnName("NUMERO_PIECE_IDENTITE")
                    .IsFixedLength();

                entity.Property(e => e.ObjectifPoursuivi)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("OBJECTIF_POURSUIVI");

                entity.Property(e => e.PersonneContact)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("PERSONNE_CONTACT");

                entity.Property(e => e.Photo).HasColumnName("PHOTO");

                entity.Property(e => e.Postnom)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("POSTNOM");

                entity.Property(e => e.Prenom)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PRENOM");

                entity.Property(e => e.ProbableDebut)
                    .HasColumnType("date")
                    .HasColumnName("PROBABLE_DEBUT");

                entity.Property(e => e.ProbableFin)
                    .HasColumnType("date")
                    .HasColumnName("PROBABLE_FIN");

                entity.Property(e => e.Promotion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PROMOTION");

                entity.Property(e => e.StatutUniverssite)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUT_UNIVERSSITE");

                entity.Property(e => e.SujetTravail)
                    .HasMaxLength(360)
                    .IsUnicode(false)
                    .HasColumnName("SUJET_TRAVAIL");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(24)
                    .HasColumnName("TELEPHONE")
                    .IsFixedLength();

                entity.Property(e => e.TelephoneContact)
                    .HasMaxLength(24)
                    .HasColumnName("TELEPHONE_CONTACT")
                    .IsFixedLength();

                entity.Property(e => e.TypePieceIdentite)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_PIECE_IDENTITE");

                entity.HasOne(d => d.IdCommuneNavigation)
                    .WithMany(p => p.Demandes)
                    .HasForeignKey(d => d.IdCommune)
                    .HasConstraintName("FK_Demande_Commune_");

                entity.HasOne(d => d.IdDomaineSujetNavigation)
                    .WithMany(p => p.Demandes)
                    .HasForeignKey(d => d.IdDomaineSujet)
                    .HasConstraintName("FK_Demande_Categorie");

                entity.HasOne(d => d.IdFilliereNavigation)
                    .WithMany(p => p.Demandes)
                    .HasForeignKey(d => d.IdFilliere)
                    .HasConstraintName("fk_DemandeFiliere");

                entity.HasOne(d => d.IdNationaliteNavigation)
                    .WithMany(p => p.Demandes)
                    .HasForeignKey(d => d.IdNationalite)
                    .HasConstraintName("FK_Demande_Pays");

                entity.HasOne(d => d.IdUniversiteNavigation)
                    .WithMany(p => p.Demandes)
                    .HasForeignKey(d => d.IdUniversite)
                    .HasConstraintName("fk_DemandeUniversite");
            });

            modelBuilder.Entity<Filiere>(entity =>
            {
                entity.HasKey(e => e.IdFiliere)
                    .HasName("PK__Filiere__72C9F4AD1EB66B1E");

                entity.ToTable("Filiere");

                entity.Property(e => e.IdFiliere).HasColumnName("ID_FILIERE");

                entity.Property(e => e.Nom)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOM");
            });

            modelBuilder.Entity<Organe>(entity =>
            {
                entity.HasKey(e => e.IdOrgane)
                    .HasName("PK_ORGANE");

                entity.ToTable("Organe");

                entity.Property(e => e.IdOrgane)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ID_ORGANE")
                    .IsFixedLength();

                entity.Property(e => e.IdOrganeParent)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ID_ORGANE_PARENT")
                    .IsFixedLength();

                entity.Property(e => e.IdTypeOrgane).HasColumnName("ID_TYPE_ORGANE");

                entity.Property(e => e.NomOrgane)
                    .HasMaxLength(120)
                    .HasColumnName("NOM_ORGANE")
                    .IsFixedLength();

                entity.HasOne(d => d.IdOrganeParentNavigation)
                    .WithMany(p => p.InverseIdOrganeParentNavigation)
                    .HasForeignKey(d => d.IdOrganeParent)
                    .HasConstraintName("FK_ORGANE_ORGANE");

                entity.HasOne(d => d.IdTypeOrganeNavigation)
                    .WithMany(p => p.Organes)
                    .HasForeignKey(d => d.IdTypeOrgane)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORGANE_TYPE_ORGANE");
            });

            modelBuilder.Entity<Pay>(entity =>
            {
                entity.HasKey(e => e.IdPays);

                entity.Property(e => e.IdPays)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ID_PAYS")
                    .IsFixedLength();

                entity.Property(e => e.NomPays)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("NOM_PAYS");
            });

            modelBuilder.Entity<Prolongement>(entity =>
            {
                entity.HasKey(e => e.IdProlongement)
                    .HasName("PK__Prolonge__28498E49E922BBAB");

                entity.ToTable("Prolongement");

                entity.Property(e => e.IdProlongement).HasColumnName("ID_PROLONGEMENT");

                entity.Property(e => e.DateDebut)
                    .HasColumnType("date")
                    .HasColumnName("DATE_DEBUT");

                entity.Property(e => e.DateFin)
                    .HasColumnType("date")
                    .HasColumnName("DATE_FIN");

                entity.Property(e => e.IdStage).HasColumnName("ID_STAGE");

                entity.Property(e => e.Motif)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOTIF");

                entity.HasOne(d => d.IdStageNavigation)
                    .WithMany(p => p.Prolongements)
                    .HasForeignKey(d => d.IdStage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProlongementStage");
            });

            modelBuilder.Entity<Stage>(entity =>
            {
                entity.HasKey(e => e.IdStage)
                    .HasName("PK__Stage__E759DB51990B8DC4");

                entity.ToTable("Stage");

                entity.Property(e => e.IdStage).HasColumnName("ID_STAGE");

                entity.Property(e => e.DateDebut)
                    .HasColumnType("date")
                    .HasColumnName("DATE_DEBUT");

                entity.Property(e => e.DateEnregistrement)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_ENREGISTREMENT");

                entity.Property(e => e.DateFin)
                    .HasColumnType("date")
                    .HasColumnName("DATE_FIN");

                entity.Property(e => e.IdService)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ID_SERVICE")
                    .IsFixedLength();

                entity.Property(e => e.IdStagiaire).HasColumnName("ID_STAGIAIRE");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.Stages)
                    .HasForeignKey(d => d.IdService)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stage_ORGANE");

                entity.HasOne(d => d.IdStagiaireNavigation)
                    .WithMany(p => p.Stages)
                    .HasForeignKey(d => d.IdStagiaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_StageStagiaire");
            });

            modelBuilder.Entity<Stagiaire>(entity =>
            {
                entity.HasKey(e => e.IdStagiaire);

                entity.ToTable("Stagiaire");

                entity.Property(e => e.IdStagiaire).HasColumnName("ID_STAGIAIRE");

                entity.Property(e => e.AdresseDomicile)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ADRESSE_DOMICILE");

                entity.Property(e => e.DateEnregistrement)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_ENREGISTREMENT");

                entity.Property(e => e.DateNaissance)
                    .HasColumnType("date")
                    .HasColumnName("DATE_NAISSANCE");

                entity.Property(e => e.Genre)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GENRE")
                    .IsFixedLength();

                entity.Property(e => e.IdCommune).HasColumnName("ID_COMMUNE");

                entity.Property(e => e.IdDemande).HasColumnName("ID_DEMANDE");

                entity.Property(e => e.IdFilliere).HasColumnName("ID_FILLIERE");

                entity.Property(e => e.IdNationalite)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ID_NATIONALITE")
                    .IsFixedLength();

                entity.Property(e => e.IdSujet).HasColumnName("ID_SUJET");

                entity.Property(e => e.IdUniversite).HasColumnName("ID_UNIVERSITE");

                entity.Property(e => e.LieuNaissance).HasColumnName("LIEU_NAISSANCE");

                entity.Property(e => e.Nom)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NOM");

                entity.Property(e => e.Photo).HasColumnName("PHOTO");

                entity.Property(e => e.Postnom)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("POSTNOM");

                entity.Property(e => e.Prenom)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PRENOM");

                entity.Property(e => e.Promotion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PROMOTION");

                entity.HasOne(d => d.IdCommuneNavigation)
                    .WithMany(p => p.Stagiaires)
                    .HasForeignKey(d => d.IdCommune)
                    .HasConstraintName("FK_Stagiaire_Commune_");

                entity.HasOne(d => d.IdDemandeNavigation)
                    .WithMany(p => p.Stagiaires)
                    .HasForeignKey(d => d.IdDemande)
                    .HasConstraintName("fk_StagiaireDemande");

                entity.HasOne(d => d.IdFilliereNavigation)
                    .WithMany(p => p.Stagiaires)
                    .HasForeignKey(d => d.IdFilliere)
                    .HasConstraintName("FK_Stagiaire_Filiere");

                entity.HasOne(d => d.IdNationaliteNavigation)
                    .WithMany(p => p.Stagiaires)
                    .HasForeignKey(d => d.IdNationalite)
                    .HasConstraintName("FK_Stagiaire_Pays");

                entity.HasOne(d => d.IdSujetNavigation)
                    .WithMany(p => p.Stagiaires)
                    .HasForeignKey(d => d.IdSujet)
                    .HasConstraintName("FK_Stagiaire_Sujet");

                entity.HasOne(d => d.IdUniversiteNavigation)
                    .WithMany(p => p.Stagiaires)
                    .HasForeignKey(d => d.IdUniversite)
                    .HasConstraintName("fk_StagiaireUniversite");
            });

            modelBuilder.Entity<StatutUniversite>(entity =>
            {
                entity.HasKey(e => e.IdStatutUniversite)
                    .HasName("PK_Statut Université");

                entity.ToTable("Statut_Universite");

                entity.Property(e => e.IdStatutUniversite)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_STATUT_UNIVERSITE");

                entity.Property(e => e.Statut)
                    .IsUnicode(false)
                    .HasColumnName("STATUT");
            });

            modelBuilder.Entity<Sujet>(entity =>
            {
                entity.HasKey(e => e.IdSujet)
                    .HasName("PK__Sujet__88B83238273AE2D5");

                entity.ToTable("Sujet");

                entity.Property(e => e.IdSujet).HasColumnName("ID_SUJET");

                entity.Property(e => e.Description)
                    .HasMaxLength(360)
                    .HasColumnName("DESCRIPTION")
                    .IsFixedLength();

                entity.Property(e => e.IdDomaine).HasColumnName("ID_DOMAINE");

                entity.Property(e => e.Titre)
                    .HasMaxLength(180)
                    .IsUnicode(false)
                    .HasColumnName("TITRE");

                entity.HasOne(d => d.IdDomaineNavigation)
                    .WithMany(p => p.Sujets)
                    .HasForeignKey(d => d.IdDomaine)
                    .HasConstraintName("FK_Sujet_Categorie");
            });

            modelBuilder.Entity<TypeInstitut>(entity =>
            {
                entity.HasKey(e => e.IdTypeInstitut)
                    .HasName("PK_Type Institut");

                entity.ToTable("Type_Institut");

                entity.Property(e => e.IdTypeInstitut)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_TYPE_INSTITUT");

                entity.Property(e => e.Type)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<TypeOrgane>(entity =>
            {
                entity.HasKey(e => e.IdTypeOrgane)
                    .HasName("PK_TYPE_ORGANE");

                entity.ToTable("TypeOrgane");

                entity.Property(e => e.IdTypeOrgane).HasColumnName("ID_TYPE_ORGANE");

                entity.Property(e => e.NomType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NOM_TYPE");
            });

            modelBuilder.Entity<Universite>(entity =>
            {
                entity.HasKey(e => e.IdUniversite)
                    .HasName("PK__Universi__E98FD41C353ECFC8");

                entity.ToTable("Universite");

                entity.Property(e => e.IdUniversite).HasColumnName("ID_UNIVERSITE");

                entity.Property(e => e.Adresse)
                    .HasMaxLength(180)
                    .IsUnicode(false)
                    .HasColumnName("ADRESSE");

                entity.Property(e => e.IdStatutUniversite).HasColumnName("ID_STATUT_UNIVERSITE");

                entity.Property(e => e.IdTypeInstitut).HasColumnName("ID_TYPE_INSTITUT");

                entity.Property(e => e.Nom)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("NOM");

                entity.Property(e => e.NomRecteur)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("NOM_RECTEUR");

                entity.Property(e => e.Sigle)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SIGLE");

                entity.HasOne(d => d.IdStatutUniversiteNavigation)
                    .WithMany(p => p.Universites)
                    .HasForeignKey(d => d.IdStatutUniversite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Universite_Statut Université");

                entity.HasOne(d => d.IdTypeInstitutNavigation)
                    .WithMany(p => p.Universites)
                    .HasForeignKey(d => d.IdTypeInstitut)
                    .HasConstraintName("FK_Universite_Type Institut");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
