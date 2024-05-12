using Components.Utilities;
using Components.Room;
using Components.Player;

PlayerActions action = new();

DungeonLayout dungeon = new();

Player player = new();

dungeon.AddRoomEnd("You stand in the kitchen.\nBehind the butcher's table there seems to indeed be an old, steep, stairwell going down into the darkness below.", new Obstacle(
        name: "The Sharp Mess",
        desc: "Dangerous tools and rusty instruments lie strewn all over this kitchen, one wrong move and it could go very bad.\nSomething is tied to the stairs, it flutters in a light breeze.",
        diff: 2,
        attr: 2,
        exdesc: "You plot a good route through the maze of rust and sharp stuff. You feel ready to navigate the maze of dangerous and sharp objects.",
        treasure: new Treasure(
            desc: "A purple cape flutters in a faint breeze. It seems to have a will of its own.",
            attr: 3,
            rew: -1,
            eqdesc: "The purple cape ensnares your head and neck.\nThe cloth grips hard, and you can barely breathe.\nYou feel it wrap around your eyes, your mouth, your nose and your neck.\nThe silky cloth cuts int your skin.\nYet you manage to wrestle yourself free.\nA dull ache thumps in your head."
        ),
        dodge: true,
        mov: true,
        cleared: "You successfully navigated the rusty field of discared glass shards and sharp utensils. You see clearly now what's tied to the top of the stairs.",
        fail: "You decide to just go for it, and sprints through the kitchen. You slip on some leftover, old veal.\nAfter you slide through the disregarded and broken kitchenutensils there's little to no difference between you,\nand the minced meat they serve in the stew.\n'Now that really makes me think' you say to yourself as the world fade to black."
    ));
dungeon.AddRoomEnd("A dank and decrepit cellar. The stank of rot fills your nostrils.", new Obstacle(
        name: "The Vat",
        desc: "A large vat of some unspeakable gunk blocks your path.\nBelow the vat lies some unfortunate creature who probably attempted the same feat you are about to.",
        diff: 3,
        attr: 1,
        exdesc: "You think you can maybe use some nearby floatsom as leverage, it should be easier to move the vat then.",
        treasure: new Treasure(
           desc: "A golden ring. A faint enscription in foreign letters encircle the surface.",
           attr: 3,
           rew: 1,
           eqdesc: "A cloud of thoughts stream into your mind, a bullrush of sensations fill your head.\nIt feels as though your head is about to burst,\nwhen suddenly it all clears.\nYou feel more in control of your mind than you have ever been before."
        ),
        attk: true,
        mov: true,
        cleared: "You successfully moved the vat. In the remains of whomever was below it something glitters.",
        fail: "For a moment the huge var seems to give way, but then it rolls back over, trapping your leg.\nIt seems you will share the same faith as whoever or whatever else lies trapped down here with you."
    ));
dungeon.AddRoomEnd("A cold chill creeps through you when you stand in this long forgotten stony hallway, deep below. Your footsteps echo down this rocky tomb", new Obstacle(
        name: "The Hallway",
        desc: "The walls seem brittle and frail. As they would fall at any moment.",
        diff: 3,
        attr: 2,
        exdesc: "The cracks in the walls widen, and the ground beneath your feet begin to rumble. It would be a good idea to run!",
        treasure: new Treasure(
            desc: "A blood covered bracelet with a sunburst jewel encrusted in its center.",
            attr: 1,
            rew: 1,
            eqdesc: "The bracelet grips on to your arm, it feels tighter and tighters.\nYou feel a weird tingling sensation below your skin.\nYour muscles heat up, your blood boils.\nYou feel stronger."
        ),
        cleared: "You run ahead, narrowly dodging the deadly rocks crashing behind you.\nAs you reach the far side you notice something glimmering in the wall.",
        fail: "You thought you were quick, but this time your feet fail you.\nYour last thought before a stone caves your head in is how pointless this whole drunken endevour was.",
        mov: true,
        dodge: true
    ));
