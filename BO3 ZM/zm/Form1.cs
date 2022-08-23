using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using dllinject;

namespace zm
{
	public class Form1 : Form
	{
		[Flags]
		private enum KeyStates
		{
			None = 0x0,
			Down = 0x1,
			Toggled = 0x2
		}

		private memory m = new memory();

		private float X;

		private float Y;

		private float Z;

		private float X_p2;

		private float Y_p2;

		private float Z_p2;

		private float X_p3;

		private float Y_p3;

		private float Z_p3;

		private float X_p4;

		private float Y_p4;

		private float Z_p4;

		private float undox;

		private float undoy;

		private float undoz;

		private float undox2;

		private float undoy2;

		private float undoz2;

		private float undox3;

		private float undoy3;

		private float undoz3;

		private float undox4;

		private float undoy4;

		private float undoz4;

		private float undox_p2;

		private float undoy_p2;

		private float undoz_p2;

		private float undox_p3;

		private float undoy_p3;

		private float undoz_p3;

		private float undox_p4;

		private float undoy_p4;

		private float undoz_p4;

		private float[] savex = new float[10];

		private float[] savey = new float[10];

		private float[] savez = new float[10];

		private float[] X_z = new float[address.vz.Length];

		private float[] Y_z = new float[address.vz.Length];

		private float[] Z_z = new float[address.vz.Length];

		private float[] float_val = new float[8];

		private uint[] int_val = new uint[3];

		private int basea;

		private long round;

		private static Mutex singleton = new Mutex(initiallyOwned: true, "tu31");

		private long start = 55096377344L;

		private long end = 55297703936L;

		private DllInjector d = new DllInjector();

		private IContainer components;

		private Button button1;

		private System.Windows.Forms.Timer process;

		private Label label1;

		private CheckBox checkBox1;

		private System.Windows.Forms.Timer vita;

		private CheckBox checkBox2;

		private System.Windows.Forms.Timer ammo;

		private CheckBox checkBox3;

		private System.Windows.Forms.Timer rapid;

		private Button button2;

		private Button button3;

		private RadioButton radioButton1;

		private RadioButton radioButton2;

		private RadioButton radioButton3;

		private Label label2;

		private System.Windows.Forms.Timer curweap;

		private System.Windows.Forms.Timer pos;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private Button button6;

		private Button button5;

		private Button button4;

		private Label label5;

		private Label label4;

		private Label label3;

		private CheckBox checkBox4;

		private CheckBox checkBox5;

		private Button button10;

		private Button button11;

		private Label label7;

		private Label label6;

		private Button button12;

		private CheckBox checkBox6;

		private NumericUpDown numericZ;

		private NumericUpDown numericY;

		private NumericUpDown numericX;

		private ToolTip toolTip1;

		private Button button13;

		private System.Windows.Forms.Timer money;

		private Label label9;

		private TabPage tabPage3;

		private Button button14;

		private CheckBox checkBox10;

		private CheckBox checkBox9;

		private CheckBox checkBox8;

		private CheckBox checkBox7;

		private Label label8;

		private NumericUpDown moneyval;

		private Button button15;

		private NumericUpDown jumpval;

		private NumericUpDown weaponval;

		private NumericUpDown gravityval;

		private NumericUpDown speedval;

		private NumericUpDown zhval;

		private CheckBox checkBox11;

		private System.Windows.Forms.Timer zhealth;

		private NumericUpDown timescaleval;

		private Button button16;

		private Button button17;

		private CheckBox checkBox12;

		private Button button22;

		private Button button21;

		private TabPage tabPage4;

		private Button button23;

		private Button button24;

		private CheckBox checkBox18;

		private Button button20;

		private CheckBox checkBox19;

		private CheckBox checkBox20;

		private CheckBox checkBox21;

		private CheckBox checkBox22;

		private Label label11;

		private NumericUpDown moneyval_p2;

		private CheckBox checkBox17;

		private Button button19;

		private CheckBox checkBox13;

		private CheckBox checkBox14;

		private CheckBox checkBox15;

		private CheckBox checkBox16;

		private NumericUpDown weaponval_p2;

		private Label label10;

		private RadioButton radioButton4;

		private RadioButton radioButton5;

		private RadioButton radioButton6;

		private Button button18;

		private System.Windows.Forms.Timer vita_p2;

		private System.Windows.Forms.Timer ammo_p2;

		private System.Windows.Forms.Timer rapid_p2;

		private System.Windows.Forms.Timer money_p2;

		private Button button36;

		private Button button35;

		private Button button38;

		private Button button37;

		private TabPage tabPage5;

		private TabPage tabPage6;

		private Button button42;

		private Button button41;

		private Button button30;

		private Button button31;

		private CheckBox checkBox33;

		private Button button32;

		private CheckBox checkBox34;

		private CheckBox checkBox35;

		private CheckBox checkBox36;

		private CheckBox checkBox37;

		private Label label13;

		private NumericUpDown moneyval_p4;

		private CheckBox checkBox38;

		private Button button33;

		private CheckBox checkBox39;

		private CheckBox checkBox40;

		private CheckBox checkBox41;

		private CheckBox checkBox42;

		private NumericUpDown weaponval_p4;

		private RadioButton radioButton10;

		private RadioButton radioButton11;

		private RadioButton radioButton12;

		private Button button34;

		private System.Windows.Forms.Timer vita_p3;

		private System.Windows.Forms.Timer ammo_p3;

		private System.Windows.Forms.Timer rapid_p3;

		private System.Windows.Forms.Timer money_p3;

		private System.Windows.Forms.Timer vita_p4;

		private System.Windows.Forms.Timer ammo_p4;

		private System.Windows.Forms.Timer rapid_p4;

		private System.Windows.Forms.Timer money_p4;

		private ComboBox comboBox1;

		private Label label14;

		private Button button7;

		private CheckBox checkBox43;

		private Button button43;

		private Button button9;

		private Button button8;

		private System.Windows.Forms.Timer freeze_z;

		private CheckBox checkBox45;

		private Button button44;

		private NumericUpDown model_p1;

		private CheckBox checkBox44;

		private CheckBox checkBox47;

		private NumericUpDown model_p2;

		private Button button45;

		private NumericUpDown model_p4;

		private Button button47;

		private CheckBox checkBox49;

		private CheckBox checkBox48;

		private TextBox textBox2;

		private TextBox textBox1;

		private Button button48;

		private Label label15;

		private System.Windows.Forms.Timer replacer;

		private CheckBox checkBox51;

		private CheckBox checkBox50;

		private NumericUpDown round_num;

		private Button button50;

		private Button button49;

		private System.Windows.Forms.Timer setaddress;

		private ComboBox comboBox2;

		private ComboBox tval;

		private ComboBox sval;

		private ComboBox alvlval;

		private ComboBox comboBox3;

		private Button button51;

		private Label label16;

		private CheckBox checkBox53;

		private CheckBox checkBox52;

		private TabPage tabPage7;
        private NumericUpDown model_p3;
        private Button button46;
        private CheckBox checkBox46;
        private Button button40;
        private Button button39;
        private Button button25;
        private Button button26;
        private CheckBox checkBox23;
        private Button button27;
        private CheckBox checkBox24;
        private CheckBox checkBox25;
        private CheckBox checkBox26;
        private CheckBox checkBox27;
        private Label label12;
        private NumericUpDown moneyval_p3;
        private CheckBox checkBox28;
        private Button button28;
        private CheckBox checkBox29;
        private CheckBox checkBox30;
        private CheckBox checkBox31;
        private CheckBox checkBox32;
        private NumericUpDown weaponval_p3;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private RadioButton radioButton9;
        private Button button29;
        private RichTextBox richTextBox1;

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern short GetKeyState(int keyCode);

		private static KeyStates GetKeyState(Keys key)
		{
			KeyStates keyStates = KeyStates.None;
			short keyState = GetKeyState((int)key);
			if ((keyState & 0x8000) == 32768)
			{
				keyStates |= KeyStates.Down;
			}
			if ((keyState & 1) == 1)
			{
				keyStates |= KeyStates.Toggled;
			}
			return keyStates;
		}

		public static bool IsKeyDown(Keys key)
		{
			return KeyStates.Down == (GetKeyState(key) & KeyStates.Down);
		}

		public static bool IsKeyToggled(Keys key)
		{
			return KeyStates.Toggled == (GetKeyState(key) & KeyStates.Toggled);
		}

		[DllImport("user32.dll")]
		public static extern short GetAsyncKeyState(int vKey);

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			m.WriteInt32(address.soldi, Convert.ToInt32(moneyval.Text));
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (m.IsOpen())
			{
				label1.Text = "找到进程";
				label1.ForeColor = Color.Blue;
				process.Interval = 500;
				if (!curweap.Enabled && !pos.Enabled)
				{
					curweap.Start();
					pos.Start();
				}
				if (basea == 0)
				{
					address.setadd();
					basea = 1;
					for (int i = 0; i < address.float_val.Length; i++)
					{
						float_val[i] = m.ReadFloat(address.float_val[i]);
					}
					for (int j = 0; j < address.int_val.Length; j++)
					{
						int_val[j] = m.ReadUInt32(address.int_val[j]);
					}
				}
			}
			else
			{
				if (curweap.Enabled && pos.Enabled)
				{
					curweap.Stop();
					pos.Stop();
				}
				m.AttackProcess("BlackOps3");
				label1.Text = "未找到进程";
				label1.ForeColor = Color.Red;
				process.Interval = 100;
				basea = 0;
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				vita.Start();
				checkBox4.Checked = false;
			}
			else
			{
				vita.Stop();
				m.WriteInt32(address.vitamax, 100);
				m.WriteInt32(address.vita, 100);
			}
		}

