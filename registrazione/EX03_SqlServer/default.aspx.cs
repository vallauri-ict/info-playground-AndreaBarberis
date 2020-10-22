using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EX03_SqlServer
{
    public partial class _default : System.Web.UI.Page
    {
        clsDB db;
        protected void Page_Load(object sender, EventArgs e)
        {
            //la connessione al db va SEMPRE fatta 
            db = new clsDB("App_Data\\registra.mdf");
            if(!Page.IsPostBack)
            {
              popolaCmbRegioni();
            }
        }

        private void popolaCmbRegioni()
        {
          
                cmbRegioni.DataSource = db.caricaRegioni();
                cmbRegioni.DataValueField = "idRegione";
                cmbRegioni.DataTextField = "Regione";
                //OBBLIGATORIO per tutti gli oggetti a cui assocciamo un DataSource
                cmbRegioni.DataBind();
                ListItem l = new ListItem();
                l.Value = "-1";
                l.Text = "---Seleziona Regione---";
                cmbRegioni.Items.Insert(0, l);
                //in questo modo posso gestire sempre selectedIndexchanged
                cmbRegioni.AutoPostBack = true;
        }

        protected void cmbRegioni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbRegioni.SelectedValue=="-1")
            {
                cmbProvince.DataSource = null;
                cmbProvince.DataBind();
                cmbProvince.Items.Clear();
                cmbComuni.DataSource = null;
                cmbComuni.DataBind();
                cmbComuni.Items.Clear();
            }
            else
            {
                cmbProvince.DataSource = db.caricaProvince(cmbRegioni.SelectedValue);
                cmbProvince.DataValueField = "idProvincia";
                cmbProvince.DataTextField = "Provincia";
                //OBBLIGATORIO per tutti gli oggetti a cui assocciamo un DataSource
                cmbProvince.DataBind();
                cmbProvince.AutoPostBack = true;
            }
        }

        protected void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbComuni.DataSource = db.caricaComuni(cmbProvince.SelectedValue);
            cmbComuni.DataValueField = "idComune";
            cmbComuni.DataTextField = "Comune";
            //OBBLIGATORIO per tutti gli oggetti a cui assocciamo un DataSource
            cmbComuni.DataBind();
            cmbComuni.AutoPostBack = true;
        }

        protected void btnInvia_Click(object sender, EventArgs e)
        {
            string idUtente;
            try
            {
                db.Cognome = txtCognome.Text;
                db.Nome = txtNome.Text;
                db.DataNascita = TxtData.Text;
                db.Comuni = cmbComuni.SelectedValue;
                db.Province = cmbProvince.SelectedValue;
                db.Regioni = cmbRegioni.SelectedValue;
                db.Password = txtPassword.Text;
                db.Username = txtUsername.Text;
                idUtente=db.registra();
                messaggio.Text = "Utente inserito con idUtente= " + idUtente;
                H1Saluto.InnerText = "Benvenuto " + txtUsername.Text;
            }
            catch(Exception ex)
            {
                messaggio.Text = "Errore: "+ex;
            }
        }

        protected void txtNome_TextChanged(object sender, EventArgs e)
        {
            messaggio.Text = "...";
        }

        protected void txtCognome_TextChanged(object sender, EventArgs e)
        {
            messaggio.Text = "...";
        }

        protected void TxtData_TextChanged(object sender, EventArgs e)
        {
            messaggio.Text = "...";
        }
    }
}