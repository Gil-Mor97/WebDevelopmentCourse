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
        XmlTextWriter a = new XmlTextWriter(Server.MapPath("MyXMLFile.xml"), System.Text.Encoding.UTF8);
        a.WriteStartDocument();

        int gameID = 1;

        a.WriteStartElement("games");
        a.WriteAttributeString("name", "HIT-the-Duck");
        a.WriteAttributeString("authors", "Gil Mor and Anna Strijko");

        a.WriteStartElement("game");
        a.WriteAttributeString("id", gameID.ToString());
        a.WriteAttributeString("gamecode", codeTB.Text);
        a.WriteAttributeString("category", categoryTB.Text);

        a.WriteElementString("question", qtnTB.Text);
        a.WriteAttributeString("id", (gameID * 100) + "");

        a.WriteElementString("answer", contentTB.Text);
        a.WriteAttributeString("id", (gameID + 100).ToString());
        a.WriteAttributeString("qType", typeRBL.SelectedValue);
        a.WriteAttributeString("isCorrect", correctRBL.SelectedValue);

        a.WriteEndElement();
        a.WriteEndElement();

        a.WriteEndDocument();
        a.Close();

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
