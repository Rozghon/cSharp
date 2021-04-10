using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Laba14
{
	public class Form1 : Form{
        private IContainer components = null;

        private byte numberOfBlinks = 1;
		private bool isCanShow = false;
        private bool isClickable = false;
        private double startWidth;
		private double startHeight;
		private char ch = 'q';
		private Timer timer;
        private Timer timer2;
        private Button buttonOk;
		private Button buttonCancel;

		public Form1(){
			this.InitializeComponent();
			this.startHeight = (double)this.buttonOk.Size.Height;
			this.startWidth = (double)this.buttonOk.Size.Width;
		}

		private void timer_Tick(object sender, EventArgs e){
			this.timer.Interval = 1000;
			bool flag = this.isCanShow;
			if (flag){
				this.Text = "Press 'OK' button";
				this.isCanShow = false;
			}
			else{
				this.Text = "";
				this.isCanShow = true;
			}
			this.numberOfBlinks += 1;
			bool flag2 = this.numberOfBlinks > 8;
			if (flag2){
				this.timer.Enabled = false;
				this.isCanShow = false;
			}
		}

		private void timer2_Tick(object sender, EventArgs e){
			bool flag = this.isCanShow;
			if (flag){
				this.Text = "'OK' will never been pressed!!!";
				this.isCanShow = false;
			}
			else{
				this.Text = "";
				this.isCanShow = true;
			}
			this.numberOfBlinks += 1;
		}

		private void buttonCancel_Click(object sender, EventArgs e){
			base.Close();
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e){
			bool flag = !this.isClickable;
			if (flag){
				bool flag2 = e.X > this.buttonOk.Location.X - 20 && e.Y > this.buttonOk.Location.Y - 20 && e.X < this.buttonOk.Location.X + this.buttonOk.Size.Width / 2 && e.Y < this.buttonOk.Location.Y + this.buttonOk.Size.Height / 2;
				if (flag2){
					this.buttonOk.Location = new Point(this.buttonOk.Location.X + 5, this.buttonOk.Location.Y + 5);
					this.ChangeSizeButton(this.buttonOk);
				}
				bool flag3 = e.X > this.buttonOk.Location.X - 15 && e.X < this.buttonOk.Location.X + this.buttonOk.Size.Width / 2 && e.Y > this.buttonOk.Location.Y + this.buttonOk.Size.Height / 2 && e.Y < this.buttonOk.Location.Y + this.buttonOk.Size.Height + 20;
				if (flag3){
					this.buttonOk.Location = new Point(this.buttonOk.Location.X + 5, this.buttonOk.Location.Y - 5);
					this.ChangeSizeButton(this.buttonOk);
				}
				bool flag4 = e.X > this.buttonOk.Location.X + this.buttonOk.Size.Width / 2 && e.X < this.buttonOk.Location.X + this.buttonOk.Size.Width + 20 && e.Y > this.buttonOk.Location.Y + this.buttonOk.Size.Height / 2 && e.Y < this.buttonOk.Location.Y + this.buttonOk.Size.Height + 20;
				if (flag4){
					this.buttonOk.Location = new Point(this.buttonOk.Location.X - 5, this.buttonOk.Location.Y - 5);
					this.ChangeSizeButton(this.buttonOk);
				}
				bool flag5 = e.X > this.buttonOk.Location.X + this.buttonOk.Size.Width / 2 && e.X < this.buttonOk.Location.X + this.buttonOk.Size.Width + 20 && e.Y < this.buttonOk.Location.Y + this.buttonOk.Size.Height / 2 && e.Y > this.buttonOk.Location.Y - 20;
				if (flag5){
					this.buttonOk.Location = new Point(this.buttonOk.Location.X - 5, this.buttonOk.Location.Y + 5);
					this.ChangeSizeButton(this.buttonOk);
				}
			}
		}

		private void buttonOk_MouseEnter(object sender, EventArgs e){
			bool flag = !this.isClickable;
			if (flag){
				this.buttonOk.Location = new Point(this.buttonCancel.Location.X + 150, this.buttonCancel.Location.Y + 150);
			}
		}

		private void btnOk_LocationChanged(object sender, EventArgs e){
			bool flag = this.buttonOk.Location.X < 5;
			if (flag){
				this.buttonOk.Location = new Point(this.buttonOk.Location.X + 175, this.buttonOk.Location.Y);
			}
			bool flag2 = this.buttonOk.Location.X + this.buttonOk.Size.Width + 5 > base.Size.Width;
			if (flag2){
				this.buttonOk.Location = new Point(base.Size.Width - 100 - this.buttonOk.Size.Width * 2, this.buttonOk.Location.Y);
			}
			bool flag3 = this.buttonOk.Location.Y < 5;
			if (flag3){
				this.buttonOk.Location = new Point(this.buttonOk.Location.X, this.buttonOk.Location.Y + 100);
			}
			bool flag4 = this.buttonOk.Location.Y + this.buttonOk.Size.Height + 25 > base.Size.Height;
			if (flag4){
				this.buttonOk.Location = new Point(this.buttonOk.Location.X, base.Size.Height - 100 - this.buttonOk.Size.Height * 2);
			}
		}

		private void ChangeSizeButton(Button b){
			this.startWidth -= 0.2;
			this.startHeight -= 0.2;
			b.Size = new Size((int)(this.startWidth - 0.1), (int)(this.startHeight - 0.1));
			bool flag = b.Size.Width <= 0 || b.Size.Height <= 0;
			if (flag){
				base.MouseMove -= new MouseEventHandler(this.Form1_MouseMove);
				this.timer2.Enabled = true;
				this.timer2_Tick(null, null);
			}
		}

		private void buttonOk_Click(object sender, EventArgs e){
			MessageBox.Show("Button 'OK' has been clicked");
		}

		private void buttonCancel_KeyDown(object sender, KeyEventArgs e){
			bool flag = this.ch == ' ' && (ushort)e.KeyData == 65;
			if (flag){
				this.ch = 'A';
			}
			bool flag2 = this.ch == 'A' && (ushort)e.KeyData == 68;
			if (flag2){
				this.ch = 'D';
			}
			bool flag3 = this.ch != 'D' || (ushort)e.KeyData != 88;
			if (!flag3){
				this.isClickable = true;
			}
		}

		private void buttonCancel_KeyUp(object sender, KeyEventArgs e){
			this.ch = ' ';
		}

		protected override void Dispose(bool disposing){
			bool flag = disposing && this.components != null;
			if (flag){
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent(){
			this.components = new Container();
			this.timer = new Timer(this.components);
			this.buttonOk = new Button();
			this.buttonCancel = new Button();
			this.timer2 = new Timer(this.components);
			base.SuspendLayout();
			this.timer.Enabled = true;
			this.timer.Interval = 3000;
			this.timer.Tick += new EventHandler(this.timer_Tick);
			this.buttonOk.ForeColor = Color.Red;
			this.buttonOk.Location = new Point(313, 215);
			this.buttonOk.Name = "btnOk";
			this.buttonOk.Size = new Size(90, 36);
			this.buttonOk.TabIndex = 1;
			this.buttonOk.TabStop = false;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.LocationChanged += new EventHandler(this.btnOk_LocationChanged);
			this.buttonOk.Click += new EventHandler(this.buttonOk_Click);
			this.buttonOk.MouseEnter += new EventHandler(this.buttonOk_MouseEnter);
			this.buttonCancel.Location = new Point(313, 257);
			this.buttonCancel.Name = "btnCancel";
			this.buttonCancel.Size = new Size(90, 36);
			this.buttonCancel.TabIndex = 0;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
			this.buttonCancel.KeyDown += new KeyEventHandler(this.buttonCancel_KeyDown);
			this.buttonCancel.KeyUp += new KeyEventHandler(this.buttonCancel_KeyUp);
			this.timer2.Interval = 1000;
			this.timer2.Tick += new EventHandler(this.timer2_Tick);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(720, 518);
			base.Controls.Add(this.buttonOk);
			base.Controls.Add(this.buttonCancel);
			base.Name = "Form1";
			this.Text = "Form1";
			base.MouseMove += new MouseEventHandler(this.Form1_MouseMove);
			base.ResumeLayout(false);
		}
	}
}