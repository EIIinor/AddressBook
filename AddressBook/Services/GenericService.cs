using System.Diagnostics;

namespace AddressBook.Services;

public class GenericService<T>  where T : class
{
    private List<T> _items;

    public GenericService()
    {
        _items = new List<T>(); 
    }

    public virtual bool Add(T type)
    {
        try
        {
            _items.Add(type);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public virtual T Get(Func<T, bool> predicate)
    {
        try
        {
            var item = _items.FirstOrDefault(predicate);
            if (item == null)
                return item!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual IEnumerable<T> GetAll()
    {
        try
        {
            return _items;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return new List<T>();
    }

    public virtual bool Remove(Func<T, bool> predicate)
    {
        try
        {
            var item = _items.FirstOrDefault(predicate);
            if (item != null)
            {
                _items.Remove(item);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
