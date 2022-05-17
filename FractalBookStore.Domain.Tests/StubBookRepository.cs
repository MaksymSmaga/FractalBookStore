﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FractalBookStore.Domain.Tests
{
    internal class StubBookRepository : IBookRepository
    {
        public Book[] ResultOfGetAllByIsbn { get; set; }
        public Book[] ResultOfGetAllByTitleOrAuthor { get; set; }
        public Book[] GetAllByIsbn(string titlePart)
        {
            return ResultOfGetAllByIsbn;
        }

        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            return ResultOfGetAllByTitleOrAuthor;
        }
    }
}