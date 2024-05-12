namespace Components.Room;
using Components.Player;
using Components.Utilities;


public class Treasure
{
    public string Description { get; set; }
    public int Attribute { get; set; }
    public int Reward { get; set; }
    public string EquipDesc { get; set; }
    public Treasure(string desc, int attr, int rew, string eqdesc)
    {
        Description = desc;
        Attribute = attr;
        Reward = rew;
        EquipDesc = eqdesc;
    }
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
    public Treasure Treasure { get; set; }
    public bool Moveable { get; set; }
    public bool Attackable { get; set; }
    public bool Talkable { get; set; }
    public bool Dodgeable { get; set; }
    public string ClearedMessage { get; set; }
    public string FailMessage { get; set; }
    public Obstacle(string desc, int diff, int attr, string exdesc, Treasure treasure, string cleared, string fail, bool attk = false, bool talk = false, bool dodge = false, bool mov = false)
    {
        Description = desc;
        Difficulty = diff;
        Attribute = attr;
        ExaminedDescription = exdesc;
        Treasure = treasure;
        Attackable = attk;
        Talkable = talk;
        Dodgeable = dodge;
        Moveable = mov;
        ClearedMessage = cleared;
        FailMessage = fail;
    }

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

public class Room
{
    public string Description { get; set; }
    public Room? Next { get; set; }
    public Room? Prev { get; set; }
    public Obstacle? Obstacle { get; set; }
    public bool Cleared { get; set; }
    public bool Examined { get; set; } = false;
    public Room(string description, Obstacle? obstacle = null, bool cleared = false, bool examined = false)
    {
        Description = description;
        Obstacle = obstacle;
    }
    public void Examine(Player player)
    {
        bool SuccessfullExamine = SkillCheck.RollSkillCheck(player.Wit, 4);
        if (SuccessfullExamine)
        {
            if (Obstacle != null)
            {
                Obstacle.Difficulty--;
                Console.WriteLine(Obstacle.ExaminedDescription);
            }
            Examined = true;

            return;
        }
        else
        {
            Console.WriteLine("You fail to notice anything out of place.");
            Examined = true;
            return;
        }
    }
    public bool CanClearObstacle(int action)
    {
        bool obstacleClearable = false;
        if (Obstacle != null)
        {
            switch (action)
            {
                case 1:
                    obstacleClearable = Obstacle.Moveable;
                    break;
                case 2:
                    obstacleClearable = Obstacle.Attackable;
                    break;
                case 3:
                    obstacleClearable = Obstacle.Talkable;
                    break;
                case 4:
                    obstacleClearable = Obstacle.Dodgeable;
                    break;
            }
        }
        return obstacleClearable;
    }
}

public class DungeonLayout
{
    public Room? Start { get; private set; }
    public Room? End { get; private set; }
    public int DungeonLength { get; private set; }
    public void AddRoomStart(string desc, Obstacle? obs = null)
    {
        Room newRoom = new(desc, obs);
        newRoom.Next = Start;
        if (Start != null)
        {
            Start.Prev = newRoom;
        }
        Start = newRoom;
        End ??= newRoom;
        DungeonLength++;
    }
    public void AddRoomEnd(string desc, Obstacle? obs = null)
    {
        if (Start == null)
        {
            AddRoomStart(desc, obs);
            return;
        }
        Room newRoom = new(desc, obs);
        if (End != null) End.Next = newRoom;
        newRoom.Prev = End;
        End = newRoom;
        DungeonLength++;

    }
}