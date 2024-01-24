using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.Jobs
{
    public static class JobMap
    {
        public static void Map(this EntityTypeBuilder<Job> entity)
        {
            entity.ToTable("Tarefa", "cadastro");

            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(p => p.Title).HasColumnName("Titulo").HasMaxLength(45);
            entity.Property(p => p.Description).HasColumnName("Descricao").HasMaxLength(150);
            entity.Property(p => p.CreatedAt).HasColumnName("DataCriacao").IsRequired();
            entity.Property(p => p.LastUpdateAt).HasColumnName("UltimaAtualizacao");
            entity.Property(e => e.UserId).HasColumnName("IdUsuario");
            entity.Property(e => e.ProjectId).HasColumnName("IdProjeto");
            entity.HasOne(p => p.Project).WithMany(p => p.Jobs).HasForeignKey(p => p.ProjectId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(p => p.User).WithMany(p => p.Jobs).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}