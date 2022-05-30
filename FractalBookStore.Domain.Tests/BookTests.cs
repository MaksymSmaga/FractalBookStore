using FractalBookStore.DTOFactory;
using System;
using Xunit;

namespace FractalBookStore.Domain.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            bool actual = BookDTOFactory.IsIsbn(null);
            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            bool actual = BookDTOFactory.IsIsbn("  ");
            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            bool actual = BookDTOFactory.IsIsbn("ISBN 123");
            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_WithIsbn10_ReturnTrue()
        {
            bool actual = BookDTOFactory.IsIsbn("IsBn 123-435-789 0");
            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_WithIsbn13_ReturnTrue()
        {
            bool actual = BookDTOFactory.IsIsbn("IsBn 123-435-789 0123");
            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_WithTrashStart_ReturnFalse()
        {
            bool actual = BookDTOFactory.IsIsbn("xxx IsBn 123-435-789 00000 yyy");
            Assert.False(actual);
        }
    }
}
