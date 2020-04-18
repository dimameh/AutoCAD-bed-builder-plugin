namespace UI
{
    partial class ModelParametersForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._mainPartHeightTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._mainPartWidthTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._mainPartLengthTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._legsHeightTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._legsDiameterTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._headboardThicknessTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._headboardHeightTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._berthCountTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._personsHeightTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._mainPartHeightTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._mainPartWidthTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._mainPartLengthTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(134, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Основная часть";
            // 
            // _mainPartHeightTextBox
            // 
            this._mainPartHeightTextBox.AccessibleDescription = "Высота основной части";
            this._mainPartHeightTextBox.Location = new System.Drawing.Point(6, 128);
            this._mainPartHeightTextBox.Name = "_mainPartHeightTextBox";
            this._mainPartHeightTextBox.Size = new System.Drawing.Size(100, 22);
            this._mainPartHeightTextBox.TabIndex = 4;
            this._mainPartHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDouble_KeyPress);
            this._mainPartHeightTextBox.Leave += new System.EventHandler(this.DoubleTextBox_Leave);
            this._mainPartHeightTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBox_PreviewKeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Высота, см";
            // 
            // _mainPartWidthTextBox
            // 
            this._mainPartWidthTextBox.AccessibleDescription = "Ширина основной части";
            this._mainPartWidthTextBox.Location = new System.Drawing.Point(6, 83);
            this._mainPartWidthTextBox.Name = "_mainPartWidthTextBox";
            this._mainPartWidthTextBox.Size = new System.Drawing.Size(100, 22);
            this._mainPartWidthTextBox.TabIndex = 2;
            this._mainPartWidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDouble_KeyPress);
            this._mainPartWidthTextBox.Leave += new System.EventHandler(this.DoubleTextBox_Leave);
            this._mainPartWidthTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBox_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ширина, см";
            // 
            // _mainPartLengthTextBox
            // 
            this._mainPartLengthTextBox.AccessibleDescription = "Длина основной части";
            this._mainPartLengthTextBox.Location = new System.Drawing.Point(6, 38);
            this._mainPartLengthTextBox.Name = "_mainPartLengthTextBox";
            this._mainPartLengthTextBox.Size = new System.Drawing.Size(100, 22);
            this._mainPartLengthTextBox.TabIndex = 0;
            this._mainPartLengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDouble_KeyPress);
            this._mainPartLengthTextBox.Leave += new System.EventHandler(this.DoubleTextBox_Leave);
            this._mainPartLengthTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBox_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Длина, см";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._legsHeightTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this._legsDiameterTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 110);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ножки";
            // 
            // _legsHeightTextBox
            // 
            this._legsHeightTextBox.AccessibleDescription = "Высота ножки";
            this._legsHeightTextBox.Location = new System.Drawing.Point(6, 83);
            this._legsHeightTextBox.Name = "_legsHeightTextBox";
            this._legsHeightTextBox.Size = new System.Drawing.Size(100, 22);
            this._legsHeightTextBox.TabIndex = 8;
            this._legsHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDouble_KeyPress);
            this._legsHeightTextBox.Leave += new System.EventHandler(this.DoubleTextBox_Leave);
            this._legsHeightTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBox_PreviewKeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Высота, см";
            // 
            // _legsDiameterTextBox
            // 
            this._legsDiameterTextBox.AccessibleDescription = "Диаметр ножки";
            this._legsDiameterTextBox.Location = new System.Drawing.Point(6, 38);
            this._legsDiameterTextBox.Name = "_legsDiameterTextBox";
            this._legsDiameterTextBox.Size = new System.Drawing.Size(100, 22);
            this._legsDiameterTextBox.TabIndex = 6;
            this._legsDiameterTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDouble_KeyPress);
            this._legsDiameterTextBox.Leave += new System.EventHandler(this.DoubleTextBox_Leave);
            this._legsDiameterTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBox_PreviewKeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Диаметр, см";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._headboardThicknessTextBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this._headboardHeightTextBox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(152, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 161);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Спинка";
            // 
            // _headboardThicknessTextBox
            // 
            this._headboardThicknessTextBox.AccessibleDescription = "Толщина спинки";
            this._headboardThicknessTextBox.Location = new System.Drawing.Point(6, 83);
            this._headboardThicknessTextBox.Name = "_headboardThicknessTextBox";
            this._headboardThicknessTextBox.Size = new System.Drawing.Size(100, 22);
            this._headboardThicknessTextBox.TabIndex = 12;
            this._headboardThicknessTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDouble_KeyPress);
            this._headboardThicknessTextBox.Leave += new System.EventHandler(this.DoubleTextBox_Leave);
            this._headboardThicknessTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBox_PreviewKeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Толщина, см";
            // 
            // _headboardHeightTextBox
            // 
            this._headboardHeightTextBox.AccessibleDescription = "Высота спинки";
            this._headboardHeightTextBox.Location = new System.Drawing.Point(6, 38);
            this._headboardHeightTextBox.Name = "_headboardHeightTextBox";
            this._headboardHeightTextBox.Size = new System.Drawing.Size(100, 22);
            this._headboardHeightTextBox.TabIndex = 10;
            this._headboardHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDouble_KeyPress);
            this._headboardHeightTextBox.Leave += new System.EventHandler(this.DoubleTextBox_Leave);
            this._headboardHeightTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBox_PreviewKeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Высота, см";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._berthCountTextBox);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this._personsHeightTextBox);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(152, 179);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(222, 110);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Параметры пользователя";
            // 
            // _berthCountTextBox
            // 
            this._berthCountTextBox.Location = new System.Drawing.Point(6, 83);
            this._berthCountTextBox.Name = "_berthCountTextBox";
            this._berthCountTextBox.Size = new System.Drawing.Size(100, 22);
            this._berthCountTextBox.TabIndex = 16;
            this._berthCountTextBox.TextChanged += new System.EventHandler(this.BerthCountTextBox_TextChanged);
            this._berthCountTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBox_PreviewKeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(213, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Количество спальных мест, шт";
            // 
            // _personsHeightTextBox
            // 
            this._personsHeightTextBox.Location = new System.Drawing.Point(6, 38);
            this._personsHeightTextBox.Name = "_personsHeightTextBox";
            this._personsHeightTextBox.Size = new System.Drawing.Size(100, 22);
            this._personsHeightTextBox.TabIndex = 14;
            this._personsHeightTextBox.TextChanged += new System.EventHandler(this.PersonsHeightTextBox_TextChanged);
            this._personsHeightTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBox_PreviewKeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Рост человека, см";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(276, 295);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(98, 29);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "Ок";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(172, 295);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(98, 29);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ModelParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 330);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModelParametersForm";
            this.Text = "Bed Builder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.TextBox _mainPartHeightTextBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox _mainPartWidthTextBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox _mainPartLengthTextBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox _legsHeightTextBox;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox _legsDiameterTextBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox _headboardThicknessTextBox;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox _headboardHeightTextBox;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox _berthCountTextBox;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox _personsHeightTextBox;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    }
}