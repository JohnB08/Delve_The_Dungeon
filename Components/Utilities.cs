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
    public Dictionary<string, int> Actions = new Dictionary<string, int> { { "move", 1 }, { "go", 1 }, { "run", 1 }, { "walk", 1 }, { "attack", 2 }, { "fight", 2 }, { "hit", 2 }, { "look", 5 }, { "examine", 5 }, { "spy", 5 }, { "scry", 5 }, { "yes", 7 }, { "y", 7 }, { "aye", 7 }, { "ye", 7 }, { "ja", 7 }, { "no", 8 }, { "n", 8 }, { "nay", 8 }, { "nei", 8 }, { "talk", 3 }, { "yell", 3 }, { "whisper", 3 }, { "fool", 3 }, { "ruse", 3 }, { "dodge", 4 }, { "roll", 4 }, { "evade", 4 }, { "trick", 3 }, { "sure", 7 }, { "help", 6 }, { "h", 6 }, { "hjelp", 6 } };
    public Dictionary<string, int> Targets = new Dictionary<string, int> { { "north", 1 }, { "backwards", 1 }, { "up", 1 }, { "south", 2 }, { "down", 2 }, { "forward", 2 }, { "on", 2 }, { "back", 1 }, { "onwards", 2 } };
    public int Action { get; private set; }
    public int Target { get; private set; }
    public string Help = "Here are some actions you can do in this game. You can try moving around. when moving around you spesify a direction\nAs an example:\n\t\t'I want to move forward'\nThis action would move you to the next room if available.\nThe rooms will contain obstacles.\nSome obstacles can be attacked, moved, talked to, or dodged.\n It's up to you to find the correct action for each obstacle.\n\nWhen you first enter a room you can also try to examine the room for clues.\nA successfull examination will make the obstacle easier to clear.";
    /// <summary>
    /// A function that takes in a string written by the user. And then tries to extract an Action, </br>
    /// and a target from said string.</br>
    /// It does this by splitting the string into an array of substrings.</br>
    /// Then compares those strings and tries to see if they have a corresponding value in the Actions and Target dictionaries</br>
    /// It then sets the first value it finds in the Actions library to PlayerAction.Action, and likewise with PlayerActions.Target</br>
    /// 
    /// </summary>
    /// <param name="input"></param>
    public void ParseAction(string input)
    {
        input = input.ToLower().Trim();
        string[] subStrings = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Action = subStrings.Select(str => Actions.ContainsKey(str) ? Actions[str] : 0).FirstOrDefault(str => str != 0);
        Target = subStrings.Select(str => Targets.ContainsKey(str) ? Targets[str] : 0).FirstOrDefault(str => str != 0);
    }

}