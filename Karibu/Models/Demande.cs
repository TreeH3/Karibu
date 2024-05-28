using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Karibu.Models
{
    public partial class Demande
    {
        public Demande()
        {
            Stagiaires = new HashSet<Stagiaire>();
        }

        [DisplayName("Id")]
        public long IdDemande { get; set; }
        [DisplayName("Nom")]
        public string Nom { get; set; } = null!;
        [DisplayName("Postnom")]
        public string? Postnom { get; set; }
        [DisplayName("Prénom")]
        public string? Prenom { get; set; }
        [DisplayName("Genre")]
        public string Genre { get; set; } = null!;
        [DisplayName("Nationalité")]
        public string? IdNationalite { get; set; }
        [DisplayName("Lieu de naissance")]
        public int? LieuNaissance { get; set; }
        [DisplayName("Date de naissance")]
        public DateTime DateNaissance { get; set; }
        [DisplayName("Commune")]
        public int? IdCommune { get; set; }
        [DisplayName("Adresse domicile")]
        public string AdresseDomicile { get; set; } = null!;
        [DisplayName("Téléphone")]
        public string? Telephone { get; set; }
        [DisplayName("Type de pièce d'identité")]
        public string? TypePieceIdentite { get; set; }
        [DisplayName("Numéro de pièce d'identité")]
        public string? NumeroPieceIdentite { get; set; }
        [DisplayName("Université")]
        public int? IdUniversite { get; set; }
        [DisplayName("Nom de l'Université")]
        public string? NomUniversite { get; set; }
        [DisplayName("Statut de l'Université")]
        public string? StatutUniverssite { get; set; }
        [DisplayName("Adresse de l'Université")]
        public string? AdresseUniversite { get; set; }
        [DisplayName("Nom du recteur")]
        public string? NomRecteur { get; set; }
        [DisplayName("Promotion")]
        public string Promotion { get; set; } = null!;
        [DisplayName("Filière")]
        public int? IdFilliere { get; set; }
        [DisplayName("Filière")]
        public string? Filliere { get; set; }
        [DisplayName("Sujet de TFC/Mémoire")]
        public string? SujetTravail { get; set; }
        [DisplayName("Domaine du sujet")]
        public int? IdDomaineSujet { get; set; }
        [DisplayName("Objectif Poursuivi")]
        public string? ObjectifPoursuivi { get; set; }
        [DisplayName("Probable début")]
        public DateTime? ProbableDebut { get; set; }
        [DisplayName("Probable fin")]
        public DateTime? ProbableFin { get; set; }
        [DisplayName("Personne à contacter")]
        public string? PersonneContact { get; set; }
        [DisplayName("Téléphone du contact")]
        public string? TelephoneContact { get; set; }
        [DisplayName("Fonction de contact")]
        public string? FonctionContact { get; set; }
        [DisplayName("Lettre de stage")]
        public byte[]? LettreStage { get; set; }
        [DisplayName("Photo")]
        public byte[]? Photo { get; set; }

        [DisplayName("Commune")]
        public virtual Commune? IdCommuneNavigation { get; set; }
        [DisplayName("Domaine du sujet")]
        public virtual Categorie? IdDomaineSujetNavigation { get; set; }
        [DisplayName("Filière")]
        public virtual Filiere? IdFilliereNavigation { get; set; }
        [DisplayName("Nationalité")]
        public virtual Pay? IdNationaliteNavigation { get; set; }
        [DisplayName("Université")]
        public virtual Universite? IdUniversiteNavigation { get; set; }
        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
    }
}