namespace Components.Dungeon;
using Components.Room;

public class RoomList
{
    public List<Room> roomList =
[
    new(
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
    new(
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
    new(
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
    new(
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
];
}