using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;

namespace TryItPage
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NatHazButton_Click(object sender, EventArgs e)
        {
            NaturalHazards.Service1Client proxyNH = new NaturalHazards.Service1Client();

           try
            {
                if (String.IsNullOrWhiteSpace(LatBox.Text) && String.IsNullOrWhiteSpace(LongBOx.Text))
                {
                    ResultNarHaz.Text = "Please enter value in both boxs.";
                }
                else if (string.IsNullOrWhiteSpace(LongBOx.Text))
                {
                    ResultNarHaz.Text = "Please enter value in  longitude box.";
                }
                else if (string.IsNullOrWhiteSpace(LatBox.Text))
                {
                    ResultNarHaz.Text = "Please enter value in latitude box.";
                }
                else
                {
                    decimal lat = Convert.ToDecimal(LatBox.Text);
                    decimal lon = Convert.ToDecimal(LongBOx.Text);
                    if ((lon <= -180 || lon >= 180) && (lat <= -90 || lat >= 90))
                    {
                        ResultNarHaz.Text = "Invalid for longtitude and Latitude!" +
                            " Valid latitude are -90 <= latitude <= 90 and " +
                            "longtitude are -180 <= longitude <= 180 ";
                    }
                    else if (lon <= -180 || lon>= 180 )
                    {
                        ResultNarHaz.Text = "Invalid for longtitude, Valid values are -180 <= longitude <= 180";
                    }
                    else if (lat<= -90 || lat>=90)
                    {
                        ResultNarHaz.Text = "Invalid for latitude,Valid values are -90 <= latitude <= 90";
                    }
                    else
                    {
                        decimal result = proxyNH.NaturalHazards(lat, lon);
                        ResultNarHaz.Text = result.ToString();

                    }
                    
                }
            }
            catch(Exception ec)
            {
                ResultNarHaz.Text = "Error Input !";
            }

        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            NewsForcus2.Service1Client proxyNF = new NewsForcus2.Service1Client();
            string[] inputRe;
            string[] result;
            List<string> resultList= new List<string>();
            string output = "";
            
            //try
            {
                if (String.IsNullOrWhiteSpace(InputNewForcusBox.Text))
                {
                    OutPutNewForcusBox.Text = "Please type input!";
                }
                else
                {
                    List<string> strinList = new List<string>();

                    foreach (string item in InputNewForcusBox.Text.Split(','))
                    {
                        strinList.Add(item);
                    }
                    inputRe = strinList.ToArray();
                    result = proxyNF.NewsForcusService(inputRe);
                    resultList = result.ToList();
                    string newLine = Environment.NewLine;
                    for (int i = 0; i < result.Length; i++)
                    {
                        output = output + (i + 1).ToString() + ": " + result[i] + newLine;

                    }
                    OutPutNewForcusBox.Text = output;
                    //OutPutNewForcusBox.Text = string.Join("\n", resultList);

                    
                    
                    //ListBox1.Items.Add(output);
                    //return View(strinList);
                   

                }
            }
           /* catch(Exception ec)
            {
                OutPutNewForcusBox.Text = "Error Input!";
            }*/
        }

        
    }
}