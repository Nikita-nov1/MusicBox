using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Domain.Models.Entities
{
    public class TrackStatistics  
    {
        public int Id { get; set; }     
        public int CountOfCalls { get; set; }
        public Track Track { get; set; }
    }
}
