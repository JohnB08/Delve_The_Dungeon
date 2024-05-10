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
    public List<string> Actions = new List<string> { "move", "attack", "examine", "go" };
    public List<string> Targets = new List<string> { "north", "south", "monster", "room", "down", "up" };
    public string Action { get; private set; }
    public string Target { get; private set; }

    public void ParseAction(string input)
    {
        input = input.ToLower().Trim();
        string[] subStrings = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Action = subStrings.FirstOrDefault(str => Actions.Contains(str));
        Target = subStrings.FirstOrDefault(str => Targets.Contains(str));
    }

}