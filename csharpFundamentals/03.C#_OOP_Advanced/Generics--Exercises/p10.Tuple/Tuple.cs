public class Tuple<Titem1, Titem2>
{
    private Titem1 item1;
    private Titem2 item2;

    public Tuple(Titem1 item1, Titem2 item2)
    {
        this.Item1 = item1;
        this.Item2 = item2;
    }

    public Titem1 Item1
    {
        get
        {
            return this.item1;
        }
        set
        {
            this.item1 = value;
        }
    }

    public Titem2 Item2
    {
        get
        {
            return this.item2;  
        }
        set
        {
            this.item2 = value;
        }
    }
}