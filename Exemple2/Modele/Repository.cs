using Microsoft.EntityFrameworkCore;

public class Repository<T> where T : class
{
	private static BookContext _db = new BookContext();
	private DbSet<T> _table = _db.Set<T>();

	public Repository()
	{
	}

	public List<T> GetAll()
	{
		return _table.ToList();
	}

	public T GetById(int id)
	{
		return _table.Find(id);
	}

	public void Add(T obj)
	{
		_table.Add(obj);
		_db.SaveChanges();
	}

	public void Update(T obj)
	{
		_table.Update(obj);
		_db.SaveChanges();
	}

	public void Delete(T obj)
	{
		_table.Remove(obj);
		_db.SaveChanges();
	}

	public void save()
	{
		_db.SaveChanges();
	}
}
