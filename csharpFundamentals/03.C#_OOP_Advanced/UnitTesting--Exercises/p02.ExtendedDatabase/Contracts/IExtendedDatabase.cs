public interface IExtendedDatabase
{
    void Add(IPerson person);
    void Remove();
    IPerson FindByUsername(string username);
    IPerson FindById(long id);
    IPerson[] Fetch();
}