dungeon.AddRoomEnd(
    "You stand in a large circular stone room.\nOld runes are carved into the stone surrounding you.\nYou see no exit, and the way you came in is now blocked. A soft clank reverberates through the hall.",
    new Obstacle(
        name: "The Lever",
        desc: "An old mechanism seems to block your path forward. It seems partly stuck,\nyet the lever that operates it feels like it could give if you just push harder.",
        diff: 3,
        attr: 1,
        exdesc: "There seems to be something jammed in the lever mechanism. You fiddled it out, and the lever seems move operatable now.",
        treasure: new Treasure(
            desc: "A large Axe. It hums slightly on the ground.",
            attr: 1,
            rew: -1,
            eqdesc: "The axe wirls alive as you get closer.\n You narrowly dodges its swing on your neck,\n but you fail to fully escape it second swing as it bites into your shoulder.\nA gracing flesh-wound, but will surely leave a mark."
        ),
        cleared: "You flip the lever, and a large *CLONK* echo throughout the ruins. An unseen door opens in the walls in front of you.",
        fail: "The lever snaps as you pulled just a little too hard.\nSeems like this is the end, with no way forward and no way back.\nMaybe you can survive on rats and fungus until someone comes and finds you.\n Because someone will come down here again, right?",
        mov: true,
        attk: true
    )
);
dungeon.AddRoomEnd(
    "This room contains a large chasm, as if a blade once pierced the ground.\nBelow is nothing but darkness.", new Obstacle(
        name: "The Bridge",
        desc: "A long, and spindly bridge spans the chasm.\nAt the other side you see a faint light promising freedom!",
        diff: 4,
        attr: 2,
        exdesc: "You notice some spare rope behind some rockfall, You tense the bridge abit. It seems more stable now.",
        treasure: new Treasure(
            desc: "A pair of hovering boots.",
            attr: 2,
            rew: -1,
            eqdesc: "The boots just doesn't want to cooperate.\n You try to take a step forward, yet one boot flies backwards.\nYou get stretched in every direction and as you feel your tendons are about to rip,\nyou finally wriggle free from the shoes."
        ),
        mov: true,
        cleared: "You successfully crossed the bridge. Something spitterspatters across your vision.",
        fail: "The flip flopping motions of the bridge makes it hard to balance. Your head just can't keep track of up and down and you stumble and slip. You fall to the abyss below, atleast you almost made it."
    )
);

dungeon.AddRoomStart("You stand in a tarvern, slightly enebriated. You heard rumours of a hidden stairwell in the kitchens of this tavern.", new Obstacle(
        name: "The Drunk",
        desc: "A old drunk blocks your way. He is armed, but doesn't seem to know so himself.",
        diff: 3,
        attr: 3,
        exdesc: "He reeks of bad grogg and old stew, it should be easy enough to fool such a creature.",
        fail: "Your remark doesn't seem to have hit the spot, the old fool fumbles for a bit as you stand there awkwardly waiting for a response.\nThen you notice it, a sting in your chest.\nThe old drunk moved so slowly and fubly you failed to notice he reached for his trusty dagger. What luck....",
        treasure: new Treasure(
           desc: "A worn parrying dagger. It glows faintly in a blue hue.",
           attr: 2,
            rew: 1,
            eqdesc: "The dagger is too worn to be effective as a weapon,\n yet as you grip the hilt a flow of memories stream into you.\nMemories of fight or flight,\nof dangerous escapades an daring doos in the night.\nYour muscle tense as you witness yourself leaping from roof top to roof top.\nYou feel lighter on your feet and ready for action."
        ),
        talk: true,
        mov: true,
        dodge: true,
        cleared: "You outwitted the old drunk, and he stumbles past you to find solace in even more brown liquid.\nHe drops his blade."
    ));
dungeon.AddRoomEnd("This is the end of your journey.");

Console.WriteLine("Welcome to Delve the dungeon.");
Console.WriteLine("Before we begin this adventure, please tell me your name:");
string? input = Console.ReadLine();
while (input != null && input.Length <= 0)
{
    Console.WriteLine("\nYou can tell me your name. Any name really. It's okay, you can lie to me.");
    input = Console.ReadLine();
}
if (input != null) player.Name = input;
Console.WriteLine("Good. Now let's make you better.\n\n");
await Task.Delay(250);
Console.WriteLine("to improve yourself you can set points into the following attributes: \n\n\tStrength\t\tAgility\t\tWit\n\nStrenght increases your ability to do heavy liftings, punch, kick and move objects.\n\nAgility is your ability to move and dogde at speed.\n\nWit is your ability to do quick thinking, either in dialogue or when examining your surroundings.");

