using System;
using System.Linq;

namespace GameThoeryLab1
{
    public class GreedySolver
    {
        public (int?[] answer, int[] usedIngredients, int totalBenefit) Solve(int[,] inputs, int[] restrictions, int[] benefits, (int lower, int? upper)[] resultBounds)
        {
            var results = new int?[benefits.Length];
            var usedIngredients = new int[restrictions.Length];

            var restrictionIndexes = restrictions.Select((restriction, i) => (i: i, restriction: restriction)).ToArray();
            
            var benefitIndexes = benefits.Select((benefit, i) => (i: i, benefit: benefit))
                .OrderByDescending(index => index.benefit)
                .ToArray();

            foreach(var benefitIndex in benefitIndexes)
            {
                var lowerBound = resultBounds[benefitIndex.i].lower;

                var allIngredientsChecksPassed = restrictionIndexes.All(restrictionIndex =>
                    usedIngredients[restrictionIndex.i] + inputs[restrictionIndex.i, benefitIndex.i] * lowerBound <= restrictionIndex.restriction
                );

                if(!allIngredientsChecksPassed)
                {
                    Array.Clear(results, 0, results.Length);
                    Array.Clear(usedIngredients, 0, usedIngredients.Length);
                    return (results, usedIngredients, 0);
                }

                results[benefitIndex.i] = lowerBound;

                for (int j = 0; j < usedIngredients.Length; ++j)
                {
                    usedIngredients[j] += inputs[j, benefitIndex.i] * lowerBound;
                }
            }

            foreach(var benefitIndex in benefitIndexes)
            {
                var bounds = resultBounds[benefitIndex.i];

                Func<int, bool> upperBoundCheck = bounds.upper.HasValue ?
                    index => index <= bounds.upper.Value :
                    (Func<int, bool>)(index => true);

                for(int i = bounds.lower + 1; upperBoundCheck(i); ++i)
                {
                    var oldValue = results[benefitIndex.i] ?? 0;
                    var deltaValue = i - oldValue;

                    var allIngredientsChecksPassed = restrictionIndexes.All(restrictionIndex => 
                        usedIngredients[restrictionIndex.i] + inputs[restrictionIndex.i, benefitIndex.i] * deltaValue <= restrictionIndex.restriction
                    );

                    if(!allIngredientsChecksPassed)
                    {
                        break;
                    }

                    results[benefitIndex.i] = i;
                    
                    for(int j = 0; j < usedIngredients.Length; ++j)
                    {
                        usedIngredients[j] += inputs[j, benefitIndex.i] * deltaValue;
                    }
                }
            }

            var total = 0;
            for (int i = 0; i < results.Length; ++i)
            {
                total += (results[i] ?? 0) * benefits[i];
            }

            return (results, usedIngredients, total);
        }
    }
}
