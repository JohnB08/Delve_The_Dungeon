namespace Components.Dungeon;
using Components.Room;

public class Dungeon
{
    public List<Room> roomList = new List<Room> {
        new Room(
            "You enter a dimly lit cavern with stalactites hanging from the ceiling. The air is damp and the ground uneven.",
            new Obstacle(
                "Slippery Rocks",
                "The ground is covered with slippery rocks, making it difficult to move without falling.",
                3,
                "Upon closer inspection, you notice a pattern in the rocks, revealing a safer path.",
                new Treasure("Agility Potion", 2, 2, "You feel lighter and quicker after drinking the potion."),
                "You navigate the treacherous ground successfully and find a small vial.",
                "You slip and fall, hitting your head on a rock. You lose consciousness.",
                mov: true,
                dodge: true
            )
        ),
        new Room(
            "A narrow passageway leads you to an underground river. The water is dark and swift.",
            new Obstacle(
                "Raging River",
                "The river is too strong to swim across without some aid.",
                4,
                "You spot some sturdy vines hanging from the ceiling that could be used to swing across.",
                new Treasure("Strength Elixir", 1, 3, "You feel your muscles swell with newfound strength."),
                "You manage to cross the river using the vines, finding a small bottle on the other side.",
                "You are swept away by the current, struggling helplessly as the water engulfs you.",
                mov: true,
                attk: true
            )
        ),
        new Room(
            "The passage opens up into a large chamber with a high ceiling. There's a faint light coming from a hole above.",
            new Obstacle(
                "Fallen Debris",
                "A pile of heavy debris blocks your way forward.",
                2,
                "Upon examining, you notice that some of the debris can be moved aside to create a path.",
                new Treasure("Golden Key", 3, 1, "The key feels ancient and valuable."),
                "You clear the debris and discover a golden key among the rubble.",
                "You are unable to move the debris, and your efforts are in vain.",
                mov: true,
                talk: true
            )
        ),
        new Room(
            "You find yourself in a room with walls covered in intricate carvings. The carvings seem to depict an ancient story.",
            new Obstacle(
                "Ancient Puzzle",
                "The carvings form a complex puzzle that needs to be solved to proceed.",
                3,
                "Careful examination reveals clues hidden in the carvings that simplify the puzzle.",
                new Treasure("Wit's Amulet", 3, 2, "You feel your mind sharpen as you put on the amulet."),
                "You solve the puzzle, and a hidden compartment opens, revealing a shining amulet.",
                "You are unable to solve the puzzle, and the room remains sealed.",
                talk: true,
                attk: true
            )
        ),
        new Room(
            "A cold wind blows as you step into a large, open chamber. In the center, there is a pedestal with a glowing orb.",
            new Obstacle(
                "Guardian Statue",
                "A statue of a fierce guardian blocks access to the orb, coming to life as you approach.",
                5,
                "You notice that the statue has weak points in its structure.",
                new Treasure("Orb of Wisdom", 3, 3, "Holding the orb, you feel a surge of clarity and insight."),
                "You defeat the guardian statue, and the glowing orb is now within your reach.",
                "The guardian strikes you down with its mighty blows, and darkness consumes you.",
                attk: true,
                dodge: true
            )
        )
    };
}