while (player.Points > 0)
{
    Console.WriteLine($"You have {player.Points} points to distribute to make yourself a little better at something. \nPlease type which attribute to increase:");
    string? attr = Console.ReadLine()?.ToLower().Trim();
    if (attr == null)
    {
        Console.WriteLine("Please write the attribute you would like to improve.");
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
        Console.WriteLine(ex.Message);
        await Task.Delay(250);
        continue;
    }
}


Room? currentRoom = dungeon.Start;
bool gameOver = false;
if (currentRoom == null)
{
    Console.WriteLine("Something went very wrong building the dungeon.");
    return;
}
while (currentRoom?.Next != null && !gameOver)
{
    Console.WriteLine($"{currentRoom.Description}");
    await Task.Delay(250);
    if (!currentRoom.Cleared) Console.WriteLine($"{currentRoom?.Obstacle?.Description}");
    await Task.Delay(250);
    Console.WriteLine("For a quick introduction to how this work, try typing 'help me!'(or just help) for some simple guidance");
    await Task.Delay(250);
    while (currentRoom != null && !currentRoom.Cleared)
    {
        Console.WriteLine("What do you want to do?");
        input = Console.ReadLine();
        if (input == null || input.Length <= 0) continue;
        action.ParseAction(input);
        if (currentRoom.Obstacle != null)
            switch (action.Action)
            {
                case 1:
                    try
                    {
                        currentRoom.Cleared = currentRoom.Obstacle.MoveObstacle(player);
                        gameOver = !currentRoom.Cleared;
                        if (gameOver) Console.WriteLine(currentRoom.Obstacle.FailMessage);
                        else Console.WriteLine(currentRoom.Obstacle.ClearedMessage);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                case 2:
                    try
                    {
                        currentRoom.Cleared = currentRoom.Obstacle.AttackObstacle(player);
                        gameOver = !currentRoom.Cleared;
                        if (gameOver) Console.WriteLine(currentRoom.Obstacle.FailMessage);
                        else Console.WriteLine(currentRoom.Obstacle.ClearedMessage);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                case 3:
                    try
                    {
                        currentRoom.Cleared = currentRoom.Obstacle.TalkToObstacle(player);
                        gameOver = !currentRoom.Cleared;
                        if (gameOver) Console.WriteLine(currentRoom.Obstacle.FailMessage);
                        else Console.WriteLine(currentRoom.Obstacle.ClearedMessage);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                case 4:
                    try
                    {
                        currentRoom.Cleared = currentRoom.Obstacle.DodgeObstacle(player);
                        gameOver = !currentRoom.Cleared;
                        if (gameOver) Console.WriteLine(currentRoom.Obstacle.FailMessage);
                        else Console.WriteLine(currentRoom.Obstacle.ClearedMessage);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                case 5:
                    currentRoom.Examine(player);
                    break;
                case 6:
                    Console.WriteLine(action.Help);
                    break;
            }
    }
    if (currentRoom != null && currentRoom.Obstacle != null && !currentRoom.Obstacle.Treasure.Equipped)
    {
        Console.WriteLine("Do you want to take the item?");
        input = Console.ReadLine();
        if (input == null || input.Length <= 0)
        {
            Console.WriteLine("Just a simple yes or no will do.");
            continue;
        }
        action.ParseAction(input);
        if (action.Affirmation != 1)
        {
            Console.WriteLine("Very well. No item for you.");
        }
        else
        {
            currentRoom.Obstacle.Treasure.EquipReward(player);
        }
    }
    Console.WriteLine("You can move on now, if you wish.");
    input = Console.ReadLine();
    if (input == null || input.Length <= 0)
    {
        Console.WriteLine("Just tell me if you want to move forward down into the dungeon.");
        continue;
    }
    action.ParseAction(input);
    if (action.Action != 1)
    {
        Console.WriteLine("Now is not the time for stuff like this.");
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
                Console.WriteLine("Cannot go there.");
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
                Console.WriteLine("Cannot go there.");
                continue;
            }
        }
        else
        {
            Console.WriteLine("Couldn't parse where you wanted to go. Please try again");
            continue;
        }
    }
}
Console.WriteLine(currentRoom?.Description);
Console.WriteLine("Thanks for playing, press any button to exit the game.");
Console.ReadLine();