using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CemeterySystem.App_Start;
using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using CemeterySystem.Services;



namespace CemeterySystem.Pages
{

    public partial class DeadPersonsDetails : System.Web.UI.Page
    {

        public bool IsCreateMode
        {
            get
            {
                return ("" + this.Request.QueryString["IsCreateMode"]).Trim().ToLower().Equals("true");
            }
        }


        public Guid DeadPersonID
        {
            get
            {
                try
                {
                    return Guid.Parse("" + this.Request.QueryString["DeadPersonID"]);
                }
                catch (Exception ex) { }
                return Guid.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!this.User.Identity.IsAuthenticated || !this.User.IsInRole(UserRoleRepository.MANAGER_ROLE_NAME))
                {
                    Response.Redirect("/Pages/LoginPage.aspx");
                }
                else
                {
                    bindGenderDropdownList();
                    bindBurialPlaceDropdownList();
                    bindFuneralCompanyDropdownList();
                    bindStaffList();

                    if (IsCreateMode)
                    {
                        btnDelete.Visible = false;
                    }
                    else
                    {
                        btnDelete.Visible = true;

                        ddlFuneralCompany.Visible = false;
                        lblFuneralCompany.Visible = false;
                        ddlStaffPerson.Visible = false;
                        lblStaffPerson.Visible = false;
                        txtFuneralDate.Visible = false;
                        lblFuneralDate.Visible = false;
                        lblDataOfFuneral.Visible = false;


                        this.loadDeadPerson();
                    }
                }
            }
        }

        private void loadDeadPerson()
        {
            DeadPerson deadPerson = new DeadPersonService().getByID(DeadPersonID.ToString());



            if (deadPerson != null)
            {

                txtFirstName.Text = deadPerson.FirstName.ToString();

                txtLastName.Text = deadPerson.LastName.ToString();

                txtPesel.Text = deadPerson.PESEL.ToString();

                ddlGender.DataSource = Enum.GetNames(typeof(EnumGender));

                int gender;
                if (deadPerson.Gender.ToString().Equals("MALE"))
                {
                    gender = 0;
                }
                else
                {
                    gender = 1;
                }

                ddlGender.SelectedValue = gender.ToString();


                ddlGraveNumber.SelectedValue = deadPerson.BurialPlaceID.ToString();

                Funeral funeral = new FuneralService().getByID(deadPerson.FuneralID.ToString());

                txtFuneralDate.Text = funeral.FuneralShortDateFormatted;



            }
            else
            {
                Response.Redirect("/Pages/DeadPersonsList.aspx");
            }
        }

        private void bindGenderDropdownList()
        {
            try
            {
                Utils.populateDropdownWithEnum(typeof(EnumGender), ddlGender);
            }
            catch (Exception ex) { }
        }




        private void bindBurialPlaceDropdownList()
        {
            try
            {
                List<BurialPlace> listBurialPlace = new BurialPlaceService().getAll();
                //ddlFieldNumber.Items.AddRange(listBurialPlace.Select(x => new ListItem(x.FieldNumber, x.BurialPlaceID.ToString())).ToArray());

                //ddlGraveNumber.Items.AddRange(listBurialPlace.Select(x => new ListItem(x.GraveNumber, x.BurialPlaceID.ToString())).ToArray());

                //ddlGraveNumber.Items.AddRange(listBurialPlace.Select(x => new ListItem(x.FieldFormatted, x.BurialPlaceID.ToString())).ToArray());
                ddlGraveNumber.Items.AddRange(listBurialPlace.OrderBy(x => x.FieldFormatted).Select(x => new ListItem(x.FieldFormatted, x.BurialPlaceID.ToString())).ToArray());



            }
            catch (Exception ex) { }
        }



        private void bindFuneralCompanyDropdownList()
        {
            try
            {
                List<FuneralCompany> listCompany = new FuneralCompanyService().getAll();
                ddlFuneralCompany.Items.AddRange(listCompany.Select(x => new ListItem(x.Name, x.FuneralCompanyID.ToString())).ToArray());
            }
            catch (Exception ex) { }
        }

        private void bindStaffList()
        {
            try
            {
                List<CemeteryStaffPerson> staffList = new CemeteryStaffPersonService().getAll();
                ddlStaffPerson.Items.AddRange(staffList.Select(x => new ListItem(x.LastName, x.CemeteryStaffPersonID.ToString())).ToArray());
            }
            catch (Exception ex) { }
        }




        private void saveDeadPerson()
        {

            Funeral funeral = null;

            DeadPerson deadPerson = null;

            if (IsCreateMode)
            {

                funeral = new Funeral()
                {
                    FuneralID = Guid.NewGuid()
                };

                deadPerson = new DeadPerson()
                {
                    DeadPersonID = Guid.NewGuid()
                };
            }
            else
            {
                deadPerson = new DeadPersonService().getByID(this.DeadPersonID.ToString());
                funeral = new FuneralService().getByID(deadPerson.FuneralID.ToString());

            }

            FuneralCompany funeralCompany = new FuneralCompanyService().getByID(ddlFuneralCompany.SelectedValue);
            CemeteryStaffPerson cemeteryStaff = new CemeteryStaffPersonService().getByID(ddlStaffPerson.SelectedValue);
            funeral.FuneralDate = DateTime.ParseExact(txtFuneralDate.Text.Trim(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            funeral.FuneralCompanyID = funeralCompany.FuneralCompanyID;
            funeral.CemeteryStaffPersonID = cemeteryStaff.CemeteryStaffPersonID;



            BurialPlace burialPlace = new BurialPlaceService().getByID(ddlGraveNumber.SelectedValue);
            deadPerson.FirstName = txtFirstName.Text;
            deadPerson.LastName = txtLastName.Text;
            deadPerson.PESEL = txtPesel.Text;
            deadPerson.Gender = (EnumGender)int.Parse(ddlGender.SelectedValue);
            deadPerson.BurialPlaceID = burialPlace.BurialPlaceID;
            deadPerson.FuneralID = funeral.FuneralID;


            if (IsCreateMode)
            {
                new FuneralService().create(funeral);

                new DeadPersonService().create(deadPerson);
                Response.Redirect(string.Format("/Pages/DeadPersonsDetails?DeadPersonID={0}", deadPerson.DeadPersonID.ToString()));
            }
            else
            {
                new DeadPersonService().update(deadPerson);
            }
        }



        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {

            DeadPerson deadPerson = new DeadPersonService().getByID(DeadPersonID.ToString());
            if (deadPerson != null)
            {
                new DeadPersonService().delete(deadPerson);
            }
            Response.Redirect("/Pages/DeadPersonsList.aspx");
            //Response.Redirect("/Pages/DeadPersonsList.aspx");

        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {

            saveDeadPerson();


        }

        protected void lbtnGoBack_ServerClick(object sender, EventArgs e)
        {

            Response.Redirect("/Pages/DeadPersonsList");

        }
    }
}