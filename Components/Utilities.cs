namespace Components.Utilities;
public class SkillCheck
{
    public static bool RollSkillCheck(int attribute, int target)
    {
        Random dice = new();
        return attribute + dice.Next(1, 7) > target;
    }
}


public class PlayerActions
{
    public Dictionary<string, string> Actions = new Dictionary<string, string> { { "move", "move" }, { "go", "move" }, { "run", "move" }, { "walk", "move" }, { "attack", "attack" }, { "fight", "attack" }, { "hit", "attack" }, { "look", "examine" }, { "examine", "examine" }, { "spy", "examine" }, { "scry", "examine" }, { "yes", "y" }, { "y", "y" }, { "aye", "y" }, { "ye", "y" }, { "ja", "y" }, { "no", "n" }, { "n", "n" }, { "nay", "n" }, { "nei", "n" }, { "talk", "talk" }, { "yell", "talk" }, { "whisper", "talk" }, { "fool", "talk" }, { "ruse", "talk" }, { "dodge", "dodge" }, { "roll", "dodge" }, { "evade", "dodge" }, { "trick", "talk" }, { "sure", "y" }, { "help", "help" }, { "h", "help" }, { "hjelp", "help" } };
    public Dictionary<string, string> Targets = new Dictionary<string, string> { { "north", "up" }, { "backwards", "up" }, { "up", "up" }, { "south", "down" }, { "down", "down" }, { "forward", "down" }, { "on", "down" } };
    public string Action { get; private set; }
    public string Target { get; private set; }

    public void ParseAction(string input)
    {
        input = input.ToLower().Trim();
        string[] subStrings = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Action = subStrings.Select(str => Actions.ContainsKey(str) ? Actions[str] : null).FirstOrDefault(str => str != null);
        Target = subStrings.Select(str => Targets.ContainsKey(str) ? Targets[str] : null).FirstOrDefault(str => str != null);
    }
    public string Help()
    {
        string HelpString = "Here are some actions you can do in this game. You can try moving around. when moving around you spesify a direction\nAs an example:\n\t\t'I want to move forward'\nThis action would move you to the next room if available.\nThe rooms will contain obstacles.\nSome obstacles can be attacked, moved, talked to, or dodged.\n It's up to you to find the correct action for each obstacle.\n\nWhen you first enter a room you can also try to examine the room for clues.\nA successfull examination will make the obstacle easier to clear.";
        return HelpString;
    }

}