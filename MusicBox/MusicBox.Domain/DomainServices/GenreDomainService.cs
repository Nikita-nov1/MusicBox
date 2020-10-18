﻿using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using System.Collections.Generic;

namespace MusicBox.Domain.DomainServices
{
    public class GenreDomainService : IGenreDomainService
    {
        private readonly IGenreRepository genreRepository;

        public GenreDomainService(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public List<Genre> GetGenres()
        {
            return genreRepository.GetAll();
        }

        public Genre GetGenre(int id)
        {
            return genreRepository.Get(id);
        }

    }
}
