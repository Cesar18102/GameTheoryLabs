using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GameThoeryLab1
{
    public partial class Form1 : Form
    {
        private List<List<NumericUpDown>> _problemInputs = new List<List<NumericUpDown>>();
        private List<NumericUpDown> _problemRestrictions = new List<NumericUpDown>();
        private List<NumericUpDown> _problemBenefits = new List<NumericUpDown>();
        private List<(NumericUpDown result, NumericUpDown lowerBound, NumericUpDown upperBound)> _results = new List<(NumericUpDown result, NumericUpDown lowerBound, NumericUpDown upperBound)>();

        private static readonly GreedySolver _solver = new GreedySolver();

        private static readonly Size PROBLEM_CELL_SIZE = new Size(50, 30);
        private static readonly Size PROBLEM_CELL_PADDING = new Size(5, 5);

        public Form1()
        {
            InitializeComponent();

            IngredientsCounter_ValueChanged(null, null);
            GoodsCounter_ValueChanged(null, null);
        }

        private void GoodsCounter_ValueChanged(object sender, EventArgs e)
        {
            var countStart = _problemInputs.FirstOrDefault()?.Count ?? 0;

            for (int i = countStart; i > GoodsCounter.Value; --i)
            {
                foreach (var row in _problemInputs)
                {
                    ProblemPanel.Controls.Remove(row.Last());
                    row.RemoveAt(row.Count - 1);
                }

                var benefitCell = _problemBenefits.Last();
                BenefitPanel.Controls.Remove(benefitCell);
                _problemBenefits.Remove(benefitCell);

                var resultCells = _results.Last();
                ResultsPanel.Controls.Remove(resultCells.result);
                ResultsPanel.Controls.Remove(resultCells.lowerBound);
                ResultsPanel.Controls.Remove(resultCells.upperBound);
                _results.RemoveAt(_results.Count - 1);
            }

            for (int i = countStart; i < GoodsCounter.Value; ++i)
            {
                for (int j = 0; j < IngredientsCounter.Value; ++j)
                {
                    var cell = GetProblemCell(i, j, -100, 100);
                    ProblemPanel.Controls.Add(cell);
                    _problemInputs[j].Add(cell);
                }
            }

            var benefitStartCount = _problemBenefits.Count;

            for (int i = benefitStartCount; i < GoodsCounter.Value; ++i)
            {
                var benefitCell = GetProblemCell(i, 0, 0, 1000);
                BenefitPanel.Controls.Add(benefitCell);
                _problemBenefits.Add(benefitCell);
            }

            var resultsStartCount = _results.Count;

            for (int i = resultsStartCount; i < GoodsCounter.Value; ++i)
            {
                var upperBoundCell = GetProblemCell(i, 0, 0, 1000);
                ResultsPanel.Controls.Add(upperBoundCell);

                var resultCell = GetProblemCell(i, 1, -1000, 1000);
                ResultsPanel.Controls.Add(resultCell);

                var lowerBoundCell = GetProblemCell(i, 2, 0, 1000);
                ResultsPanel.Controls.Add(lowerBoundCell);

                _results.Add((resultCell, lowerBoundCell, upperBoundCell));
            }
        }

        private void IngredientsCounter_ValueChanged(object sender, EventArgs e)
        {
            var countStart = _problemInputs.Count;

            for(int i = countStart; i > IngredientsCounter.Value; --i)
            {
                foreach (var cell in _problemInputs.Last())
                {
                    ProblemPanel.Controls.Remove(cell);
                }

                _problemInputs.RemoveAt(countStart - 1);

                var restrictionCell = _problemRestrictions.Last();
                RestrictionsPanel.Controls.Remove(restrictionCell);
                _problemRestrictions.Remove(restrictionCell);
            }

            for(int i = countStart; i < IngredientsCounter.Value; ++i)
            {
                var cellRow = new List<NumericUpDown>();

                for(int j = 0; j < GoodsCounter.Value; ++j)
                {
                    var cell = GetProblemCell(j, i, -100, 100);
                    ProblemPanel.Controls.Add(cell);
                    cellRow.Add(cell);
                }
                _problemInputs.Add(cellRow);

                var restrictionCell = GetProblemCell(0, i, 0, 100000);
                RestrictionsPanel.Controls.Add(restrictionCell);
                _problemRestrictions.Add(restrictionCell);
            }
        }

        private NumericUpDown GetProblemCell(int xi, int yi, decimal min, decimal max)
        {
            var cell = new NumericUpDown() { Minimum = min, Maximum = max };
            cell.Size = PROBLEM_CELL_SIZE;
            cell.Location = new Point(
                xi * (PROBLEM_CELL_SIZE.Width + PROBLEM_CELL_PADDING.Width),
                yi * (PROBLEM_CELL_SIZE.Height + PROBLEM_CELL_PADDING.Height)
            );
            return cell;
        }

        private (int[,] inputs, int[] restrictions, int[] benefits, (int lower, int? upper)[] resultBounds) GetData()
        {
            var inputs = new int[_problemInputs.Count, _problemInputs[0].Count];

            for(int i = 0; i < _problemInputs.Count; ++i)
            {
                for(int j = 0; j < _problemInputs[i].Count; ++j)
                {
                    inputs[i, j] = Convert.ToInt32(_problemInputs[i][j].Value);
                }
            }

            var restrictions = _problemRestrictions.Select(restriction => Convert.ToInt32(restriction.Value)).ToArray();
            var benefits = _problemBenefits.Select(benefit => Convert.ToInt32(benefit.Value)).ToArray();
            var resultBounds = _results.Select(
                result => (
                    Convert.ToInt32(result.lowerBound.Value),
                    result.upperBound.Value == 0 ? null : (int?)Convert.ToInt32(result.upperBound.Value)
                )
            ).ToArray();

            return (inputs, restrictions, benefits, resultBounds);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            var data = GetData();
            var answer = _solver.Solve(data.inputs, data.restrictions, data.benefits, data.resultBounds);

            if(answer.answer.All(value => value == null))
            {
                MessageBox.Show("No solution wa found");
                return;
            }
            
            for(int i = 0; i < answer.answer.Length; ++i)
            {
                _results[i].result.Value = answer.answer[i] ?? 0;
            }

            TotalBenefitLabel.Text = answer.totalBenefit.ToString();
        }
    }
}
