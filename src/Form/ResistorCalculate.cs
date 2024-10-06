using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public partial class ResistorCalculate : Form
{
	private Color color1 = Color.Black;
	private Color color2 = Color.Black;
	private Color color3 = Color.Black;
	private Color color4 = Color.Brown;
	private int a, b;
	
	public ResistorCalculate()
	{
		InitializeComponent();
	}
	
	private double ResiztorCalc(int a, int b)
	{
		return a * Math.Pow(10, b);
	}
	
	private string GetSembol(double ohm)
	{
		if (ohm >= 1000000000)
        {
            double gOhm = ohm / 1000000000.0;
            return $"{gOhm}GΩ";
        }
		else if(ohm >= 1000000)
		{
			double mohm = ohm / 1000000.0;
			return $"{mohm}MΩ";
		}
		else if(ohm >= 1000)
		{
			double kohm = ohm / 1000.0;
			return $"{kohm}KΩ";
		}
		else
		{
			return $"{ohm}Ω";
		}
	}
	
	/** Events **/
	private void OnPainting(object sender, PaintEventArgs e)
	{
		Graphics g = e.Graphics;

        g.FillRectangle(new SolidBrush(color1), new Rectangle(100, 53, 12, 66)); // 1. Bant
        g.FillRectangle(new SolidBrush(color2), new Rectangle(130, 58, 12, 55)); // 2. Bant
        g.FillRectangle(new SolidBrush(color3), new Rectangle(160, 58, 12, 55)); // 3. Bant (Multiplier)
        g.FillRectangle(new SolidBrush(color4), new Rectangle(205, 53, 12, 66)); // 4. Bant (Tolerans)
		
		Item item1 = (Item)cmb1.SelectedItem;
		Item item2 = (Item)cmb2.SelectedItem;
		Item item3 = (Item)cmb3.SelectedItem;
		Item item4 = (Item)cmb4.SelectedItem;
		
        Font font = new Font("Arial", 12);
        g.DrawString(item1.getMultiplier().ToString(), font, Brushes.Black, 100, 30);
        g.DrawString(item2.getMultiplier().ToString(), font, Brushes.Black, 130, 30);
        g.DrawString("10^" + item3.getMultiplier().ToString(), font, Brushes.Black, 150, 30);
        g.DrawString(item4.getTolerans(), font, Brushes.Black, 205, 30);
        
        g.DrawString("4 Band", new Font("Arial", 12), Brushes.Black, 3, 60);
        g.DrawString(GetSembol(ResiztorCalc(a, b)) + "  " + item4.getTolerans(), new Font("Arial", 12), Brushes.Black, 245, 60);
	}
	
	private void OnSelectedIndexChanged(object sender, EventArgs e)
	{
		Item item1 = (Item)cmb1.SelectedItem;
		Item item2 = (Item)cmb2.SelectedItem;
		Item item3 = (Item)cmb3.SelectedItem;
		Item item4 = (Item)cmb4.SelectedItem;
		
		this.color1 = item1.getColor();
		this.color2 = item2.getColor();
		this.color3 = item3.getColor();
		this.color4 = item4.getColor();
		
		a = int.Parse(item1.getMultiplier().ToString() + item2.getMultiplier().ToString());
		b = item3.getMultiplier();
		
		txt1.Text = Convert.ToString(ResiztorCalc(a, 9));
		txt2.Text = Convert.ToString(ResiztorCalc(a, 6));
		txt3.Text = Convert.ToString(ResiztorCalc(a, 3));
		txt4.Text = Convert.ToString(ResiztorCalc(a, 0));
		txt5.Text = Convert.ToString(ResiztorCalc(a, -3));
		txt6.Text = Convert.ToString(ResiztorCalc(a, -6));
		txt7.Text = Convert.ToString(ResiztorCalc(a, -9));
		txt8.Text = Convert.ToString(ResiztorCalc(a, -12));
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