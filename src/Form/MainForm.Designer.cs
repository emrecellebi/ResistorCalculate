using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

partial class MainForm
{
	private IContainer components = null;
	private TabControl tab = new TabControl();
	private TableLayoutPanel lytPnlMaster = new TableLayoutPanel();
	
	protected override void Dispose(bool disposing)
	{
		if(disposing && (components != null))
			components.Dispose();
		base.Dispose(disposing);
	}
	
	private void InitializeComponent()
	{
		tab.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);
		tab.Dock = DockStyle.Fill;
		tab.AutoSize = true;
		tab.TabPages.Add(new FourBandResistor());
		tab.TabPages.Add(new FiveBandResistor());
		
		lytPnlMaster.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);
		lytPnlMaster.Dock = DockStyle.Fill;
		lytPnlMaster.ColumnCount = 1;
		lytPnlMaster.RowCount = 1;
		lytPnlMaster.AutoSize = true;
		lytPnlMaster.Padding = new Padding(5);
		lytPnlMaster.Controls.Add(tab, 0, 0);
		this.Controls.Add(lytPnlMaster);
		
		this.Size = new Size(700, 500);
		this.Text = "Resistor Calculate";
	}
}