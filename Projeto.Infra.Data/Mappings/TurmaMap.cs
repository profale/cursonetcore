using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Descricao)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(t => t.DataIniciio)
                .IsRequired();

            //TURMA TEM 1 PROFESSOR
            //PROFESSOR TEM MUITAS TURMAS
            builder.HasOne(t => t.Professor)
                .WithMany(p => p.Turmas)
                .HasForeignKey(t => t.ProfessorId);
        }
    }
}
