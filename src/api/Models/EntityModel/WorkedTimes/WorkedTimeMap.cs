using api.Models.EntityModel.Jobs;
using api.Models.EntityModel.WorkedTimes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.Users
{
    public static class WorkedTimeMap
    {
        public static void Map(this EntityTypeBuilder<WorkedTime> entity)
        {
            entity.ToTable("TempoTrabalhado", "cadastro");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(e => e.JobId).HasColumnName("IdTarefa").IsRequired(false);
            entity.Property(e => e.ProjectId).HasColumnName("IdProjeto").IsRequired(false);
            entity.HasOne(p => p.Job).WithOne(p => p.WorkedTime).HasForeignKey<WorkedTime>(p => p.JobId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(p => p.Project).WithOne(p => p.WorkedTime).HasForeignKey<WorkedTime>(p => p.ProjectId).OnDelete(DeleteBehavior.Cascade);
            entity.Property(e => e.Hours).HasColumnName("Horas");
            entity.Property(e => e.Days).HasColumnName("Dias");
            entity.Property(e => e.Months).HasColumnName("Meses");
        }
    }
}