namespace Components.Room;

public class Room
{
    public string Description { get; set; }
    public Room Next { get; set; }
    public Room Prev { get; set; }
    public Room(string description)
    {
        Description = description;
    }
}

public class DungeonLayout
{
    public Room Start { get; private set; }
    public Room End { get; private set; }
    public int DungeonLength { get; private set; }
    public void AddRoomStart(string desc)
    {
        Room newRoom = new(desc);
        newRoom.Next = Start;
        if (Start != null)
        {
            Start.Prev = newRoom;
        }
        Start = newRoom;
        End ??= newRoom;
        DungeonLength++;
    }
    public void AddRoomEnd(string desc)
    {
        if (Start == null)
        {
            AddRoomStart(desc);
            return;
        }
        Room newRoom = new(desc);
        End.Next = newRoom;
        newRoom.Prev = End;
        End = newRoom;
        DungeonLength++;

    }
}