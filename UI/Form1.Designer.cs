namespace UI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caloriesProductTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.calculateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radioButtonADO = new System.Windows.Forms.RadioButton();
            this.radioButtonDapper = new System.Windows.Forms.RadioButton();
            this.radioButtonEntity = new System.Windows.Forms.RadioButton();
            this.labelTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Your daily calories =";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 102);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(589, 250);
            this.dataGridView1.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.caloriesProductTableToolStripMenuItem,
            this.calculateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(615, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // caloriesProductTableToolStripMenuItem
            // 
            this.caloriesProductTableToolStripMenuItem.Name = "caloriesProductTableToolStripMenuItem";
            this.caloriesProductTableToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.caloriesProductTableToolStripMenuItem.Text = "Calories product table";
            this.caloriesProductTableToolStripMenuItem.Click += new System.EventHandler(this.caloriesProductTableToolStripMenuItem_Click);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(13, 72);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(157, 23);
            this.buttonCalculate.TabIndex = 13;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(178, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(2, 19);
            this.label4.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(178, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(2, 19);
            this.label5.TabIndex = 17;
            // 
            // calculateToolStripMenuItem
            // 
            this.calculateToolStripMenuItem.Name = "calculateToolStripMenuItem";
            this.calculateToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.calculateToolStripMenuItem.Text = "Calculate";
            this.calculateToolStripMenuItem.Click += new System.EventHandler(this.calculateToolStripMenuItem_Click);
            // 
            // radioButtonADO
            // 
            this.radioButtonADO.AutoSize = true;
            this.radioButtonADO.Checked = true;
            this.radioButtonADO.Location = new System.Drawing.Point(326, 45);
            this.radioButtonADO.Name = "radioButtonADO";
            this.radioButtonADO.Size = new System.Drawing.Size(131, 21);
            this.radioButtonADO.TabIndex = 18;
            this.radioButtonADO.TabStop = true;
            this.radioButtonADO.Text = "ADO Repository";
            this.radioButtonADO.UseVisualStyleBackColor = true;
            this.radioButtonADO.CheckedChanged += new System.EventHandler(this.radioButtonADO_CheckedChanged);
            // 
            // radioButtonDapper
            // 
            this.radioButtonDapper.AutoSize = true;
            this.radioButtonDapper.Enabled = false;
            this.radioButtonDapper.Location = new System.Drawing.Point(326, 75);
            this.radioButtonDapper.Name = "radioButtonDapper";
            this.radioButtonDapper.Size = new System.Drawing.Size(148, 21);
            this.radioButtonDapper.TabIndex = 19;
            this.radioButtonDapper.Text = "Dapper Repository";
            this.radioButtonDapper.UseVisualStyleBackColor = true;
            this.radioButtonDapper.CheckedChanged += new System.EventHandler(this.radioButtonDapper_CheckedChanged);
            // 
            // radioButtonEntity
            // 
            this.radioButtonEntity.AutoSize = true;
            this.radioButtonEntity.Location = new System.Drawing.Point(466, 45);
            this.radioButtonEntity.Name = "radioButtonEntity";
            this.radioButtonEntity.Size = new System.Drawing.Size(136, 21);
            this.radioButtonEntity.TabIndex = 20;
            this.radioButtonEntity.Text = "Entity Repository";
            this.radioButtonEntity.UseVisualStyleBackColor = true;
            this.radioButtonEntity.CheckedChanged += new System.EventHandler(this.radioButtonEntity_CheckedChanged);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(480, 77);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(51, 17);
            this.labelTime.TabIndex = 21;
            this.labelTime.Text = "Time =";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 365);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.radioButtonEntity);
            this.Controls.Add(this.radioButtonDapper);
            this.Controls.Add(this.radioButtonADO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Easy weight loss";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caloriesProductTableToolStripMenuItem;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem calculateToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButtonADO;
        private System.Windows.Forms.RadioButton radioButtonDapper;
        private System.Windows.Forms.RadioButton radioButtonEntity;
        private System.Windows.Forms.Label labelTime;
    }
}

