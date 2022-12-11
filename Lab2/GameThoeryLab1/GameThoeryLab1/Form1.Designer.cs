
namespace GameThoeryLab1
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.GoodsCounter = new System.Windows.Forms.NumericUpDown();
            this.IngredientsCounter = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ProblemPanel = new System.Windows.Forms.Panel();
            this.RestrictionsPanel = new System.Windows.Forms.Panel();
            this.BenefitPanel = new System.Windows.Forms.Panel();
            this.ResultsPanel = new System.Windows.Forms.Panel();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalBenefitLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientsCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Goods count:";
            // 
            // GoodsCounter
            // 
            this.GoodsCounter.Location = new System.Drawing.Point(110, 12);
            this.GoodsCounter.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.GoodsCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GoodsCounter.Name = "GoodsCounter";
            this.GoodsCounter.Size = new System.Drawing.Size(120, 20);
            this.GoodsCounter.TabIndex = 1;
            this.GoodsCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GoodsCounter.ValueChanged += new System.EventHandler(this.GoodsCounter_ValueChanged);
            // 
            // IngredientsCounter
            // 
            this.IngredientsCounter.Location = new System.Drawing.Point(110, 38);
            this.IngredientsCounter.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.IngredientsCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IngredientsCounter.Name = "IngredientsCounter";
            this.IngredientsCounter.Size = new System.Drawing.Size(120, 20);
            this.IngredientsCounter.TabIndex = 3;
            this.IngredientsCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IngredientsCounter.ValueChanged += new System.EventHandler(this.IngredientsCounter_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingredients count:";
            // 
            // ProblemPanel
            // 
            this.ProblemPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ProblemPanel.Location = new System.Drawing.Point(236, 12);
            this.ProblemPanel.Name = "ProblemPanel";
            this.ProblemPanel.Size = new System.Drawing.Size(423, 355);
            this.ProblemPanel.TabIndex = 4;
            // 
            // RestrictionsPanel
            // 
            this.RestrictionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RestrictionsPanel.Location = new System.Drawing.Point(665, 12);
            this.RestrictionsPanel.Name = "RestrictionsPanel";
            this.RestrictionsPanel.Size = new System.Drawing.Size(78, 355);
            this.RestrictionsPanel.TabIndex = 5;
            // 
            // BenefitPanel
            // 
            this.BenefitPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BenefitPanel.Location = new System.Drawing.Point(236, 373);
            this.BenefitPanel.Name = "BenefitPanel";
            this.BenefitPanel.Size = new System.Drawing.Size(507, 52);
            this.BenefitPanel.TabIndex = 5;
            // 
            // ResultsPanel
            // 
            this.ResultsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ResultsPanel.Location = new System.Drawing.Point(236, 431);
            this.ResultsPanel.Name = "ResultsPanel";
            this.ResultsPanel.Size = new System.Drawing.Size(507, 102);
            this.ResultsPanel.TabIndex = 6;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(15, 67);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(215, 23);
            this.CalculateButton.TabIndex = 7;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total Benefit:";
            // 
            // TotalBenefitLabel
            // 
            this.TotalBenefitLabel.AutoSize = true;
            this.TotalBenefitLabel.Location = new System.Drawing.Point(88, 110);
            this.TotalBenefitLabel.Name = "TotalBenefitLabel";
            this.TotalBenefitLabel.Size = new System.Drawing.Size(13, 13);
            this.TotalBenefitLabel.TabIndex = 9;
            this.TotalBenefitLabel.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 538);
            this.Controls.Add(this.TotalBenefitLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.ResultsPanel);
            this.Controls.Add(this.BenefitPanel);
            this.Controls.Add(this.RestrictionsPanel);
            this.Controls.Add(this.ProblemPanel);
            this.Controls.Add(this.IngredientsCounter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GoodsCounter);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GoodsCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientsCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown GoodsCounter;
        private System.Windows.Forms.NumericUpDown IngredientsCounter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel ProblemPanel;
        private System.Windows.Forms.Panel RestrictionsPanel;
        private System.Windows.Forms.Panel BenefitPanel;
        private System.Windows.Forms.Panel ResultsPanel;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TotalBenefitLabel;
    }
}

