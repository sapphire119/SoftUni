using System;

public class Exceptions
{
    public static ArgumentException nameException = new ArgumentException($" cannot contain fewer than 3 symbols!");
    public static ArgumentException salaryException = new ArgumentException("Salary cannot be less than 460 leva!");
    public static ArgumentException ageException = new ArgumentException("Age cannot be zero or a negative integer!");
}