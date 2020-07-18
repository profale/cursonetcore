using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(150).IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(100).IsRequired();


        }
    }
}
