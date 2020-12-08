using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryitPageA6
{
    public partial class NewsForcus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CombineSoapService.Service1Client proxy = new CombineSoapService.Service1Client();
            string[] inputRe;
            string[] result;
            List<string> resultList = new List<string>();
            string output = "";
            try
            {
                if(string.IsNullOrWhiteSpace(InputNewForcusBox.Text))
                {
                    OutOutNewForcusBox.Text = "Please type Input!";
                }
                else
                {
                    List<string> strinList = new List<string>();

                    foreach (string item in InputNewForcusBox.Text.Split(','))
                    {
                        strinList.Add(item);
                    }
                    inputRe = strinList.ToArray();
                    result = proxy.NewsForcusService(inputRe);
                    resultList = result.ToList();
                    string newLine = Environment.NewLine;
                    for (int i = 0; i < result.Length; i++)
                    {
                        output = output + (i + 1).ToString() + ": " + result[i] + newLine;

                    }
                    OutOutNewForcusBox.Text = output;
                }
            }
            catch(Exception ec)
            {
                OutOutNewForcusBox.Text = "Error !";
            }
        }
    }
}