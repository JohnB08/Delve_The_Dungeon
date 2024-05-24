namespace Components.Dungeon;
using Components.Room;

public class Dungeon
{
    public List<Room> roomList = new List<Room>
{
    new Room(
        "You enter a dimly lit chamber with walls scorched by fire. The heat is palpable, and you can feel the sweat forming on your brow.",
        new Obstacle(
            "Blazing Embers",
            "The floor is covered in smoldering embers that threaten to burn your feet with every step.",
            1,
            "The embers give off a faint smell of burnt wood, sharp and smoky.",
            "Upon closer inspection, you notice gaps between the embers that could be carefully navigated.",
            new Treasure(
                "Fireproof Boots",
                2,
                1,
                "As you wear the boots, you feel a surge of agility coursing through you."
            ),
            "You manage to traverse the embers unscathed, feeling a sense of accomplishment.",
            "The embers ignite your clothing, and you succumb to the flames.",
            mov: true,
            dodge: true
        )
    ),
    new Room(
        "The next room is a narrow corridor with flaming torches lining the walls. The flames dance menacingly, casting eerie shadows.",
        new Obstacle(
            "Torch Gauntlet",
            "Torches blaze fiercely along the walls, making the passage perilous.",
            2,
            "The torches emit a strong, acrid smell, almost suffocating.",
            "You notice that some torches flicker slightly, indicating they might be less stable.",
            new Treasure(
                "Flame Amulet",
                3,
                1,
                "Wearing the amulet, you feel a sharpness in your mind, a readiness for any challenge."
            ),
            "You skillfully navigate through the corridor, the flames failing to touch you.",
            "A torch falls, igniting the corridor and trapping you in an inferno.",
            mov: true,
            dodge: true
        )
    ),
    new Room(
        "You enter a grand hall, the walls lined with dragon carvings, their mouths spouting intermittent bursts of flame.",
        new Obstacle(
            "Dragon Flame Trap",
            "The dragon carvings periodically spew flames across the hall, creating a deadly obstacle.",
            3,
            "The air is filled with the pungent odor of burnt metal and stone.",
            "Examining the carvings closely, you notice a pattern to the flame bursts.",
            new Treasure(
                "Dragon Scale Shield",
                1,
                2,
                "Equipping the shield, you feel a surge of strength and protection."
            ),
            "You time your movements perfectly, slipping past the flames unscathed.",
            "A burst of dragon fire engulfs you, leaving nothing but ashes.",
            attk: true,
            dodge: true
        )
    ),
    new Room(
        "The next chamber is a small, claustrophobic space filled with a thick, choking smoke that makes it hard to see and breathe.",
        new Obstacle(
            "Smoke Screen",
            "The room is filled with dense smoke, obscuring your vision and making it hard to breathe.",
            3,
            "The smoke smells of burning herbs, sharp and acrid.",
            "Through the haze, you spot a series of vents on the walls.",
            new Treasure(
                "Breathing Mask",
                3,
                2,
                "With the mask on, you can breathe easily and think more clearly."
            ),
            "You manage to find and activate the vents, clearing the smoke.",
            "The smoke overwhelms you, and you collapse, gasping for breath.",
            mov: true,
            talk: true
        )
    ),
    new Room(
        "You step into a cavernous room with a large pit of lava in the center. The heat is intense, and the air shimmers with it.",
        new Obstacle(
            "Lava Pit",
            "A large pit of bubbling lava dominates the room, blocking your path.",
            4,
            "The lava gives off an intense, sulfuric smell.",
            "You notice some stable-looking rocks jutting out of the lava, forming a potential path.",
            new Treasure(
                "Heat-Resistant Cloak",
                2,
                2,
                "Wearing the cloak, you feel the intense heat dissipate around you."
            ),
            "You deftly navigate across the rocks, avoiding the molten danger.",
            "A misstep sends you plunging into the lava, your journey ending in a fiery death.",
            mov: true,
            dodge: true
        )
    ),
    new Room(
        "The final chamber is a grand throne room, the throne itself wreathed in magical flames. A fire elemental stands guard, its eyes burning with a fierce intelligence.",
        new Obstacle(
            "Fire Elemental",
            "A fire elemental blocks your path, its body composed entirely of roaring flames.",
            5,
            "The elemental smells like a burning forest, wood and leaves consumed by fire.",
            "You notice a faint shimmer around the elemental, suggesting it might have a weak spot.",
            new Treasure(
                "Elemental Core",
                1,
                3,
                "The core imbues you with immense strength, making you feel invincible."
            ),
            "You manage to defeat or negotiate with the elemental, claiming its core.",
            "The elemental overwhelms you with its fiery power, reducing you to ashes.",
            attk: true,
            talk: true
        )
    )
};
}