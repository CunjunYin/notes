using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Relationship.Many2Many;
using System.Reflection.Emit;

namespace Relationship.One2Many.Required.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasMany(author => author.Books)
           .WithOne(book => book.Author)
           .HasForeignKey(book => book.AuthorID);
    }
}