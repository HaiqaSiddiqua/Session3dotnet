using System;

namespace Session1LinqApp.Exceptions
{
    public class BookNotFoundException : Exception
    {
        // Pass a clear message down to the base C# Exception class
        public BookNotFoundException(int id) : base($"Book with ID {id} was not found. Please try again.")
        {
        }
    }
}
