namespace Components.Player;
public class Player
{
    public string? Name { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Wit { get; set; }
    public int Points { get; private set; } = 3;
    public void AddPointsToStats(string stat)
    {
        if (Points > 0)
        {
            switch (stat)
            {
                case "strength":
                    Strength++;
                    Points--;
                    break;
                case "agility":
                    Agility++;
                    Points--;
                    break;
                case "wit":
                    Wit++;
                    Points--;
                    break;
                default:
                    throw new ArgumentException("That is not a valid character trait. Please choose either Strength, Agility or Wit.");
            }

        }
        else
        {
            throw new InvalidOperationException("I'm sorry, but you cannot distribute more points");
        }
    }
}