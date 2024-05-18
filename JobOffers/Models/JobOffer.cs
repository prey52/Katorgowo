using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JobOffers.Models
{
    public class JobOffer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RecruiterId { get; set; }
        public string Status { get; set; }
        public int Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Requitements { get; set; }
        public string Salary { get; set; }
        public string WorkingTime { get; set; }
        public string ContractType { get; set; }
        public string Benefits { get; set; }
    }
}
