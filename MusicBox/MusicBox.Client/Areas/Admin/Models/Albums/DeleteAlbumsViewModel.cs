﻿using MusicBox.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicBox.Areas.Admin.Models.Albums
{
    public class DeleteAlbumsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public short Year { get; set; }
        public DateTime DateOfCreation { get; set; }
        public Artist Artist { get; set; }

    }
}