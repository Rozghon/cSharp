using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Laba19
{
	public class Form1 : Form{
		private IContainer components;
		private TextBox txtBox;
		private CheckBox chkBoxOne;
		private CheckBox chkBoxTwo;
		public string Company{get; set;}
		public string AppName{get; set;}

		public Form1(){
			this.InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e){
			this.LoadFromReg();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e){
			this.SaveReg();
		}

		private void SaveXml(){
			Record rec = new Record(base.Location, base.Size, this.txtBox.Text, new bool[]{
				this.chkBoxOne.Checked,
				this.chkBoxTwo.Checked
			});
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Record));
			bool flaf = !File.Exists("s.xml");
			if (flaf){
				File.Create("s.xml");
			}
			using (Stream stream = File.Open("s.xml", FileMode.Truncate, FileAccess.Write, FileShare.None)){
				xmlSerializer.Serialize(stream, rec);
			}
		}

		private void LoadFromXml(){
			using (Stream stream = File.Open("s.xml", FileMode.Open, FileAccess.Read, FileShare.Read)){
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(Record));
				Record record = (Record)xmlSerializer.Deserialize(stream);
				base.Location = record.Position;
				base.Size = record.Size;
				this.txtBox.Text = record.TextBox;
				this.chkBoxOne.Checked = record.CheckBox[0];
				this.chkBoxTwo.Checked = record.CheckBox[1];
			}
		}

		private void SaveReg(){
			RegistryKey registryKey = null;
			try{
				registryKey = Registry.CurrentUser.OpenSubKey(string.Format("test", true));
				bool flaf = registryKey == null;
				if (flaf){
					throw new NullReferenceException();
				}
			}
			catch (NullReferenceException){
				registryKey = Registry.CurrentUser.CreateSubKey(string.Format("test"));
			}
			catch (Exception exeption){
				MessageBox.Show(exeption.Message, exeption.Source, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try{
				registryKey.SetValue("PositionX", base.Location.X, RegistryValueKind.DWord);
				registryKey.SetValue("PositionY", base.Location.Y, RegistryValueKind.DWord);
				registryKey.SetValue("Width", base.Width, RegistryValueKind.DWord);
				registryKey.SetValue("Height", base.Height, RegistryValueKind.DWord);
				registryKey.SetValue("Text", this.txtBox.Text, RegistryValueKind.String);
				registryKey.SetValue("Check 1", this.chkBoxOne.Checked.ToString(), RegistryValueKind.String);
				registryKey.SetValue("Check 2", this.chkBoxTwo.Checked.ToString(), RegistryValueKind.String);
			}
			catch (Exception exeption2){
				MessageBox.Show(exeption2.Message, exeption2.Source, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void LoadFromReg(){
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(string.Format("test"));
			base.Location = new Point((int)registryKey.GetValue("Pos_x"), (int)registryKey.GetValue("Pos_y"));
			base.Size = new Size((int)registryKey.GetValue("Width"), (int)registryKey.GetValue("Height"));
			this.txtBox.Text = (string)registryKey.GetValue("Text");
			this.chkBoxOne.Checked = bool.Parse((string)registryKey.GetValue("Check 1"));
			this.chkBoxTwo.Checked = bool.Parse((string)registryKey.GetValue("Check 2"));
		}

		protected override void Dispose(bool disposing){
			bool flaf = disposing && this.components != null;
			if (flaf){
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent(){
            this.txtBox = new System.Windows.Forms.TextBox();
            this.chkBoxOne = new System.Windows.Forms.CheckBox();
            this.chkBoxTwo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            this.txtBox.Location = new System.Drawing.Point(20, 20);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(200, 30);
            this.txtBox.TabIndex = 0;
            this.chkBoxOne.AutoSize = true;
            this.chkBoxOne.Location = new System.Drawing.Point(20, 50);
            this.chkBoxOne.Name = "chkBoxOne";
            this.chkBoxOne.Size = new System.Drawing.Size(100, 20);
            this.chkBoxOne.TabIndex = 1;
            this.chkBoxOne.Text = "checkBox1";
            this.chkBoxOne.UseVisualStyleBackColor = true;
            this.chkBoxTwo.AutoSize = true;
            this.chkBoxTwo.Location = new System.Drawing.Point(120, 50);
            this.chkBoxTwo.Name = "chkBoxTwo";
            this.chkBoxTwo.Size = new System.Drawing.Size(100, 20);
            this.chkBoxTwo.TabIndex = 2;
            this.chkBoxTwo.Text = "checkBox2";
            this.chkBoxTwo.UseVisualStyleBackColor = true;

            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.chkBoxTwo);
            this.Controls.Add(this.chkBoxOne);
            this.Controls.Add(this.txtBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
		}
	}

	public class Record
	{
		public bool[] CheckBox;
		[XmlElement]
		public Point Position { get; set; }
		[XmlElement]
		public Size Size { get; set; }
		public string TextBox { get; set; }

		public Record(Point p, Size s, string textbox, bool[] check)
		{
			this.Position = p;
			this.Size = s;
			this.TextBox = textbox;
			this.CheckBox = check;
		}
	}
}
