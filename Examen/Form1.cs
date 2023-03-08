using Microsoft.VisualBasic.Logging;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Examen
{
    public partial class Form1 : Form
    {
        Graphics papel;
        bool paint;
        private Graphics g;
        Bitmap bm;
        private Point? previousPoint;
        private Pen pen = new Pen(Color.Black, 3);
       
        public Form1()
        {
            InitializeComponent();
         
            g = Graphics.FromImage(bm);
            pbPapel.Image = new Bitmap(pbPapel.Height, pbPapel.Width);
            papel = pbPapel.CreateGraphics();
            pbPapel.Image = bm;

            pen = new Pen(Color.FromArgb(0, 0, 0), 3);
            papel.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void btnImagen_Click(object sender, EventArgs e)

        {


            OpenFileDialog getimage = new OpenFileDialog();
            DialogResult result = getimage.ShowDialog();
            if (result == DialogResult.OK)
            {
                pbPapel.Image = Image.FromFile(getimage.FileName);

            }

        }



        private void pbPapel_MouseDown(object sender, MouseEventArgs e)
        {
            // Inicializa la variable Graphics a partir del PictureBox
            g = pbPapel.CreateGraphics();
           
        }

        private void pbPapel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && g != null) // Verifica si se está presionando el botón izquierdo del mouse y si ya se inicializó el objeto Graphics
            {
                // Dibuja un círculo en la posición del mouse
                g.FillEllipse(Brushes.Black, e.X - 10, e.Y - 10, 10, 10);
            }
            //  previousPoint = e.Location;
        }

        private void pbPapel_MouseUp(object sender, MouseEventArgs e)
        {
            pbPapel.Show();
            g.Dispose();
            g = null;
            

            //previousPoint = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";


            if (guardar.ShowDialog() == DialogResult.OK)
            {
                Bitmap btm = bm.Clone(new Rectangle(0, 0, pbPapel.Width, pbPapel.Height), bm.PixelFormat);
                btm.Save(guardar.FileName, ImageFormat.Png);


            }



        }


    }
}
