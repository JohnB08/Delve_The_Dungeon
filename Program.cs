using Components.Utilities;
using Components.Room;


PlayerActions action = new();

DungeonLayout dungeon = new();

dungeon.AddRoomStart("A dank and decrepit cellar. The stank of rot fills your nostrils.");
dungeon.AddRoomEnd("A cold chill creeps through you as you enter this long forgotten stony hallway, deep below. Your footsteps echo down this rocky tomb");
dungeon.AddRoomEnd("You reached the end, Good job!");
dungeon.AddRoomStart("You stand in a tarvern, slightly enebriated. A stairwell calls you down to adventure.");

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
            if (action.Target != "north" && action.Target != "south")
            {
                Console.WriteLine("I cannot go in that direction, try going north or south.");
            }
            else
            {
                if (action.Target == "north")
                {
                    currentRoom = currentRoom.Next;
                    continue;
                }
                else if (action.Target == "south")
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