using Components.Utilities;
using Components.Room;
using Components.Player;


PlayerActions action = new();

DungeonLayout dungeon = new();

Player player = new();



dungeon.AddRoomStart("A dank and decrepit cellar. The stank of rot fills your nostrils.");
dungeon.AddRoomEnd("A cold chill creeps through you as you enter this long forgotten stony hallway, deep below. Your footsteps echo down this rocky tomb");
dungeon.AddRoomEnd("You reached the end, Good job!");
dungeon.AddRoomStart("You stand in a tarvern, slightly enebriated. A stairwell calls you down to adventure.");
Console.WriteLine("Welcome to Delve the dungeon.");
Console.WriteLine("Before we begin this adventure, please tell me your name:");
string? playerInput = Console.ReadLine();
while (playerInput.Length <= 0)
{
    Console.WriteLine("\nYou can tell me your name. Any name really. It's okay, you can lie to me.");
    playerInput = Console.ReadLine();
}
player.Name = playerInput;
Console.WriteLine("Good. Now let's make you better.\n\n");

while (player.Points > 0)
{
    Console.WriteLine($"You have {player.Points} points to distribute to make yourself a little better at something. \n The attributes you can increase are: \n\n\tStrength\t\tAgility\t\tWit\n\nPlease choose one to increase:");
    string attr = Console.ReadLine();
    if (attr == null)
    {
        Console.WriteLine("Please write the attribute you would like to improve.");
        continue;
    }
    try
    {
        player.AddPointsToStats(attr);
        continue;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        continue;
    }
}

Room currentRoom = dungeon.Start;
while (currentRoom.Next != null)
{
    Console.WriteLine($"{currentRoom.Description}");
    Console.WriteLine("What do you want to do?");
    string input = Console.ReadLine();
    if (input == null) continue;
    else
    {
        action.ParseAction(input);
        Console.WriteLine($"{action.Action} {action.Target}");
        if (action.Action != "go" && action.Action != "move")
        {
            Console.WriteLine("I'm sorry, that action is currently impossible.");
            continue;
        }
        else
        {
            if (action.Target != "north" && action.Target != "south" && action.Target != "down" && action.Target != "up")
            {
                Console.WriteLine("I cannot go in that direction. I can only move north, south, up or down.");
            }
            else
            {
                if (action.Target == "north" || action.Target == "down")
                {
                    currentRoom = currentRoom.Next;
                    continue;
                }
                else if (action.Target == "south" || action.Target == "up")
                {
                    if (currentRoom.Prev == null) continue;
                    else
                    {
                        currentRoom = currentRoom.Prev;
                        continue;
                    }
                }
            }
        }
    }
}
Console.WriteLine(currentRoom.Description);