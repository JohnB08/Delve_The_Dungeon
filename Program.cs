using Components.Utilities;
using Components.Room;
using Components.Player;

PlayerActions action = new();

DungeonLayout dungeon = new();

GameState game = new();

Player player = new();

await GameMessage.PrintMessage("Welcome to Delve the dungeon.", 25);
await GameMessage.PrintMessage("Before we begin this adventure, please tell me your name:", 25);
string? input = Console.ReadLine()?.Trim();
while (String.IsNullOrEmpty(input))
{
    await GameMessage.PrintMessage("\nYou can tell me your name. Any name really. It's okay, you can lie to me.", 25);
    input = Console.ReadLine();
}
player.Name = input;
await GameMessage.PrintMessage("Good. Now let's make you better.\n\n", 25);
await Task.Delay(250);
await GameMessage.PrintMessage("to improve yourself you can set points into the following attributes: \n\n\tStrength\t\tAgility\t\tWit\n\nStrength increases your ability to do heavy liftings, punch, kick and move objects.\n\nAgility is your ability to move and dogde at speed.\n\nWit is your ability to do quick thinking, either in dialogue or when examining your surroundings.", 25);

while (player.Points > 0)
{
    await GameMessage.PrintMessage($"You have {player.Points} points to distribute to make yourself a little better at something. \nPlease type which attribute to increase:", 25);
    string? attr = Console.ReadLine()?.ToLower().Trim();
    if (attr == null)
    {
        await GameMessage.PrintMessage("Please write the attribute you would like to improve.", 25);
        await Task.Delay(250);
        continue;
    }
    try
    {
        player.AddPointsToStats(attr);
        continue;
    }
    catch (Exception ex)
    {
        await GameMessage.PrintMessage(ex.Message, 25);
        await Task.Delay(250);
        continue;
    }
}
List<Room> roomList = new List<Room>
{
    new Room(
        "You stumble upon a small clearing in the dense forest, where a mystical deer radiates a gentle, ethereal glow.",
        new Obstacle(
            "Mystical Deer",
            "A radiant deer whose presence seems to calm the very air around it.",
            2,
            "Upon closer inspection, the deer's antlers shimmer with a subtle sparkle, hinting at hidden magic.",
            new Treasure("Antler Pendant", 3, 3, "Wearing it, your thoughts quicken and deepen."),
            "The deer bows its head and steps aside, allowing you access to a hidden grove.",
            "As you approach hastily, the deer vanishes, and thorny vines rapidly grow, blocking your path permanently.",
            attk: false, talk: true, dodge: true, mov: false
        )
    ),
    new Room(
        "A cavern echoing with the sound of dripping water opens up to reveal walls glittering with crystals. A large crystal cluster blocks the passage ahead.",
        new Obstacle(
            "Crystal Cluster",
            "A dazzling, almost blinding cluster of sharp crystals obstructing the way.",
            4,
            "Examining the cluster reveals its structure is more fragile than it appears, suggesting it could be carefully dismantled.",
            new Treasure("Crystal Shard", 2, 2, "As you hold the shard, your movements become swifter."),
            "With careful manipulation, the crystals are dislodged, clearing the path forward.",
            "In a reckless attempt to break through, a crystal shard ricochets and strikes you fatally.",
            attk: true, talk: false, dodge: false, mov: true
        )
    ),
    new Room(
        "At the heart of a ruined palace, a throne room lays forgotten. Seated upon the throne is a spectral king, gazing mournfully into the distance.",
        new Obstacle(
            "Spectral King",
            "A ghostly monarch bound to his throne, his presence fills the air with sorrow and cold.",
            3,
            "Upon closer observation, you notice a crown that seems to pulse with a dim light.",
            new Treasure("Royal Seal", 1, 5, "Clutching the seal, you feel your strength surge."),
            "The spectral king acknowledges your respect and vanishes, leaving his crown behind.",
            "Disturbing the spectral king enrages him, unleashing a fury that freezes you to your core.",
            attk: false, talk: true, dodge: false, mov: false
        )
    ),
    new Room(
        "Deep within the jungle, you find an ancient altar surrounded by stone idols. One idol suddenly animates, its eyes glowing ominously.",
        new Obstacle(
            "Animated Idol",
            "A stone idol imbued with ancient magic, blocking access to the sacred altar.",
            3,
            "You spot a sequence of symbols at the base of the idol, perhaps a clue to deactivating its magic.",
            new Treasure("Idol's Heart", 1, 3, "Your muscles tense with newfound power as you grasp the heart."),
            "The idol's magic dissipates, and it returns to inert stone, clearing the way to the altar.",
            "Attempting to bypass the idol triggers a deadly trap, sealing your fate with no escape.",
            attk: true, talk: false, dodge: true, mov: false
        )
    )
};

