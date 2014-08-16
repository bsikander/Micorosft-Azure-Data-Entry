using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
//Added by behroz - Start
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.Configuration;
//End

namespace ConteoCiudadano
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                Response.Redirect("Account/Login.aspx");
            }
            if (Page.IsPostBack) return;

            UpdateImage();

        }

        protected void UpdateImage()
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Select top 1 Nombre from Acta order by Transcripciones Asc");
            cmd.Connection = cnn;
            string ImageName = (string)cmd.ExecuteScalar();
            cnn.Close();
            Session["Image"] = ImageName;

            //TODO: save the ImageID not FileName in Session
            //TODO:put the value in another place more memory efficient instead session (viewstate?)
            //TODO: Optimize DB Access


            //TODO: Zoom the image to the botom/left 850x588
            //TODO: on button press: update image, Post results, clean textboxes, focus first textbox with Javascript/Ajax dont postback

       
            //Added by Behroz - Start
            Image1.ImageUrl = GetImageFromBlob(ImageName);
            //End- behroz
            
           // imgActa.ImageUrl = @"/Images/Actas/" + ImageName;

            //commented by behroz - start
            //Image1.ImageUrl = @"/Images/Actas/" + ImageName;
            //end - behroz

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            cnn.Open();

            SqlCommand cmdInsert = new SqlCommand("Insert Into Transcripcion (FechaHora,UsuarioID,PAN,PRI,PRD,VERDE,PT,MC,NA,PRI_VERDE,PRD_PT_MC,PRD_PT,PRD_MC,PT_MC,NR,VN,TOTAL) Values  (@FechaHora,@UsuarioID,@PAN,@PRI,@PRD,@VERDE,@PT,@MC,@NA,@PRI_VERDE,@PRD_PT_MC,@PRD_PT,@PRD_MC,@PT_MC,@NR,@VN,@TOTAL)");
            cmdInsert.Connection = cnn;
            
            cmdInsert.Parameters.Add("@FechaHora",SqlDbType.DateTime).Value = DateTime.Now;
            cmdInsert.Parameters.Add("@UsuarioID",SqlDbType.Int).Value = 1;//TODO : Authenticated User ID
            cmdInsert.Parameters.Add("@PAN", SqlDbType.Int).Value = txtPAN.Text;
            cmdInsert.Parameters.Add("@PRI", SqlDbType.Int).Value=txtPRI.Text;
            cmdInsert.Parameters.Add("@PRD", SqlDbType.Int).Value=txtPRD.Text;
            cmdInsert.Parameters.Add("@VERDE", SqlDbType.Int).Value=txtVerde.Text;
            cmdInsert.Parameters.Add("@PT", SqlDbType.Int).Value=txtPT.Text;
            cmdInsert.Parameters.Add("@MC", SqlDbType.Int).Value=txtMC.Text;
            cmdInsert.Parameters.Add("@NA", SqlDbType.Int).Value=txtNA.Text;
            cmdInsert.Parameters.Add("@PRI_VERDE", SqlDbType.Int).Value=txtPRI_Verde.Text;
            cmdInsert.Parameters.Add("@PRD_PT_MC", SqlDbType.Int).Value=txtPRD_PT_MC.Text;
            cmdInsert.Parameters.Add("@PRD_PT", SqlDbType.Int).Value=txtPRD_PT.Text;
            cmdInsert.Parameters.Add("@PRD_MC", SqlDbType.Int).Value=txtPRD_MC.Text;
            cmdInsert.Parameters.Add("@PT_MC", SqlDbType.Int).Value=txtPT_MC.Text;
            cmdInsert.Parameters.Add("@NR", SqlDbType.Int).Value=txtNR.Text;
            cmdInsert.Parameters.Add("@VN", SqlDbType.Int).Value=txtVN.Text;
            cmdInsert.Parameters.Add("@TOTAL", SqlDbType.Int).Value = txtTotal.Text;

            cmdInsert.ExecuteNonQuery();

            SqlCommand cmdUpdate = new SqlCommand("Update Acta set Transcripciones = Transcripciones + 1 Where Nombre = '" + Session["Image"] + "'");
            cmdUpdate.Connection = cnn;
            cmdUpdate.ExecuteNonQuery();

            cnn.Close();

            UpdateImage();

        }

        //Added by behroz
        /// <summary>
        /// This function gets the Images from Blob Storage on Azure
        /// </summary>
        /// <param name="pImageName"></param>
        /// <returns></returns>
        private string GetImageFromBlob(string pImageName)
        {   

            string[] lArr = pImageName.Split('-');
            string lFolderName = lArr[0].Trim();
            if (lFolderName.Trim() != string.Empty)
            {
                #region "Comments"
                
                //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                //ConfigurationManager.AppSettings["StorageConnectionString"]);

                //// Create the blob client
                //CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                //// Retrieve reference to a previously created container
                //CloudBlobDirectory container = blobClient.GetBlobDirectoryReference("actas/" + lFolderName + "/");
                
                ////for testing
                ////int i = 0;
                //// Loop over blobs within the container and output the URI to each of them
                //foreach (var blobItem in container.ListBlobs())
                //{
                //    if (blobItem.Uri.ToString().Contains(pImageName))
                //    {
                //        //for testing
                //        //lbltest.Text = "Total Count:" + i.ToString() + "/ImageName:" + pImageName + "/" + blobItem.Uri.ToString();
                //        return blobItem.Uri.ToString();
                //    }
                //    //i++;
                //}
                #endregion
                string lImageURLComplete = string.Empty;
                lImageURLComplete = ConfigurationManager.AppSettings["BlobURL"] + lFolderName + "/" + pImageName;
                return lImageURLComplete;
            }
            
            //add check here.
            return "";

        }
        //End - behroz
    }
}
