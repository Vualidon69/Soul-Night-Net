using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedPanel : Panel
{
    public int BorderRadius { get; set; } = 20; // Bo góc 20px
    public Color BorderColor { get; set; } = Color.Black; // Màu viền
    public int BorderThickness { get; set; } = 2; // Độ dày viền

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        using (GraphicsPath path = new GraphicsPath())
        {
            int radius = BorderRadius * 2;
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90); // Góc trái trên
            path.AddArc(new Rectangle(Width - radius, 0, radius, radius), 270, 90); // Góc phải trên
            path.AddArc(new Rectangle(Width - radius, Height - radius, radius, radius), 0, 90); // Góc phải dưới
            path.AddArc(new Rectangle(0, Height - radius, radius, radius), 90, 90); // Góc trái dưới
            path.CloseFigure();

            this.Region = new Region(path);
            using (Pen pen = new Pen(BorderColor, BorderThickness))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
    }
}
