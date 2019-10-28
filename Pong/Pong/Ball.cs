using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    class Ball : Animated
    {
        private int imageCount = 0;
        private PictureBox pb;
        private Point direction;
        public override void RotateImage() => RotateImage(ref imageCount, ref pb, "Square");
        public override void Move() => Move(ref pb, ref direction);

        private static void RotateImage(ref int imageCount, ref PictureBox pb, string classToString)
        {
            imageCount = imageCount == 0 ? 1 : 0;
            pb.Image = Image.FromFile("C:/Users/AnotherMan/source/repos/LAB3/" + imageCount + classToString + ".png");
        }

        public Ball(Point location,Point vector, Panel GameBoard)
        {
            pb = new PictureBox();
            pb.Image = Image.FromFile("C:/Users/AnotherMan/source/repos/LAB3/0Square.png");
            direction = vector;
            pb.Location = location;
            pb.Size = new Size(40, 40);
            pb.BackColor = Color.Transparent;
            GameBoard.Controls.Add(pb);

        }
    }
}
