﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityTypes.Model.Configuration;

public class StuentFunctionConfiguration : IEntityTypeConfiguration<StudentFunction>
{
    public void Configure(EntityTypeBuilder<StudentFunction> builder)
    {
        builder.HasNoKey().ToFunction("FulltimeStudentFunction");
        builder.Property(student => student.Name);
        builder.Property(student => student.NameLength);
    }
}