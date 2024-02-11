namespace Timer
{
    partial class FormTimer
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTimer));
            timer = new System.Windows.Forms.Timer(components);
            contextMenuStrip = new ContextMenuStrip(components);
            pauseToolStripMenuItem = new ToolStripMenuItem();
            resetToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            secondsToolStripMenuItem = new ToolStripMenuItem();
            minutesToolStripMenuItem = new ToolStripMenuItem();
            hoursToolStripMenuItem = new ToolStripMenuItem();
            hHMMToolStripMenuItem = new ToolStripMenuItem();
            hHHHMMSSToolStripMenuItem = new ToolStripMenuItem();
            dateToolStripMenuItem = new ToolStripMenuItem();
            dayOfWeekToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 10;
            timer.Tick += timerTimer_Tick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { pauseToolStripMenuItem, resetToolStripMenuItem, optionsToolStripMenuItem, exitToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new Size(117, 92);
            // 
            // pauseToolStripMenuItem
            // 
            pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            pauseToolStripMenuItem.Size = new Size(116, 22);
            pauseToolStripMenuItem.Text = "Pause";
            pauseToolStripMenuItem.Click += pauseToolStripMenuItem_Click;
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new Size(116, 22);
            resetToolStripMenuItem.Text = "Reset";
            resetToolStripMenuItem.Click += resetToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { secondsToolStripMenuItem, minutesToolStripMenuItem, hoursToolStripMenuItem, hHMMToolStripMenuItem, hHHHMMSSToolStripMenuItem, dateToolStripMenuItem, dayOfWeekToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(116, 22);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // secondsToolStripMenuItem
            // 
            secondsToolStripMenuItem.Name = "secondsToolStripMenuItem";
            secondsToolStripMenuItem.Size = new Size(180, 22);
            secondsToolStripMenuItem.Text = "Seconds";
            secondsToolStripMenuItem.Click += secondsToolStripMenuItem_Click;
            // 
            // minutesToolStripMenuItem
            // 
            minutesToolStripMenuItem.Name = "minutesToolStripMenuItem";
            minutesToolStripMenuItem.Size = new Size(180, 22);
            minutesToolStripMenuItem.Text = "Minutes";
            minutesToolStripMenuItem.Click += minutesToolStripMenuItem_Click;
            // 
            // hoursToolStripMenuItem
            // 
            hoursToolStripMenuItem.Name = "hoursToolStripMenuItem";
            hoursToolStripMenuItem.Size = new Size(180, 22);
            hoursToolStripMenuItem.Text = "Hours";
            hoursToolStripMenuItem.Click += hoursToolStripMenuItem_Click;
            // 
            // hHMMToolStripMenuItem
            // 
            hHMMToolStripMenuItem.Name = "hHMMToolStripMenuItem";
            hHMMToolStripMenuItem.Size = new Size(180, 22);
            hHMMToolStripMenuItem.Text = "HH:MM";
            hHMMToolStripMenuItem.Click += hHMMToolStripMenuItem_Click;
            // 
            // hHHHMMSSToolStripMenuItem
            // 
            hHHHMMSSToolStripMenuItem.Name = "hHHHMMSSToolStripMenuItem";
            hHHHMMSSToolStripMenuItem.Size = new Size(180, 22);
            hHHHMMSSToolStripMenuItem.Text = "HH:MM:SS";
            hHHHMMSSToolStripMenuItem.Click += hHHHMMSSToolStripMenuItem_Click;
            // 
            // dateToolStripMenuItem
            // 
            dateToolStripMenuItem.Name = "dateToolStripMenuItem";
            dateToolStripMenuItem.Size = new Size(180, 22);
            dateToolStripMenuItem.Text = "Date";
            dateToolStripMenuItem.Click += dateToolStripMenuItem_Click;
            // 
            // dayOfWeekToolStripMenuItem
            // 
            dayOfWeekToolStripMenuItem.Name = "dayOfWeekToolStripMenuItem";
            dayOfWeekToolStripMenuItem.Size = new Size(180, 22);
            dayOfWeekToolStripMenuItem.Text = "Day of week";
            dayOfWeekToolStripMenuItem.Click += dayOfWeekToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(116, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // FormTimer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(459, 79);
            ContextMenuStrip = contextMenuStrip;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormTimer";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Timer";
            TopMost = true;
            FormClosed += FormTimer_FormClosed;
            Load += FormTimer_Load;
            Paint += FormTimer_Paint;
            MouseDown += timerTimer_MouseDown;
            Move += FormTimer_Move;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripMenuItem pauseToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem secondsToolStripMenuItem;
        private ToolStripMenuItem minutesToolStripMenuItem;
        private ToolStripMenuItem hoursToolStripMenuItem;
        private ToolStripMenuItem hHHHMMSSToolStripMenuItem;
        private ToolStripMenuItem hHMMToolStripMenuItem;
        private ToolStripMenuItem dateToolStripMenuItem;
        private ToolStripMenuItem dayOfWeekToolStripMenuItem;
    }
}