foreach (var room in roomList)
{
    dungeon.AddRoomEnd(room.Description, room.Obstacle);
}
dungeon.AddRoomEnd("This is the end of your journey.");



Room? currentRoom = dungeon.Start;
if (currentRoom == null)
{
    Console.WriteLine("Something went very wrong building the dungeon.");
    return;
}
while (currentRoom?.Next != null && !game.GameOver)
{
    await GameMessage.PrintMessage($"{currentRoom.Description}", 25);
    if (!currentRoom.Cleared) await GameMessage.PrintMessage($"{currentRoom?.Obstacle?.Description}", 25);
    if (currentRoom == dungeon.Start) await GameMessage.PrintMessage("For a quick introduction to how this work, try typing 'help me!'(or just help) for some simple guidance", 25);
    while (currentRoom != null && !currentRoom.Cleared && !game.GameOver)
    {
        await GameMessage.PrintMessage("What do you want to do?", 25);
        input = Console.ReadLine();
        if (input == null || input.Length <= 0) continue;
        action.ParseAction(input);
        if (currentRoom.Obstacle != null)
        {
            game.GameOver = await currentRoom.RunObstacleLogic(player, action);
        }
    }
    if (game.GameOver) continue;
    if (currentRoom != null && currentRoom.Obstacle != null && !currentRoom.Obstacle.Treasure.Equipped)
    {
        await GameMessage.PrintMessage(currentRoom.Obstacle.Treasure.Description, 25);
        await GameMessage.PrintMessage("Do you want to take the item?", 25);
        input = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(input))
        {
            await GameMessage.PrintMessage("Just a simple yes or no will do.", 25);
            continue;
        }
        action.ParseAction(input);
        if (action.Affirmation != 1 && action.Action != 7)
        {
            await GameMessage.PrintMessage("Very well. No item for you.", 25);
        }
        else
        {
            await currentRoom.Obstacle.Treasure.EquipReward(player);
        }
    }
    await GameMessage.PrintMessage("You can move on now, if you wish.", 25);
    input = Console.ReadLine()?.Trim();
    if (String.IsNullOrEmpty(input))
    {
        await GameMessage.PrintMessage("Just tell me if you want to move forward down into the dungeon.", 25);
        continue;
    }
    action.ParseAction(input);
    if (action.Action != 1)
    {
        await GameMessage.PrintMessage("Now is not the time for stuff like this.", 25);
        continue;
    }
    else
    {
        if (action.Target == 1)
        {
            if (currentRoom?.Prev != null)
            {
                currentRoom = currentRoom.Prev;
            }
            else
            {
                await GameMessage.PrintMessage("Cannot go there.", 25);
                continue;
            }
        }
        else if (action.Target == 2)
        {
            if (currentRoom?.Next != null)
            {
                currentRoom = currentRoom.Next;
            }
            else
            {
                await GameMessage.PrintMessage("Cannot go there.", 25);
                continue;
            }
        }
        else
        {
            await GameMessage.PrintMessage("Couldn't parse where you wanted to go. Please try again", 25);
            continue;
        }
    }
}
if (!game.GameOver) Console.WriteLine(currentRoom?.Description);
await GameMessage.PrintMessage("Thanks for playing, press any button to exit the game.", 25);
Console.ReadLine();