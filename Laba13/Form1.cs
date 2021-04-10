using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Laba13{
	public class Form1 : Form{
        IContainer components = null;
        Button[] buttons = new Button[16];
		Random random = new Random();
		List<int> numbers = new List<int>();
		TabControl tabControl;
		TabPage tabTask1;
        TabPage tabTask2;
        ComboBox comboBox1;
        Button buttonRemove;
		Button buttonAdd;
        Button button;
		TextBox textBox;
		TextBox textBoxResult;

        private int i = 1;
        private int rand;


        public Form1(){
			this.InitializeComponent();
			int n = 1;
			Button[] array = this.buttons;
			for (int i = 0; i < array.Length; i++){
				Button button = array[i];
				this.numbers.Add(n++);
			}
			int num2 = 0;
			for (int j = 1; j < this.buttons.Length + 1; j++){
				this.button = new Button();
				this.button.Location = new Point(num2 * this.button.Size.Width + 60, (j - 1) % 4 * this.button.Size.Height + 30);
				n = this.random.Next(this.numbers.Count - 1);
				this.button.Name = this.numbers[n].ToString();
				this.button.Size = new Size(new Point(40, 20));
				this.button.Text = this.numbers[n].ToString();
				this.button.Click += new EventHandler(this.btnArray_Click);
				this.numbers.RemoveAt(n);
				n++;
				this.buttons[j - 1] = this.button;
				this.tabTask2.Controls.Add(this.buttons[j - 1]);
				bool flag = j % 4 == 0;
				if (flag){
					num2++;
				}
			}
			n = 1;
			Button[] array2 = this.buttons;
			for (int k = 0; k < array2.Length; k++){
				Button button2 = array2[k];
				this.numbers.Add(n++);
			}
		}

		private void Form1_Load(object sender, EventArgs e){
		}

		private void btn_Click(object sender, EventArgs e){
			bool flag = (sender as Button).Name == this.buttonAdd.Name;
			if (flag){
				bool flag2 = this.textBox.Text != "";
				if (flag2){
					this.comboBox1.Items.Add(this.textBox.Text);
					this.textBox.Text = "";
				}
			}
			else{
				bool flag3 = this.comboBox1.Items.Count != 0;
				if (flag3){
					this.comboBox1.Items.RemoveAt(this.comboBox1.Items.Count - 1);
				}
			}
		}

		private void btnArray_Click(object sender, EventArgs e){
			bool flag = (sender as Button).Name == this.i.ToString();
			if (flag){
				this.textBoxResult.Text = "";
				(sender as Button).Visible = false;
				this.numbers.RemoveAt(this.numbers.IndexOf(this.i));
				Button[] array = this.buttons;
				for (int i = 0; i < array.Length; i++){
					Button button = array[i];
					bool visible = button.Visible;
					if (visible){
						this.rand = this.random.Next(this.numbers.Count);
						button.Name = this.numbers[this.rand].ToString();
						button.Text = this.numbers[this.rand].ToString();
						this.numbers.RemoveAt(this.rand);
					}
				}
				for (int j = this.i + 1; j < this.buttons.Length + 1; j++){
					this.numbers.Add(j);
				}
				this.i++;
			}
			else{
				bool flag2 = this.i != 1;
				if (flag2){
					this.ClearNumbers();
				}
			}
			bool flag3 = this.i == 17;
			if (flag3){
				this.textBoxResult.TextAlign = HorizontalAlignment.Center;
				this.textBoxResult.Text = "Молодець!!!";
				this.ClearNumbers();
			}
		}

		private void ClearNumbers(){
			this.numbers.Clear();
			this.i = 1;
			for (int i = this.i; i < this.buttons.Length + 1; i++){
				this.numbers.Add(i);
			}
			Button[] array = this.buttons;
			for (int j = 0; j < array.Length; j++){
				Button button = array[j];
				bool flag = !button.Visible;
				if (flag){
					button.Visible = true;
				}
				this.rand = this.random.Next(this.numbers.Count - 1);
				button.Name = this.numbers[this.rand].ToString();
				button.Text = this.numbers[this.rand].ToString();
				this.numbers.RemoveAt(this.rand);
			}
			for (int k = this.i; k < this.buttons.Length + 1; k++){
				this.numbers.Add(k);
			}
		}

		protected override void Dispose(bool disposing){
			bool flag = disposing && this.components != null;
			if (flag){
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent(){
			this.tabControl = new TabControl();
			this.tabTask1 = new TabPage();
			this.textBox = new TextBox();
			this.buttonRemove = new Button();
			this.buttonAdd = new Button();
			this.comboBox1 = new ComboBox();
			this.tabTask2 = new TabPage();
			this.textBoxResult = new TextBox();
			this.button = new Button();
			this.tabControl.SuspendLayout();
			this.tabTask1.SuspendLayout();
			this.tabTask2.SuspendLayout();
			base.SuspendLayout();
			this.tabControl.Controls.Add(this.tabTask1);
			this.tabControl.Controls.Add(this.tabTask2);
			this.tabControl.Location = new Point(12, 12);
			this.tabControl.Name = "tbControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new Size(400, 250);
			this.tabControl.TabIndex = 0;
			this.tabTask1.Controls.Add(this.textBox);
			this.tabTask1.Controls.Add(this.buttonRemove);
			this.tabTask1.Controls.Add(this.buttonAdd);
			this.tabTask1.Controls.Add(this.comboBox1);
			this.tabTask1.Location = new Point(4, 22);
			this.tabTask1.Name = "tbTask1";
			this.tabTask1.Padding = new Padding(3);
			this.tabTask1.Size = new Size(372, 213);
			this.tabTask1.TabIndex = 0;
			this.tabTask1.Text = "Завдання 1";
			this.tabTask1.UseVisualStyleBackColor = true;
			this.textBox.BackColor = Color.White;
			this.textBox.Location = new Point(6, 9);
			this.textBox.Name = "txtBox";
			this.textBox.Size = new Size(121, 20);
			this.textBox.TabIndex = 3;
			this.buttonRemove.ForeColor = Color.Blue;
			this.buttonRemove.Location = new Point(247, 6);
			this.buttonRemove.Name = "btnRemove";
			this.buttonRemove.Size = new Size(75, 23);
			this.buttonRemove.TabIndex = 2;
			this.buttonRemove.Text = "Видалити";
			this.buttonRemove.UseVisualStyleBackColor = true;
			this.buttonRemove.Click += new EventHandler(this.btn_Click);
			this.buttonAdd.ForeColor = Color.Blue;
			this.buttonAdd.Location = new Point(152, 6);
			this.buttonAdd.Name = "btnAdd";
			this.buttonAdd.Size = new Size(75, 23);
			this.buttonAdd.TabIndex = 1;
			this.buttonAdd.Text = "Додати";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new EventHandler(this.btn_Click);
			this.comboBox1.BackColor = Color.Brown;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new Point(6, 43);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new Size(121, 21);
			this.comboBox1.TabIndex = 0;
			this.tabTask2.Controls.Add(this.textBoxResult);
			this.tabTask2.Location = new Point(4, 22);
			this.tabTask2.Name = "tbTask2";
			this.tabTask2.Padding = new Padding(3);
			this.tabTask2.Size = new Size(372, 213);
			this.tabTask2.TabIndex = 1;
			this.tabTask2.Text = "Завдання 2";
			this.tabTask2.UseVisualStyleBackColor = true;
			this.textBoxResult.BackColor = Color.Green;
			this.textBoxResult.Location = new Point(119, 174);
			this.textBoxResult.Name = "txtBoxResult";
			this.textBoxResult.Size = new Size(147, 20);
			this.textBoxResult.TabIndex = 0;
			this.button.Location = new Point(30, 23);
			this.button.Name = "button1";
			this.button.Size = new Size(40, 20);
			this.button.TabIndex = 1;
			this.button.Text = "button1";
			this.button.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(636, 399);
			base.Controls.Add(this.tabControl);
			base.Name = "Form1";
			this.Text = "Form1";
			base.Load += new EventHandler(this.Form1_Load);
			this.tabControl.ResumeLayout(false);
			this.tabTask1.ResumeLayout(false);
			this.tabTask1.PerformLayout();
			this.tabTask2.ResumeLayout(false);
			this.tabTask2.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}