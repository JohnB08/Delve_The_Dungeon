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
    public void Examine(Player player)
    {
        bool SuccessfullExamine = SkillCheck.RollSkillCheck(player.Wit, 4);
        if (SuccessfullExamine)
        {
            Obstacle.Difficulty--;
            Examined = true;
            Console.WriteLine(Obstacle.ExaminedDescription);
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
    public void FillLayout()
    {
        List<Treasure> treasures = new List<Treasure> {
        new Treasure(
            "A golden ring. A faint enscription in foreign letters encircle the surface.",
            3,
            1,
            "A cloud of thoughts stream into your mind, a bullrush of sensations fill your head.\nIt feels as though your head is about to burst,\nwhen suddenly it all clears.\nYou feel more in control of your mind than you have ever been before."
        ), new Treasure(
            "A blood covered bracelet with a sunburst jewel encrusted in its center.",
            1,
            1,
            "The bracelet grips on to your arm, it feels tighter and tighters.\nYou feel a weird tingling sensation below your skin.\nYour muscles heat up, your blood boils.\nYou feel stronger."
        ), new Treasure(
            "A worn parrying dagger. It glows faintly in a blue hue.",
            2,
            1,
            "The dagger is too worn to be effective as a weapon,\n yet as you grip the hilt a flow of memories stream into you.\nMemories of fight or flight,\nof dangerous escapades an daring doos in the night.\nYour muscle tense as you witness yourself leaping from roof top to roof top.\nYou feel lighter on your feet and ready for action."
        ), new Treasure(
            "A purple cape flutters in a faint breeze.",
            3,
            -1,
            "The purple cape ensnares your head and neck.\nThe cloth grips hard, and you can barely breathe.\nYou feel it wrap around your eyes, your mouth, your nose and your neck.\nThe silky cloth cuts int your skin.\nYet you manage to wrestle yourself free.\nA dull ache thumps in your head."
        ), new Treasure(
            "A large Axe. It hums slightly on the ground.",
            1,
            -1,
            "The axe wirls alive as you get closer.\n You narrowly dodges its swing on your neck,\n but you fail to fully escape it second swing as it bites into your shoulder.\nA gracing flesh-wound, but will surely leave a mark."
        ), new Treasure(
            "A pair of hovering boots.",
            2,
            -1,
            "The boots just doesn't want to cooperate.\n You try to take a step forward, yet one boot flies backwards.\nYou get stretched in every direction and as you feel your tendons are about to rip,\nyou finally wriggle free from the shoes."
        )};
    }

}