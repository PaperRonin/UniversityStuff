using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    class Ball : Animated
    {
        private int imageCount = 0;
        private PictureBox pb;
        private Point direction;
        public override void Move()
        {
            switch (CheckLoc(pb, direction, GameForm.GameBoard))
            {
                case "left":
                    TPoint.Win(2);
                    break;

                case "right":
                    TPoint.Win(1);
                    break;

                case "top":
                case "bot":
                    direction.Y *= -1;
                    Move(pb, direction);
                    break;
                default:
                    Move(pb, direction);
                    break;
            }
        }

        public Ball(Point location, Point vector, Panel GameBoard)
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
