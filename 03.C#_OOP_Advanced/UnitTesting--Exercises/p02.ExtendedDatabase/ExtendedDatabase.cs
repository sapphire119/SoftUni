using System;
using System.Collections.Generic;
using System.Linq;

public class ExtendedDatabase : IExtendedDatabase
{
    private const int DefaultCapacity = 16;

    private int currentIndex;
    private IPerson[] people;

    public ExtendedDatabase()
    {
        this.people = new IPerson[16];
        this.currentIndex = -1;
    }

    public ExtendedDatabase(params IPerson[] people)
        : this()
    {
        SetInputParams(people);
    }

    private void SetInputParams(IPerson[] inputPeople)
    {
        if (inputPeople == null) return;
        if (inputPeople.Length > 16)
        {
            throw new InvalidOperationException($"Array's capacity must be 16!");
        }
        Array.Copy(inputPeople, this.people, inputPeople.Length);
        this.currentIndex = inputPeople.Length - 1;
    }

    public void Add(IPerson person)
    {
        if (this.currentIndex + 1 >= this.people.Length)
        {
            throw new InvalidOperationException("Array is full!");
        }

        var existingUserWithId = this.people.Where(p => p != null).SingleOrDefault(p => p.Id == person.Id);
        if (existingUserWithId != null)
        {
            throw new InvalidOperationException($"User with Id: {person.Id} already exists");
        }

        var existingUserWithUsername = this.people.Where(p => p != null).SingleOrDefault(p => p.Username == person.Username);
        if (existingUserWithUsername != null)
        {
            throw new InvalidOperationException($"User with Username: {person.Username} already exists");
        }


        this.currentIndex++;
        this.people[this.currentIndex] = person;
    }

    public IPerson[] Fetch()
    {
        var arrayToFetch = new IPerson[this.currentIndex + 1];
        Array.Copy(this.people, arrayToFetch, this.currentIndex + 1);
        return arrayToFetch;
    }

    public IPerson FindById(long id)
    {
        var existingPerson = this.people.Where(p => p != null).SingleOrDefault(p => p.Id == id);
        if (existingPerson == null)
        {
            throw new InvalidOperationException($"Person with Id: {id} doesn't exist!");
        }

        if (existingPerson.Id < 0)
        {
            throw new ArgumentOutOfRangeException("Ids cannot be negative!", new ArgumentException());
        }

        return existingPerson;
    }

    public IPerson FindByUsername(string username)
    {
        var existingPerson = this.people.Where(p => p != null).SingleOrDefault(p => p.Username == username);
        if (existingPerson == null)
        {
            throw new InvalidOperationException($"User with username: {username} is non existant!");
        }

        if (existingPerson.Username == null)
        {
            throw new ArgumentNullException($"Username of user with Id:{existingPerson.Id} is null!", new NullReferenceException());
        }

        return existingPerson;
    }

    public void Remove()
    {
        if (this.currentIndex < 0)
        {
            throw new InvalidOperationException("Array is empty!");
        }
        this.people[this.currentIndex] = default(IPerson);
        this.currentIndex--;
    }
}