using MusicBox.Domain.Models.Entities;
using System;
using System.Collections.Generic;
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

            HasKey(s => s.Id);

            Property(p => p.Title);


        }
    }
}
