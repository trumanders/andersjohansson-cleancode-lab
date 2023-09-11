public class GoalBuilder
{
    private Goal goal;
    public GoalBuilder()
    {
        goal = new Goal();
    }

    public GoalBuilder SetGoalLength(int length)
    {
        goal.GoalLength = length;
        return this;
    }

    public GoalBuilder GenerateRandomGoal()
    {
        Random random = new Random();

        do
        {
            string newRandomDigit = random.Next(10).ToString();
            if (!goal.GoalString.Contains(newRandomDigit))
                goal.GoalString += newRandomDigit;
        } while (goal.GoalString.Length < goal.GoalLength);
        return this;    }


    public Goal Build()
    {
        return goal;
    }
}
