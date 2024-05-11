﻿using Components.Utilities;
using Components.Room;
using Components.Player;


PlayerActions action = new();

DungeonLayout dungeon = new();

Player player = new();
dungeon.AddRoomEnd("You enter the kitchen.\nBehind the butcher's table there seems to indeed be an old, steep, stairwell going down into the darkness below.", new Obstacle(
        desc: "There seems to be some gaps in the stairs going down.",
        diff: 2,
        attr: 2,
        exdesc: "It should be easy enough to climb the railing instead of worrying about the gaps in the stairs.",
        treasure: new Treasure(
            "A purple cape flutters in a faint breeze. It seems to have a will of its own.",
            3,
            -1,
            "The purple cape ensnares your head and neck.\nThe cloth grips hard, and you can barely breathe.\nYou feel it wrap around your eyes, your mouth, your nose and your neck.\nThe silky cloth cuts int your skin.\nYet you manage to wrestle yourself free.\nA dull ache thumps in your head."
        ),
        dodge: true,
        mov: true,
        cleared: "You successfully climbed down the stairs, something is tied to the bottom rung.",
        fail: "You hop, skip and jump your way down the stairs. It all goes swimmingly until you missjudge a step. \nInstead you end up falling head first into a large casket below. The brown familiar fluid fills your lungs,\n and as the world goes dark you think:'This isn't the worst way to go...'"
    ));
dungeon.AddRoomEnd("A dank and decrepit cellar. The stank of rot fills your nostrils.", new Obstacle(
        desc: "A large vat of some unspeakable gunk blocks your path.\nBelow the vat lies some unfortunate creature who probably attempted the same feat you are about to.",
        diff: 3,
        attr: 1,
        exdesc: "You think you can maybe use some nearby floatsom as leverage, it should be easier to move the vat then.",
        treasure: new Treasure(
            "A golden ring. A faint enscription in foreign letters encircle the surface.",
            3,
            1,
            "A cloud of thoughts stream into your mind, a bullrush of sensations fill your head.\nIt feels as though your head is about to burst,\nwhen suddenly it all clears.\nYou feel more in control of your mind than you have ever been before."
        ),
        attk: true,
        mov: true,
        cleared: "You successfully moved the vat. In the remains of whomever was below it something glitters.",
        fail: "For a moment the huge var seems to give way, but then it rolls back over, trapping your leg.\nIt seems you will share the same faith as whoever or whatever else lies trapped down here with you."
    ));
dungeon.AddRoomEnd("A cold chill creeps through you as you enter this long forgotten stony hallway, deep below. Your footsteps echo down this rocky tomb", new Obstacle(
        desc: "The walls seem brittle and frail. As they would fall at any moment.",
        diff: 3,
        attr: 2,
        exdesc: "The cracks in the walls widen, and the ground beneath your feet begin to rumble. It would be a good idea to run!",
        treasure: new Treasure(
            "A blood covered bracelet with a sunburst jewel encrusted in its center.",
            1,
            1,
            "The bracelet grips on to your arm, it feels tighter and tighters.\nYou feel a weird tingling sensation below your skin.\nYour muscles heat up, your blood boils.\nYou feel stronger."
        ),
        cleared: "You run ahead, narrowly dodging the deadly rocks crashing behind you.\nAs you reach the far side you notice something glimmering in the wall.",
        fail: "You thought you were quick, but this time your feet fail you.\nYour last thought before a stone caves your head in is how pointless this whole drunken endevour was.",
        mov: true,
        dodge: true
    ));
dungeon.AddRoomEnd(
    "You enter a large circular stone room.\nOld runes are carved into the stone surrounding you.\nYou see no exit, and the way you came in is now blocked. A soft clank reverberates through the hall.",
    new Obstacle(
        desc: "An old mechanism seems to block your path forward. It seems partly stuck,\nyet the lever that operates it feels like it could give if you just push harder.",
        diff: 3,
        attr: 1,
        exdesc: "There seems to be something jammed in the lever mechanism. You fiddled it out, and the lever seems move operatable now.",
        treasure: new Treasure(
            "A large Axe. It hums slightly on the ground.",
            1,
            -1,
            "The axe wirls alive as you get closer.\n You narrowly dodges its swing on your neck,\n but you fail to fully escape it second swing as it bites into your shoulder.\nA gracing flesh-wound, but will surely leave a mark."
        ),
        cleared: "You flip the lever, and a large *CLONK* echo throughout the ruins. An unseen door opens in the walls in front of you.",
        fail: "The lever snaps as you pulled just a little too hard.\nSeems like this is the end, with no way forward and no way back.\nMaybe you can survive on rats and fungus until someone comes and finds you.\n Because someone will come down here again, right?",
        mov: true,
        attk: true
    )
);
dungeon.AddRoomEnd(
    "You enter a large chasm, as if a blade once pierced the ground.\nBelow is nothing but darkness.\nFar ahead on the opposite side you see a faint light.", new Obstacle(
        desc: "A long, and spindly bridge spans the chasm between you and fresh air.",
        diff: 4,
        attr: 2,
        exdesc: "You notice some spare rope behind some rockfall, You tense the bridge abit. It seems more stable now.",
        treasure: new Treasure(
            "A pair of hovering boots.",
            2,
            -1,
            "The boots just doesn't want to cooperate.\n You try to take a step forward, yet one boot flies backwards.\nYou get stretched in every direction and as you feel your tendons are about to rip,\nyou finally wriggle free from the shoes."
        ),
        mov: true,
        cleared: "You successfully crossed the bridge. Something spitterspatters across your vision.",
        fail: "The flip flopping motions of the bridge makes it hard to balance. Your head just can't keep track of up and down and you stumble and slip. You fall to the abyss below, atleast you almost made it."
    )
);