		private void vita_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.vita, int.MaxValue);
			m.WriteInt32(address.vitamax, int.MaxValue);
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked)
			{
				ammo.Start();
				return;
			}
			ammo.Stop();
			m.WriteInt32(address.ammo1, 10);
			m.WriteInt32(address.ammo2, 10);
			m.WriteInt32(address.ammo3, 10);
			m.WriteInt32(address.ammo4, 10);
			m.WriteInt32(address.ammo5, 10);
			m.WriteInt32(address.ammo6, 10);
			m.WriteInt32(address.ammo7, 10);
		}

		private void ammo_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.ammo1, 50);
			m.WriteInt32(address.ammo2, 50);
			m.WriteInt32(address.ammo3, 50);
			m.WriteInt32(address.ammo4, 50);
			m.WriteInt32(address.ammo5, 50);
			m.WriteInt32(address.ammo6, 50);
			m.WriteInt32(address.ammo7, 50);
			m.WriteFloat(address.skull, 100f);
		}

		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox3.Checked)
			{
				rapid.Start();
			}
			else
			{
				rapid.Stop();
			}
		}

		private void rapid_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.rapid, 0);
			m.WriteInt32(address.rapid2, 0);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			m.WriteFloat(address.jump, Convert.ToSingle(jumpval.Text));
		}

		private void curweap_Tick(object sender, EventArgs e)
		{
			label2.Text = "当前武器ID: " + m.ReadString(address.curweap);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				m.WriteInt32(address.give1, Convert.ToInt32(weaponval.Text));
			}
			if (radioButton2.Checked)
			{
				m.WriteInt32(address.give2, Convert.ToInt32(weaponval.Text));
			}
			if (radioButton3.Checked)
			{
				m.WriteInt32(address.give3, Convert.ToInt32(weaponval.Text));
			}
		}

		private void pos_Tick(object sender, EventArgs e)
		{
			X = m.ReadFloat(address.X);
			Y = m.ReadFloat(address.Y);
			Z = m.ReadFloat(address.Z);
			X_p2 = m.ReadFloat(address.X_p2);
			Y_p2 = m.ReadFloat(address.Y_p2);
			Z_p2 = m.ReadFloat(address.Z_p2);
			X_p3 = m.ReadFloat(address.X_p3);
			Y_p3 = m.ReadFloat(address.Y_p3);
			Z_p3 = m.ReadFloat(address.Z_p3);
			X_p4 = m.ReadFloat(address.X_p4);
			Y_p4 = m.ReadFloat(address.Y_p4);
			Z_p4 = m.ReadFloat(address.Z_p4);
			label9.Text = "Z: " + m.ReadString(address.nzombie);
			label3.Text = "X轴: " + X;
			label4.Text = "Y轴: " + Y;
			label5.Text = "Z轴: " + Z;
			if (checkBox5.Checked)
			{
				if (IsKeyDown(Keys.NumPad8))
				{
					m.WriteFloat(address.X, X + 30f);
				}
				if (IsKeyDown(Keys.NumPad2))
				{
					m.WriteFloat(address.X, X - 30f);
				}
				if (IsKeyDown(Keys.NumPad4))
				{
					m.WriteFloat(address.Y, Y + 30f);
				}
				if (IsKeyDown(Keys.NumPad6))
				{
					m.WriteFloat(address.Y, Y - 30f);
				}
				if (IsKeyDown(Keys.NumPad9))
				{
					m.WriteFloat(address.Z, Z + 50f);
				}
				if (IsKeyDown(Keys.NumPad3))
				{
					m.WriteFloat(address.Z, Z - 50f);
				}
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			int num = 0;
			switch (comboBox1.Text)
			{
			case "Pos 1":
				savex[0] = X;
				savey[0] = Y;
				savez[0] = Z;
				break;
			case "Pos 2":
				savex[1] = X;
				savey[1] = Y;
				savez[1] = Z;
				break;
			case "Pos 3":
				savex[2] = X;
				savey[2] = Y;
				savez[2] = Z;
				break;
			case "Pos 4":
				savex[3] = X;
				savey[3] = Y;
				savez[3] = Z;
				break;
			case "Pos 5":
				savex[4] = X;
				savey[4] = Y;
				savez[4] = Z;
				break;
			case "Pos 6":
				savex[5] = X;
				savey[5] = Y;
				savez[5] = Z;
				break;
			case "Pos 7":
				savex[6] = X;
				savey[6] = Y;
				savez[6] = Z;
				break;
			case "Pos 8":
				savex[7] = X;
				savey[7] = Y;
				savez[7] = Z;
				break;
			case "Pos 9":
				savex[8] = X;
				savey[8] = Y;
				savez[8] = Z;
				break;
			case "Pos 10":
				savex[9] = X;
				savey[9] = Y;
				savez[9] = Z;
				break;
			default:
				num = 1;
				break;
			}
			if (num == 0)
			{
				button5.Enabled = true;
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			int num = 0;
			switch (comboBox1.Text)
			{
			case "Pos 1":
				if (savex[0] != 0f && savey[0] != 0f && savez[0] != 0f)
				{
					m.WriteFloat(address.X, savex[0]);
					m.WriteFloat(address.Y, savey[0]);
					m.WriteFloat(address.Z, savez[0]);
				}
				else
				{
					num = 1;
				}
				break;
			case "Pos 2":
				if (savex[1] != 0f && savey[1] != 0f && savez[1] != 0f)
				{
					m.WriteFloat(address.X, savex[1]);
					m.WriteFloat(address.Y, savey[1]);
					m.WriteFloat(address.Z, savez[1]);
				}
				else
				{
					num = 1;
				}
				break;
			case "Pos 3":
				if (savex[2] != 0f && savey[2] != 0f && savez[2] != 0f)
				{
					m.WriteFloat(address.X, savex[2]);
					m.WriteFloat(address.Y, savey[2]);
					m.WriteFloat(address.Z, savez[2]);
				}
				else
				{
					num = 1;
				}
				break;
			case "Pos 4":
				if (savex[3] != 0f && savey[3] != 0f && savez[3] != 0f)
				{
					m.WriteFloat(address.X, savex[3]);
					m.WriteFloat(address.Y, savey[3]);
					m.WriteFloat(address.Z, savez[3]);
				}
				else
				{
					num = 1;
				}
				break;
			case "Pos 5":
				if (savex[4] != 0f && savey[4] != 0f && savez[4] != 0f)
				{
					m.WriteFloat(address.X, savex[4]);
					m.WriteFloat(address.Y, savey[4]);
					m.WriteFloat(address.Z, savez[4]);
				}
				else
				{
					num = 1;
				}
				break;
			case "Pos 6":
				if (savex[5] != 0f && savey[5] != 0f && savez[5] != 0f)
				{
					m.WriteFloat(address.X, savex[5]);
					m.WriteFloat(address.Y, savey[5]);
					m.WriteFloat(address.Z, savez[5]);
				}
				else
				{
					num = 1;
				}
				break;
			case "Pos 7":
				if (savex[6] != 0f && savey[6] != 0f && savez[6] != 0f)
				{
					m.WriteFloat(address.X, savex[6]);
					m.WriteFloat(address.Y, savey[6]);
					m.WriteFloat(address.Z, savez[6]);
				}
				else
				{
					num = 1;
				}
				break;
			case "Pos 8":
				if (savex[7] != 0f && savey[7] != 0f && savez[7] != 0f)
				{
					m.WriteFloat(address.X, savex[7]);
					m.WriteFloat(address.Y, savey[7]);
					m.WriteFloat(address.Z, savez[7]);
				}
				else
				{
					num = 1;
				}
				break;
			case "Pos 9":
				if (savex[8] != 0f && savey[8] != 0f && savez[8] != 0f)
				{
					m.WriteFloat(address.X, savex[8]);
					m.WriteFloat(address.Y, savey[8]);
					m.WriteFloat(address.Z, savez[8]);
				}
				else
				{
					num = 1;
				}
				break;
			case "Pos 10":
				if (savex[9] != 0f && savey[9] != 0f && savez[9] != 0f)
				{
					m.WriteFloat(address.X, savex[9]);
					m.WriteFloat(address.Y, savey[9]);
					m.WriteFloat(address.Z, savez[9]);
				}
				else
				{
					num = 1;
				}
				break;
			default:
				num = 1;
				break;
			}
			if (num == 0)
			{
				undox = X;
				undoy = Y;
				undoz = Z;
				button6.Enabled = true;
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			m.WriteFloat(address.X, undox);
			m.WriteFloat(address.Y, undoy);
			m.WriteFloat(address.Z, undoz);
			button6.Enabled = false;
		}

		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox4.Checked)
			{
				checkBox1.Checked = false;
				m.WriteNOP(address.vita);
			}
			else
			{
				m.WriteInt32(address.vita, 100);
			}
		}

		private void checkBox5_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox5.Checked)
			{
				label6.Visible = true;
				label7.Visible = true;
			}
			else
			{
				label6.Visible = false;
				label7.Visible = false;
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
		}

		private void button11_Click(object sender, EventArgs e)
		{
			switch (sval.Text)
			{
			case "50":
				m.WriteInt32(address.speed, (int)int_val[0]);
				break;
			case "190":
				m.WriteInt32(address.speed, (int)int_val[1]);
				break;
			case "500":
				m.WriteInt32(address.speed, (int)int_val[2]);
				break;
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			MessageBox.Show("By MisterY. V100 - TU31.由Fallingfl汉化");
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			if (e.CloseReason != CloseReason.WindowsShutDown)
			{
				singleton.WaitOne(TimeSpan.Zero, exitContext: true);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (!singleton.WaitOne(TimeSpan.Zero, exitContext: true))
			{
				MessageBox.Show("Already running");
				Application.Exit();
			}
			tabPage1.Text = "主要功能";
			tabPage3.Text = "其他功能";
			tabPage2.Text = "传送功能";
			tabPage4.Text = "P2功能";
			tabPage5.Text = "P3功能";
			tabPage6.Text = "P4功能";
			Text = "";
			toolTip1.SetToolTip(checkBox6, "冻结");
			toolTip1.SetToolTip(checkBox11, "冻结");
			toolTip1.SetToolTip(numericX, "X轴");
			toolTip1.SetToolTip(numericY, "Y轴");
			toolTip1.SetToolTip(numericZ, "Z轴");
			moneyval.Maximum = decimal.MaxValue;
			moneyval.Minimum = 0m;
			jumpval.Maximum = decimal.MaxValue;
			jumpval.Minimum = 0m;
			weaponval.Maximum = decimal.MaxValue;
			gravityval.Maximum = 2147483647m;
			gravityval.Minimum = 0m;
			speedval.Maximum = 2147483647m;
			speedval.Minimum = 0m;
			zhval.Maximum = decimal.MaxValue;
			zhval.Minimum = 0m;
			numericX.Maximum = decimal.MaxValue;
			numericX.Minimum = decimal.MinValue;
			numericY.Maximum = decimal.MaxValue;
			numericY.Minimum = decimal.MinValue;
			numericZ.Maximum = decimal.MaxValue;
			numericZ.Minimum = decimal.MinValue;
			timescaleval.Maximum = 5000m;
			timescaleval.Minimum = 0m;
			weaponval_p2.Maximum = decimal.MaxValue;
			moneyval_p2.Maximum = decimal.MaxValue;
			moneyval_p2.Minimum = 0m;
			weaponval_p3.Maximum = decimal.MaxValue;
			moneyval_p3.Maximum = decimal.MaxValue;
			moneyval_p3.Minimum = 0m;
			weaponval_p4.Maximum = decimal.MaxValue;
			moneyval_p4.Maximum = decimal.MaxValue;
			moneyval_p4.Minimum = 0m;
			model_p1.Maximum = 255m;
			model_p1.Minimum = 0m;
			model_p2.Maximum = 255m;
			model_p2.Minimum = 0m;
			model_p3.Maximum = 255m;
			model_p3.Minimum = 0m;
			model_p4.Maximum = 255m;
			model_p4.Minimum = 0m;
			round_num.Maximum = decimal.MaxValue;
			round_num.Minimum = 0m;
			alvlval.Text = "800";
			sval.Text = "190";
			tval.Text = "1";
		}

		private void button13_Click(object sender, EventArgs e)
		{
			undox3 = m.ReadFloat(address.X);
			undoy3 = m.ReadFloat(address.Y);
			undoz3 = m.ReadFloat(address.Z);
			m.WriteFloat(address.X, Convert.ToSingle(numericX.Text));
			m.WriteFloat(address.Y, Convert.ToSingle(numericY.Text));
			m.WriteFloat(address.Z, Convert.ToSingle(numericZ.Text));
			button17.Enabled = true;
		}

		private void tabPage2_Click(object sender, EventArgs e)
		{
		}

		private void money_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.soldi, Convert.ToInt32(moneyval.Text));
		}

		private void checkBox6_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox6.Checked)
			{
				money.Start();
			}
			else
			{
				money.Stop();
			}
		}

		private void tabPage1_Click(object sender, EventArgs e)
		{
		}

		private void checkBox7_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox7.Checked)
			{
				m.WriteInt32(address.perk, m.ReadString(address.perk) + 1);
			}
			else
			{
				m.WriteInt32(address.perk, m.ReadString(address.perk) - 1);
			}
		}

		private void checkBox8_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox8.Checked)
			{
				m.WriteInt32(address.perk, m.ReadString(address.perk) + 262144);
			}
			else
			{
				m.WriteInt32(address.perk, m.ReadString(address.perk) - 262144);
			}
		}

		private void checkBox9_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox9.Checked)
			{
				m.WriteInt32(address.perk, m.ReadString(address.perk) + 268435456);
			}
			else
			{
				m.WriteInt32(address.perk, m.ReadString(address.perk) - 268435456);
			}
		}

		private void checkBox10_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox10.Checked)
			{
				m.WriteInt32(address.perk2, m.ReadString(address.perk2) + 134217728);
			}
			else
			{
				m.WriteInt32(address.perk2, m.ReadString(address.perk2) - 134217728);
			}
		}

		private void button14_Click(object sender, EventArgs e)
		{
			checkBox7.Checked = false;
			checkBox8.Checked = false;
			checkBox9.Checked = false;
			checkBox10.Checked = false;
			m.WriteInt32(address.perk, 0);
			m.WriteInt32(address.perk2, 0);
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
		}

		private void button15_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < address.vz.Length; i++)
			{
				m.WriteInt32(address.vz[i], Convert.ToInt32(zhval.Text));
			}
		}

		private void checkBox11_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox11.Checked)
			{
				zhealth.Start();
			}
			else
			{
				zhealth.Stop();
			}
		}

		private void zhealth_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < address.vz.Length; i++)
			{
				m.WriteInt32(address.vz[i], Convert.ToInt32(zhval.Text));
			}
		}

		private void button16_Click(object sender, EventArgs e)
		{
			switch (tval.Text)
			{
			case "0.1":
				m.WriteFloat(address.timescale, float_val[0]);
				break;
			case "0.5":
				m.WriteFloat(address.timescale, float_val[1]);
				break;
			case "1":
				m.WriteFloat(address.timescale, float_val[2]);
				break;
			case "1.5":
				m.WriteFloat(address.timescale, float_val[3]);
				break;
			case "2":
				m.WriteFloat(address.timescale, float_val[4]);
				break;
			case "3":
				m.WriteFloat(address.timescale, float_val[5]);
				break;
			case "5":
				m.WriteFloat(address.timescale, float_val[6]);
				break;
			case "10":
				m.WriteFloat(address.timescale, float_val[7]);
				break;
			}
		}

		private void button17_Click(object sender, EventArgs e)
		{
			m.WriteFloat(address.X, undox3);
			m.WriteFloat(address.Y, undoy3);
			m.WriteFloat(address.Z, undoz3);
			button17.Enabled = false;
		}

		private void checkBox12_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox12.Checked)
			{
				m.WriteInt32(address.freeze, 4);
			}
			else
			{
				m.WriteInt32(address.freeze, 0);
			}
		}

		private void button21_Click(object sender, EventArgs e)
		{
			undox4 = m.ReadFloat(address.X);
			undoy4 = m.ReadFloat(address.Y);
			undoz4 = m.ReadFloat(address.Z);
			m.WriteFloat(address.X, X_p2 + 20f);
			m.WriteFloat(address.Y, Y_p2 + 20f);
			m.WriteFloat(address.Z, Z_p2);
			button22.Enabled = true;
		}

		private void button22_Click(object sender, EventArgs e)
		{
			m.WriteFloat(address.X, undox4);
			m.WriteFloat(address.Y, undoy4);
			m.WriteFloat(address.Z, undoz4);
			button22.Enabled = false;
		}

		private void checkBox18_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox18.Checked)
			{
				m.WriteInt32(address.freeze_p2, 4);
			}
			else
			{
				m.WriteInt32(address.freeze_p2, 0);
			}
		}

		private void tabPage4_Click(object sender, EventArgs e)
		{
		}

		private void checkBox14_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox14.Checked)
			{
				vita_p2.Start();
				checkBox13.Checked = false;
			}
			else
			{
				vita_p2.Stop();
				m.WriteInt32(address.vitamax_p2, 100);
				m.WriteInt32(address.vita_p2, 100);
			}
		}

		private void vita_p2_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.vita_p2, int.MaxValue);
			m.WriteInt32(address.vitamax_p2, int.MaxValue);
		}

		private void checkBox15_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox15.Checked)
			{
				ammo_p2.Start();
				return;
			}
			ammo_p2.Stop();
			m.WriteInt32(address.ammo1_p2, 10);
			m.WriteInt32(address.ammo2_p2, 10);
			m.WriteInt32(address.ammo3_p2, 10);
			m.WriteInt32(address.ammo4_p2, 10);
			m.WriteInt32(address.ammo5_p2, 10);
			m.WriteInt32(address.ammo6_p2, 10);
			m.WriteInt32(address.ammo7_p2, 10);
		}

		private void ammo_p2_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.ammo1_p2, 50);
			m.WriteInt32(address.ammo2_p2, 50);
			m.WriteInt32(address.ammo3_p2, 50);
			m.WriteInt32(address.ammo4_p2, 50);
			m.WriteInt32(address.ammo5_p2, 50);
			m.WriteInt32(address.ammo6_p2, 50);
			m.WriteInt32(address.ammo7_p2, 50);
			m.WriteFloat(address.skull_p2, 100f);
		}

		private void checkBox16_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox16.Checked)
			{
				rapid_p2.Start();
			}
			else
			{
				rapid_p2.Stop();
			}
		}

		private void rapid_p2_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.rapid_p2, 0);
			m.WriteInt32(address.rapid2_p2, 0);
		}

		private void checkBox13_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox13.Checked)
			{
				checkBox14.Checked = false;
				m.WriteNOP(address.vita_p2);
			}
			else
			{
				m.WriteInt32(address.vita_p2, 100);
			}
		}

		private void button19_Click(object sender, EventArgs e)
		{
			m.WriteInt32(address.soldi_p2, Convert.ToInt32(moneyval_p2.Text));
		}

		private void money_p2_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.soldi_p2, Convert.ToInt32(moneyval_p2.Text));
		}

		private void button18_Click(object sender, EventArgs e)
		{
			if (radioButton6.Checked)
			{
				m.WriteInt32(address.give1_p2, Convert.ToInt32(weaponval_p2.Text));
			}
			if (radioButton5.Checked)
			{
				m.WriteInt32(address.give2_p2, Convert.ToInt32(weaponval_p2.Text));
			}
			if (radioButton4.Checked)
			{
				m.WriteInt32(address.give3_p2, Convert.ToInt32(weaponval_p2.Text));
			}
		}

		private void checkBox17_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox17.Checked)
			{
				money_p2.Start();
			}
			else
			{
				money_p2.Stop();
			}
		}

		private void button24_Click(object sender, EventArgs e)
		{
			undox_p2 = m.ReadFloat(address.X_p2);
			undoy_p2 = m.ReadFloat(address.Y_p2);
			undoz_p2 = m.ReadFloat(address.Z_p2);
			m.WriteFloat(address.X_p2, X + 20f);
			m.WriteFloat(address.Y_p2, Y + 20f);
			m.WriteFloat(address.Z_p2, Z);
			button23.Enabled = true;
		}

		private void button23_Click(object sender, EventArgs e)
		{
			m.WriteFloat(address.X_p2, undox_p2);
			m.WriteFloat(address.Y_p2, undoy_p2);
			m.WriteFloat(address.Z_p2, undoz_p2);
			button23.Enabled = false;
		}

		private void checkBox22_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox22.Checked)
			{
				m.WriteInt32(address.perk_p2, m.ReadString(address.perk_p2) + 1);
			}
			else
			{
				m.WriteInt32(address.perk_p2, m.ReadString(address.perk_p2) - 1);
			}
		}

		private void checkBox21_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox21.Checked)
			{
				m.WriteInt32(address.perk_p2, m.ReadString(address.perk_p2) + 262144);
			}
			else
			{
				m.WriteInt32(address.perk_p2, m.ReadString(address.perk_p2) - 262144);
			}
		}

		private void checkBox20_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox20.Checked)
			{
				m.WriteInt32(address.perk_p2, m.ReadString(address.perk_p2) + 268435456);
			}
			else
			{
				m.WriteInt32(address.perk_p2, m.ReadString(address.perk_p2) - 268435456);
			}
		}

		private void checkBox19_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox19.Checked)
			{
				m.WriteInt32(address.perk2_p2, m.ReadString(address.perk2_p2) + 134217728);
			}
			else
			{
				m.WriteInt32(address.perk2_p2, m.ReadString(address.perk2_p2) - 134217728);
			}
		}

		private void button20_Click(object sender, EventArgs e)
		{
			checkBox22.Checked = false;
			checkBox21.Checked = false;
			checkBox20.Checked = false;
			checkBox19.Checked = false;
			m.WriteInt32(address.perk_p2, 0);
			m.WriteInt32(address.perk2_p2, 0);
		}

		private void button36_Click(object sender, EventArgs e)
		{
			undox4 = m.ReadFloat(address.X);
			undoy4 = m.ReadFloat(address.Y);
			undoz4 = m.ReadFloat(address.Z);
			m.WriteFloat(address.X, X_p3 + 20f);
			m.WriteFloat(address.Y, Y_p3 + 20f);
			m.WriteFloat(address.Z, Z_p3);
			button22.Enabled = true;
		}

		private void button35_Click(object sender, EventArgs e)
		{
			undox4 = m.ReadFloat(address.X);
			undoy4 = m.ReadFloat(address.Y);
			undoz4 = m.ReadFloat(address.Z);
			m.WriteFloat(address.X, X_p4 + 20f);
			m.WriteFloat(address.Y, Y_p4 + 20f);
			m.WriteFloat(address.Z, Z_p4);
			button22.Enabled = true;
		}

		private void button37_Click(object sender, EventArgs e)
		{
			undox_p2 = m.ReadFloat(address.X_p2);
			undoy_p2 = m.ReadFloat(address.Y_p2);
			undoz_p2 = m.ReadFloat(address.Z_p2);
			m.WriteFloat(address.X_p2, X_p3 + 20f);
			m.WriteFloat(address.Y_p2, Y_p3 + 20f);
			m.WriteFloat(address.Z_p2, Z_p3);
			button23.Enabled = true;
		}

		private void button38_Click(object sender, EventArgs e)
		{
			undox_p2 = m.ReadFloat(address.X_p2);
			undoy_p2 = m.ReadFloat(address.Y_p2);
			undoz_p2 = m.ReadFloat(address.Z_p2);
			m.WriteFloat(address.X_p2, X_p4 + 20f);
			m.WriteFloat(address.Y_p2, Y_p4 + 20f);
			m.WriteFloat(address.Z_p2, Z_p4);
			button23.Enabled = true;
		}

		private void button26_Click(object sender, EventArgs e)
		{
			undox_p3 = m.ReadFloat(address.X_p3);
			undoy_p3 = m.ReadFloat(address.Y_p3);
			undoz_p3 = m.ReadFloat(address.Z_p3);
			m.WriteFloat(address.X_p3, X + 20f);
			m.WriteFloat(address.Y_p3, Y + 20f);
			m.WriteFloat(address.Z_p3, Z);
			button25.Enabled = true;
		}

		private void button39_Click(object sender, EventArgs e)
		{
			undox_p3 = m.ReadFloat(address.X_p3);
			undoy_p3 = m.ReadFloat(address.Y_p3);
			undoz_p3 = m.ReadFloat(address.Z_p3);
			m.WriteFloat(address.X_p3, X_p2 + 20f);
			m.WriteFloat(address.Y_p3, Y_p2 + 20f);
			m.WriteFloat(address.Z_p3, Z_p2);
			button25.Enabled = true;
		}

		private void button40_Click(object sender, EventArgs e)
		{
			undox_p3 = m.ReadFloat(address.X_p3);
			undoy_p3 = m.ReadFloat(address.Y_p3);
			undoz_p3 = m.ReadFloat(address.Z_p3);
			m.WriteFloat(address.X_p3, X_p4 + 20f);
			m.WriteFloat(address.Y_p3, Y_p4 + 20f);
			m.WriteFloat(address.Z_p3, Z_p4);
			button25.Enabled = true;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			m.WriteFloat(address.X_p3, undox_p3);
			m.WriteFloat(address.Y_p3, undoy_p3);
			m.WriteFloat(address.Z_p3, undoz_p3);
			button25.Enabled = false;
		}

		private void button31_Click(object sender, EventArgs e)
		{
			undox_p4 = m.ReadFloat(address.X_p4);
			undoy_p4 = m.ReadFloat(address.Y_p4);
			undoz_p4 = m.ReadFloat(address.Z_p4);
			m.WriteFloat(address.X_p4, X + 20f);
			m.WriteFloat(address.Y_p4, Y + 20f);
			m.WriteFloat(address.Z_p4, Z);
			button30.Enabled = true;
		}

		private void button41_Click(object sender, EventArgs e)
		{
			undox_p4 = m.ReadFloat(address.X_p4);
			undoy_p4 = m.ReadFloat(address.Y_p4);
			undoz_p4 = m.ReadFloat(address.Z_p4);
			m.WriteFloat(address.X_p4, X_p2 + 20f);
			m.WriteFloat(address.Y_p4, Y_p2 + 20f);
			m.WriteFloat(address.Z_p4, Z_p2);
			button30.Enabled = true;
		}

		private void button42_Click(object sender, EventArgs e)
		{
			undox_p4 = m.ReadFloat(address.X_p4);
			undoy_p4 = m.ReadFloat(address.Y_p4);
			undoz_p4 = m.ReadFloat(address.Z_p4);
			m.WriteFloat(address.X_p4, X_p3 + 20f);
			m.WriteFloat(address.Y_p4, Y_p3 + 20f);
			m.WriteFloat(address.Z_p4, Z_p3);
			button30.Enabled = true;
		}

		private void button30_Click(object sender, EventArgs e)
		{
			m.WriteFloat(address.X_p4, undox_p4);
			m.WriteFloat(address.Y_p4, undoy_p4);
			m.WriteFloat(address.Z_p4, undoz_p4);
			button25.Enabled = false;
		}

		private void checkBox30_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox30.Checked)
			{
				vita_p3.Start();
				checkBox29.Checked = false;
			}
			else
			{
				vita_p3.Stop();
				m.WriteInt32(address.vitamax_p3, 100);
				m.WriteInt32(address.vita_p3, 100);
			}
		}

		private void vita_p3_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.vita_p3, int.MaxValue);
			m.WriteInt32(address.vitamax_p3, int.MaxValue);
		}

		private void checkBox31_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox31.Checked)
			{
				ammo_p3.Start();
				return;
			}
			ammo_p3.Stop();
			m.WriteInt32(address.ammo1_p3, 10);
			m.WriteInt32(address.ammo2_p3, 10);
			m.WriteInt32(address.ammo3_p3, 10);
			m.WriteInt32(address.ammo4_p3, 10);
			m.WriteInt32(address.ammo5_p3, 10);
			m.WriteInt32(address.ammo6_p3, 10);
			m.WriteInt32(address.ammo7_p3, 10);
		}

		private void ammo_p3_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.ammo1_p3, 50);
			m.WriteInt32(address.ammo2_p3, 50);
			m.WriteInt32(address.ammo3_p3, 50);
			m.WriteInt32(address.ammo4_p3, 50);
			m.WriteInt32(address.ammo5_p3, 50);
			m.WriteInt32(address.ammo6_p3, 50);
			m.WriteInt32(address.ammo7_p3, 50);
			m.WriteFloat(address.skull_p3, 100f);
		}

		private void checkBox32_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox32.Checked)
			{
				rapid_p3.Start();
			}
			else
			{
				rapid_p3.Stop();
			}
		}

		private void rapid_p3_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.rapid_p3, 0);
			m.WriteInt32(address.rapid2_p3, 0);
		}

		private void checkBox29_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox29.Checked)
			{
				checkBox30.Checked = false;
				m.WriteNOP(address.vita_p3);
			}
			else
			{
				m.WriteInt32(address.vita_p3, 100);
			}
		}

		private void checkBox23_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox23.Checked)
			{
				m.WriteInt32(address.freeze_p3, 4);
			}
			else
			{
				m.WriteInt32(address.freeze_p3, 0);
			}
		}

		private void button28_Click(object sender, EventArgs e)
		{
			m.WriteInt32(address.soldi_p3, Convert.ToInt32(moneyval_p3.Text));
		}

		private void checkBox28_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox28.Checked)
			{
				money_p3.Start();
			}
			else
			{
				money_p3.Stop();
			}
		}

		private void money_p3_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.soldi_p3, Convert.ToInt32(moneyval_p3.Text));
		}

		private void button29_Click(object sender, EventArgs e)
		{
			if (radioButton9.Checked)
			{
				m.WriteInt32(address.give1_p3, Convert.ToInt32(weaponval_p3.Text));
			}
			if (radioButton8.Checked)
			{
				m.WriteInt32(address.give2_p3, Convert.ToInt32(weaponval_p3.Text));
			}
			if (radioButton7.Checked)
			{
				m.WriteInt32(address.give3_p3, Convert.ToInt32(weaponval_p3.Text));
			}
		}

		private void checkBox27_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox27.Checked)
			{
				m.WriteInt32(address.perk_p3, m.ReadString(address.perk_p3) + 1);
			}
			else
			{
				m.WriteInt32(address.perk_p3, m.ReadString(address.perk_p3) - 1);
			}
		}

		private void checkBox26_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox26.Checked)
			{
				m.WriteInt32(address.perk_p3, m.ReadString(address.perk_p3) + 262144);
			}
			else
			{
				m.WriteInt32(address.perk_p3, m.ReadString(address.perk_p3) - 262144);
			}
		}

		private void checkBox25_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox25.Checked)
			{
				m.WriteInt32(address.perk_p3, m.ReadString(address.perk_p3) + 268435456);
			}
			else
			{
				m.WriteInt32(address.perk_p3, m.ReadString(address.perk_p3) - 268435456);
			}
		}

		private void checkBox24_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox24.Checked)
			{
				m.WriteInt32(address.perk2_p3, m.ReadString(address.perk2_p3) + 134217728);
			}
			else
			{
				m.WriteInt32(address.perk2_p3, m.ReadString(address.perk2_p3) - 134217728);
			}
		}

		private void button27_Click(object sender, EventArgs e)
		{
			checkBox27.Checked = false;
			checkBox26.Checked = false;
			checkBox25.Checked = false;
			checkBox24.Checked = false;
			m.WriteInt32(address.perk_p3, 0);
			m.WriteInt32(address.perk2_p3, 0);
		}

		private void checkBox40_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox40.Checked)
			{
				vita_p4.Start();
				checkBox39.Checked = false;
			}
			else
			{
				vita_p4.Stop();
				m.WriteInt32(address.vitamax_p4, 100);
				m.WriteInt32(address.vita_p4, 100);
			}
		}

		private void vita_p4_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.vita_p4, int.MaxValue);
			m.WriteInt32(address.vitamax_p4, int.MaxValue);
		}

		private void checkBox41_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox41.Checked)
			{
				ammo_p4.Start();
				return;
			}
			ammo_p4.Stop();
			m.WriteInt32(address.ammo1_p4, 10);
			m.WriteInt32(address.ammo2_p4, 10);
			m.WriteInt32(address.ammo3_p4, 10);
			m.WriteInt32(address.ammo4_p4, 10);
			m.WriteInt32(address.ammo5_p4, 10);
			m.WriteInt32(address.ammo6_p4, 10);
			m.WriteInt32(address.ammo7_p4, 10);
		}

		private void ammo_p4_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.ammo1_p4, 50);
			m.WriteInt32(address.ammo2_p4, 50);
			m.WriteInt32(address.ammo3_p4, 50);
			m.WriteInt32(address.ammo4_p4, 50);
			m.WriteInt32(address.ammo5_p4, 50);
			m.WriteInt32(address.ammo6_p4, 50);
			m.WriteInt32(address.ammo7_p4, 50);
			m.WriteFloat(address.skull_p4, 100f);
		}

		private void checkBox42_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox42.Checked)
			{
				rapid_p4.Start();
			}
			else
			{
				rapid_p4.Stop();
			}
		}

		private void rapid_p4_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.rapid_p4, 0);
			m.WriteInt32(address.rapid2_p4, 0);
		}

		private void checkBox50_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox50.Checked)
			{
				m.WriteXBytes(address.ai_meleedamage, new byte[4] { 5, 0, 48, 0 });
			}
			else
			{
				m.WriteXBytes(address.ai_meleedamage, new byte[4] { 225, 47, 222, 137 });
			}
		}

		private void button50_Click(object sender, EventArgs e)
		{
			MessageBox.Show(address.round_static.ToString("X"));
			if (m.ReadString(address.round_static) != 0)
			{
				try
				{
					round = m.FindPattern(start, end, "\u0001\0\0\0\u0001\0\0\0\a\0\0\0\u0001\0\0\0\u0002\u0001\0\0\0\0\0\0yB\0\0\0\0\0\0\0\0\0\0\0\0\0\0¹Æ\u001d", "??????xxxxxx?xxxxxxxxxxx???xxxxx????xxxxxxx");
					m.WriteInt32(round, Convert.ToInt32(round_num.Text));
					MessageBox.Show(round.ToString("X"));
				}
				catch (Exception)
				{
					MessageBox.Show("无法切换回合，请尝试重新启动游戏");
				}
			}
		}

		private void If_Alivet(int int32)
		{
		}

		private void tabPage5_Click(object sender, EventArgs e)
		{
		}

		private void button49_Click(object sender, EventArgs e)
		{
			string sDllPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\abc.dll";
			if (d.Inject("BlackOps3", sDllPath) == DllInjectionResult.DllNotFound)
			{
				MessageBox.Show("DLL未注入");
			}
		}

		private void button51_Click(object sender, EventArgs e)
		{
		}

		private void tabPage3_Click(object sender, EventArgs e)
		{
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (comboBox1.Text)
			{
			case "Pos 1":
				if (savex[0] != 0f && savey[0] != 0f && savez[0] != 0f)
				{
					button5.Enabled = true;
				}
				else
				{
					button5.Enabled = false;
				}
				break;
			case "Pos 2":
				if (savex[1] != 0f && savey[1] != 0f && savez[1] != 0f)
				{
					button5.Enabled = true;
				}
				else
				{
					button5.Enabled = false;
				}
				break;
			case "Pos 3":
				if (savex[2] != 0f && savey[2] != 0f && savez[2] != 0f)
				{
					button5.Enabled = true;
				}
				else
				{
					button5.Enabled = false;
				}
				break;
			case "Pos 4":
				if (savex[3] != 0f && savey[3] != 0f && savez[3] != 0f)
				{
					button5.Enabled = true;
				}
				else
				{
					button5.Enabled = false;
				}
				break;
			case "Pos 5":
				if (savex[4] != 0f && savey[4] != 0f && savez[4] != 0f)
				{
					button5.Enabled = true;
				}
				else
				{
					button5.Enabled = false;
				}
				break;
			case "Pos 6":
				if (savex[5] != 0f && savey[5] != 0f && savez[5] != 0f)
				{
					button5.Enabled = true;
				}
				else
				{
					button5.Enabled = false;
				}
				break;
			case "Pos 7":
				if (savex[6] != 0f && savey[6] != 0f && savez[6] != 0f)
				{
					button5.Enabled = true;
				}
				else
				{
					button5.Enabled = false;
				}
				break;
			case "Pos 8":
				if (savex[7] != 0f && savey[7] != 0f && savez[7] != 0f)
				{
					button5.Enabled = true;
				}
				else
				{
					button5.Enabled = false;
				}
				break;
			case "Pos 9":
				if (savex[8] != 0f && savey[8] != 0f && savez[8] != 0f)
				{
					button5.Enabled = true;
				}
				else
				{
					button5.Enabled = false;
				}
				break;
			case "Pos 10":
				if (savex[9] != 0f && savey[9] != 0f && savez[9] != 0f)
				{
					button5.Enabled = true;
				}
				else
				{
					button5.Enabled = false;
				}
				break;
			}
		}

		private void setaddress_Tick(object sender, EventArgs e)
		{
			address.setadd();
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			_ = string.Empty;
			string[] array = null;
			try
			{
				array = File.ReadAllLines(Path.GetDirectoryName(Application.ExecutablePath) + "\\tp.txt");
				int num = Array.IndexOf(array, comboBox2.SelectedItem.ToString());
				numericX.Text = array[num + 1];
				numericY.Text = array[num + 2];
				numericZ.Text = array[num + 3];
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("File 'tp.txt' not found");
			}
			toolTip1.SetToolTip(comboBox2, comboBox2.Text);
		}

		private void comboBox2_DropDown(object sender, EventArgs e)
		{
			comboBox2.Items.Clear();
			_ = string.Empty;
			string[] array = null;
			try
			{
				array = File.ReadAllLines(Path.GetDirectoryName(Application.ExecutablePath) + "\\tp.txt");
				for (int i = 0; i < array.Count(); i++)
				{
					if (i % 5 == 0)
					{
						comboBox2.Items.Add(array[i]);
					}
				}
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("File 'tp.txt' not found");
			}
		}

		private void checkBox52_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void checkBox53_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox53.Checked)
			{
				checkBox52.Checked = true;
				m.WriteXBytes(address.sv_cheats, new byte[4] { 154, 0, 140, 0 });
			}
			else
			{
				m.WriteXBytes(address.sv_cheats, new byte[4] { 5, 0, 48, 0 });
			}
		}

		private void button51_Click_1(object sender, EventArgs e)
		{
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void alvlval_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void checkBox39_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox39.Checked)
			{
				checkBox40.Checked = false;
				m.WriteNOP(address.vita_p4);
			}
			else
			{
				m.WriteInt32(address.vita_p4, 100);
			}
		}

		private void checkBox33_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox33.Checked)
			{
				m.WriteInt32(address.freeze_p4, 4);
			}
			else
			{
				m.WriteInt32(address.freeze_p4, 0);
			}
		}

		private void button33_Click(object sender, EventArgs e)
		{
			m.WriteInt32(address.soldi_p4, Convert.ToInt32(moneyval_p4.Text));
		}

		private void checkBox38_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox38.Checked)
			{
				money_p4.Start();
			}
			else
			{
				money_p4.Stop();
			}
		}

		private void money_p4_Tick(object sender, EventArgs e)
		{
			m.WriteInt32(address.soldi_p4, Convert.ToInt32(moneyval_p4.Text));
		}

		private void button34_Click(object sender, EventArgs e)
		{
			if (radioButton12.Checked)
			{
				m.WriteInt32(address.give1_p4, Convert.ToInt32(weaponval_p4.Text));
			}
			if (radioButton11.Checked)
			{
				m.WriteInt32(address.give2_p4, Convert.ToInt32(weaponval_p4.Text));
			}
			if (radioButton10.Checked)
			{
				m.WriteInt32(address.give3_p4, Convert.ToInt32(weaponval_p4.Text));
			}
		}

		private void checkBox37_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox37.Checked)
			{
				m.WriteInt32(address.perk_p4, m.ReadString(address.perk_p4) + 1);
			}
			else
			{
				m.WriteInt32(address.perk_p4, m.ReadString(address.perk_p4) - 1);
			}
		}

		private void checkBox36_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox36.Checked)
			{
				m.WriteInt32(address.perk_p4, m.ReadString(address.perk_p4) + 262144);
			}
			else
			{
				m.WriteInt32(address.perk_p4, m.ReadString(address.perk_p4) - 262144);
			}
		}

		private void checkBox35_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox35.Checked)
			{
				m.WriteInt32(address.perk_p4, m.ReadString(address.perk_p4) + 268435456);
			}
			else
			{
				m.WriteInt32(address.perk_p4, m.ReadString(address.perk_p4) - 268435456);
			}
		}

		private void checkBox34_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox34.Checked)
			{
				m.WriteInt32(address.perk2_p4, m.ReadString(address.perk2_p4) + 134217728);
			}
			else
			{
				m.WriteInt32(address.perk2_p4, m.ReadString(address.perk2_p4) - 134217728);
			}
		}

		private void button32_Click(object sender, EventArgs e)
		{
			checkBox37.Checked = false;
			checkBox36.Checked = false;
			checkBox35.Checked = false;
			checkBox34.Checked = false;
			m.WriteInt32(address.perk_p4, 0);
			m.WriteInt32(address.perk2_p4, 0);
		}

		private void checkBox43_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox43.Checked)
			{
				for (int i = 0; i < address.vz.Length; i++)
				{
					X_z[i] = m.ReadFloat(address.X_z[i]);
					Y_z[i] = m.ReadFloat(address.Y_z[i]);
					Z_z[i] = m.ReadFloat(address.Z_z[i]);
				}
				freeze_z.Start();
			}
			else
			{
				freeze_z.Stop();
			}
		}

		private void freeze_z_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < address.vz.Length; i++)
			{
				m.WriteFloat(address.X_z[i], X_z[i]);
				m.WriteFloat(address.Y_z[i], Y_z[i]);
				m.WriteFloat(address.Z_z[i], Z_z[i]);
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			int num = 0;
			if (checkBox43.Checked)
			{
				checkBox43.Checked = false;
				num = 1;
			}
			for (int i = 0; i < address.vz.Length; i++)
			{
				m.WriteFloat(address.X_z[i], X + 50f);
				m.WriteFloat(address.Y_z[i], Y + 50f);
				m.WriteFloat(address.Z_z[i], Z);
			}
			if (num == 1)
			{
				checkBox43.Checked = true;
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			int num = 0;
			if (checkBox43.Checked)
			{
				checkBox43.Checked = false;
				num = 1;
			}
			for (int i = 0; i < address.vz.Length; i++)
			{
				m.WriteFloat(address.X_z[i], X_p2 + 50f);
				m.WriteFloat(address.Y_z[i], Y_p2 + 50f);
				m.WriteFloat(address.Z_z[i], Z_p2);
			}
			if (num == 1)
			{
				checkBox43.Checked = true;
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			int num = 0;
			if (checkBox43.Checked)
			{
				checkBox43.Checked = false;
				num = 1;
			}
			for (int i = 0; i < address.vz.Length; i++)
			{
				m.WriteFloat(address.X_z[i], X_p3 + 50f);
				m.WriteFloat(address.Y_z[i], Y_p3 + 50f);
				m.WriteFloat(address.Z_z[i], Z_p3);
			}
			if (num == 1)
			{
				checkBox43.Checked = true;
			}
		}

		private void button43_Click(object sender, EventArgs e)
		{
			int num = 0;
			if (checkBox43.Checked)
			{
				checkBox43.Checked = false;
				num = 1;
			}
			for (int i = 0; i < address.vz.Length; i++)
			{
				m.WriteFloat(address.X_z[i], X_p4 + 50f);
				m.WriteFloat(address.Y_z[i], Y_p4 + 50f);
				m.WriteFloat(address.Z_z[i], Z_p4);
			}
			if (num == 1)
			{
				checkBox43.Checked = true;
			}
		}

		private void checkBox45_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox45.Checked)
			{
				m.WriteInt32(address.thirdperson, 1);
			}
			else
			{
				m.WriteInt32(address.thirdperson, 0);
			}
		}

		private void button44_Click_1(object sender, EventArgs e)
		{
			m.WriteByte(address.model, Convert.ToByte(model_p1.Text));
		}

		private void checkBox44_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox44.Checked)
			{
				m.WriteInt32(address.thirdperson_p2, 1);
			}
			else
			{
				m.WriteInt32(address.thirdperson_p2, 0);
			}
		}

		private void checkBox46_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox46.Checked)
			{
				m.WriteInt32(address.thirdperson_p3, 1);
			}
			else
			{
				m.WriteInt32(address.thirdperson_p3, 0);
			}
		}

		private void checkBox47_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox47.Checked)
			{
				m.WriteInt32(address.thirdperson_p4, 1);
			}
			else
			{
				m.WriteInt32(address.thirdperson_p4, 0);
			}
		}

		private void button45_Click(object sender, EventArgs e)
		{
			m.WriteByte(address.model_p2, Convert.ToByte(model_p2.Text));
		}

		private void button46_Click(object sender, EventArgs e)
		{
			m.WriteByte(address.model_p3, Convert.ToByte(model_p3.Text));
		}

		private void button47_Click(object sender, EventArgs e)
		{
			m.WriteByte(address.model_p4, Convert.ToByte(model_p4.Text));
		}

		private void checkBox48_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox48.Checked)
			{
				m.WriteXBytes(address.g_ai, new byte[4] { 5, 0, 48, 0 });
			}
			else
			{
				m.WriteXBytes(address.g_ai, new byte[4] { 154, 0, 140, 0 });
			}
		}

		private void checkBox49_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox49.Checked)
			{
				m.WriteXBytes(address.g_spawnai, new byte[4] { 5, 0, 48, 0 });
			}
			else
			{
				m.WriteXBytes(address.g_spawnai, new byte[4] { 154, 0, 140, 0 });
			}
		}

		private void button48_Click(object sender, EventArgs e)
		{
			string text = textBox1.Text;
			string text2 = textBox2.Text;
			if (text.Length > 7 && text2.Length > 7)
			{
				if (text2.Length > text.Length)
				{
					MessageBox.Show("The name length of the gobblegum that you want to replace is too short");
					return;
				}
				int num = 0;
				string text3 = string.Empty;
				for (int i = 0; i < text.Length; i++)
				{
					text3 += "x";
				}
				while (text2.Length < text.Length)
				{
					text2 += ".";
				}
				byte[] bytes = new ASCIIEncoding().GetBytes(text2);
				for (int j = 0; j < text2.Length; j++)
				{
					if (bytes[j] == 46)
					{
						bytes[j] = 0;
					}
				}
				long num2 = 2315255808L;
				while (num2 != -1)
				{
					num2 = m.FindPattern(num2, 2868903936L, text, text3);
					if (num2 != -1)
					{
						num = 1;
						m.WriteXBytes(num2, bytes);
					}
				}
				if (num == 0)
				{
					MessageBox.Show("Gobblegum not found");
					return;
				}
				label15.Text = "Gobblegum Replaced!";
				label15.ForeColor = Color.Green;
				replacer.Start();
			}
			else
			{
				MessageBox.Show("Insert minimum 8 characters");
			}
		}

		private void replacer_Tick(object sender, EventArgs e)
		{
			replacer.Stop();
			label15.Text = "Gobblegum Replacer";
			label15.ForeColor = Color.Black;
		}

		private void checkBox51_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox51.Checked)
			{
				m.WriteByte(address.norecoil, 117);
			}
			else
			{
				m.WriteByte(address.norecoil, 116);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.process = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.vita = new System.Windows.Forms.Timer(this.components);
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.ammo = new System.Windows.Forms.Timer(this.components);
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.rapid = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.curweap = new System.Windows.Forms.Timer(this.components);
            this.pos = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tval = new System.Windows.Forms.ComboBox();
            this.sval = new System.Windows.Forms.ComboBox();
            this.alvlval = new System.Windows.Forms.ComboBox();
            this.timescaleval = new System.Windows.Forms.NumericUpDown();
            this.button16 = new System.Windows.Forms.Button();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.zhval = new System.Windows.Forms.NumericUpDown();
            this.speedval = new System.Windows.Forms.NumericUpDown();
            this.gravityval = new System.Windows.Forms.NumericUpDown();
            this.weaponval = new System.Windows.Forms.NumericUpDown();
            this.jumpval = new System.Windows.Forms.NumericUpDown();
            this.moneyval = new System.Windows.Forms.NumericUpDown();
            this.button15 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button51 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.checkBox53 = new System.Windows.Forms.CheckBox();
            this.checkBox52 = new System.Windows.Forms.CheckBox();
            this.button49 = new System.Windows.Forms.Button();
            this.round_num = new System.Windows.Forms.NumericUpDown();
            this.button50 = new System.Windows.Forms.Button();
            this.checkBox50 = new System.Windows.Forms.CheckBox();
            this.checkBox51 = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button48 = new System.Windows.Forms.Button();
            this.checkBox49 = new System.Windows.Forms.CheckBox();
            this.checkBox48 = new System.Windows.Forms.CheckBox();
            this.model_p1 = new System.Windows.Forms.NumericUpDown();
            this.button44 = new System.Windows.Forms.Button();
            this.checkBox45 = new System.Windows.Forms.CheckBox();
            this.button43 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.checkBox43 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.button14 = new System.Windows.Forms.Button();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button36 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.numericZ = new System.Windows.Forms.NumericUpDown();
            this.numericY = new System.Windows.Forms.NumericUpDown();
            this.numericX = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.model_p2 = new System.Windows.Forms.NumericUpDown();
            this.button45 = new System.Windows.Forms.Button();
            this.checkBox44 = new System.Windows.Forms.CheckBox();
            this.button38 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.button20 = new System.Windows.Forms.Button();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.checkBox20 = new System.Windows.Forms.CheckBox();
            this.checkBox21 = new System.Windows.Forms.CheckBox();
            this.checkBox22 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.moneyval_p2 = new System.Windows.Forms.NumericUpDown();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.button19 = new System.Windows.Forms.Button();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.weaponval_p2 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.button18 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.model_p3 = new System.Windows.Forms.NumericUpDown();
            this.button46 = new System.Windows.Forms.Button();
            this.checkBox46 = new System.Windows.Forms.CheckBox();
            this.button40 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.checkBox23 = new System.Windows.Forms.CheckBox();
            this.button27 = new System.Windows.Forms.Button();
            this.checkBox24 = new System.Windows.Forms.CheckBox();
            this.checkBox25 = new System.Windows.Forms.CheckBox();
            this.checkBox26 = new System.Windows.Forms.CheckBox();
            this.checkBox27 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.moneyval_p3 = new System.Windows.Forms.NumericUpDown();
            this.checkBox28 = new System.Windows.Forms.CheckBox();
            this.button28 = new System.Windows.Forms.Button();
            this.checkBox29 = new System.Windows.Forms.CheckBox();
            this.checkBox30 = new System.Windows.Forms.CheckBox();
            this.checkBox31 = new System.Windows.Forms.CheckBox();
            this.checkBox32 = new System.Windows.Forms.CheckBox();
            this.weaponval_p3 = new System.Windows.Forms.NumericUpDown();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.button29 = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.model_p4 = new System.Windows.Forms.NumericUpDown();
            this.button47 = new System.Windows.Forms.Button();
            this.checkBox47 = new System.Windows.Forms.CheckBox();
            this.button42 = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.checkBox33 = new System.Windows.Forms.CheckBox();
            this.button32 = new System.Windows.Forms.Button();
            this.checkBox34 = new System.Windows.Forms.CheckBox();
            this.checkBox35 = new System.Windows.Forms.CheckBox();
            this.checkBox36 = new System.Windows.Forms.CheckBox();
            this.checkBox37 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.moneyval_p4 = new System.Windows.Forms.NumericUpDown();
            this.checkBox38 = new System.Windows.Forms.CheckBox();
            this.button33 = new System.Windows.Forms.Button();
            this.checkBox39 = new System.Windows.Forms.CheckBox();
            this.checkBox40 = new System.Windows.Forms.CheckBox();
            this.checkBox41 = new System.Windows.Forms.CheckBox();
            this.checkBox42 = new System.Windows.Forms.CheckBox();
            this.weaponval_p4 = new System.Windows.Forms.NumericUpDown();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.button34 = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.money = new System.Windows.Forms.Timer(this.components);
            this.zhealth = new System.Windows.Forms.Timer(this.components);
            this.vita_p2 = new System.Windows.Forms.Timer(this.components);
            this.ammo_p2 = new System.Windows.Forms.Timer(this.components);
            this.rapid_p2 = new System.Windows.Forms.Timer(this.components);
            this.money_p2 = new System.Windows.Forms.Timer(this.components);
            this.vita_p3 = new System.Windows.Forms.Timer(this.components);
            this.ammo_p3 = new System.Windows.Forms.Timer(this.components);
            this.rapid_p3 = new System.Windows.Forms.Timer(this.components);
            this.money_p3 = new System.Windows.Forms.Timer(this.components);
            this.vita_p4 = new System.Windows.Forms.Timer(this.components);
            this.ammo_p4 = new System.Windows.Forms.Timer(this.components);
            this.rapid_p4 = new System.Windows.Forms.Timer(this.components);
            this.money_p4 = new System.Windows.Forms.Timer(this.components);
            this.freeze_z = new System.Windows.Forms.Timer(this.components);
            this.replacer = new System.Windows.Forms.Timer(this.components);
            this.setaddress = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timescaleval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zhval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gravityval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jumpval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyval)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.round_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_p1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericX)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.model_p2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyval_p2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponval_p2)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.model_p3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyval_p3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponval_p3)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.model_p4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyval_p4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponval_p4)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "金钱";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // process
            // 
            this.process.Enabled = true;
            this.process.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(276, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "未找到进程";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "无敌";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // vita
            // 
            this.vita.Tick += new System.EventHandler(this.vita_Tick);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(120, 28);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "无限子弹";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // ammo
            // 
            this.ammo.Tick += new System.EventHandler(this.ammo_Tick);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(244, 28);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(72, 16);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "快速射击";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // rapid
            // 
            this.rapid.Interval = 10;
            this.rapid.Tick += new System.EventHandler(this.rapid_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 21);
            this.button2.TabIndex = 7;
            this.button2.Text = "超级跳跃";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 162);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 21);
            this.button3.TabIndex = 8;
            this.button3.Text = "给予武器";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 205);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 16);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "武器1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(73, 205);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 16);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.Text = "武器2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(139, 205);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(53, 16);
            this.radioButton3.TabIndex = 12;
            this.radioButton3.Text = "武器3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "当前武器ID: ";
            // 
            // curweap
            // 
            this.curweap.Interval = 200;
            this.curweap.Tick += new System.EventHandler(this.curweap_Tick);
            // 
            // pos
            // 
            this.pos.Interval = 50;
            this.pos.Tick += new System.EventHandler(this.pos_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(662, 341);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button10);
            this.tabPage1.Controls.Add(this.tval);
            this.tabPage1.Controls.Add(this.sval);
            this.tabPage1.Controls.Add(this.alvlval);
            this.tabPage1.Controls.Add(this.timescaleval);
            this.tabPage1.Controls.Add(this.button16);
            this.tabPage1.Controls.Add(this.checkBox11);
            this.tabPage1.Controls.Add(this.zhval);
            this.tabPage1.Controls.Add(this.speedval);
            this.tabPage1.Controls.Add(this.gravityval);
            this.tabPage1.Controls.Add(this.weaponval);
            this.tabPage1.Controls.Add(this.jumpval);
            this.tabPage1.Controls.Add(this.moneyval);
            this.tabPage1.Controls.Add(this.button15);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.checkBox6);
            this.tabPage1.Controls.Add(this.button12);
            this.tabPage1.Controls.Add(this.button11);
            this.tabPage1.Controls.Add(this.checkBox4);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.radioButton3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.radioButton2);
            this.tabPage1.Controls.Add(this.radioButton1);
            this.tabPage1.Controls.Add(this.checkBox2);
            this.tabPage1.Controls.Add(this.checkBox3);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(654, 315);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "-";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tval
            // 
            this.tval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tval.FormattingEnabled = true;
            this.tval.Items.AddRange(new object[] {
            "0.1",
            "0.5",
            "1",
            "1.5",
            "2",
            "3",
            "5",
            "10"});
            this.tval.Location = new System.Drawing.Point(350, 118);
            this.tval.Name = "tval";
            this.tval.Size = new System.Drawing.Size(81, 20);
            this.tval.TabIndex = 41;
            // 
            // sval
            // 
            this.sval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sval.FormattingEnabled = true;
            this.sval.Items.AddRange(new object[] {
            "50",
            "190",
            "500"});
            this.sval.Location = new System.Drawing.Point(350, 72);
            this.sval.Name = "sval";
            this.sval.Size = new System.Drawing.Size(81, 20);
            this.sval.TabIndex = 40;
            // 
            // alvlval
            // 
            this.alvlval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alvlval.FormattingEnabled = true;
            this.alvlval.Items.AddRange(new object[] {
            "Default",
            "100",
            "200",
            "250",
            "300",
            "350",
            "400",
            "450",
            "500",
            "550",
            "600",
            "700",
            "800"});
            this.alvlval.Location = new System.Drawing.Point(258, 260);
            this.alvlval.Name = "alvlval";
            this.alvlval.Size = new System.Drawing.Size(81, 20);
            this.alvlval.TabIndex = 39;
            this.alvlval.SelectedIndexChanged += new System.EventHandler(this.alvlval_SelectedIndexChanged);
            // 
            // timescaleval
            // 
            this.timescaleval.DecimalPlaces = 1;
            this.timescaleval.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.timescaleval.Location = new System.Drawing.Point(444, 272);
            this.timescaleval.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.timescaleval.Name = "timescaleval";
            this.timescaleval.Size = new System.Drawing.Size(99, 21);
            this.timescaleval.TabIndex = 38;
            this.timescaleval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(258, 118);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 21);
            this.button16.TabIndex = 37;
            this.button16.Text = "游戏速度";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(444, 168);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(15, 14);
            this.checkBox11.TabIndex = 36;
            this.checkBox11.UseVisualStyleBackColor = true;
            this.checkBox11.CheckedChanged += new System.EventHandler(this.checkBox11_CheckedChanged);
            // 
            // zhval
            // 
            this.zhval.Location = new System.Drawing.Point(366, 166);
            this.zhval.Name = "zhval";
            this.zhval.Size = new System.Drawing.Size(65, 21);
            this.zhval.TabIndex = 35;
            this.zhval.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // speedval
            // 
            this.speedval.Location = new System.Drawing.Point(549, 288);
            this.speedval.Maximum = new decimal(new int[] {
            190,
            0,
            0,
            0});
            this.speedval.Name = "speedval";
            this.speedval.Size = new System.Drawing.Size(99, 21);
            this.speedval.TabIndex = 34;
            this.speedval.Value = new decimal(new int[] {
            190,
            0,
            0,
            0});
            // 
            // gravityval
            // 
            this.gravityval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.gravityval.Location = new System.Drawing.Point(549, 261);
            this.gravityval.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.gravityval.Name = "gravityval";
            this.gravityval.Size = new System.Drawing.Size(99, 21);
            this.gravityval.TabIndex = 33;
            this.gravityval.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // weaponval
            // 
            this.weaponval.Location = new System.Drawing.Point(99, 164);
            this.weaponval.Name = "weaponval";
            this.weaponval.Size = new System.Drawing.Size(99, 21);
            this.weaponval.TabIndex = 32;
            // 
            // jumpval
            // 
            this.jumpval.DecimalPlaces = 3;
            this.jumpval.Location = new System.Drawing.Point(99, 118);
            this.jumpval.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.jumpval.Name = "jumpval";
            this.jumpval.Size = new System.Drawing.Size(99, 21);
            this.jumpval.TabIndex = 31;
            this.jumpval.Value = new decimal(new int[] {
            39,
            0,
            0,
            0});
            // 
            // moneyval
            // 
            this.moneyval.Location = new System.Drawing.Point(99, 73);
            this.moneyval.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.moneyval.Name = "moneyval";
            this.moneyval.Size = new System.Drawing.Size(99, 21);
            this.moneyval.TabIndex = 30;
            this.moneyval.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(258, 164);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(91, 21);
            this.button15.TabIndex = 28;
            this.button15.Text = "僵尸血量";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "僵尸: 0";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(208, 78);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 15;
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(5, 282);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(49, 21);
            this.button12.TabIndex = 20;
            this.button12.Text = "关于";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(258, 71);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 21);
            this.button11.TabIndex = 18;
            this.button11.Text = "速度";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(148, 259);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(104, 21);
            this.button10.TabIndex = 16;
            this.button10.Text = "Any Lvl = Ground";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(350, 28);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(48, 16);
            this.checkBox4.TabIndex = 15;
            this.checkBox4.Text = "无视";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.comboBox3);
            this.tabPage3.Controls.Add(this.button51);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.checkBox53);
            this.tabPage3.Controls.Add(this.checkBox52);
            this.tabPage3.Controls.Add(this.button49);
            this.tabPage3.Controls.Add(this.round_num);
            this.tabPage3.Controls.Add(this.button50);
            this.tabPage3.Controls.Add(this.checkBox50);
            this.tabPage3.Controls.Add(this.checkBox51);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.button48);
            this.tabPage3.Controls.Add(this.checkBox49);
            this.tabPage3.Controls.Add(this.checkBox48);
            this.tabPage3.Controls.Add(this.model_p1);
            this.tabPage3.Controls.Add(this.button44);
            this.tabPage3.Controls.Add(this.checkBox45);
            this.tabPage3.Controls.Add(this.button43);
            this.tabPage3.Controls.Add(this.button9);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Controls.Add(this.checkBox43);
            this.tabPage3.Controls.Add(this.checkBox12);
            this.tabPage3.Controls.Add(this.button14);
            this.tabPage3.Controls.Add(this.checkBox10);
            this.tabPage3.Controls.Add(this.checkBox9);
            this.tabPage3.Controls.Add(this.checkBox8);
            this.tabPage3.Controls.Add(this.checkBox7);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(654, 315);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "-";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "恶灵之影",
            "巨人工厂",
            "钢铁之龙",
            "绝望之岛",
            "血狱之城",
            "启示录"});
            this.comboBox3.Location = new System.Drawing.Point(534, 221);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(104, 20);
            this.comboBox3.TabIndex = 61;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // button51
            // 
            this.button51.Location = new System.Drawing.Point(469, 220);
            this.button51.Name = "button51";
            this.button51.Size = new System.Drawing.Size(42, 21);
            this.button51.TabIndex = 60;
            this.button51.Text = "地图";
            this.button51.UseVisualStyleBackColor = true;
            this.button51.Click += new System.EventHandler(this.button51_Click_1);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(428, 183);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 58;
            this.label16.Text = "更改地图";
            // 
            // checkBox53
            // 
            this.checkBox53.AutoSize = true;
            this.checkBox53.Location = new System.Drawing.Point(390, 74);
            this.checkBox53.Name = "checkBox53";
            this.checkBox53.Size = new System.Drawing.Size(78, 16);
            this.checkBox53.TabIndex = 57;
            this.checkBox53.Text = "sv_******";
            this.checkBox53.UseVisualStyleBackColor = true;
            this.checkBox53.CheckedChanged += new System.EventHandler(this.checkBox53_CheckedChanged);
            // 
            // checkBox52
            // 
            this.checkBox52.AutoSize = true;
            this.checkBox52.Location = new System.Drawing.Point(150, 291);
            this.checkBox52.Name = "checkBox52";
            this.checkBox52.Size = new System.Drawing.Size(84, 16);
            this.checkBox52.TabIndex = 56;
            this.checkBox52.Text = "开发者模式";
            this.checkBox52.UseVisualStyleBackColor = true;
            this.checkBox52.CheckedChanged += new System.EventHandler(this.checkBox52_CheckedChanged);
            // 
            // button49
            // 
            this.button49.Location = new System.Drawing.Point(270, 220);
            this.button49.Name = "button49";
            this.button49.Size = new System.Drawing.Size(99, 21);
            this.button49.TabIndex = 54;
            this.button49.Text = "控制台";
            this.button49.UseVisualStyleBackColor = true;
            this.button49.Click += new System.EventHandler(this.button49_Click);
            // 
            // round_num
            // 
            this.round_num.Enabled = false;
            this.round_num.Location = new System.Drawing.Point(85, 218);
            this.round_num.Name = "round_num";
            this.round_num.Size = new System.Drawing.Size(51, 21);
            this.round_num.TabIndex = 53;
            this.round_num.Visible = false;
            // 
            // button50
            // 
            this.button50.Enabled = false;
            this.button50.Location = new System.Drawing.Point(379, 220);
            this.button50.Name = "button50";
            this.button50.Size = new System.Drawing.Size(89, 21);
            this.button50.TabIndex = 52;
            this.button50.Text = "更换";
            this.button50.UseVisualStyleBackColor = true;
            this.button50.Click += new System.EventHandler(this.button50_Click);
            // 
            // checkBox50
            // 
            this.checkBox50.AutoSize = true;
            this.checkBox50.Location = new System.Drawing.Point(150, 259);
            this.checkBox50.Name = "checkBox50";
            this.checkBox50.Size = new System.Drawing.Size(84, 16);
            this.checkBox50.TabIndex = 51;
            this.checkBox50.Text = "无僵尸伤害";
            this.checkBox50.UseVisualStyleBackColor = true;
            this.checkBox50.CheckedChanged += new System.EventHandler(this.checkBox50_CheckedChanged);
            // 
            // checkBox51
            // 
            this.checkBox51.AutoSize = true;
            this.checkBox51.Location = new System.Drawing.Point(245, 108);
            this.checkBox51.Name = "checkBox51";
            this.checkBox51.Size = new System.Drawing.Size(60, 16);
            this.checkBox51.TabIndex = 50;
            this.checkBox51.Text = "无后座";
            this.checkBox51.UseVisualStyleBackColor = true;
            this.checkBox51.CheckedChanged += new System.EventHandler(this.checkBox51_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Enabled = false;
            this.label15.Location = new System.Drawing.Point(479, 260);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 49;
            this.label15.Text = "泡泡糖更改";
            this.label15.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(555, 276);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(83, 21);
            this.textBox2.TabIndex = 48;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(430, 275);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(81, 21);
            this.textBox1.TabIndex = 47;
            // 
            // button48
            // 
            this.button48.Enabled = false;
            this.button48.Location = new System.Drawing.Point(517, 275);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(32, 21);
            this.button48.TabIndex = 46;
            this.button48.Text = "-->";
            this.button48.UseVisualStyleBackColor = true;
            this.button48.Click += new System.EventHandler(this.button48_Click);
            // 
            // checkBox49
            // 
            this.checkBox49.AutoSize = true;
            this.checkBox49.Location = new System.Drawing.Point(245, 74);
            this.checkBox49.Name = "checkBox49";
            this.checkBox49.Size = new System.Drawing.Size(96, 16);
            this.checkBox49.TabIndex = 45;
            this.checkBox49.Text = "禁止生成僵尸";
            this.checkBox49.UseVisualStyleBackColor = true;
            this.checkBox49.CheckedChanged += new System.EventHandler(this.checkBox49_CheckedChanged);
            // 
            // checkBox48
            // 
            this.checkBox48.AutoSize = true;
            this.checkBox48.Location = new System.Drawing.Point(390, 37);
            this.checkBox48.Name = "checkBox48";
            this.checkBox48.Size = new System.Drawing.Size(84, 16);
            this.checkBox48.TabIndex = 44;
            this.checkBox48.Text = "关闭僵尸AI";
            this.checkBox48.UseVisualStyleBackColor = true;
            this.checkBox48.CheckedChanged += new System.EventHandler(this.checkBox48_CheckedChanged);
            // 
            // model_p1
            // 
            this.model_p1.Location = new System.Drawing.Point(372, 181);
            this.model_p1.Name = "model_p1";
            this.model_p1.Size = new System.Drawing.Size(45, 21);
            this.model_p1.TabIndex = 43;
            // 
            // button44
            // 
            this.button44.Location = new System.Drawing.Point(270, 181);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(89, 21);
            this.button44.TabIndex = 42;
            this.button44.Text = "更改模型";
            this.button44.UseVisualStyleBackColor = true;
            this.button44.Click += new System.EventHandler(this.button44_Click_1);
            // 
            // checkBox45
            // 
            this.checkBox45.AutoSize = true;
            this.checkBox45.Location = new System.Drawing.Point(390, 10);
            this.checkBox45.Name = "checkBox45";
            this.checkBox45.Size = new System.Drawing.Size(72, 16);
            this.checkBox45.TabIndex = 41;
            this.checkBox45.Text = "第三人称";
            this.checkBox45.UseVisualStyleBackColor = true;
            this.checkBox45.CheckedChanged += new System.EventHandler(this.checkBox45_CheckedChanged);
            // 
            // button43
            // 
            this.button43.Location = new System.Drawing.Point(63, 288);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(48, 21);
            this.button43.TabIndex = 39;
            this.button43.Text = "玩家4";
            this.button43.UseVisualStyleBackColor = true;
            this.button43.Click += new System.EventHandler(this.button43_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(3, 288);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(54, 21);
            this.button9.TabIndex = 38;
            this.button9.Text = "玩家3";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(63, 256);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(48, 21);
            this.button8.TabIndex = 37;
            this.button8.Text = "玩家2";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 220);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 12);
            this.label14.TabIndex = 36;
            this.label14.Text = "僵尸传送到:";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(3, 256);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(54, 21);
            this.button7.TabIndex = 35;
            this.button7.Text = "玩家1";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // checkBox43
            // 
            this.checkBox43.AutoSize = true;
            this.checkBox43.Location = new System.Drawing.Point(245, 37);
            this.checkBox43.Name = "checkBox43";
            this.checkBox43.Size = new System.Drawing.Size(72, 16);
            this.checkBox43.TabIndex = 34;
            this.checkBox43.Text = "冻结僵尸";
            this.checkBox43.UseVisualStyleBackColor = true;
            this.checkBox43.CheckedChanged += new System.EventHandler(this.checkBox43_CheckedChanged);
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(245, 10);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(72, 16);
            this.checkBox12.TabIndex = 33;
            this.checkBox12.Text = "冻结玩家";
            this.checkBox12.UseVisualStyleBackColor = true;
            this.checkBox12.CheckedChanged += new System.EventHandler(this.checkBox12_CheckedChanged);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(40, 128);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 21);
            this.button14.TabIndex = 32;
            this.button14.Text = "重置饮料";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(103, 85);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(48, 16);
            this.checkBox10.TabIndex = 31;
            this.checkBox10.Text = "厚血";
            this.checkBox10.UseVisualStyleBackColor = true;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.checkBox10_CheckedChanged);
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(10, 85);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(48, 16);
            this.checkBox9.TabIndex = 30;
            this.checkBox9.Text = "快跑";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(103, 46);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(72, 16);
            this.checkBox8.TabIndex = 29;
            this.checkBox8.Text = "子弹分裂";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(8, 46);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(48, 16);
            this.checkBox7.TabIndex = 28;
            this.checkBox7.Text = "三枪";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(74, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "饮料:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.button36);
            this.tabPage2.Controls.Add(this.button35);
            this.tabPage2.Controls.Add(this.button22);
            this.tabPage2.Controls.Add(this.button21);
            this.tabPage2.Controls.Add(this.button17);
            this.tabPage2.Controls.Add(this.button13);
            this.tabPage2.Controls.Add(this.numericZ);
            this.tabPage2.Controls.Add(this.numericY);
            this.tabPage2.Controls.Add(this.numericX);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.checkBox5);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(654, 315);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "-";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(502, 261);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(108, 20);
            this.comboBox2.TabIndex = 23;
            this.comboBox2.DropDown += new System.EventHandler(this.comboBox2_DropDown);
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Pos 1",
            "Pos 2",
            "Pos 3",
            "Pos 4",
            "Pos 5",
            "Pos 6",
            "Pos 7",
            "Pos 8",
            "Pos 9",
            "Pos 10"});
            this.comboBox1.Location = new System.Drawing.Point(201, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(94, 20);
            this.comboBox1.TabIndex = 21;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button36
            // 
            this.button36.Location = new System.Drawing.Point(237, 142);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(99, 21);
            this.button36.TabIndex = 20;
            this.button36.Text = "传送到玩家3";
            this.button36.UseVisualStyleBackColor = true;
            this.button36.Click += new System.EventHandler(this.button36_Click);
            // 
            // button35
            // 
            this.button35.Location = new System.Drawing.Point(133, 201);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(88, 21);
            this.button35.TabIndex = 19;
            this.button35.Text = "传送到玩家4";
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.button35_Click);
            // 
            // button22
            // 
            this.button22.Enabled = false;
            this.button22.Location = new System.Drawing.Point(237, 201);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(99, 21);
            this.button22.TabIndex = 18;
            this.button22.Text = "取消";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(133, 142);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(88, 21);
            this.button21.TabIndex = 17;
            this.button21.Text = "传送到玩家2";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button17
            // 
            this.button17.Enabled = false;
            this.button17.Location = new System.Drawing.Point(530, 234);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(55, 21);
            this.button17.TabIndex = 16;
            this.button17.Text = "取消";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(530, 196);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(55, 21);
            this.button13.TabIndex = 15;
            this.button13.Text = "传送";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // numericZ
            // 
            this.numericZ.DecimalPlaces = 3;
            this.numericZ.Location = new System.Drawing.Point(530, 168);
            this.numericZ.Name = "numericZ";
            this.numericZ.Size = new System.Drawing.Size(55, 21);
            this.numericZ.TabIndex = 14;
            // 
            // numericY
            // 
            this.numericY.DecimalPlaces = 3;
            this.numericY.Location = new System.Drawing.Point(555, 141);
            this.numericY.Name = "numericY";
            this.numericY.Size = new System.Drawing.Size(55, 21);
            this.numericY.TabIndex = 13;
            // 
            // numericX
            // 
            this.numericX.DecimalPlaces = 3;
            this.numericX.Location = new System.Drawing.Point(494, 141);
            this.numericX.Name = "numericX";
            this.numericX.Size = new System.Drawing.Size(55, 21);
            this.numericX.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(245, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "数字8, 数字2, 数字4, 数字6 = 更改X/Y坐标";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "使用数字键移动玩家 (数字9 = 上, 数字3 = 下)";
            this.label6.Visible = false;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(10, 234);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(60, 16);
            this.checkBox5.TabIndex = 9;
            this.checkBox5.Text = "无剪辑";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Z轴: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y轴: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "X轴: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(309, 91);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 21);
            this.button6.TabIndex = 2;
            this.button6.Text = "取消传送";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(201, 91);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 21);
            this.button5.TabIndex = 1;
            this.button5.Text = "加载位置";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(102, 91);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 21);
            this.button4.TabIndex = 0;
            this.button4.Text = "保存位置";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.model_p2);
            this.tabPage4.Controls.Add(this.button45);
            this.tabPage4.Controls.Add(this.checkBox44);
            this.tabPage4.Controls.Add(this.button38);
            this.tabPage4.Controls.Add(this.button37);
            this.tabPage4.Controls.Add(this.button23);
            this.tabPage4.Controls.Add(this.button24);
            this.tabPage4.Controls.Add(this.checkBox18);
            this.tabPage4.Controls.Add(this.button20);
            this.tabPage4.Controls.Add(this.checkBox19);
            this.tabPage4.Controls.Add(this.checkBox20);
            this.tabPage4.Controls.Add(this.checkBox21);
            this.tabPage4.Controls.Add(this.checkBox22);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.moneyval_p2);
            this.tabPage4.Controls.Add(this.checkBox17);
            this.tabPage4.Controls.Add(this.button19);
            this.tabPage4.Controls.Add(this.checkBox13);
            this.tabPage4.Controls.Add(this.checkBox14);
            this.tabPage4.Controls.Add(this.checkBox15);
            this.tabPage4.Controls.Add(this.checkBox16);
            this.tabPage4.Controls.Add(this.weaponval_p2);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.radioButton4);
            this.tabPage4.Controls.Add(this.radioButton5);
            this.tabPage4.Controls.Add(this.radioButton6);
            this.tabPage4.Controls.Add(this.button18);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(654, 315);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "-";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // model_p2
            // 
            this.model_p2.Location = new System.Drawing.Point(115, 242);
            this.model_p2.Name = "model_p2";
            this.model_p2.Size = new System.Drawing.Size(65, 21);
            this.model_p2.TabIndex = 59;
            // 
            // button45
            // 
            this.button45.Location = new System.Drawing.Point(8, 240);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(89, 21);
            this.button45.TabIndex = 58;
            this.button45.Text = "更改模型";
            this.button45.UseVisualStyleBackColor = true;
            this.button45.Click += new System.EventHandler(this.button45_Click);
            // 
            // checkBox44
            // 
            this.checkBox44.AutoSize = true;
            this.checkBox44.Location = new System.Drawing.Point(151, 58);
            this.checkBox44.Name = "checkBox44";
            this.checkBox44.Size = new System.Drawing.Size(72, 16);
            this.checkBox44.TabIndex = 57;
            this.checkBox44.Text = "第三人称";
            this.checkBox44.UseVisualStyleBackColor = true;
            this.checkBox44.CheckedChanged += new System.EventHandler(this.checkBox44_CheckedChanged);
            // 
            // button38
            // 
            this.button38.Location = new System.Drawing.Point(222, 288);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(88, 21);
            this.button38.TabIndex = 56;
            this.button38.Text = "传送到玩家4";
            this.button38.UseVisualStyleBackColor = true;
            this.button38.Click += new System.EventHandler(this.button38_Click);
            // 
            // button37
            // 
            this.button37.Location = new System.Drawing.Point(115, 288);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(88, 21);
            this.button37.TabIndex = 55;
            this.button37.Text = "传送到玩家3";
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // button23
            // 
            this.button23.Enabled = false;
            this.button23.Location = new System.Drawing.Point(344, 288);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(99, 21);
            this.button23.TabIndex = 54;
            this.button23.Text = "取消";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(8, 288);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(88, 21);
            this.button24.TabIndex = 53;
            this.button24.Text = "传送到玩家1";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // checkBox18
            // 
            this.checkBox18.AutoSize = true;
            this.checkBox18.Location = new System.Drawing.Point(9, 58);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(72, 16);
            this.checkBox18.TabIndex = 52;
            this.checkBox18.Text = "冻结玩家";
            this.checkBox18.UseVisualStyleBackColor = true;
            this.checkBox18.CheckedChanged += new System.EventHandler(this.checkBox18_CheckedChanged);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(440, 195);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(75, 21);
            this.button20.TabIndex = 51;
            this.button20.Text = "重置汽水";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // checkBox19
            // 
            this.checkBox19.AutoSize = true;
            this.checkBox19.Location = new System.Drawing.Point(513, 168);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(48, 16);
            this.checkBox19.TabIndex = 50;
            this.checkBox19.Text = "厚血";
            this.checkBox19.UseVisualStyleBackColor = true;
            this.checkBox19.CheckedChanged += new System.EventHandler(this.checkBox19_CheckedChanged);
            // 
            // checkBox20
            // 
            this.checkBox20.AutoSize = true;
            this.checkBox20.Location = new System.Drawing.Point(359, 168);
            this.checkBox20.Name = "checkBox20";
            this.checkBox20.Size = new System.Drawing.Size(48, 16);
            this.checkBox20.TabIndex = 49;
            this.checkBox20.Text = "快跑";
            this.checkBox20.UseVisualStyleBackColor = true;
            this.checkBox20.CheckedChanged += new System.EventHandler(this.checkBox20_CheckedChanged);
            // 
            // checkBox21
            // 
            this.checkBox21.AutoSize = true;
            this.checkBox21.Location = new System.Drawing.Point(513, 105);
            this.checkBox21.Name = "checkBox21";
            this.checkBox21.Size = new System.Drawing.Size(72, 16);
            this.checkBox21.TabIndex = 48;
            this.checkBox21.Text = "子弹分裂";
            this.checkBox21.UseVisualStyleBackColor = true;
            this.checkBox21.CheckedChanged += new System.EventHandler(this.checkBox21_CheckedChanged);
            // 
            // checkBox22
            // 
            this.checkBox22.AutoSize = true;
            this.checkBox22.Location = new System.Drawing.Point(359, 105);
            this.checkBox22.Name = "checkBox22";
            this.checkBox22.Size = new System.Drawing.Size(48, 16);
            this.checkBox22.TabIndex = 47;
            this.checkBox22.Text = "三枪";
            this.checkBox22.UseVisualStyleBackColor = true;
            this.checkBox22.CheckedChanged += new System.EventHandler(this.checkBox22_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(455, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 46;
            this.label11.Text = "汽水:";
            // 
            // moneyval_p2
            // 
            this.moneyval_p2.Location = new System.Drawing.Point(124, 100);
            this.moneyval_p2.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.moneyval_p2.Name = "moneyval_p2";
            this.moneyval_p2.Size = new System.Drawing.Size(99, 21);
            this.moneyval_p2.TabIndex = 45;
            this.moneyval_p2.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // checkBox17
            // 
            this.checkBox17.AutoSize = true;
            this.checkBox17.Location = new System.Drawing.Point(244, 102);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(15, 14);
            this.checkBox17.TabIndex = 44;
            this.checkBox17.UseVisualStyleBackColor = true;
            this.checkBox17.CheckedChanged += new System.EventHandler(this.checkBox17_CheckedChanged);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(8, 100);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(87, 21);
            this.button19.TabIndex = 43;
            this.button19.Text = "金钱";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(457, 6);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(48, 16);
            this.checkBox13.TabIndex = 42;
            this.checkBox13.Text = "无视";
            this.checkBox13.UseVisualStyleBackColor = true;
            this.checkBox13.CheckedChanged += new System.EventHandler(this.checkBox13_CheckedChanged);
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(6, 6);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(48, 16);
            this.checkBox14.TabIndex = 39;
            this.checkBox14.Text = "无敌";
            this.checkBox14.UseVisualStyleBackColor = true;
            this.checkBox14.CheckedChanged += new System.EventHandler(this.checkBox14_CheckedChanged);
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(151, 6);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(72, 16);
            this.checkBox15.TabIndex = 40;
            this.checkBox15.Text = "无限子弹";
            this.checkBox15.UseVisualStyleBackColor = true;
            this.checkBox15.CheckedChanged += new System.EventHandler(this.checkBox15_CheckedChanged);
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(304, 6);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(72, 16);
            this.checkBox16.TabIndex = 41;
            this.checkBox16.Text = "快速射击";
            this.checkBox16.UseVisualStyleBackColor = true;
            this.checkBox16.CheckedChanged += new System.EventHandler(this.checkBox16_CheckedChanged);
            // 
            // weaponval_p2
            // 
            this.weaponval_p2.Location = new System.Drawing.Point(112, 168);
            this.weaponval_p2.Name = "weaponval_p2";
            this.weaponval_p2.Size = new System.Drawing.Size(99, 21);
            this.weaponval_p2.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(230, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 37;
            this.label10.Text = "武器ID: ";
            this.label10.Visible = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(200, 195);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(53, 16);
            this.radioButton4.TabIndex = 36;
            this.radioButton4.Text = "武器3";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(115, 195);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(53, 16);
            this.radioButton5.TabIndex = 35;
            this.radioButton5.Text = "武器2";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.Location = new System.Drawing.Point(34, 195);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(53, 16);
            this.radioButton6.TabIndex = 34;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "武器1";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(9, 168);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(87, 21);
            this.button18.TabIndex = 33;
            this.button18.Text = "给予武器";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.model_p3);
            this.tabPage5.Controls.Add(this.button46);
            this.tabPage5.Controls.Add(this.checkBox46);
            this.tabPage5.Controls.Add(this.button40);
            this.tabPage5.Controls.Add(this.button39);
            this.tabPage5.Controls.Add(this.button25);
            this.tabPage5.Controls.Add(this.button26);
            this.tabPage5.Controls.Add(this.checkBox23);
            this.tabPage5.Controls.Add(this.button27);
            this.tabPage5.Controls.Add(this.checkBox24);
            this.tabPage5.Controls.Add(this.checkBox25);
            this.tabPage5.Controls.Add(this.checkBox26);
            this.tabPage5.Controls.Add(this.checkBox27);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.moneyval_p3);
            this.tabPage5.Controls.Add(this.checkBox28);
            this.tabPage5.Controls.Add(this.button28);
            this.tabPage5.Controls.Add(this.checkBox29);
            this.tabPage5.Controls.Add(this.checkBox30);
            this.tabPage5.Controls.Add(this.checkBox31);
            this.tabPage5.Controls.Add(this.checkBox32);
            this.tabPage5.Controls.Add(this.weaponval_p3);
            this.tabPage5.Controls.Add(this.radioButton7);
            this.tabPage5.Controls.Add(this.radioButton8);
            this.tabPage5.Controls.Add(this.radioButton9);
            this.tabPage5.Controls.Add(this.button29);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(654, 315);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "-";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Click += new System.EventHandler(this.tabPage5_Click);
            // 
            // model_p3
            // 
            this.model_p3.Location = new System.Drawing.Point(115, 240);
            this.model_p3.Name = "model_p3";
            this.model_p3.Size = new System.Drawing.Size(65, 21);
            this.model_p3.TabIndex = 81;
            // 
            // button46
            // 
            this.button46.Location = new System.Drawing.Point(7, 240);
            this.button46.Name = "button46";
            this.button46.Size = new System.Drawing.Size(89, 21);
            this.button46.TabIndex = 80;
            this.button46.Text = "更改模型";
            this.button46.UseVisualStyleBackColor = true;
            this.button46.Click += new System.EventHandler(this.button46_Click);
            // 
            // checkBox46
            // 
            this.checkBox46.AutoSize = true;
            this.checkBox46.Location = new System.Drawing.Point(173, 57);
            this.checkBox46.Name = "checkBox46";
            this.checkBox46.Size = new System.Drawing.Size(72, 16);
            this.checkBox46.TabIndex = 79;
            this.checkBox46.Text = "第三人称";
            this.checkBox46.UseVisualStyleBackColor = true;
            this.checkBox46.CheckedChanged += new System.EventHandler(this.checkBox46_CheckedChanged);
            // 
            // button40
            // 
            this.button40.Location = new System.Drawing.Point(222, 289);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(88, 21);
            this.button40.TabIndex = 78;
            this.button40.Text = "传送到玩家4";
            this.button40.UseVisualStyleBackColor = true;
            this.button40.Click += new System.EventHandler(this.button40_Click);
            // 
            // button39
            // 
            this.button39.Location = new System.Drawing.Point(115, 289);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(88, 21);
            this.button39.TabIndex = 77;
            this.button39.Text = "传送到玩家2";
            this.button39.UseVisualStyleBackColor = true;
            this.button39.Click += new System.EventHandler(this.button39_Click);
            // 
            // button25
            // 
            this.button25.Enabled = false;
            this.button25.Location = new System.Drawing.Point(325, 289);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(99, 21);
            this.button25.TabIndex = 76;
            this.button25.Text = "取消";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // button26
            // 
            this.button26.Location = new System.Drawing.Point(8, 289);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(88, 21);
            this.button26.TabIndex = 75;
            this.button26.Text = "传送到玩家1";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // checkBox23
            // 
            this.checkBox23.AutoSize = true;
            this.checkBox23.Location = new System.Drawing.Point(6, 57);
            this.checkBox23.Name = "checkBox23";
            this.checkBox23.Size = new System.Drawing.Size(72, 16);
            this.checkBox23.TabIndex = 74;
            this.checkBox23.Text = "冻结玩家";
            this.checkBox23.UseVisualStyleBackColor = true;
            this.checkBox23.CheckedChanged += new System.EventHandler(this.checkBox23_CheckedChanged);
            // 
            // button27
            // 
            this.button27.Location = new System.Drawing.Point(473, 249);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(75, 21);
            this.button27.TabIndex = 73;
            this.button27.Text = "重置汽水";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // checkBox24
            // 
            this.checkBox24.AutoSize = true;
            this.checkBox24.Location = new System.Drawing.Point(520, 227);
            this.checkBox24.Name = "checkBox24";
            this.checkBox24.Size = new System.Drawing.Size(48, 16);
            this.checkBox24.TabIndex = 72;
            this.checkBox24.Text = "厚血";
            this.checkBox24.UseVisualStyleBackColor = true;
            this.checkBox24.CheckedChanged += new System.EventHandler(this.checkBox24_CheckedChanged);
            // 
            // checkBox25
            // 
            this.checkBox25.AutoSize = true;
            this.checkBox25.Location = new System.Drawing.Point(402, 227);
            this.checkBox25.Name = "checkBox25";
            this.checkBox25.Size = new System.Drawing.Size(48, 16);
            this.checkBox25.TabIndex = 71;
            this.checkBox25.Text = "快跑";
            this.checkBox25.UseVisualStyleBackColor = true;
            this.checkBox25.CheckedChanged += new System.EventHandler(this.checkBox25_CheckedChanged);
            // 
            // checkBox26
            // 
            this.checkBox26.AutoSize = true;
            this.checkBox26.Location = new System.Drawing.Point(520, 182);
            this.checkBox26.Name = "checkBox26";
            this.checkBox26.Size = new System.Drawing.Size(72, 16);
            this.checkBox26.TabIndex = 70;
            this.checkBox26.Text = "子弹分裂";
            this.checkBox26.UseVisualStyleBackColor = true;
            this.checkBox26.CheckedChanged += new System.EventHandler(this.checkBox26_CheckedChanged);
            // 
            // checkBox27
            // 
            this.checkBox27.AutoSize = true;
            this.checkBox27.Location = new System.Drawing.Point(402, 182);
            this.checkBox27.Name = "checkBox27";
            this.checkBox27.Size = new System.Drawing.Size(48, 16);
            this.checkBox27.TabIndex = 69;
            this.checkBox27.Text = "三枪";
            this.checkBox27.UseVisualStyleBackColor = true;
            this.checkBox27.CheckedChanged += new System.EventHandler(this.checkBox27_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(485, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 68;
            this.label12.Text = "汽水:";
            // 
            // moneyval_p3
            // 
            this.moneyval_p3.Location = new System.Drawing.Point(124, 121);
            this.moneyval_p3.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.moneyval_p3.Name = "moneyval_p3";
            this.moneyval_p3.Size = new System.Drawing.Size(99, 21);
            this.moneyval_p3.TabIndex = 67;
            this.moneyval_p3.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // checkBox28
            // 
            this.checkBox28.AutoSize = true;
            this.checkBox28.Location = new System.Drawing.Point(254, 123);
            this.checkBox28.Name = "checkBox28";
            this.checkBox28.Size = new System.Drawing.Size(15, 14);
            this.checkBox28.TabIndex = 66;
            this.checkBox28.UseVisualStyleBackColor = true;
            this.checkBox28.CheckedChanged += new System.EventHandler(this.checkBox28_CheckedChanged);
            // 
            // button28
            // 
            this.button28.Location = new System.Drawing.Point(21, 121);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(87, 21);
            this.button28.TabIndex = 65;
            this.button28.Text = "金钱";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.button28_Click);
            // 
            // checkBox29
            // 
            this.checkBox29.AutoSize = true;
            this.checkBox29.Location = new System.Drawing.Point(532, 6);
            this.checkBox29.Name = "checkBox29";
            this.checkBox29.Size = new System.Drawing.Size(48, 16);
            this.checkBox29.TabIndex = 64;
            this.checkBox29.Text = "无视";
            this.checkBox29.UseVisualStyleBackColor = true;
            this.checkBox29.CheckedChanged += new System.EventHandler(this.checkBox29_CheckedChanged);
            // 
            // checkBox30
            // 
            this.checkBox30.AutoSize = true;
            this.checkBox30.Location = new System.Drawing.Point(6, 6);
            this.checkBox30.Name = "checkBox30";
            this.checkBox30.Size = new System.Drawing.Size(48, 16);
            this.checkBox30.TabIndex = 61;
            this.checkBox30.Text = "无敌";
            this.checkBox30.UseVisualStyleBackColor = true;
            this.checkBox30.CheckedChanged += new System.EventHandler(this.checkBox30_CheckedChanged);
            // 
            // checkBox31
            // 
            this.checkBox31.AutoSize = true;
            this.checkBox31.Location = new System.Drawing.Point(173, 6);
            this.checkBox31.Name = "checkBox31";
            this.checkBox31.Size = new System.Drawing.Size(72, 16);
            this.checkBox31.TabIndex = 62;
            this.checkBox31.Text = "无限子弹";
            this.checkBox31.UseVisualStyleBackColor = true;
            this.checkBox31.CheckedChanged += new System.EventHandler(this.checkBox31_CheckedChanged);
            // 
            // checkBox32
            // 
            this.checkBox32.AutoSize = true;
            this.checkBox32.Location = new System.Drawing.Point(325, 6);
            this.checkBox32.Name = "checkBox32";
            this.checkBox32.Size = new System.Drawing.Size(72, 16);
            this.checkBox32.TabIndex = 63;
            this.checkBox32.Text = "快速射击";
            this.checkBox32.UseVisualStyleBackColor = true;
            this.checkBox32.CheckedChanged += new System.EventHandler(this.checkBox32_CheckedChanged);
            // 
            // weaponval_p3
            // 
            this.weaponval_p3.Location = new System.Drawing.Point(124, 165);
            this.weaponval_p3.Name = "weaponval_p3";
            this.weaponval_p3.Size = new System.Drawing.Size(99, 21);
            this.weaponval_p3.TabIndex = 60;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(188, 192);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(53, 16);
            this.radioButton7.TabIndex = 58;
            this.radioButton7.Text = "武器3";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(115, 192);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(53, 16);
            this.radioButton8.TabIndex = 57;
            this.radioButton8.Text = "武器2";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Checked = true;
            this.radioButton9.Location = new System.Drawing.Point(49, 192);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(53, 16);
            this.radioButton9.TabIndex = 56;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "武器1";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(21, 165);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(87, 21);
            this.button29.TabIndex = 55;
            this.button29.Text = "给予武器";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.model_p4);
            this.tabPage6.Controls.Add(this.button47);
            this.tabPage6.Controls.Add(this.checkBox47);
            this.tabPage6.Controls.Add(this.button42);
            this.tabPage6.Controls.Add(this.button41);
            this.tabPage6.Controls.Add(this.button30);
            this.tabPage6.Controls.Add(this.button31);
            this.tabPage6.Controls.Add(this.checkBox33);
            this.tabPage6.Controls.Add(this.button32);
            this.tabPage6.Controls.Add(this.checkBox34);
            this.tabPage6.Controls.Add(this.checkBox35);
            this.tabPage6.Controls.Add(this.checkBox36);
            this.tabPage6.Controls.Add(this.checkBox37);
            this.tabPage6.Controls.Add(this.label13);
            this.tabPage6.Controls.Add(this.moneyval_p4);
            this.tabPage6.Controls.Add(this.checkBox38);
            this.tabPage6.Controls.Add(this.button33);
            this.tabPage6.Controls.Add(this.checkBox39);
            this.tabPage6.Controls.Add(this.checkBox40);
            this.tabPage6.Controls.Add(this.checkBox41);
            this.tabPage6.Controls.Add(this.checkBox42);
            this.tabPage6.Controls.Add(this.weaponval_p4);
            this.tabPage6.Controls.Add(this.radioButton10);
            this.tabPage6.Controls.Add(this.radioButton11);
            this.tabPage6.Controls.Add(this.radioButton12);
            this.tabPage6.Controls.Add(this.button34);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(654, 315);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "-";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // model_p4
            // 
            this.model_p4.Location = new System.Drawing.Point(115, 246);
            this.model_p4.Name = "model_p4";
            this.model_p4.Size = new System.Drawing.Size(65, 21);
            this.model_p4.TabIndex = 81;
            // 
            // button47
            // 
            this.button47.Location = new System.Drawing.Point(8, 246);
            this.button47.Name = "button47";
            this.button47.Size = new System.Drawing.Size(89, 21);
            this.button47.TabIndex = 80;
            this.button47.Text = "更改模型";
            this.button47.UseVisualStyleBackColor = true;
            this.button47.Click += new System.EventHandler(this.button47_Click);
            // 
            // checkBox47
            // 
            this.checkBox47.AutoSize = true;
            this.checkBox47.Location = new System.Drawing.Point(178, 54);
            this.checkBox47.Name = "checkBox47";
            this.checkBox47.Size = new System.Drawing.Size(72, 16);
            this.checkBox47.TabIndex = 79;
            this.checkBox47.Text = "第三人称";
            this.checkBox47.UseVisualStyleBackColor = true;
            this.checkBox47.CheckedChanged += new System.EventHandler(this.checkBox47_CheckedChanged);
            // 
            // button42
            // 
            this.button42.Location = new System.Drawing.Point(234, 289);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(88, 21);
            this.button42.TabIndex = 78;
            this.button42.Text = "传送到玩家3";
            this.button42.UseVisualStyleBackColor = true;
            this.button42.Click += new System.EventHandler(this.button42_Click);
            // 
            // button41
            // 
            this.button41.Location = new System.Drawing.Point(115, 289);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(88, 21);
            this.button41.TabIndex = 77;
            this.button41.Text = "传送到玩家2";
            this.button41.UseVisualStyleBackColor = true;
            this.button41.Click += new System.EventHandler(this.button41_Click);
            // 
            // button30
            // 
            this.button30.Enabled = false;
            this.button30.Location = new System.Drawing.Point(339, 289);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(99, 21);
            this.button30.TabIndex = 76;
            this.button30.Text = "取消";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(8, 289);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(88, 21);
            this.button31.TabIndex = 75;
            this.button31.Text = "传送到玩家1";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // checkBox33
            // 
            this.checkBox33.AutoSize = true;
            this.checkBox33.Location = new System.Drawing.Point(6, 54);
            this.checkBox33.Name = "checkBox33";
            this.checkBox33.Size = new System.Drawing.Size(72, 16);
            this.checkBox33.TabIndex = 74;
            this.checkBox33.Text = "冻结玩家";
            this.checkBox33.UseVisualStyleBackColor = true;
            this.checkBox33.CheckedChanged += new System.EventHandler(this.checkBox33_CheckedChanged);
            // 
            // button32
            // 
            this.button32.Location = new System.Drawing.Point(491, 246);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(75, 21);
            this.button32.TabIndex = 73;
            this.button32.Text = "重置汽水";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // checkBox34
            // 
            this.checkBox34.AutoSize = true;
            this.checkBox34.Location = new System.Drawing.Point(544, 224);
            this.checkBox34.Name = "checkBox34";
            this.checkBox34.Size = new System.Drawing.Size(48, 16);
            this.checkBox34.TabIndex = 72;
            this.checkBox34.Text = "厚血";
            this.checkBox34.UseVisualStyleBackColor = true;
            this.checkBox34.CheckedChanged += new System.EventHandler(this.checkBox34_CheckedChanged);
            // 
            // checkBox35
            // 
            this.checkBox35.AutoSize = true;
            this.checkBox35.Location = new System.Drawing.Point(420, 224);
            this.checkBox35.Name = "checkBox35";
            this.checkBox35.Size = new System.Drawing.Size(48, 16);
            this.checkBox35.TabIndex = 71;
            this.checkBox35.Text = "快跑";
            this.checkBox35.UseVisualStyleBackColor = true;
            this.checkBox35.CheckedChanged += new System.EventHandler(this.checkBox35_CheckedChanged);
            // 
            // checkBox36
            // 
            this.checkBox36.AutoSize = true;
            this.checkBox36.Location = new System.Drawing.Point(544, 189);
            this.checkBox36.Name = "checkBox36";
            this.checkBox36.Size = new System.Drawing.Size(72, 16);
            this.checkBox36.TabIndex = 70;
            this.checkBox36.Text = "子弹分裂";
            this.checkBox36.UseVisualStyleBackColor = true;
            this.checkBox36.CheckedChanged += new System.EventHandler(this.checkBox36_CheckedChanged);
            // 
            // checkBox37
            // 
            this.checkBox37.AutoSize = true;
            this.checkBox37.Location = new System.Drawing.Point(420, 189);
            this.checkBox37.Name = "checkBox37";
            this.checkBox37.Size = new System.Drawing.Size(48, 16);
            this.checkBox37.TabIndex = 69;
            this.checkBox37.Text = "三枪";
            this.checkBox37.UseVisualStyleBackColor = true;
            this.checkBox37.CheckedChanged += new System.EventHandler(this.checkBox37_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(505, 154);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 68;
            this.label13.Text = "汽水:";
            // 
            // moneyval_p4
            // 
            this.moneyval_p4.Location = new System.Drawing.Point(121, 106);
            this.moneyval_p4.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.moneyval_p4.Name = "moneyval_p4";
            this.moneyval_p4.Size = new System.Drawing.Size(99, 21);
            this.moneyval_p4.TabIndex = 67;
            this.moneyval_p4.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // checkBox38
            // 
            this.checkBox38.AutoSize = true;
            this.checkBox38.Location = new System.Drawing.Point(234, 110);
            this.checkBox38.Name = "checkBox38";
            this.checkBox38.Size = new System.Drawing.Size(15, 14);
            this.checkBox38.TabIndex = 66;
            this.checkBox38.UseVisualStyleBackColor = true;
            this.checkBox38.CheckedChanged += new System.EventHandler(this.checkBox38_CheckedChanged);
            // 
            // button33
            // 
            this.button33.Location = new System.Drawing.Point(10, 106);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(87, 21);
            this.button33.TabIndex = 65;
            this.button33.Text = "金钱";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // checkBox39
            // 
            this.checkBox39.AutoSize = true;
            this.checkBox39.Location = new System.Drawing.Point(530, 6);
            this.checkBox39.Name = "checkBox39";
            this.checkBox39.Size = new System.Drawing.Size(48, 16);
            this.checkBox39.TabIndex = 64;
            this.checkBox39.Text = "无视";
            this.checkBox39.UseVisualStyleBackColor = true;
            this.checkBox39.CheckedChanged += new System.EventHandler(this.checkBox39_CheckedChanged);
            // 
            // checkBox40
            // 
            this.checkBox40.AutoSize = true;
            this.checkBox40.Location = new System.Drawing.Point(6, 6);
            this.checkBox40.Name = "checkBox40";
            this.checkBox40.Size = new System.Drawing.Size(48, 16);
            this.checkBox40.TabIndex = 61;
            this.checkBox40.Text = "无敌";
            this.checkBox40.UseVisualStyleBackColor = true;
            this.checkBox40.CheckedChanged += new System.EventHandler(this.checkBox40_CheckedChanged);
            // 
            // checkBox41
            // 
            this.checkBox41.AutoSize = true;
            this.checkBox41.Location = new System.Drawing.Point(178, 6);
            this.checkBox41.Name = "checkBox41";
            this.checkBox41.Size = new System.Drawing.Size(72, 16);
            this.checkBox41.TabIndex = 62;
            this.checkBox41.Text = "无限子弹";
            this.checkBox41.UseVisualStyleBackColor = true;
            this.checkBox41.CheckedChanged += new System.EventHandler(this.checkBox41_CheckedChanged);
            // 
            // checkBox42
            // 
            this.checkBox42.AutoSize = true;
            this.checkBox42.Location = new System.Drawing.Point(375, 6);
            this.checkBox42.Name = "checkBox42";
            this.checkBox42.Size = new System.Drawing.Size(72, 16);
            this.checkBox42.TabIndex = 63;
            this.checkBox42.Text = "快速射击";
            this.checkBox42.UseVisualStyleBackColor = true;
            this.checkBox42.CheckedChanged += new System.EventHandler(this.checkBox42_CheckedChanged);
            // 
            // weaponval_p4
            // 
            this.weaponval_p4.Location = new System.Drawing.Point(121, 150);
            this.weaponval_p4.Name = "weaponval_p4";
            this.weaponval_p4.Size = new System.Drawing.Size(99, 21);
            this.weaponval_p4.TabIndex = 60;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(178, 213);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(53, 16);
            this.radioButton10.TabIndex = 58;
            this.radioButton10.Text = "武器3";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(99, 213);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(53, 16);
            this.radioButton11.TabIndex = 57;
            this.radioButton11.Text = "武器2";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Checked = true;
            this.radioButton12.Location = new System.Drawing.Point(21, 213);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(53, 16);
            this.radioButton12.TabIndex = 56;
            this.radioButton12.TabStop = true;
            this.radioButton12.Text = "武器1";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // button34
            // 
            this.button34.Location = new System.Drawing.Point(10, 150);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(87, 21);
            this.button34.TabIndex = 55;
            this.button34.Text = "给予武器";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.richTextBox1);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(654, 315);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "关于";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(243, 24);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "此BO3僵尸修改器由Fallingfl无聊汉化而来";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // money
            // 
            this.money.Tick += new System.EventHandler(this.money_Tick);
            // 
            // zhealth
            // 
            this.zhealth.Tick += new System.EventHandler(this.zhealth_Tick);
            // 
            // vita_p2
            // 
            this.vita_p2.Tick += new System.EventHandler(this.vita_p2_Tick);
            // 
            // ammo_p2
            // 
            this.ammo_p2.Tick += new System.EventHandler(this.ammo_p2_Tick);
            // 
            // rapid_p2
            // 
            this.rapid_p2.Interval = 10;
            this.rapid_p2.Tick += new System.EventHandler(this.rapid_p2_Tick);
            // 
            // money_p2
            // 
            this.money_p2.Tick += new System.EventHandler(this.money_p2_Tick);
            // 
            // vita_p3
            // 
            this.vita_p3.Tick += new System.EventHandler(this.vita_p3_Tick);
            // 
            // ammo_p3
            // 
            this.ammo_p3.Tick += new System.EventHandler(this.ammo_p3_Tick);
            // 
            // rapid_p3
            // 
            this.rapid_p3.Interval = 10;
            this.rapid_p3.Tick += new System.EventHandler(this.rapid_p3_Tick);
            // 
            // money_p3
            // 
            this.money_p3.Tick += new System.EventHandler(this.money_p3_Tick);
            // 
            // vita_p4
            // 
            this.vita_p4.Tick += new System.EventHandler(this.vita_p4_Tick);
            // 
            // ammo_p4
            // 
            this.ammo_p4.Interval = 10;
            this.ammo_p4.Tick += new System.EventHandler(this.ammo_p4_Tick);
            // 
            // rapid_p4
            // 
            this.rapid_p4.Interval = 10;
            this.rapid_p4.Tick += new System.EventHandler(this.rapid_p4_Tick);
            // 
            // money_p4
            // 
            this.money_p4.Tick += new System.EventHandler(this.money_p4_Tick);
            // 
            // freeze_z
            // 
            this.freeze_z.Tick += new System.EventHandler(this.freeze_z_Tick);
            // 
            // replacer
            // 
            this.replacer.Interval = 1500;
            this.replacer.Tick += new System.EventHandler(this.replacer_Tick);
            // 
            // setaddress
            // 
            this.setaddress.Enabled = true;
            this.setaddress.Interval = 5000;
            this.setaddress.Tick += new System.EventHandler(this.setaddress_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 344);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BO3僵尸修改器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timescaleval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zhval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gravityval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jumpval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyval)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.round_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_p1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericX)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.model_p2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyval_p2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponval_p2)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.model_p3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyval_p3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponval_p3)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.model_p4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyval_p4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponval_p4)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
