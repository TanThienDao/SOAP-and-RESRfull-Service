using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryitPageA6
{
    public partial class StatePopulation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ResultButton_Click(object sender, EventArgs e)
        {
            string url = "http://webstrar59.fulton.asu.edu/Page1/PopulationByState.svc/Population?state=";
            var result = "";
            int final = 0;
            if (!string.IsNullOrWhiteSpace(StateNameBox.Text))
            {
                url = url + StateNameBox.Text;

                using (WebClient client = new WebClient())
                {
                    result = client.DownloadString(url);
                }
                final = Convert.ToInt32(result);
                //ResultLabel.Text = final.ToString();
                if(final==444)
                {
                    ResultLabel.Text = "Error Your Input name of State is wrong, please try again.";
                }
                else if(final==666)
                {
                    ResultLabel.Text = "Error! you let input is Null string.";
                }
                else if(final == 555)
                {
                    ResultLabel.Text = "Error! this error result when you delete null string and leave lenght od string input is 0";
                }
                else
                {
                    //ResultLabel.Text = " Some Error I did not think off ?";
                    ResultLabel.Text = final.ToString();
                }
                //ResultLabel.Text = final.ToString();
            }
            else
            {
                ResultLabel.Text = "Please enter State name.";
            }
        }
    }
}