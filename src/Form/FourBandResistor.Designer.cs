using System;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

partial class FourBandResistor
{
	private IContainer components = null;
	private PictureBox img = new PictureBox();
	private GroupBox grp1 = new GroupBox();
	private GroupBox grp2 = new GroupBox();
	private ComboBox cmb1 = new ComboBox();
	private ComboBox cmb2 = new ComboBox();
	private ComboBox cmb3 = new ComboBox();
	private ComboBox cmb4 = new ComboBox();
	private Label lbl1 = new Label();
	private Label lbl2 = new Label();
	private Label lbl3 = new Label();
	private Label lbl4 = new Label();
	private Label lbl5 = new Label();
	private Label lbl6 = new Label();
	private Label lbl7 = new Label();
	private Label lbl8 = new Label();
	private Label lbl9 = new Label();
	private Label lbl10 = new Label();
	private Label lbl11 = new Label();
	private Label lbl12 = new Label();
	private Label lbl13 = new Label();
	private TextBox txt1 = new TextBox();
	private TextBox txt2 = new TextBox();
	private TextBox txt3 = new TextBox();
	private TextBox txt4 = new TextBox();
	private TextBox txt5 = new TextBox();
	private TextBox txt6 = new TextBox();
	private TextBox txt7 = new TextBox();
	private TextBox txt8 = new TextBox();
	private TextBox txt9 = new TextBox();
	private TableLayoutPanel lytPnlMaster = new TableLayoutPanel();
	private TableLayoutPanel lytPnlColor = new TableLayoutPanel();
	private TableLayoutPanel lytPnlSonuc = new TableLayoutPanel();
	
	protected override void Dispose(bool disposing)
	{
		if(disposing && (components != null))
			components.Dispose();
		base.Dispose(disposing);
	}
	
	private void InitializeComponent()
	{
		Item[] colors = { new Item("Siyah", Color.Black, 0, ""), new Item("Kahve", Color.Brown, 1, ""), new Item("Kırmızı", Color.Red, 2, ""), new Item("Turuncu", Color.Orange, 3, ""), new Item("Sarı", Color.Yellow, 4, ""), new Item("Yeşil", Color.Green, 5, ""), new Item("Mavi", Color.Blue, 6, ""), new Item("Mor", Color.Purple, 7, ""), new Item("Gri", Color.Gray, 8, ""), new Item("Beyaz", Color.White, 9, "") };
		Item[] multiplier = { new Item("Siyah", Color.Black, 0, ""), new Item("Kahve", Color.Brown, 1, ""), new Item("Kırmızı", Color.Red, 2, ""), new Item("Turuncu", Color.Orange, 3, ""), new Item("Sarı", Color.Yellow, 4, ""), new Item("Yeşil", Color.Green, 5, ""), new Item("Mavi", Color.Blue, 6, ""), new Item("Mor", Color.Purple, 7, ""), new Item("Gri", Color.Gray, 8, ""), new Item("Beyaz", Color.White, 9, ""), new Item("Altın", Color.Gold, -1, ""), new Item("Gümüş", Color.Silver, -2, "") };
		Item[] tolerans = { new Item("Kahve", Color.Brown, 1, "±1%"), new Item("Kırmızı", Color.Red, 2, "±2%"), new Item("Yeşil", Color.Green, 5, "±0.5%"), new Item("Mavi", Color.Blue, 6, "±0.25%"), new Item("Mor", Color.Purple, 7, "±0.1%"), new Item("Gri", Color.Gray, 8, "±0.05%"), new Item("Altın", Color.Gold, -1, "±5%"), new Item("Gümüş", Color.Silver, -2, "±10%") };
		
		
		string resImg = "ResistorCalculate.resources.resistor.png";
		Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resImg);


		// string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
		// foreach (string resource in resourceNames)
			// Console.WriteLine(resource);
		
