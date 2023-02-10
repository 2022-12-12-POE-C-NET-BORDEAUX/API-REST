using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
	public int Id { get; set; }

	[Required]
	public string Title { get; set; }
	[Required]
	public string Author { get; set; }
	[Required]
	public int SectionId { get; set; }
	[ForeignKey("SectionId")]
	public Section? MySection { get; set; }

	public Book(string title, string author, int sectionId, Section section)
	{
		Title = title;
		Author = author;
		MySection = section;
		SectionId = sectionId;
		MySection = section;
		MySection.Books.Add(this);
	}

	public Book()
	{

	}
}

public class BookContext : DbContext
{
	public DbSet<Book> Books { get; set; }
	public DbSet<Section> Sections { get; set; }

	public BookContext()
	{
		Database.EnsureDeleted();
		Database.EnsureCreated();
		Sections.Add(new Section("Section 1"));
		Sections.Add(new Section("Section 2"));
		Sections.Add(new Section("Section 3"));
		SaveChanges();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseMySQL("Server=localhost;Database=Section;User=root;Password=0000");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Book>()
			.HasOne(b => b.MySection)
			.WithMany(s => s.Books)
			.HasForeignKey(b => b.SectionId);
	}
}
