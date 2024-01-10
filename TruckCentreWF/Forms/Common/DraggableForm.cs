using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TruckCentreWF.Forms
{
    public class DraggableForm : Form
    {
        private Point mouseLocation;

        public DraggableForm()
        {
            // Set the form's start position to the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // Attach event handlers for mouse down and mouse move on the form
            this.MouseDown += DraggableForm_MouseDown;
            this.MouseMove += DraggableForm_MouseMove;
        }

        private void DraggableForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Save the current mouse location
            mouseLocation = new Point(e.X, e.Y);
        }

        private void DraggableForm_MouseMove(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is pressed
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the new location based on the mouse movement
                Point point = Control.MousePosition;
                point.Offset(-mouseLocation.X, -mouseLocation.Y);

                // Set the new form location
                Location = point;
            }
        }
    
    }
}


