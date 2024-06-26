﻿using JobOffers.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OfertyPracy.Database
{
    public class OfertyPracyBenefity
    {
        [Key]
        public int Id { get; set; }
        public string Opis { get; set; }

        // Klucz obcy do ofert
        public int OfertaPracyId { get; set; }
        public OfertyPracyModel OfertaPracy { get; set; }
    }
}
