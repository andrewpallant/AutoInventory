using AutoInventory.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoInventory
{
    public partial class EditCar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtYear.Attributes["max"] = "" + DateTime.Now.Year;

            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request["id"]))
                {
                    String strID = Request["id"];
                    Int32 id = Int32.Parse(strID);
                    Automobile car = Automobile.getCar(id);
                    if (car.ID > 0)
                    {
                        txtManufacturer.Text = car.Manufacturer;
                        txtMake.Text = car.Make;
                        txtYear.Text = "" + car.Year;
                        txtColour.Text = car.Colour;
                        txtSeating.Text = "" + car.Seating;
                    }
                    else
                    {
                        // For Some Reason I cannot Find the Car
                        Response.Redirect("CarInventory.aspx");
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Automobile car = new Automobile();
            if (!String.IsNullOrEmpty(Request["id"]))
            {
                String strID = Request["id"];
                Int32 id = Int32.Parse(strID);
                car = Automobile.getCar(id);
            }
            else
            {
                car.ID = 0;
            }

            car.Manufacturer = txtManufacturer.Text;
            car.Make = txtMake.Text;
            car.Year = Int32.Parse(txtYear.Text);
            car.Colour = txtColour.Text;
            car.Seating = Int32.Parse(txtSeating.Text);

            car = car.Save();

            if (car.ID > 0)
            {
                Response.Redirect("CarInventory.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request["id"]))
            {
                String strID = Request["id"];
                Int32 id = Int32.Parse(strID);
                Automobile car = Automobile.Delete(id);
                if(car.ID > 0)
                {
                    Response.Redirect("CarInventory.aspx");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarInventory.aspx");
        }
    }
}