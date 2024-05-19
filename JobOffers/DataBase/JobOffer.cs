using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JobOffers.DataBase
{
    public class JobOffer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RecruiterId { get; set; }
        [ForeignKey("Status")]
        public int Status { get; set; } //from list
        public int Title {  get; set; }
        [ForeignKey("Category")]
        public int Category { get; set; } //from list
        public string Description { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Requitements { get; set; } //REWORK IN FUTURE
        public string Salary { get; set; }
        [ForeignKey("WorkingTime")]
        public int WorkingTime { get; set; } //from list
        [ForeignKey("ContractType")]
        public int ContractType { get; set; } //from list
        public string Benefits { get; set; } //REWORK IN FUTURE

    }
}
