using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    class playerControls : Animated
    {
        public PictureBox pb;
        private Point direction;
        public playerControls(Panel GameBoard, Point location)
        {
            pb = new PictureBox();
            pb.Image = Properties.Resources.plank;
            pb.Size = new Size(30, 200);
            pb.BackColor = Color.Transparent;
            pb.Location = location;
            GameBoard.Controls.Add(pb);
        }
        public void PMove(Point d)
        {
            direction = d;
            Move();
        }

        public void SetPosition(Point location) => SetPosition(pb, location);
        public void Hide() => Hide(pb);

        public override void Move()
        {
            string flag = CheckCollision();
            if (flag != "top" && flag != "bot")
            {
                Move(pb, direction);
            }

        }
        private string CheckCollision()
        {
            if (pb.Location.Y + pb.Height + direction.Y > GlobalVariables.gB.Height)//bottom hit
            {
                Move(pb, new Point(direction.X, GlobalVariables.gB.Height - pb.Location.Y - pb.Height));
                return "bot";
            }
            else if (pb.Location.Y + direction.Y < 0)//top hit
            {
                Move(pb, new Point(direction.X, -pb.Location.Y));
                return "top";
            }
            return "clear";
        }
    }
}
