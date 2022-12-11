
namespace GameTheoryLab3
{
    partial class GameMatrixTile
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AIDrunkInput = new System.Windows.Forms.NumericUpDown();
            this.AIKnowledgeInput = new System.Windows.Forms.NumericUpDown();
            this.YouDrunkInput = new System.Windows.Forms.NumericUpDown();
            this.YourKnowledgeInput = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.AIDrunkInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AIKnowledgeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YouDrunkInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YourKnowledgeInput)).BeginInit();
            this.SuspendLayout();
            // 
            // AIDrunkInput
            // 
            this.AIDrunkInput.Location = new System.Drawing.Point(23, 1);
            this.AIDrunkInput.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.AIDrunkInput.Name = "AIDrunkInput";
            this.AIDrunkInput.Size = new System.Drawing.Size(30, 20);
            this.AIDrunkInput.TabIndex = 1;
            this.toolTip1.SetToolTip(this.AIDrunkInput, "AI drunk");
            // 
            // AIKnowledgeInput
            // 
            this.AIKnowledgeInput.Location = new System.Drawing.Point(45, 23);
            this.AIKnowledgeInput.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.AIKnowledgeInput.Name = "AIKnowledgeInput";
            this.AIKnowledgeInput.Size = new System.Drawing.Size(30, 20);
            this.AIKnowledgeInput.TabIndex = 2;
            this.toolTip1.SetToolTip(this.AIKnowledgeInput, "AI knowledge");
            // 
            // YouDrunkInput
            // 
            this.YouDrunkInput.Location = new System.Drawing.Point(0, 32);
            this.YouDrunkInput.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.YouDrunkInput.Name = "YouDrunkInput";
            this.YouDrunkInput.Size = new System.Drawing.Size(30, 20);
            this.YouDrunkInput.TabIndex = 3;
            this.toolTip1.SetToolTip(this.YouDrunkInput, "You drunk");
            // 
            // YourKnowledgeInput
            // 
            this.YourKnowledgeInput.Location = new System.Drawing.Point(20, 54);
            this.YourKnowledgeInput.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.YourKnowledgeInput.Name = "YourKnowledgeInput";
            this.YourKnowledgeInput.Size = new System.Drawing.Size(30, 20);
            this.YourKnowledgeInput.TabIndex = 4;
            this.toolTip1.SetToolTip(this.YourKnowledgeInput, "Your knowledge");
            // 
            // GameMatrixTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.YourKnowledgeInput);
            this.Controls.Add(this.YouDrunkInput);
            this.Controls.Add(this.AIKnowledgeInput);
            this.Controls.Add(this.AIDrunkInput);
            this.Name = "GameMatrixTile";
            this.Size = new System.Drawing.Size(75, 75);
            ((System.ComponentModel.ISupportInitialize)(this.AIDrunkInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AIKnowledgeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YouDrunkInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YourKnowledgeInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown AIDrunkInput;
        private System.Windows.Forms.NumericUpDown AIKnowledgeInput;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown YouDrunkInput;
        private System.Windows.Forms.NumericUpDown YourKnowledgeInput;
    }
}
