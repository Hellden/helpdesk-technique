//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket_Attente
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sujet { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> DateDebut { get; set; }
        public string Suivie { get; set; }
        public Nullable<int> Validation { get; set; }
        public string Commentaire { get; set; }
        public Nullable<System.DateTime> DateFinTicket { get; set; }
    }
}
