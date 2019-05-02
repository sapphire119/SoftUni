public interface IDatabase
{
    void AddElement(int number);
    void RemoveElement();
    int[] Fetch();
}