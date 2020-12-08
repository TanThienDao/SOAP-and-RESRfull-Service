using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryitPageA6
{
    public partial class NaturalHazardPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            CombineSoapService.Service1Client proxyNH = new CombineSoapService.Service1Client();
            try
            {
                if (String.IsNullOrWhiteSpace(LattitudeBox.Text) && String.IsNullOrWhiteSpace(LongtitudeBox.Text))
                {
                    RRRLabel.Text = "Please enter value in both boxs.";
                }
                else if (string.IsNullOrWhiteSpace(LongtitudeBox.Text))
                {
                    RRRLabel.Text = "Please enter value in  longitude box.";
                }
                else if (string.IsNullOrWhiteSpace(LattitudeBox.Text))
                {
                    RRRLabel.Text = "Please enter value in latitude box.";
                }
                else
                {
                    decimal lat = Convert.ToDecimal(LattitudeBox.Text);
                    decimal lon = Convert.ToDecimal(LongtitudeBox.Text);
                    if ((lon <= -180 || lon >= 180) && (lat <= -90 || lat >= 90))
                    {
                        RRRLabel.Text = "Invalid for longtitude and Latitude!" +
                            " Valid latitude are -90 <= latitude <= 90 and " +
                            "longtitude are -180 <= longitude <= 180 ";
                    }
                    else if (lon <= -180 || lon >= 180)
                    {
                        RRRLabel.Text = "Invalid for longtitude, Valid values are -180 <= longitude <= 180";
                    }
                    else if (lat <= -90 || lat >= 90)
                    {
                        RRRLabel.Text = "Invalid for latitude,Valid values are -90 <= latitude <= 90";
                    }
                    else
                    {
                        decimal result = proxyNH.NaturalHazards(lat, lon);
                        RRRLabel.Text = result.ToString();

                    }

                }
            }
            catch(Exception ec)
            {
                RRRLabel.Text = "Error input!";
            }
        }
    }
}