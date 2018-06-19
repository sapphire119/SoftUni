using System.Collections.Generic;

public class Department
{
    private string name;
    private Room[] rooms;

    public Department()
    {
        this.Rooms = new Room[20];
        for (int index = 0; index < this.Rooms.Length; index++)
        {
            this.Rooms[index] = new Room();
        }
    }

    public Department(string name)
        : this()
    {
        this.Name = name;
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

    public Room[] Rooms
    {
        get
        {
            return this.rooms;
        }
        set
        {
            this.rooms = value;
        }
    }

}