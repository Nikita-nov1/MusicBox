using MusicBox.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Data.Configurations
{
   
    public class ArtistConfiguration : EntityTypeConfiguration<Artist>
    {
        public ArtistConfiguration()
        {
            ToTable("Artists");

            HasKey(c => c.Id);

            Property(p => p.Title).HasColumnName("Full_Name").HasMaxLength(30).IsRequired();
            HasIndex(c => c.Title).IsUnique(true);




        }
    }
}
