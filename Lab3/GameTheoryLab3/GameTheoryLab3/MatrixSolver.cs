using System;
using System.Collections.Generic;
using System.Linq;

namespace GameTheoryLab3
{
    public class MatrixSolver
    {
        private static Random _rand = new Random();

        public (int i, int j) PlayerStep(GameInfo gameInfo, int playersQuestion)
        {
            var randomAiAnswerIndex = GetRandomIndexOfNonEmptyTile(gameInfo, 1, playersQuestion);
            gameInfo.UpdateTotalValues(gameInfo.Tiles[playersQuestion, randomAiAnswerIndex]);
            return (playersQuestion, randomAiAnswerIndex);
        }

        public (int i, int j) AIStep(GameInfo gameInfo, bool clever)
        {
            var aiStep = 0;

            if (clever)
            {
                var bestSteps = GetOptimalAISteps(gameInfo);
                aiStep = bestSteps[_rand.Next(0, bestSteps.Length)];
            }
            else
            {
                var gameWidth = gameInfo.Tiles.GetLength(1);
                aiStep = _rand.Next(0, gameWidth);
            }

            var randomPlayerAnswerIndex = GetRandomIndexOfNonEmptyTile(gameInfo, 0, aiStep);
            gameInfo.UpdateTotalValues(gameInfo.Tiles[randomPlayerAnswerIndex, aiStep]);
            return (randomPlayerAnswerIndex, aiStep);
        }

        public int[] GetOptimalPlayerSteps(GameInfo gameInfo)
        {
            return GetOptimalSteps(gameInfo, 0, 1, tile => (tile.YouDrunk, tile.YourKnowledge));
        }

        public int[] GetOptimalAISteps(GameInfo gameInfo)
        {
            return GetOptimalSteps(gameInfo, 1, 0, tile => (tile.AIDrunk, tile.AIKnowledge));
        }

        private int[] GetOptimalSteps(GameInfo gameInfo, int strategiesDimension, int resultsDimension, Func<TileInfo, (int drunk, int knowledge)> tileDataAggregator)
        {
            var strategiesCount = gameInfo.Tiles.GetLength(strategiesDimension);
            var resultsCount = gameInfo.Tiles.GetLength(resultsDimension);

            var resultsByStrategy = new Dictionary<int, List<(int drunk, int knowledge, double probability)>>();

            for (int i = 0; i < strategiesCount; ++i)
            {
                var probableResults = new List<(int drunk, int knowledge, double probability)>();

                for (int j = 0; j < resultsCount; ++j)
                {
                    var indices = new int[2];
                    indices[strategiesDimension] = i;
                    indices[resultsDimension] = j;

                    var tile = gameInfo.Tiles.GetValue(indices) as TileInfo;

                    if (tile.IsEmpty)
                    {
                        continue;
                    }

                    (var drunk, var knowledge) = tileDataAggregator(tile);
                    var probability = gameInfo.Probabilities[j];

                    probableResults.Add((drunk, knowledge, probability));
                }

                resultsByStrategy.Add(i, probableResults);
            }

            var weightedResultsByStrategy = resultsByStrategy.ToDictionary(
                strategy => strategy.Key,
                results => results.Value.Aggregate(0.0, (weightedResult, result) => weightedResult + (result.drunk + result.knowledge) * result.probability)
            );

            var sortedResults = weightedResultsByStrategy.OrderByDescending(weightedResult => weightedResult.Value).ToArray();

            var firstBestResult = sortedResults.First().Value;
            var bestStrategies = sortedResults.TakeWhile(result => result.Value == firstBestResult).Select(result => result.Key).ToArray();

            return bestStrategies;
        }

        private int GetRandomIndexOfNonEmptyTile(GameInfo gameInfo, int dimensionToSearch, int selectedIndexOfOtherDimension)
        {
            var searchSize = gameInfo.Tiles.GetLength(dimensionToSearch);

            Func<TileInfo[,], int, TileInfo> tileGetter = dimensionToSearch == 0 ?
                (Func<TileInfo[,], int, TileInfo>)((tiles, counter) => tiles[counter, selectedIndexOfOtherDimension]) :
                (tiles, counter) => tiles[selectedIndexOfOtherDimension, counter];

            var totalProbability = 0.0;
            var randomValue = _rand.NextDouble();
            var randomIndex = -1;

            for (int i = 0; i < searchSize; ++i)
            {
                var tile = tileGetter(gameInfo.Tiles, i);
                if (!tile.IsEmpty)
                {
                    totalProbability += gameInfo.Probabilities[i];

                    if (totalProbability >= randomValue && randomIndex == -1)
                    {
                        randomIndex = i;
                    }
                }
            }

            if (totalProbability != 1 || randomIndex == -1)
            {
                throw new InvalidOperationException("Sum of probabilities must be equal to 1");
            }

            return randomIndex;
        }
    }
}
