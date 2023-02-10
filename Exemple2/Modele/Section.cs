public class Section
{
	public int Id { get; set; }
	public List<Book> Books { get; set; }
	public string Name { get; set; }

	public Section()
	{
		Books = new List<Book>();
	}

	public Section(string name)
	{
		Name = name;
		Books = new List<Book>();
	}
}
