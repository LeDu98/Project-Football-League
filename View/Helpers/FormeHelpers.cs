using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Helpers
{
    public class FormeHelpers
    {
        public static bool TextFieldValidator(TextBox[] textBoxes)
        {
            bool validate = true;
            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.BackColor = Color.Red;
                    validate = false;
                }
                else
                {
                    textBox.BackColor = Color.White;
                }
            }
            return validate;
        }

       

        
    }
}
