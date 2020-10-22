using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ADOSQLServer2017_ns;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public class clsDB
    {
        ADOSQLServer2017 ado;
        private string cognome;
        private string nome;
        private string username;
        private string password;
        private string dataNascita;
        private string comuni;
        private string province;
        private string regioni;

    public string Cognome 
    { 
        get 
        {
            return cognome; 
        }
        set 
        {
            if (value.Length < 3)
            {
                throw new Exception("Cognome non valido");
            }
            else
                cognome = value;
        } 
    }
    

    public string Nome
    {
        get
        {
            return nome;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new Exception("Nome non valido");
            }
            else
                nome = value;
        }
    }
   

    public string Username
    {
        get
        {
            return username;
        }
        set
        {
            if (value.Length < 5)
            {
                throw new Exception("username non valido");
            }
            else
                username = value;
        }
    }
   

    public string Password
    {
        get
        {
            return password;
        }
        set
        {
            if (value.Length < 6)
            {
                throw new Exception("Password non valida");
            }
            else
                password = value;
        }
    }
   

    public string DataNascita
    {
        get
        {
            return dataNascita;
        }
        set
        {
            try
            {
                DateTime d = Convert.ToDateTime(value);
                dataNascita = value;
            }
            catch (Exception)
            {
                throw new Exception("Data non valida");
            }
            if (value.Length < 3)
            {
                throw new Exception("Data non valida");
            }
            else
                dataNascita = value;
        }
    }
    public string Comuni
    {
        get
        {
            return comuni;
        }
        set
        {
                comuni = value;
        }
    }
    public string Province
    {
        get
        {
            return province;
        }
        set
        {
            province = value;
        }
    }
    public string Regioni
    {
        get
        {
            return regioni;
        }
        set
        {
            regioni = value;
        }
    }

    public clsDB (string nomeDB)
    {
            this.ado = new ADOSQLServer2017(nomeDB);
    }

    public DataTable caricaRegioni()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText += "SELECT * FROM Regioni ORDER BY Regione ASC";
        cmd.CommandType = CommandType.Text;
        return ado.EseguiQuery(cmd);
    }

    public string registra()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText += "Insert into Utente (Nome, Cognome, Data_nascita, ComuneNascita, ProvinciaNascita, RegioneNascita, Username, Pwd) VALUES (@Nome, @Cognome, @Data_nascita, @ComuneNascita, @ProvinciaNascita, @RegioneNascita, @Username, @Pwd)";
        //per ritornare la chiave primaria del record inserito
        cmd.CommandText += "SELECT SCOPE_IDENTITY() ";
        cmd.Parameters.AddWithValue("@Nome", nome);
        cmd.Parameters.AddWithValue("@Cognome", cognome);
        cmd.Parameters.AddWithValue("@Data_nascita", dataNascita);
        cmd.Parameters.AddWithValue("@ComuneNascita", comuni);
        cmd.Parameters.AddWithValue("@ProvinciaNascita", province);
        cmd.Parameters.AddWithValue("@RegioneNascita", regioni);
        cmd.Parameters.AddWithValue("@Username", username);
        cmd.Parameters.AddWithValue("@Pwd", password);
        cmd.CommandType = CommandType.Text;
        return ado.EseguiScalar(cmd).ToString();
    }

    public DataTable caricaProvince(string id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText += "SELECT * FROM Province WHERE IdRegione =@idRegione ORDER BY Provincia ASC";
        cmd.Parameters.AddWithValue("@idRegione", id);
        cmd.CommandType = CommandType.Text;
        return ado.EseguiQuery(cmd);
    }

    public DataTable caricaComuni(string id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText += "SELECT * FROM Comuni WHERE IdProvincia =@idProvincia ORDER BY Comune ASC";
        cmd.Parameters.AddWithValue("@idProvincia", id);
        cmd.CommandType = CommandType.Text;
        return ado.EseguiQuery(cmd);
    }
}
