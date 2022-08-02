 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Track_ShuttleRun
{
    public partial class DialogMessage : Form
    {
        public DialogMessage(String message, Color bgColor)
        {
            InitializeComponent();
            BackColor = bgColor;
            textMessage.Text = message;
        }

        private void DialogMessage_Load(object sender, EventArgs e)
        {
            timer_Close.Start();
        }

        private void timer_Close_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCloseMessage_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
