using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryitPageA6
{
    public partial class RainFall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PopulationButton_Click(object sender, EventArgs e)
        {
            CombineSoapService.Service1Client proxy = new CombineSoapService.Service1Client();
            if(!string.IsNullOrWhiteSpace(LocationNameBox.Text))
            {
                ResultRainCondition.Text=proxy.RainFall(LocationNameBox.Text);
            }
            else
            {
                ResultRainCondition.Text = "Please enter Location!";
            }
        }
    }
}