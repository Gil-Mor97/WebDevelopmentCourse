using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        XmlDocument xmlDoc = XmlDataSource1.GetXmlDocument();
        int myId = Convert.ToInt16(xmlDoc.SelectSingleNode("//idCounter").InnerXml);
        myId++;
        string myNewId = myId.ToString();
        xmlDoc.SelectSingleNode("//idCounter").InnerXml = myNewId;
        // יצירת ענף סטודנט     
        XmlElement myNewStudentNode = xmlDoc.CreateElement("student");
        myNewStudentNode.SetAttribute("id", myNewId);
        myNewStudentNode.SetAttribute("isPass", "false");

        // יצירת ענף שם הסטודנט
        XmlElement myNewNameNode = xmlDoc.CreateElement("name");
        myNewNameNode.InnerXml = Server.UrlEncode(addNameTB.Text);
        myNewStudentNode.AppendChild(myNewNameNode);

        // יצירת ענף ציונים ללא הציונים עצמם
        XmlElement myGradesNode = xmlDoc.CreateElement("grades");
        myNewStudentNode.AppendChild(myGradesNode);

        XmlNode FirstStudent = xmlDoc.SelectNodes("/students/student").Item(0);
        xmlDoc.SelectSingleNode("/students").InsertBefore(myNewStudentNode, FirstStudent);
        XmlDataSource1.Save();
        GridView1.DataBind();
        addNameTB.Text = "";


    }

    // פונקציה זו תרוץ בעת לחיצה על תיבות הטקסט
    protected void isPassCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        // טעינה של העץ
        XmlDocument xmlDoc = XmlDataSource1.GetXmlDocument();
        // תחילה אנו מבררים מהו ה -אי די- של הפריט בעץ ה אקס אם אל
        CheckBox myCheckBox = (CheckBox)sender;
        // מושכים את האי די של הפריט באמצעות המאפיין שהוספנו באופן ידני לתיבה
        string theId = myCheckBox.Attributes["theItemId"];
        //שאילתא למציאת הסטודנט שברצוננו לעדכן
        XmlNode theStudents = xmlDoc.SelectSingleNode("/students/student[@id=" + theId + "]");

        //קבלת הערך החדש של התיבה לאחר הלחיצה
        bool NewIsPass = myCheckBox.Checked;

        //עדכון של המאפיין בעץ
        theStudents.Attributes["isPass"].InnerText = NewIsPass.ToString();
        //שמירה בעץ והצגה
        XmlDataSource1.Save();
        GridView1.DataBind();

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        // תחילה אנו מבררים מהו ה -אי די- של הפריט בעץ ה אקס אם אל
        ImageButton i = (ImageButton)e.CommandSource;
        // אנו מושכים את האי די של הפריט באמצעות מאפיין לא שמור במערכת שהוספנו באופן ידני לכפתור-תמונה
        string theId = i.Attributes["theItemId"];
        Session["theItemIdSession"] = i.Attributes["theItemId"];


        // עלינו לברר איזו פקודה צריכה להתבצע - הפקודה רשומה בכל כפתור             
        switch (e.CommandName)
        {
            //אם נלחץ על כפתור מחיקה יקרא לפונקציה של מחיקה                    
            case "deleteRow":
                deleteRow(theId);
                break;

            //אם נלחץ על כפתור עריכה (העפרון) נעבור לדף עריכה                    
            case "editRow":

                Response.Redirect("Edit.aspx");
                break;
        }

    }
    //מחיקת סטודנט
    void deleteRow(string theItemId)
    {
        //הסרת ענף של משחק קיים באמצעות זיהוי האיי דיי שניתן לו על ידי לחיצה עליו מתוך הטבלה
        //שמירה ועדכון לתוך העץ ולגריד ויו
        XmlDocument Document = XmlDataSource1.GetXmlDocument();
        XmlNode node = Document.SelectSingleNode("/students/student[@id='" + theItemId + "']");
        node.ParentNode.RemoveChild(node);

        XmlDataSource1.Save();
        GridView1.DataBind();

    }

}