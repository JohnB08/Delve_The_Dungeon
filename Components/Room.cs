namespace Components.Room;
using Components.Player;
using Components.Utilities;


public class Treasure
{
    public string Description { get; set; }
    public int Attribute { get; set; }
    public int Reward { get; set; }
    public string EquipDesc { get; set; }
    public void EquipReward(Player player)
    {
        switch (Attribute)
        {
            case 1:
                player.Strength += Reward;
                break;
            case 2:
                player.Agility += Reward;
                break;
            case 3:
                player.Wit += Reward;
                break;
        }
        Console.WriteLine($"{EquipDesc}");
    }
}
public class Obstacle
{
    public string Description { get; set; }
    public int Difficulty { get; set; }
    public int Attribute { get; set; }
    public string ExaminedDescription { get; set; }
    public Treasure treasure { get; set; }

    public bool OvercomeObstacle(Player player)
    {
        int playerAttribute = 0;
        switch (Attribute)
        {
            case 1:
                playerAttribute = player.Strength;
                break;
            case 2:
                playerAttribute = player.Agility;
                break;
            case 3:
                playerAttribute = player.Wit;
                break;
        }
        return SkillCheck.RollSkillCheck(playerAttribute, Difficulty);
    }
}

public class ExamineRoom
{
    public void Examine(Player player, Room room)
    {
        bool SuccessfullExamine = SkillCheck.RollSkillCheck(player.Wit, 4);
        if (SuccessfullExamine)
        {
            room.Obstacle.Difficulty--;
            room.Examined = true;
            Console.WriteLine(room.Obstacle.ExaminedDescription);
            return;
        }
        else
        {
            Console.WriteLine("You fail to notice anything out of place.");
            room.Examined = true;
            return;
        }
    }
}
public class Room
{
    public string Description { get; set; }
    public Room Next { get; set; }
    public Room Prev { get; set; }
    public Obstacle Obstacle { get; set; }
    public bool Examined { get; set; } = false;
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