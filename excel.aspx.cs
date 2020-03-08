using System;
using System.IO;

namespace testexcelupload
{
    public partial class excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload1.PostedFile.FileName; // getting the file path of uploaded file  
            string filename1 = Path.GetFileName(filePath); // getting the file name of uploaded file  
            string ext = Path.GetExtension(filename1); // getting the file extension of uploaded file  
            string type = String.Empty;
            if (!FileUpload1.HasFile)
            {
                Response.Write("Please Select File"); //if file uploader has no file selected  
            }
            else
            if (FileUpload1.HasFile)
            {
                try
                {
                    switch (ext) // this switch code validate the files which allow to upload only excel file you can change it for any file  
                    {
                        case ".xls":
                            type = "application/vnd.ms-excel";
                            break;
                        case ".xlsx":
                            type = "application/vnd.ms-excel";
                            break;
                    }
                    /*if(ext!=".xls"||ext!=".xlsx")
                    {
                        Response.Write("upload only excel files");
                    }*/
                    //Response.Write(ext);
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
                /*if (type != String.Empty)
                {
                    MySqlConnection con = new MySqlConnection(@"server=localhost,userid=root,password=root,database=ajax");
                    Stream fs = FileUpload1.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs); //reads the   binary files  
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length); //counting the file length into bytes  
                    con.Open();
                    string query = "insert into excelupload(Name,type,data) values (@Name, @type, @Data)"; //insert query  
                    MySqlCommand com = new MySqlCommand(query, con);
                    com.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = filename1;
                    com.Parameters.AddWithValue("@type", SqlDbType.VarChar).Value = type;
                    com.Parameters.AddWithValue("@Data", SqlDbType.Binary).Value = bytes;
                    com.ExecuteNonQuery();
                    con.Close();
                }*/
            }
        }
    }
}
