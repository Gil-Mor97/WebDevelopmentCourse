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

    protected void Button1_Click(object sender, EventArgs e)
    {
        string filename = "MyXMLFile.xml";
        XmlTextWriter a = new XmlTextWriter(Server.MapPath(filename), System.Text.Encoding.UTF8);
        a.WriteStartDocument();

        int gameID = 1;

        a.WriteStartElement("games");
        a.WriteAttributeString("name", "HIT-the-Duck");
        a.WriteAttributeString("authors", "Gil Mor and Anna Strijko");

        a.WriteStartElement("game");
        a.WriteAttributeString("id", gameID.ToString());
        a.WriteAttributeString("gamecode", codeTB.Text);
        a.WriteAttributeString("category", categoryTB.Text);

        a.WriteStartElement("question");
        string qtnID = gameID * 100 + "";
        a.WriteAttributeString("id", qtnID);
        a.WriteString(qtnTB.Text);
        a.WriteEndElement();

        a.WriteStartElement("answer");
        string ansID = (gameID + 100 * gameID) + "";
        a.WriteAttributeString("id", ansID);
        a.WriteAttributeString("qType", typeRBL.SelectedValue);
        a.WriteAttributeString("isCorrect", correctRBL.SelectedValue);
        a.WriteString(contentTB.Text);
        a.WriteEndElement();


        a.WriteEndElement();
        a.WriteEndElement();

        a.WriteEndDocument();
        a.Close();

        Response.Write("<script>alert('The file " + filename + " was created successfully');</script>");
    }
}

/*
<?xml version="1.0" encoding="UTF-8"?>
<games name="HIT-the-Duck" authors="Gil Mor and Anna Strijko">
  <game id="1" category="mammals" gamecode="101">
    <question id="100">Choose only animals which are mammals.</question >
    <answer id="101" qType="image" isCorrect="true">cat1.jpg</answer>
    <answer id="102" qType="image" isCorrect="false">butterfly1.jpg</answer>
    <answer id="103" qType="text" isCorrect="true">Lion</answer>
    <answer id="104" qType="text" isCorrect="false">Caterpiller</answer>
  </game>
 </games>
*/
