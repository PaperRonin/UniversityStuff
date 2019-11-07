using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    class playerControls : Animated
    {
        public PictureBox pb;
        public Point direction;
        public playerControls(Panel GameBoard, Point location)
        {
            pb = new PictureBox();
            pb.Image = Properties.Resources.plank;
            pb.Size = new Size(40, 200);
            pb.BackColor = Color.Transparent;
            pb.Location = location;
            GameBoard.Controls.Add(pb);
        }
        public void PMove(Point d)
        {
            direction = d;
            Move();
        }
        public override void Move()
        {
            string flag = CheckCollision(pb, direction);
            if (flag != "top" && flag != "bot")
            {
                Move(pb, direction);
            }

        }
    }
}
