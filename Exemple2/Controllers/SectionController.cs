using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SectionController : ControllerBase
{
	private static readonly BookContext _context = new();

	public SectionController()
	{
	}

	// GET: api/Section
	[HttpGet]
	public List<string> GetSections()
	{
		return _context.Sections.Select(s => s.Name).ToList();
	}

	// GET: api/Section/5
	[HttpGet("{id}")]
	public Section GetSection(int id)
	{
		return _context.Sections.Find(id);
	}

	// POST: api/Section
	[HttpPost]
	public void PostSection(Section section)
	{
		// absence de book ?
		_context.Sections.Add(section);
		_context.SaveChanges();
	}

	// PUT: api/Section/5
	[HttpPut("{id}")]
	public void PutSection(int id, Section section)
	{
		var sectionToUpdate = _context.Sections.Find(id);
		if (sectionToUpdate != null)
		{
			sectionToUpdate.Name = section.Name;
			_context.SaveChanges();
		}
	}

	// DELETE: api/Section/5
	[HttpDelete("{id}")]
	public void DeleteSection(int id)
	{
		var section = _context.Sections.Find(id);
		if (section != null)
		{
			_context.Sections.Remove(section);
			_context.SaveChanges();
		}
	}
}
