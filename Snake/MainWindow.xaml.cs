using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Set up the snake body as a poly line
        Polyline snakeBody = new Polyline();

        //Set up the point collection to be used in the snake
        PointCollection points = new PointCollection();

        //Changeable variables
        int snakeGirth = 5;
        int snakeLength = 400;
        int clickCounter = 0;
        int bColor;
        int lColor;
        string[] colors = { "Red", "Pink", "Yellow", "Green", "Blue", "Purple" };

        public MainWindow()
        {
            InitializeComponent();

            //Set the initial color and size of the snake
            snakeBody.StrokeThickness = snakeGirth;
            snakeBody.Stroke = Brushes.Black;

            //Make the snake points limit
            for (int snakePoints = 0; snakePoints < snakeLength; snakePoints++)
            {
                points.Add(new Point(snakePoints, snakePoints));
            }

            //Make points the points for snake body
            snakeBody.Points = points;
            //Paint the snake
            painting_Canvas.Children.Add(snakeBody);

        }

        private void painting_Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point cursorPoint = Mouse.GetPosition(painting_Canvas);
            snakeBody.Points.Add(cursorPoint);

            snakeHead.SetValue(Canvas.LeftProperty, (cursorPoint.X - 10));
            snakeHead.SetValue(Canvas.TopProperty, (cursorPoint.Y - 10));

            //Make a new point based on where the mouse is currently on the canvas
            for (int i = 0; i < snakeBody.Points.Count - 1; i++)
            {
                snakeBody.Points[i] = new Point(snakeBody.Points[i + 1].X, snakeBody.Points[i + 1].Y);
            }

            //Remove the "first" snake point in the points aka the current var in point 0
            snakeBody.Points.RemoveAt(0);

        }

        private void painting_Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clickCounter++;

            var random = new Random();
            int previousLColor = lColor;
            lColor = random.Next(colors.Length);

            while (lColor == bColor || lColor == previousLColor)
            {
                lColor = random.Next(colors.Length);
            }
            //------
            if (lColor == 0)
            {
                snakeBody.Stroke = Brushes.Red;
                snakeHead.Fill = new SolidColorBrush(Colors.Red);
            }
            else if(lColor == 1)
            {
                snakeBody.Stroke = Brushes.Pink;
                snakeHead.Fill = new SolidColorBrush(Colors.Pink);
            }
            else if(lColor == 2)
            {
                snakeBody.Stroke = Brushes.Yellow;
                snakeHead.Fill = new SolidColorBrush(Colors.Yellow);
            }
            else if(lColor == 3)
            {
                snakeBody.Stroke = Brushes.Green;
                snakeHead.Fill = new SolidColorBrush(Colors.Green);
            }
            else if(lColor == 4)
            {
                snakeBody.Stroke = Brushes.Blue;
                snakeHead.Fill = new SolidColorBrush(Colors.Blue);
            }
            else if(lColor == 5)
            {
                snakeBody.Stroke = Brushes.Purple;
                snakeHead.Fill = new SolidColorBrush(Colors.Purple);
            }

            if (clickCounter % 5 == 0)
            {
                int previousBColor = bColor;
                bColor = random.Next(colors.Length);

                while (bColor == lColor || bColor == previousBColor)
                {
                    bColor = random.Next(colors.Length);
                }

                if (bColor == 0)
                {
                    painting_Canvas.Background = new SolidColorBrush(Colors.Red);
                }
                else if (bColor == 1)
                {
                    painting_Canvas.Background = new SolidColorBrush(Colors.Pink);
                }
                else if (bColor == 2)
                {
                    painting_Canvas.Background = new SolidColorBrush(Colors.Yellow);
                }
                else if (bColor == 3)
                {
                    painting_Canvas.Background = new SolidColorBrush(Colors.Green);
                }
                else if (bColor == 4)
                {
                    painting_Canvas.Background = new SolidColorBrush(Colors.Blue);
                }
                else if (bColor == 5)
                {
                    painting_Canvas.Background = new SolidColorBrush(Colors.Purple);
                }
            }

        }
    }
}
