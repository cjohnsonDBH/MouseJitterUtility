namespace MouseJitterUtility
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnStartStop = new System.Windows.Forms.Button();
            this.txtMinDistance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxDistance = new System.Windows.Forms.TextBox();
            this.chkSmoothTransitions = new System.Windows.Forms.CheckBox();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPauseDuration = new System.Windows.Forms.TextBox();
            this.trackIntensity = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackIntensity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStartStop.Location = new System.Drawing.Point(12, 134);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(192, 35);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // txtMinDistance
            // 
            this.txtMinDistance.Location = new System.Drawing.Point(127, 24);
            this.txtMinDistance.Name = "txtMinDistance";
            this.txtMinDistance.Size = new System.Drawing.Size(47, 23);
            this.txtMinDistance.TabIndex = 1;
            this.txtMinDistance.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Min Distance (px):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max Distance (px):";
            // 
            // txtMaxDistance
            // 
            this.txtMaxDistance.Location = new System.Drawing.Point(127, 53);
            this.txtMaxDistance.Name = "txtMaxDistance";
            this.txtMaxDistance.Size = new System.Drawing.Size(47, 23);
            this.txtMaxDistance.TabIndex = 3;
            this.txtMaxDistance.Text = "15";
            // 
            // chkSmoothTransitions
            // 
            this.chkSmoothTransitions.AutoSize = true;
            this.chkSmoothTransitions.Location = new System.Drawing.Point(18, 91);
            this.chkSmoothTransitions.Name = "chkSmoothTransitions";
            this.chkSmoothTransitions.Size = new System.Drawing.Size(129, 19);
            this.chkSmoothTransitions.TabIndex = 5;
            this.chkSmoothTransitions.Text = "Smooth Movement";
            this.chkSmoothTransitions.UseVisualStyleBackColor = true;
            this.chkSmoothTransitions.CheckedChanged += new System.EventHandler(this.chkSmoothTransitions_CheckedChanged);
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(191, 27);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(92, 15);
            this.lblFrequency.TabIndex = 7;
            this.lblFrequency.Text = "Frequency (ms):";
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(314, 24);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(47, 23);
            this.txtFrequency.TabIndex = 6;
            this.txtFrequency.Text = "20";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Pause Duration (ms):";
            // 
            // txtPauseDuration
            // 
            this.txtPauseDuration.Location = new System.Drawing.Point(314, 53);
            this.txtPauseDuration.Name = "txtPauseDuration";
            this.txtPauseDuration.Size = new System.Drawing.Size(47, 23);
            this.txtPauseDuration.TabIndex = 8;
            this.txtPauseDuration.Text = "20";
            // 
            // trackIntensity
            // 
            this.trackIntensity.Location = new System.Drawing.Point(215, 79);
            this.trackIntensity.Margin = new System.Windows.Forms.Padding(0);
            this.trackIntensity.Name = "trackIntensity";
            this.trackIntensity.Size = new System.Drawing.Size(96, 45);
            this.trackIntensity.TabIndex = 10;
            this.trackIntensity.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackIntensity.ValueChanged += new System.EventHandler(this.trackIntensity_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Speed:";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(314, 87);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(47, 23);
            this.txtSpeed.TabIndex = 12;
            this.txtSpeed.Text = "1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 181);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackIntensity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPauseDuration);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.txtFrequency);
            this.Controls.Add(this.chkSmoothTransitions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaxDistance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMinDistance);
            this.Controls.Add(this.btnStartStop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "AutoMouse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackIntensity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStartStop;
        private TextBox txtMinDistance;
        private Label label1;
        private Label label2;
        private TextBox txtMaxDistance;
        private CheckBox chkSmoothTransitions;
        private Label lblFrequency;
        private TextBox txtFrequency;
        private Label label3;
        private TextBox txtPauseDuration;
        private TrackBar trackIntensity;
        private Label label4;
        private TextBox txtSpeed;
    }
}