﻿using FractalBookStore.Domain.Services;
using Moq;
using Xunit;

namespace FractalBookStore.Domain.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();

            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "") });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
               .Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookRepositoryStub.Object);

            var validIsbn = "ISBN 12345-67890";
            var actual = bookService.GetAllByQuery(validIsbn);
             
            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }
    }
}