using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryitPageA6
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreatedButton_Click(object sender, EventArgs e)
        {
            CombineSoapService.Service1Client proxy = new CombineSoapService.Service1Client();
            if(!string.IsNullOrWhiteSpace(UsernameBox.Text)&&!string.IsNullOrWhiteSpace(PasswordBox.Text) )
            {
                bool create =proxy.AccontService(UsernameBox.Text, PasswordBox.Text);
                if(create)
                {
                    ResultLabel.Text = "Account creates sucessful.";
                }
                else
                {
                    ResultLabel.Text = "Username already exit, please enter different username.";
                }
            }
            else
            {
                ResultLabel.Text = "Please enter your infomation. ";
            }
        }
    }
}