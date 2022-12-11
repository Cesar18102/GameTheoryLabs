using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace GameTheoryLab3
{
    public partial class GameMatrixTile : UserControl
    {
        private static readonly Bitmap NORMAL_CELL;
        private static readonly Bitmap EMPTY_CELL;

        public event EventHandler<EventArgs> ValueChanged;

        private Color? _borderColor;

        public int AIDrunk
        {
            get => Convert.ToInt32(AIDrunkInput.Value);
            set => AIDrunkInput.Value = value;
        }
        public int AIKnowledge
        {
            get => Convert.ToInt32(AIKnowledgeInput.Value);
            set => AIKnowledgeInput.Value = value;
        }
        public int YouDrunk
        {
            get => Convert.ToInt32(YouDrunkInput.Value);
            set => YouDrunkInput.Value = value;
        }
        public int YourKnowledge
        {
            get => Convert.ToInt32(YourKnowledgeInput.Value);
            set => YourKnowledgeInput.Value = value;
        }
        public bool IsEmpty { get; private set; }

        public Color? BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                 Invalidate();
            }
        }

        static GameMatrixTile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            NORMAL_CELL = new Bitmap(assembly.GetManifestResourceStream("GameTheoryLab3.resources.GameMatrixTileBackground.png"));
            EMPTY_CELL = new Bitmap(assembly.GetManifestResourceStream("GameTheoryLab3.resources.GameMatrixEmptyTileBackground.png"));
        }

        public GameMatrixTile()
        {
            InitializeComponent();

            BackgroundImage = NORMAL_CELL;

            AIDrunkInput.ValueChanged += OnValuesChanged;
            AIKnowledgeInput.ValueChanged += OnValuesChanged;
            YouDrunkInput.ValueChanged += OnValuesChanged;
            YourKnowledgeInput.ValueChanged += OnValuesChanged;
        }

        private void OnValuesChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(sender, e);
        }

        public void MakeEmpty()
        {
            BackgroundImage = EMPTY_CELL;
            IsEmpty = true;

            AIDrunkInput.Visible = false;
            AIKnowledgeInput.Visible = false;

            YouDrunkInput.Visible = false;
            YourKnowledgeInput.Visible = false;
        }

        public void SetValues(int aiDrunk, int aiKnowledge, int youDrunk, int yourKnowledge)
        {
            AIDrunk = aiDrunk;
            AIKnowledge = aiKnowledge;
            YouDrunk = youDrunk;
            YourKnowledge = yourKnowledge;
        }

        public void PutValues(TileInfo tileInfo)
        {
            tileInfo.AIDrunk = AIDrunk;
            tileInfo.AIKnowledge = AIKnowledge;
            tileInfo.YouDrunk = YouDrunk;
            tileInfo.YourKnowledge = YourKnowledge;
            tileInfo.IsEmpty = IsEmpty;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if(!_borderColor.HasValue)
            {
                return;
            }

            using (var pen = new Pen(_borderColor.Value, 3))
            {
                var rect = new Rectangle(3 + Location.X, 3 + Location.Y, Width - 7, Height - 7);  
                e.Graphics.DrawRectangle(pen, ClientRectangle);
            }
        }
    }
}
