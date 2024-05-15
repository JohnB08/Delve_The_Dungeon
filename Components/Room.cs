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
    public async Task EquipReward(Player player)
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
        await GameMessage.PrintMessage(EquipDesc, 25);
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
    /// <param name="exdesc">When examined, what do the player spot, describe how examining made the obstacle easier to overcome.</param>
    /// <param name="treasure">This is the treasure object associated with the Obstacle</param>
    /// <param name="cleared">The message presented to the player if the obstacle is cleared.</param>
    /// <param name="fail">The message presented to the player if the obstacle is failed.</param>
    /// <param name="attk">Can it be attacked?</param>
    /// <param name="talk">Can it be talked to?</param>
    /// <param name="dodge">Can the player dodge it?</param>
    /// <param name="mov">Can the player move it?</param>
    public Obstacle(string name, string desc, int diff, string exdesc, Treasure treasure, string cleared, string fail, bool attk = false, bool talk = false, bool dodge = false, bool mov = false)
    {
        Name = name;
        Description = desc;
        Difficulty = diff;
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
    /// Function that tries to attack the obstacle using a player object. Throws an exception if the obstacle is non-attackable.
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool AttackObstacle(Player player)
    {
        if (Attackable)
        {
            return SkillCheck.RollSkillCheck(player.Strength, Difficulty);
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
            return SkillCheck.RollSkillCheck(player.Wit, Difficulty);
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
            return SkillCheck.RollSkillCheck(player.Agility, Difficulty);
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
            return SkillCheck.RollSkillCheck(player.Strength, Difficulty);
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
    public async Task Examine(Player player)
    {
        if (Examined)
        {
            await GameMessage.PrintMessage("You cannot learn anything else from this room.", 25);
            return;
        }
        bool SuccessfullExamine = SkillCheck.RollSkillCheck(player.Wit, 4);
        if (SuccessfullExamine)
        {
            if (Obstacle != null)
            {
                Obstacle.Difficulty--;
                await GameMessage.PrintMessage(Obstacle.ExaminedDescription, 25);
            }
            Examined = true;

            return;
        }
        else
        {
            await GameMessage.PrintMessage("You fail to notice anything out of place.", 25);
            Examined = true;
            return;
        }
    }
    /// <summary>
    /// The main method that runs the obstacle logic.
    /// </summary>
    /// <param name="player">The player is the current player object.</param>
    /// <param name="Actions">the Actions is the current player actions parsed.</param>
    /// <param name="gameOver">The main bool game over. called as a reference so the method knows what to manipulate.</param>
    public async Task<bool> RunObstacleLogic(Player player, PlayerActions Actions)
    {
        if (Obstacle == null) return false;
        switch (Actions.Action)
        {
            case 1:
                try
                {
                    Cleared = Obstacle.MoveObstacle(player);
                    if (!Cleared) await GameMessage.PrintMessage(Obstacle.FailMessage, 25);
                    else await GameMessage.PrintMessage(Obstacle.ClearedMessage, 25);
                    return !Cleared;
                }
                catch (Exception ex)
                {
                    await GameMessage.PrintMessage(ex.Message, 25);
                    return false;
                }
            case 2:
                try
                {
                    Cleared = Obstacle.AttackObstacle(player);
                    if (!Cleared) await GameMessage.PrintMessage(Obstacle.FailMessage, 25);
                    else await GameMessage.PrintMessage(Obstacle.ClearedMessage, 25);
                    return !Cleared;
                }
                catch (Exception ex)
                {
                    await GameMessage.PrintMessage(ex.Message, 25);
                    return false;
                }
            case 3:
                try
                {
                    Cleared = Obstacle.TalkToObstacle(player);
                    if (!Cleared) await GameMessage.PrintMessage(Obstacle.FailMessage, 25);
                    else await GameMessage.PrintMessage(Obstacle.ClearedMessage, 25);
                    return !Cleared;
                }
                catch (Exception ex)
                {
                    await GameMessage.PrintMessage(ex.Message, 25);
                    return false;
                }
            case 4:
                try
                {
                    Cleared = Obstacle.DodgeObstacle(player);
                    if (!Cleared) await GameMessage.PrintMessage(Obstacle.FailMessage, 25);
                    else await GameMessage.PrintMessage(Obstacle.ClearedMessage, 25);
                    return !Cleared;
                }
                catch (Exception ex)
                {
                    await GameMessage.PrintMessage(ex.Message, 25);
                    return false;
                }
            case 5:
                await Examine(player);
                return false;
            case 6:
                await GameMessage.PrintMessage(Actions.Help, 25);
                return false;
            default:
                await GameMessage.PrintMessage("I couldn't quite understand what you wanted.\nTry again, or type help for some help!", 25);
                return false;
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