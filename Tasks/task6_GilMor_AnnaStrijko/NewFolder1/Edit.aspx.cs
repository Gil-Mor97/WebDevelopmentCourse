using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string myStudentID = Session["theItemIdSession"].ToString();
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("XMLFiles/students.xml"));
        XmlNode myStudent = myDoc.SelectSingleNode("/students/student[@id='"+myStudentID+"']");

        StudentName.Text = Server.UrlDecode(myStudent.SelectSingleNode("name").InnerText);

    }
}