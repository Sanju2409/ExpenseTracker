using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        //categoryid
        public int CategoryId { get; set; }
        public Category Category { get; set; } //navigational property:it is to implement foreign key relationship with base Category model
        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; } //? indicates it can be nullable

        public DateTime Date { get; set; }= DateTime.Now;
    }
}
