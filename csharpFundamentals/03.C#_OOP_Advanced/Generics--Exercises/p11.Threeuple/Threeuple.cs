public class Threeuple<Titem1, Titem2, TItem3>
{
    private Titem1 item1;
    private Titem2 item2;
    private TItem3 item3;

    public Threeuple(Titem1 item1, Titem2 item2, TItem3 item3)
    {
        this.Item1 = item1;
        this.Item2 = item2;
        this.item3 = item3;
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

    public TItem3 Item3
    {
        get
        {
            return this.item3;
        }
        set
        {
            this.item3 = value;
        }
    }
}