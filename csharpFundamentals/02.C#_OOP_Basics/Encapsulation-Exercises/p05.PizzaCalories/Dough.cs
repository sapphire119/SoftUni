using System.Collections.Generic;

public class Dough
{
    private decimal weight;
    private string bakingTechnique;
    private string flourType;

    public Dough() { }

    public Dough(decimal weight, string bakingTechnique, string flourType)
        : this()
    {
        this.Weight = weight;
        this.BakingTechnique = bakingTechnique;
        this.FlourType = flourType;
    }

    public string FlourType
    {
        get
        {
            return this.flourType;
        }
        private set
        {
            if (!FlourtypeType.FlourTypes.ContainsKey(value.ToLower()))
            {
                throw DoughExceptions.InvalidDoughException;
            }
            this.flourType = value;
        }
    }

    public string BakingTechnique
    {
        get
        {
            return this.bakingTechnique;
        }
        private set
        {
            if (!BakingTechniqueType.bakingTechnique.ContainsKey(value.ToLower()))
            {
                throw DoughExceptions.InvalidDoughException;
            }
            this.bakingTechnique = value;
        }
    }

    public decimal Weight
    {
        get
        {
            return this.weight;
        }
        private set
        {
            if (!(1.0M <= value && value <= 200.0M))
            {
                throw DoughExceptions.WeightException;
            }
            this.weight = value;
        }
    }

    public decimal CaloriesInDough => this.CalculateCaloriesForDough();

    private decimal CalculateCaloriesForDough()
    {
        var calories = (2 * this.Weight) * 
                    FlourtypeType.FlourTypes[this.FlourType.ToLower()] * 
                    BakingTechniqueType.bakingTechnique[this.BakingTechnique.ToLower()];
        
        return calories;
    }
}