public class PriceCalculator
{
    private decimal pricePerDay;
    private long numberOfDays;
    private DiscountType discount;
    private SeasonType season;

    public PriceCalculator() { }

    public PriceCalculator(decimal pricePerDay, long numberOfDays ,SeasonType season)
        : this()
    {
        this.PricePerDay = pricePerDay;
        this.NumberOfDays = numberOfDays;
        this.Season = season;
        this.Discount = DiscountType.None;
    }

    public SeasonType Season
    {
        get
        {
            return this.season;
        }
        set
        {
            this.season = value;
        }
    }

    public DiscountType Discount
    {
        get
        {
            return this.discount;
        }
        set
        {
            this.discount = value;
        }
    }


    public long NumberOfDays
    {
        get
        {
            return this.numberOfDays;
        }
        set
        {
            this.numberOfDays = value;
        }
    }

    public decimal PricePerDay
    {
        get
        {
            return this.pricePerDay;
        }
        set
        {
            this.pricePerDay = value;
        }
    }

    public decimal CalculateTotalPrice()
    {
        var totalSum = (this.PricePerDay * (int)this.Season) * this.NumberOfDays;
        totalSum -= totalSum * ((int)this.Discount / 100.0M);

        return totalSum;
    }
}