		img.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);
		img.Image = Image.FromStream(stream);
		img.Width = 340;
        img.Height = 179;
		img.Paint += new PaintEventHandler(OnPainting);
		
		
		grp1.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		grp1.Dock = DockStyle.Fill;
		grp1.AutoSize = true;
		grp1.Text = "Renk Değerleri";
		
		lbl1.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		lbl1.Text = "1. Bant";
		lbl1.Font = new Font("Arial", 12);
		
		lbl2.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		lbl2.Text = "2. Bant";
		lbl2.Font = new Font("Arial", 12);
		
		lbl3.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		lbl3.Text = "3. Bant (Çarpan)";
		lbl3.Font = new Font("Arial", 12);
		
		lbl4.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		lbl4.Text = "4. Bant (Tolerans)";
		lbl4.Font = new Font("Arial", 12);
		
		cmb1.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		cmb1.DropDownStyle = ComboBoxStyle.DropDownList;
		for(int i = 0; i < colors.Length; i++)
			cmb1.Items.Add(colors[i]);
		cmb1.SelectedIndex = 0;
		cmb1.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
		
		cmb2.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		cmb2.DropDownStyle = ComboBoxStyle.DropDownList;
		for(int i = 0; i < colors.Length; i++)
			cmb2.Items.Add(colors[i]);
		cmb2.SelectedIndex = 0;
		cmb2.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
		
		cmb3.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		cmb3.DropDownStyle = ComboBoxStyle.DropDownList;
		for(int i = 0; i < multiplier.Length; i++)
			cmb3.Items.Add(multiplier[i]);
		cmb3.SelectedIndex = 0;
		cmb3.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
		
		cmb4.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		cmb4.DropDownStyle = ComboBoxStyle.DropDownList;
		for(int i = 0; i < tolerans.Length; i++)
			cmb4.Items.Add(tolerans[i]);
		cmb4.SelectedIndex = 0;
		cmb4.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
		
		lytPnlColor.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);
		lytPnlColor.Dock = DockStyle.Fill;
		lytPnlColor.ColumnCount = 2;
		lytPnlColor.RowCount = 5;
		lytPnlColor.AutoSize = true;
		lytPnlColor.Controls.Add(lbl1, 0, 0);
		lytPnlColor.Controls.Add(cmb1, 0, 1);
		lytPnlColor.Controls.Add(lbl2, 1, 0);
		lytPnlColor.Controls.Add(cmb2, 1, 1);
		lytPnlColor.Controls.Add(lbl3, 0, 2);
		lytPnlColor.Controls.Add(cmb3, 0, 3);
		lytPnlColor.Controls.Add(lbl4, 1, 2);
		lytPnlColor.Controls.Add(cmb4, 1, 3);
		lytPnlColor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		lytPnlColor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		grp1.Controls.Add(lytPnlColor);
		
		
		
		grp2.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		grp2.Dock = DockStyle.Fill;
		grp2.AutoSize = true;
		grp2.Text = "Sonuçlar";
		
		lbl5.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		lbl5.Text = "GigaOhm";
		lbl5.Font = new Font("Arial", 12);
		
		lbl6.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		lbl6.Text = "MegaOhm";
		lbl6.Font = new Font("Arial", 12);
		
		lbl7.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		lbl7.Text = "KiloOhm";
		lbl7.Font = new Font("Arial", 12);
		
		lbl8.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		lbl8.Text = "Ohm";
		lbl8.Font = new Font("Arial", 12);
		
		lbl9.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		lbl9.Text = "PikoOhm";
		lbl9.Font = new Font("Arial", 12);
		
		lbl10.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		lbl10.Text = "NanoOhm";
		lbl10.Font = new Font("Arial", 12);
		
		lbl11.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		lbl11.Text = "MikroOhm";
		lbl11.Font = new Font("Arial", 12);
		
		lbl12.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		lbl12.Text = "MiliOhm";
		lbl12.Font = new Font("Arial", 12);
		
		lbl13.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		lbl13.Text = "Tolerans";
		lbl13.Font = new Font("Arial", 12);
		
		txt1.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		txt1.Font = new Font("Arial", 12);
		txt1.ReadOnly = true;
		
		txt2.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		txt2.Font = new Font("Arial", 12);
		txt2.ReadOnly = true;
		
		txt3.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		txt3.Font = new Font("Arial", 12);
		txt3.ReadOnly = true;
		
		txt4.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		txt4.Font = new Font("Arial", 12);
		txt4.ReadOnly = true;
		
		txt5.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		txt5.Font = new Font("Arial", 12);
		txt5.ReadOnly = true;
		
		txt6.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		txt6.Font = new Font("Arial", 12);
		txt6.ReadOnly = true;
		
		txt7.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		txt7.Font = new Font("Arial", 12);
		txt7.ReadOnly = true;
		
		txt8.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		txt8.Font = new Font("Arial", 12);
		txt8.ReadOnly = true;
		
		txt9.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
		txt9.Font = new Font("Arial", 12);
		txt9.ReadOnly = true;
		
		lytPnlSonuc.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);
		lytPnlSonuc.Dock = DockStyle.Fill;
		lytPnlSonuc.ColumnCount = 2;
		lytPnlSonuc.RowCount = 10;
		lytPnlSonuc.AutoSize = true;
		lytPnlSonuc.Controls.Add(lbl5, 0, 0);
		lytPnlSonuc.Controls.Add(txt1, 1, 0);
		lytPnlSonuc.Controls.Add(lbl6, 0, 1);
		lytPnlSonuc.Controls.Add(txt2, 1, 1);
		lytPnlSonuc.Controls.Add(lbl7, 0, 2);
		lytPnlSonuc.Controls.Add(txt3, 1, 2);
		lytPnlSonuc.Controls.Add(lbl8, 0, 3);
		lytPnlSonuc.Controls.Add(txt4, 1, 3);
		lytPnlSonuc.Controls.Add(lbl9, 0, 4);
		lytPnlSonuc.Controls.Add(txt5, 1, 4);
		lytPnlSonuc.Controls.Add(lbl10, 0, 5);
		lytPnlSonuc.Controls.Add(txt6, 1, 5);
		lytPnlSonuc.Controls.Add(lbl11, 0, 6);
		lytPnlSonuc.Controls.Add(txt7, 1, 6);
		lytPnlSonuc.Controls.Add(lbl12, 0, 7);
		lytPnlSonuc.Controls.Add(txt8, 1, 7);
		lytPnlSonuc.Controls.Add(lbl13, 0, 8);
		lytPnlSonuc.Controls.Add(txt9, 1, 8);
		lytPnlSonuc.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		lytPnlSonuc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		grp2.Controls.Add(lytPnlSonuc);
		
		
		lytPnlMaster.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);
		lytPnlMaster.Dock = DockStyle.Fill;
		lytPnlMaster.ColumnCount = 2;
		lytPnlMaster.RowCount = 2;
		lytPnlMaster.AutoSize = true;
		lytPnlMaster.Controls.Add(img, 0, 0);
		lytPnlMaster.Controls.Add(grp1, 0, 1);
		lytPnlMaster.Controls.Add(grp2, 1, 0);
		lytPnlMaster.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350f));
		lytPnlMaster.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		lytPnlMaster.SetRowSpan(grp2, 2);
		this.Controls.Add(lytPnlMaster);
		
		this.Text = "4 Band Resistor";
	}
}