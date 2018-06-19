﻿using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private int age;
    private List<BankAccount> accounts;

    public Person()
    {
        this.accounts = new List<BankAccount>();
    }

    public Person(string name, int age)
        : this()
    {
        this.Name = name;
        this.Age = age;
    }

    public Person(string name, int age, List<BankAccount> accounts)
        :this(name, age)
    {
        this.accounts = accounts;
    }

    public List<BankAccount> Accounts
    {
        get
        {
            return this.accounts;
        }
        set
        {
            this.accounts = value;
        }
    }

    //public IReadOnlyCollection<BankAccount> Accounts
    //{
    //    get
    //    {
    //        return new List<BankAccount>(accounts);
    //    }
    //}

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public decimal GetBalance()
    {
        return this.Accounts.Sum(a => a.Balance);
    }
}