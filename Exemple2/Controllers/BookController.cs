using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Exemple.Controllers;

[Route("/api/Section/{SectionID}/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
	private static readonly BookContext _context = new();

	public BookController()
	{
	}

	// GET: api/Book
	[HttpGet]
	public List<String> GetBooks(int SectionID)
	{
		return _context.Books.Where(b => b.SectionId == SectionID).Select(b => b.Title).ToList();
	}

	// GET: api/Book/5
	[HttpGet("{id}")]
	public Book GetBook(int id)
	{
		return _context.Books.Find(id);
	}

	// POST: api/Book
	[HttpPost]
	public void PostBook(Book book)
	{
		_context.Books.Add(book);
		_context.SaveChanges();
	}

	// PUT: api/Book/5
	[HttpPut("{id}")]
	public void PutBook(int id, Book book)
	{
		var bookToUpdate = _context.Books.Find(id);
		if (bookToUpdate != null)
		{
			bookToUpdate.Title = book.Title;
			bookToUpdate.Author = book.Author;
			bookToUpdate.SectionId = book.SectionId;
			_context.SaveChanges();
		}
	}

	// DELETE: api/Book/5
	[HttpDelete("{id}")]
	public void DeleteBook(int id)
	{
		var book = _context.Books.Find(id);
		if (book != null)
		{
			_context.Books.Remove(book);
			_context.SaveChanges();
		}
	}
}
