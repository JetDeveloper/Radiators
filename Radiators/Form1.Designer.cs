namespace Radiators
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ledTempSwitch = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ledTempRestBR = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ledTempRestSB = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ledPower = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numberEdge = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.tempEnv = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radLength = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledTempSwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTempRestBR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTempRestSB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledPower)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberEdge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempEnv)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLength)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ledTempSwitch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ledTempRestBR);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ledTempRestSB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ledPower);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Характеристики диода";
            // 
            // ledTempSwitch
            // 
            this.ledTempSwitch.DecimalPlaces = 2;
            this.ledTempSwitch.Location = new System.Drawing.Point(329, 96);
            this.ledTempSwitch.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ledTempSwitch.Name = "ledTempSwitch";
            this.ledTempSwitch.Size = new System.Drawing.Size(86, 20);
            this.ledTempSwitch.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Температура перехода (°С):";
            // 
            // ledTempRestBR
            // 
            this.ledTempRestBR.DecimalPlaces = 2;
            this.ledTempRestBR.Location = new System.Drawing.Point(329, 70);
            this.ledTempRestBR.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ledTempRestBR.Name = "ledTempRestBR";
            this.ledTempRestBR.Size = new System.Drawing.Size(86, 20);
            this.ledTempRestBR.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Тепловое сопротивление корпус-радиатор (°С/Вт):";
            // 
            // ledTempRestSB
            // 
            this.ledTempRestSB.DecimalPlaces = 2;
            this.ledTempRestSB.Location = new System.Drawing.Point(329, 44);
            this.ledTempRestSB.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ledTempRestSB.Name = "ledTempRestSB";
            this.ledTempRestSB.Size = new System.Drawing.Size(86, 20);
            this.ledTempRestSB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тепловое сопротивление переход-корпус (°С/Вт):";
            // 
            // ledPower
            // 
            this.ledPower.DecimalPlaces = 2;
            this.ledPower.Location = new System.Drawing.Point(329, 18);
            this.ledPower.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ledPower.Name = "ledPower";
            this.ledPower.Size = new System.Drawing.Size(86, 20);
            this.ledPower.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Рассеиваемая мощность (Вт):";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radLength);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.numberEdge);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tempEnv);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 220);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Радиатор";
            // 
            // numberEdge
            // 
            this.numberEdge.Location = new System.Drawing.Point(329, 72);
            this.numberEdge.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numberEdge.Name = "numberEdge";
            this.numberEdge.Size = new System.Drawing.Size(86, 20);
            this.numberEdge.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Количество ребер (шт.):";
            // 
            // tempEnv
            // 
            this.tempEnv.DecimalPlaces = 2;
            this.tempEnv.Location = new System.Drawing.Point(329, 47);
            this.tempEnv.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tempEnv.Name = "tempEnv";
            this.tempEnv.Size = new System.Drawing.Size(86, 20);
            this.tempEnv.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Алюминий",
            "Дюралюминий",
            "Латунь",
            "Серебро",
            "Медь"});
            this.comboBox1.Location = new System.Drawing.Point(329, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Алюминий";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Температура окружающей среды: (°С):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Материал радиатора:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(450, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(291, 356);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Результаты расчета";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(279, 330);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(358, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Рассчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radLength
            // 
            this.radLength.DecimalPlaces = 4;
            this.radLength.Location = new System.Drawing.Point(329, 100);
            this.radLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.radLength.Name = "radLength";
            this.radLength.Size = new System.Drawing.Size(86, 20);
            this.radLength.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Протяженность радиатора (м):";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 419);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Расчет размеров радиатора";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledTempSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTempRestBR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTempRestSB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledPower)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberEdge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempEnv)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ledPower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ledTempSwitch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ledTempRestBR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ledTempRestSB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown tempEnv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numberEdge;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown radLength;
        private System.Windows.Forms.Label label7;
    }
}

