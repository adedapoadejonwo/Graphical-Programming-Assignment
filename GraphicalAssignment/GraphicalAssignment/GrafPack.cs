using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace GraphicalAssignment
{


    public partial class GrafPack : Form
    {

        private readonly MainMenu mainMenu;
        private bool selectSquareStatus = false;
        private bool selectTriangleStatus = false;
        private bool selectCircleStatus = false;
        private bool selectRectangleStatus = false;
        private bool selectOvalStatus = false;

        private bool penBlack = false;
        private bool penBlue = false;
        private bool penRed = false;
        private bool penGreen = false;
        private Pen drawingPen = new Pen(Color.Black);

        private static readonly bool selectOption;

        private static readonly List<Shape> listOfShapes = new List<Shape>();

        private int clicknumber = 0;
        private Point one;
        private Point two;
        private Point Three;
        private readonly MenuItem selectItem = new MenuItem();

        public GrafPack()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            WindowState = FormWindowState.Maximized;
            BackColor = Color.White;

            // The following approach uses menu items coupled with mouse clicks
            MainMenu mainMenu = new MainMenu();
            MenuItem createItem = new MenuItem();
            MenuItem squareItem = new MenuItem();
            MenuItem triangleItem = new MenuItem();
            MenuItem circleItem = new MenuItem();
            MenuItem rectangleItem = new MenuItem();
            MenuItem deleteItem = new MenuItem();
            MenuItem deleteAllItem = new MenuItem();
            MenuItem transformItem = new MenuItem();
            MenuItem exitItem = new MenuItem();
            MenuItem ovalItem = new MenuItem();
            MenuItem penColorItem = new MenuItem();
            MenuItem penBlackItem = new MenuItem();
            MenuItem penBlueItem = new MenuItem();
            MenuItem penRedItem = new MenuItem();
            MenuItem penGreenItem = new MenuItem();

            createItem.Text = "&Create";
            squareItem.Text = "&Square";
            triangleItem.Text = "&Triangle";
            selectItem.Text = "&Select";
            deleteItem.Text = "&Delete";
            transformItem.Text = "&Transform";
            circleItem.Text = "&Circle";
            rectangleItem.Text = "&Rectangle";
            exitItem.Text = "&Exit";
            deleteAllItem.Text = "&Delete All";
            ovalItem.Text = "&Oval";
            penColorItem.Text = "&Pen Color";
            penBlackItem.Text = "&Black";
            penBlueItem.Text = "&Blue";
            penRedItem.Text = "&Red";
            penGreenItem.Text = "&Green";

            mainMenu.MenuItems.Add(createItem);
            mainMenu.MenuItems.Add(selectItem);
            mainMenu.MenuItems.Add(penColorItem);
            createItem.MenuItems.Add(squareItem);
            createItem.MenuItems.Add(triangleItem);
            createItem.MenuItems.Add(rectangleItem);
            createItem.MenuItems.Add(circleItem);
            createItem.MenuItems.Add(ovalItem);
            mainMenu.MenuItems.Add(transformItem);
            mainMenu.MenuItems.Add(deleteItem);
            mainMenu.MenuItems.Add(deleteAllItem);
            mainMenu.MenuItems.Add(exitItem);
            penColorItem.MenuItems.Add(penBlackItem);
            penColorItem.MenuItems.Add(penBlueItem);
            penColorItem.MenuItems.Add(penRedItem);
            penColorItem.MenuItems.Add(penGreenItem);


            selectItem.Click += new System.EventHandler(selectShape);
            squareItem.Click += new System.EventHandler(selectSquare);
            triangleItem.Click += new System.EventHandler(selectTriangle);
            rectangleItem.Click += new System.EventHandler(selectRectangle);
            circleItem.Click += new System.EventHandler(selectCircle);
            exitItem.Click += new System.EventHandler(selectExit);
            ovalItem.Click += new System.EventHandler(selectOval);
            deleteAllItem.Click += new System.EventHandler(selectDeleteAll);
            penBlackItem.Click += new System.EventHandler(selectBlackPen);
            penBlueItem.Click += new System.EventHandler(selectBluePen);
            penRedItem.Click += new System.EventHandler(selectRedPen);
            penGreenItem.Click += new System.EventHandler(selectGreenPen);
            deleteItem.Click += new System.EventHandler(selectDelete);
            toolStripComboBox1.SelectedIndexChanged += ToolStripComboBox1_SelectedIndexChanged;

            Menu = mainMenu;
            MouseClick += mouseClick;
        }


        private void ToolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listOfShapes[toolStripComboBox1.SelectedIndex].HasBeenSelected = true;
            MessageBox.Show(toolStripComboBox1.SelectedItem + " has been selected");

        }



        //the following methods are called when a user selects a shape to create
        private void selectSquare(object sender, EventArgs e)
        {
            selectSquareStatus = true;
            selectCircleStatus = false;
            selectTriangleStatus = false;
            selectRectangleStatus = false;
            selectOvalStatus = false;
            MessageBox.Show("Click OK and then click once each at two locations to create a square");
        }

        private void selectTriangle(object sender, EventArgs e)
        {
            selectTriangleStatus = true;
            selectSquareStatus = false;
            selectCircleStatus = false;
            selectRectangleStatus = false;
            selectOvalStatus = false;
            MessageBox.Show("Click OK and then click once each at three locations to create a triangle");
        }

        private void selectOval(object sender, EventArgs e)
        {
            selectTriangleStatus = false;
            selectSquareStatus = false;
            selectCircleStatus = false;
            selectRectangleStatus = false;
            selectOvalStatus = true;
            MessageBox.Show("Click OK and then click once each at two locations to create an Oval");
        }

        private void selectCircle(object sender, EventArgs e)
        {
            selectCircleStatus = true;
            selectSquareStatus = false;
            selectTriangleStatus = false;
            selectRectangleStatus = false;
            selectOvalStatus = false;
            MessageBox.Show("Click OK and then click once each at two locations to create a Circle, first click is the midpoint and the second is the radius");
        }

        private void selectRectangle(object sender, EventArgs e)
        {
            selectSquareStatus = false;
            selectCircleStatus = false;
            selectTriangleStatus = false;
            selectRectangleStatus = true;
            selectOvalStatus = false;
            MessageBox.Show("Click OK and then click once each at two locations to create a Rectangle, first click is the top left corner and second click is the bottom right corner of the shape");
        }

        //this method is called when a user clicks the select button
        private void selectShape(object sender, EventArgs e)
        {
            selectSquareStatus = false;
            selectCircleStatus = false;
            selectTriangleStatus = false;
            selectRectangleStatus = false;
            selectOvalStatus = false;
            MessageBox.Show("Select Enabled, Please use the drop down menu below to select the shape");
        }

        //the following methods allow the user to choose a pen color
        private void selectBlackPen(object sender, EventArgs e)
        {
            penBlack = true;
            penBlue = false;
            penRed = false;
            penGreen = false;

            drawingPen = new Pen(Color.Black);
            MessageBox.Show("Pen Color is Black");
        }

        private void selectBluePen(object sender, EventArgs e)
        {
            penBlack = false;
            penBlue = true;
            penRed = false;
            penGreen = false;

            drawingPen = new Pen(Color.Blue);
            MessageBox.Show("Pen Color is Blue");
        }

        private void selectRedPen(object sender, EventArgs e)
        {
            penBlack = false;
            penBlue = false;
            penRed = true;
            penGreen = false;

            drawingPen = new Pen(Color.Red);
            MessageBox.Show("Pen Color is Red");
        }

        
        private void selectGreenPen(object sender, EventArgs e)
        {
            penBlack = false;
            penBlue = false;
            penRed = false;
            penGreen = true;

            drawingPen = new Pen(Color.Green);
            MessageBox.Show("Pen Color is Green");
        }

        //this method is used to redraw the shape when it is deleted
        private void Redraw()
        {
            Graphics g = CreateGraphics();
            g.Clear(this.BackColor);

            foreach (Shape shape in listOfShapes)
            {
                shape.draw(g, drawingPen);
            }
        }

        //this method is used when the delete option has been selected and removes the object from the list 
        private void selectDelete(object sender, EventArgs e)
        {
            for(int i = 0; i< listOfShapes.Count(); i++)
            {
                if(listOfShapes[i].HasBeenSelected == true)
                {
                    listOfShapes[i].HasBeenDeleted = true;
                    

                    listOfShapes[i] = null;
                    listOfShapes.RemoveAt(i);

                }
                
            }
            Redraw();
        }

        //this method is called when the delete all button is clicked
        private void selectDeleteAll(object sender, EventArgs e)
        {

            Refresh();

            if (listOfShapes != null)
            {
                listOfShapes.Clear();
            }

        }

        //this method allows the user to cleanly exit the program
        private void selectExit(object sender, EventArgs e)
        {

            MessageBox.Show("You have chosen to exit the program");
            Close();
        }

        // This method is quite important and detects all mouse clicks - other methods may need
        // to be implemented to detect other kinds of event handling eg keyboard presses.
        private void mouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 'if' statements can distinguish different selected menu operations to implement.
                // There may be other (better, more efficient) approaches to event handling,
                // but this approach works.
                if (selectSquareStatus == true)
                {
                    if (clicknumber == 0)
                    {
                        one = new Point(e.X, e.Y);
                        clicknumber = 1;
                    }
                    else
                    {
                        two = new Point(e.X, e.Y);
                        clicknumber = 0;
                        selectSquareStatus = false;

                        Graphics g = CreateGraphics();

                        Square aShape = new Square(one, two);
                        aShape.draw(g, drawingPen);
                        aShape.ShapeType = "Square";
                        listOfShapes.Add(aShape);// adds the shape to the listOfShapes list

                    }
                }
                else if (selectTriangleStatus == true)
                {
                    if (clicknumber == 0)
                    {
                        one = new Point(e.X, e.Y);
                        clicknumber = 1;
                    }
                    else if (clicknumber == 1)
                    {
                        two = new Point(e.X, e.Y);
                        clicknumber = 2;
                    }
                    else if (clicknumber == 2)
                    {
                        Three = new Point(e.X, e.Y);
                        clicknumber = 0;
                        selectTriangleStatus = false;

                        Graphics g = CreateGraphics();

                        Triangle aTriangle = new Triangle(one, two, Three);
                        aTriangle.draw(g, drawingPen);
                        aTriangle.ShapeType = "Triangle";
                        listOfShapes.Add(aTriangle);
                    }
                }
                else if (selectCircleStatus == true)
                {
                    if (clicknumber == 0)
                    {
                        one = new Point(e.X, e.Y);
                        clicknumber = 1;
                    }
                    else
                    {
                        two = new Point(e.X, e.Y);
                        clicknumber = 0;
                        selectCircleStatus = false;

                        Graphics g = CreateGraphics();

                        Circle aCircle = new Circle(one, two);
                        aCircle.drawCircle(g, drawingPen);
                        aCircle.ShapeType = "Circle";
                        listOfShapes.Add(aCircle);
                    }
                }
                else if (selectRectangleStatus == true)
                {
                    if (clicknumber == 0)
                    {
                        one = new Point(e.X, e.Y);
                        clicknumber = 1;
                    }
                    else
                    {
                        two = new Point(e.X, e.Y);
                        clicknumber = 0;
                        selectRectangleStatus = false;

                        Graphics g = CreateGraphics();

                        Rectangle aRectangle = new Rectangle(one, two);
                        aRectangle.draw(g, drawingPen);
                        aRectangle.ShapeType = "Rectangle";
                        listOfShapes.Add(aRectangle);
                    }
                }
                else if (selectOvalStatus == true)
                {
                    if (clicknumber == 0)
                    {
                        one = new Point(e.X, e.Y);
                        clicknumber = 1;
                    }
                    else
                    {
                        two = new Point(e.X, e.Y);
                        clicknumber = 0;
                        selectOvalStatus = false;

                        Graphics g = CreateGraphics();

                        Oval anOval = new Oval(one, two);
                        anOval.draw(g, drawingPen);
                        anOval.ShapeType = "Oval";
                        listOfShapes.Add(anOval);
                    }
                }
            }
            //the following code adds an object to a list every time a shape has been created
            toolStripComboBox1.Items.Clear();
            toolStripComboBox1.Items.AddRange(listOfShapes.Select(x => x.ShapeType + " " + listOfShapes.IndexOf(x)).ToArray());
        }
    }
}
