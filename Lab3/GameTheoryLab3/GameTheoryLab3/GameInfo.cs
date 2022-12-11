namespace GameTheoryLab3
{
    public class GameInfo
    {
        public TileInfo[,] Tiles { get; set; }
        public double[] Probabilities { get; set; }

        public int TotalAIDrunk { get; set; }
        public int TotalAIKnowledge { get; set; }
        public int TotalYouDrunk { get; set; }
        public int TotalYourKnowledge { get; set; }

        public void UpdateTotalValues(TileInfo step)
        {
            TotalAIDrunk += step.AIDrunk;
            TotalAIKnowledge += step.AIKnowledge;
            TotalYouDrunk += step.YouDrunk;
            TotalYourKnowledge += step.YourKnowledge;
        }
    }

    public class TileInfo
    {
        public int AIDrunk { get; set; }
        public int AIKnowledge { get; set; }
        public int YouDrunk { get; set; }
        public int YourKnowledge { get; set; }
        public bool IsEmpty { get; set; }
    }
}
