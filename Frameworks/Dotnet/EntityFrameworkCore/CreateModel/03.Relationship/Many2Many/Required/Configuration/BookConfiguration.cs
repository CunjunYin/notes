using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Relationship.Many2Many.Required.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasMany(user => user.users)
            .WithMany(book => book.books);
            //.UsingEntity<Dictionary<string, object>>(
            //    "BookAuthor", // Name of the join table
            //    j => j.HasOne<User>().WithMany(), // property in the join entity to 'Author'
            //    j => j.HasOne<Book>().WithMany()  // property in the join entity to 'Book'
            //);
    }
}