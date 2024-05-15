using Components.Utilities;
using Components.Room;
using Components.Player;
using Components.Dungeon;

PlayerActions action = new();

DungeonLayout dungeon = new();

GameState game = new();
RoomList rooms = new();
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
foreach (var room in rooms.roomList)
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