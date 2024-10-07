using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public partial class FiveBandResistor : TabPage
{
	private Color color1 = Color.Black;
	private Color color2 = Color.Black;
	private Color color5 = Color.Black;
	private Color color3 = Color.Black;
	private Color color4 = Color.Brown;
	private int a, b;
	
	public FiveBandResistor()
	{
		InitializeComponent();
	}
	
	/** Events **/
	private void OnPainting(object sender, PaintEventArgs e)
	{
		Graphics g = e.Graphics;

        g.FillRectangle(new SolidBrush(color1), new Rectangle(100, 53, 11, 66)); // 1. Bant
        g.FillRectangle(new SolidBrush(color2), new Rectangle(130, 58, 11, 55)); // 2. Bant
        g.FillRectangle(new SolidBrush(color5), new Rectangle(154, 58, 11, 55)); // 3. Bant
        g.FillRectangle(new SolidBrush(color3), new Rectangle(179, 58, 11, 55)); // 4. Bant (Multiplier)
        g.FillRectangle(new SolidBrush(color4), new Rectangle(208, 53, 11, 66)); // 5. Bant (Tolerans)
		
		Item item1 = (Item)cmb1.SelectedItem; // 1. Bant
		Item item2 = (Item)cmb2.SelectedItem; // 2. Bant
		Item item5 = (Item)cmb5.SelectedItem; // 3. Bant
		Item item3 = (Item)cmb3.SelectedItem; // 4. Bant (Multiplier)
		Item item4 = (Item)cmb4.SelectedItem; // 5. Bant (Tolerans)
		
        Font font = new Font("Arial", 12);
        g.DrawString(item1.getMultiplier().ToString(), font, Brushes.Black, 99, 30);  // 1. Bant
        g.DrawString(item2.getMultiplier().ToString(), font, Brushes.Black, 129, 30);  // 2. Bant
        g.DrawString(item5.getMultiplier().ToString(), font, Brushes.Black, 154, 30);  // 3. Bant
        g.DrawString(item3.getMultiplier().ToString(), font, Brushes.Black, 177, 30);  // 4. Bant (Multiplier)
        g.DrawString(item4.getTolerans(), font, Brushes.Black, 205, 30);  // 5. Bant (Tolerans)
        
        g.DrawString("5 Band", new Font("Arial", 12), Brushes.Black, 3, 60);
        g.DrawString(Utils.GetSembol(Utils.ResiztorCalc(a, b)) + "  " + item4.getTolerans(), new Font("Arial", 12), Brushes.Black, 245, 60);
	}
	
	private void OnSelectedIndexChanged(object sender, EventArgs e)
	{
		Item item1 = (Item)cmb1.SelectedItem; // 1. Bant
		Item item2 = (Item)cmb2.SelectedItem; // 2. Bant
		Item item5 = (Item)cmb5.SelectedItem; // 3. Bant
		Item item3 = (Item)cmb3.SelectedItem; // 4. Bant (Multiplier)
		Item item4 = (Item)cmb4.SelectedItem; // 5. Bant (Tolerans)
		
		this.color1 = item1.getColor(); // 1. Bant
		this.color2 = item2.getColor(); // 2. Bant
		this.color5 = item5.getColor(); // 3. Bant
		this.color3 = item3.getColor(); // 4. Bant (Multiplier)
		this.color4 = item4.getColor(); // 5. Bant (Tolerans)
		
		a = int.Parse(item1.getMultiplier().ToString() + item2.getMultiplier().ToString() + item5.getMultiplier().ToString());
		b = item3.getMultiplier();
		
		txt1.Text = Convert.ToString(Utils.ResiztorCalc(a, 9));
		txt2.Text = Convert.ToString(Utils.ResiztorCalc(a, 6));
		txt3.Text = Convert.ToString(Utils.ResiztorCalc(a, 3));
		txt4.Text = Convert.ToString(Utils.ResiztorCalc(a, 0));
		txt5.Text = Convert.ToString(Utils.ResiztorCalc(a, -3));
		txt6.Text = Convert.ToString(Utils.ResiztorCalc(a, -6));
		txt7.Text = Convert.ToString(Utils.ResiztorCalc(a, -9));
		txt8.Text = Convert.ToString(Utils.ResiztorCalc(a, -12));
		txt9.Text = item4.getTolerans();
		
		this.img.Invalidate();
	}
	
	class Item
	{
		private string name;
		private Color color;
		private int multiplier;
		private string tolerans;
		
		public Item(string name, Color color, int multiplier, string tolerans)
		{
			this.name = name;
			this.color = color;
			this.multiplier = multiplier;
			this.tolerans = tolerans;
		}
		
		public Color getColor()
		{
			return color;
		}
		
		public int getMultiplier()
		{
			return multiplier;
		}
		
		public string getTolerans()
		{
			return tolerans;
		}
		
		public override string ToString()
		{
			return name;
		}
	}
}