dungeon.AddRoomStart("You stand in a tarvern, slightly enebriated. You heard rumours of a hidden stairwell in the kitchens of this tavern.", new Obstacle(
        desc: "A old drunk blocks your way. He is armed, but doesn't seem to know so himself.",
        diff: 3,
        attr: 3,
        exdesc: "He reeks of bad grogg and old stew, it should be easy enough to fool such a creature.",
        fail: "Your remark doesn't seem to have hit the spot, the old fool fumbles for a bit as you stand there awkwardly waiting for a response.\nThen you notice it, a sting in your chest.\nThe old drunk moved so slowly and fubly you failed to notice he reached for his trusty dagger. What luck....",
        treasure: new Treasure(
            "A worn parrying dagger. It glows faintly in a blue hue.",
            2,
            1,
            "The dagger is too worn to be effective as a weapon,\n yet as you grip the hilt a flow of memories stream into you.\nMemories of fight or flight,\nof dangerous escapades an daring doos in the night.\nYour muscle tense as you witness yourself leaping from roof top to roof top.\nYou feel lighter on your feet and ready for action."
        ),
        talk: true,
        mov: true,
        dodge: true,
        cleared: "You outwitted the old drunk, and he stumbles past you to find solace in even more brown liquid."
    ));
dungeon.AddRoomEnd("This is the end of your journey.", null);
Console.WriteLine("Welcome to Delve the dungeon.");
Console.WriteLine("Before we begin this adventure, please tell me your name:");
string? nameInput = Console.ReadLine();
while (nameInput.Length <= 0)
{
    Console.WriteLine("\nYou can tell me your name. Any name really. It's okay, you can lie to me.");
    nameInput = Console.ReadLine();
}
player.Name = nameInput;
Console.WriteLine("Good. Now let's make you better.\n\n");

while (player.Points > 0)
{
    Console.WriteLine($"You have {player.Points} points to distribute to make yourself a little better at something. \n The attributes you can increase are: \n\n\tStrength\t\tAgility\t\tWit\n\nPlease choose one to increase:");
    string attr = Console.ReadLine().ToLower().Trim();
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
bool gameOver = false;
while (currentRoom.Next != null && !gameOver)
{
    Console.WriteLine($"{currentRoom.Description}");
    if (!currentRoom.Cleared) Console.WriteLine($"{currentRoom.Obstacle.Description}");
    Console.WriteLine("What do you want to do?");
    string input = Console.ReadLine();
    if (input == null) continue;
    else
    {
        action.ParseAction(input);
        if (action.Action == null) continue;
        if (!currentRoom.Cleared)
        {
            if (action.Action == "examine")
            {
                currentRoom.Examine(player);
                continue;
            }
            bool canUseAction = currentRoom.CanClearObstacle(action.Action);
            if (!canUseAction)
            {
                Console.WriteLine("Cannot do that to get past this obstacle.");
                continue;
            }
            bool didObstacle = currentRoom.Obstacle.OvercomeObstacle(player);
            if (!didObstacle)
            {
                Console.WriteLine(currentRoom.Obstacle.FailMessage);
                gameOver = true;
            }
            else
            {
                Console.WriteLine(currentRoom.Obstacle.ClearedMessage);
                Console.WriteLine("Do you want to equip the treasure?");
                input = Console.ReadLine();
                if (input != null)
                {
                    action.ParseAction(input);
                    if (action.Action != "y")
                    {
                        Console.WriteLine("Very well!");
                        currentRoom.Cleared = true;
                        continue;
                    }
                    else
                    {
                        currentRoom.Obstacle.Treasure.EquipReward(player);
                        currentRoom.Cleared = true;
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Indecisive, huh? We'll discard this item for now.");
                    currentRoom.Cleared = true;
                    continue;
                }
            }
        }
        else
        {
            if (action.Action == "move")
            {
                if (action.Target == "up")
                {
                    if (currentRoom.Prev != null)
                    {
                        currentRoom = currentRoom.Prev;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Cannot go this way.");
                        continue;
                    }
                }
                else if (action.Target == "down")
                {
                    if (currentRoom.Next != null)
                    {
                        currentRoom = currentRoom.Next;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Cannot go this way.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("That's not a valid direction.");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("There's nothing else to do in this room, better move on.");
            }
        }
    }
}
currentRoom = dungeon.End;
Console.WriteLine(currentRoom.Description);