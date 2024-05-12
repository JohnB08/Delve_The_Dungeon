namespace Components.Room;
using Components.Player;
using Components.Utilities;


public class Treasure
{
    public string Description { get; set; }
    public int Attribute { get; set; }
    public int Reward { get; set; }
    public string EquipDesc { get; set; }
    public bool Equipped { get; set; } = false;
    /// <summary>
    /// The treasure a player can obtain when clearing an obstacle.
    /// </summary>
    /// <param name="desc">A description of the treasure.</param>
    /// <param name="attr">What attribute does it affect. 1 is strength, 2 is agility, 3 is wit.</param>
    /// <param name="rew">how does it affect the attribute? Integer increasing (or decreasing) the set attribute.</param>
    /// <param name="eqdesc">A message displayed when the item is equipped.</param>
    public Treasure(string desc, int attr, int rew, string eqdesc)
    {
        Description = desc;
        Attribute = attr;
        Reward = rew;
        EquipDesc = eqdesc;
    }
    /// <summary>
    /// A function that equips the item to the player, increasing (or decreasing) the affected attribute.
    /// </summary>
    /// <param name="player"></param>
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
        Equipped = true;
        Console.WriteLine($"{EquipDesc}");
    }
}
public class Obstacle
{
    public string Name { get; set; }
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
    /// <summary>
    /// The constructor for the Obstacle object.
    /// </summary>
    /// <param name="name">The name of the obstacle</param>
    /// <param name="desc">A description of the obstacle, presented to the player</param>
    /// <param name="diff">Int, how difficult is it (keep the number lower than 5 for a "fair" experience.</param>
    /// <param name="attr">What attribute should the player use to overcome it, 1 is strength, 2 is agility, 3 is wit.</param>
    /// <param name="exdesc">When examined, what do the player spot, describe how examining made the obstacle easier to overcome.</param>
    /// <param name="treasure">This is the treasure object associated with the Obstacle</param>
    /// <param name="cleared">The message presented to the player if the obstacle is cleared.</param>
    /// <param name="fail">The message presented to the player if the obstacle is failed.</param>
    /// <param name="attk">Can it be attacked?</param>
    /// <param name="talk">Can it be talked to?</param>
    /// <param name="dodge">Can the player dodge it?</param>
    /// <param name="mov">Can the player move it?</param>
    public Obstacle(string name, string desc, int diff, int attr, string exdesc, Treasure treasure, string cleared, string fail, bool attk = false, bool talk = false, bool dodge = false, bool mov = false)
    {
        Name = name;
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
    /// <summary>
    /// Denne funksjonen tar in et player object, og ser på int Attribute på obstacle den er tilknyttet. 
    /// Den tar så en skillskjekk mellom Player og difficulty til objectet.
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
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
    /// <summary>
    /// Function that tries to attack the obstacle using a player object. Throws an exception if the obstacle is non-attackable.
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool AttackObstacle(Player player)
    {
        if (Attackable)
        {
            return OvercomeObstacle(player);
        }
        else
        {
            throw new InvalidOperationException($"You cannot attack {Name}");
        }
    }
    /// <summary>
    /// Function that tries to talk to the obstacle using the player object, throws exception if peace was never an option.
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool TalkToObstacle(Player player)
    {
        if (Talkable)
        {
            return OvercomeObstacle(player);
        }
        else
        {
            throw new InvalidOperationException($"You cannot talk to {Name}");
        }
    }
    /// <summary>
    /// Function that tries to dodge the obstacle, throws exception if dodging is not possible or needed.
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool DodgeObstacle(Player player)
    {
        if (Dodgeable)
        {
            return OvercomeObstacle(player);
        }
        else
        {
            throw new InvalidOperationException($"Dodging {Name} didn't accomplish anything.");
        }
    }
    /// <summary>
    /// Function that tries to move the obstacle, throws an exception if the object is immoveable.
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool MoveObstacle(Player player)
    {
        if (Moveable)
        {
            return OvercomeObstacle(player);
        }
        else
        {
            throw new InvalidOperationException($"You cannot move {Name}");
        }
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
    /// <summary>
    /// Checks if the room can be examined. Then rolls the examine skillcheck to see if you can make the obstacle a little easier.
    /// </summary>
    /// <param name="player"></param>
    public void Examine(Player player)
    {
        if (Examined)
        {
            Console.WriteLine("You cannot learn anything else from this room.");
            return;
        }
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
}
/* The dungeon layout is a doubly linked list. Where each room referes to the previous and the next room. the Start room is accessible outside. */
public class DungeonLayout
{
    public Room? Start { get; private set; }
    public Room? End { get; private set; }
    public int DungeonLength { get; private set; }
    /// <summary>
    /// Adds a room to the start of a dungeon (simmilar to Array.Shift()). 
    /// </summary>
    /// <param name="desc"></param>
    /// <param name="obs"></param>
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

    /// <summary>
    /// Adds a room to the end of the dungeon (simmilar to Array.Push()).
    /// </summary>
    /// <param name="desc"></param>
    /// <param name="obs"></param>
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