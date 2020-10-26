using MusicBox.Domain.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace MusicBox.Areas.Admin.Models.Albums
{
    public class DeleteAlbumsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Album year")]
        public short Year { get; set; }
        [Display(Name = "Album date of creation")]
        public DateTime DateOfCreation { get; set; }
        [Display(Name = "Album artist")]
        public Artist Artist { get; set; }

    }
}