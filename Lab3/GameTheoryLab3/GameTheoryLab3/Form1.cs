using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GameTheoryLab3
{
    public partial class Form1 : Form
    {
        private Button[] _playersButtons;
        private GameMatrixTile[,] _gameMatrix;
        private NumericUpDown[] _aiProbabilityInputs;
        
        private GameInfo _gameInfo;
        private MatrixSolver _solver = new MatrixSolver();

        private (int i, int j)? _prevPlayerStep;
        private (int i, int j)? _prevAiStep;

        private int _step = 0;
        
        private const int GAME_HEIGHT = 4;
        private const int GAME_WIDTH = 4;

        public Form1()
        {
            InitializeComponent();

            _playersButtons = new Button[]
            {
                AskSomethTrivialDone,
                AskSomethUnusualDone,
                AskSomethTrivialNeverDone,
                AskSomethUnusualNeverDone
            };

            foreach(var playerButton in _playersButtons)
            {
                playerButton.Click += PlayerButton_Click;
            }

            _gameMatrix = new GameMatrixTile[,]
            {
                { gameMatrixTile1, gameMatrixTile2, gameMatrixTile3, gameMatrixTile4 },
                { gameMatrixTile8, gameMatrixTile7, gameMatrixTile6, gameMatrixTile5 },
                { gameMatrixTile12, gameMatrixTile11, gameMatrixTile10, gameMatrixTile9 },
                { gameMatrixTile16, gameMatrixTile15, gameMatrixTile14, gameMatrixTile13 }
            };

            _aiProbabilityInputs = new NumericUpDown[]
            {
                DoneTrivialProbabilityInput,
                DoneUnusualProbabilityInput,
                NeverDoneTrivialProbabilityInput,
                NeverDoneUnusualProbabilityInput
            };

            //set up default values
            _gameMatrix[0, 1].MakeEmpty();
            _gameMatrix[0, 3].MakeEmpty();
            _gameMatrix[1, 0].MakeEmpty();
            _gameMatrix[1, 2].MakeEmpty();
            _gameMatrix[2, 1].MakeEmpty();
            _gameMatrix[2, 3].MakeEmpty();
            _gameMatrix[3, 0].MakeEmpty();
            _gameMatrix[3, 2].MakeEmpty();

            _gameMatrix[0, 0].SetValues(-1, 0, -1, 0);
            _gameMatrix[0, 2].SetValues(0, 0, -1, 1);
            _gameMatrix[1, 1].SetValues(-1, 1, -1, 1);
            _gameMatrix[1, 3].SetValues(0, 1, -1, 0);
            _gameMatrix[2, 0].SetValues(-1, 1, 0, 0);
            _gameMatrix[2, 2].SetValues(0, 1, 0, 1);
            _gameMatrix[3, 1].SetValues(-1, 0, 0, 1);
            _gameMatrix[3, 3].SetValues(0, 0, 0, 0);

            _gameInfo = new GameInfo()
            {
                Tiles = new TileInfo[GAME_HEIGHT, GAME_WIDTH],
                Probabilities = new double[GAME_WIDTH]
            };

            for(int i = 0; i < GAME_HEIGHT; ++i)
            {
                for(int j = 0; j < GAME_WIDTH; ++j)
                {
                    _gameInfo.Tiles[i, j] = new TileInfo();
                    _gameMatrix[i, j].ValueChanged += OnInputValueChanged;
                }
            }

            for(int i = 0; i < _aiProbabilityInputs.Length; ++i)
            {
                _aiProbabilityInputs[i].ValueChanged += OnInputValueChanged;
            }

            UpdateGameInfo();
            UpdateHints();
        }

        private void OnInputValueChanged(object sender, EventArgs e)
        {
            UpdateGameInfo();
            UpdateHints();
        }

        private void AIHaveDoneTrivialProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            NeverDoneTrivialProbabilityInput.Value = 1 - DoneTrivialProbabilityInput.Value;
        }

        private void AIHaveDoneUnusualProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            NeverDoneUnusualProbabilityInput.Value = 1 - DoneUnusualProbabilityInput.Value;
        }

        private void UpdateGameInfo()
        {
            for (int j = 0; j < GAME_WIDTH; ++j)
            {
                for (int i = 0; i < GAME_HEIGHT; ++i)
                {
                    _gameMatrix[j, i].PutValues(_gameInfo.Tiles[j, i]);
                }

                _gameInfo.Probabilities[j] = Convert.ToDouble(_aiProbabilityInputs[j].Value);
            }
        }

        private void PlayerButton_Click(object sender, EventArgs e)
        {
            _step++;
            StepLabel.Text = _step.ToString();

            if(_prevPlayerStep.HasValue)
            {
                _gameMatrix[_prevPlayerStep.Value.i, _prevPlayerStep.Value.j].BorderColor = null;
            }

            if(_prevAiStep.HasValue)
            {
                _gameMatrix[_prevAiStep.Value.i, _prevAiStep.Value.j].BorderColor = null;
            }    

            UpdateGameInfo();

            var buttonIndex = Array.IndexOf(_playersButtons, sender);
            _prevPlayerStep = _solver.PlayerStep(_gameInfo, buttonIndex);
            _prevAiStep = _solver.AIStep(_gameInfo, CleverAICheckBox.Checked);

            _gameMatrix[_prevPlayerStep.Value.i, _prevPlayerStep.Value.j].BorderColor = Color.Green;
            _gameMatrix[_prevAiStep.Value.i, _prevAiStep.Value.j].BorderColor = Color.Red;


            YouHaveDrunkLabel.Text = _gameInfo.TotalYouDrunk.ToString();
            YouKnowAILabel.Text = _gameInfo.TotalYourKnowledge.ToString();

            AIHaveDrunkLabel.Text = _gameInfo.TotalAIDrunk.ToString();
            AIKnowsYouLabel.Text = _gameInfo.TotalAIKnowledge.ToString();

            UpdateHints();
        }

        private void ShowHintsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateHints();
        }

        private void UpdateHints()
        {
            ColorPlayerButtons(Enumerable.Range(0, _playersButtons.Length).ToArray(), SystemColors.Control);

            if (ShowHintsCheckBox.Checked)
            {
                var playerBestSteps = _solver.GetOptimalPlayerSteps(_gameInfo);
                ColorPlayerButtons(playerBestSteps, Color.LightGreen);

                //var aiBestSteps = _solver.GetOptimalAISteps(_gameInfo);
                //ColorPlayerButtons(aiBestSteps, Color.IndianRed);
            }
        }

        private void ColorPlayerButtons(int[] indices, Color color)
        {
            foreach (var index in indices)
            {
                _playersButtons[index].BackColor = color;
            }
        }
    }
}
