namespace ActualAsciiConverterThisTime

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
                AsciiConvert();

            }
        }

        private string pixels = "Ñ@#W$9876543210?!abc;:+=-,._ ";

        public void AsciiConvert()
        {
            var temp = (Bitmap)pictureBox1.Image;
            Bitmap bmap = (Bitmap)temp.Clone();

            //var img = new Bitmap("C:\\Users\\hikki\\Desktop\\neco.jpg");
            using (var wrtr = new StreamWriter("C:\\Users\\hikki\\Desktop\\OUTPUT.txt"))
            {
                for (var i = 0; i < bmap.Width; i++)
                {
                    for (var j = 0; j < bmap.Height; j++)
                    {
                        var color = bmap.GetPixel(i, j);
                        var bright = Brightness(color);
                        var idx = bright / 255 * (pixels.Length - 1);
                        var pxl = pixels[(int)Math.Round(idx)];
                        System.Console.WriteLine(pxl);
                        wrtr.Write(pxl);

                    }
                    wrtr.WriteLine();
                    pictureBox2.Image = (Bitmap)bmap;
                }
            };

        }
        private static double Brightness(Color c)
        {
            return Math.Sqrt(
               c.R * c.R * .241 +
               c.G * c.G * .691 +
               c.B * c.B * .068);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsciiConvert();
        }
    }

}
