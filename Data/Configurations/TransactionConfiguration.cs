using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;


namespace api.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(t => t.AppUser)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}