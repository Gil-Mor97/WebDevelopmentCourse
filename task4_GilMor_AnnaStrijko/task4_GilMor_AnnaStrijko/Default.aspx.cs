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
        string gamecode = TextBox1.Text;
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("myTree.xml"));

        XmlNodeList a = myDoc.SelectNodes("/games/game[@gamecode='" + gamecode + "']");
        foreach (XmlNode b in a)
        {
            TextBox1.Text += b.InnerXml.ToString() + " ";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string gamecode = TextBox2.Text;

        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("myTree.xml"));

        XmlNodeList a = myDoc.SelectNodes("/games/game[@gamecode='" + gamecode +"']/designer");
        foreach (XmlNode b in a)
        {
            TextBox2.Text += b.InnerXml.ToString() + " ";
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("myTree.xml"));

        XmlNodeList a = myDoc.SelectNodes("/catalog/game[3]/designer[3]");
        foreach (XmlNode b in a)
        {
            TextBox3.Text += b.InnerXml.ToString() + " ";
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("myTree.xml"));

        XmlNodeList a = myDoc.SelectNodes("/catalog/game[year<2005]/title");
        foreach (XmlNode b in a)
        {
            TextBox4.Text += b.InnerXml.ToString() + " ";
        }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("myTree.xml"));

        XmlNodeList a = myDoc.SelectNodes("/catalog/game[price=50.49]/title[@rating='mature']");
        foreach (XmlNode b in a)
        {
            TextBox5.Text += b.InnerXml.ToString() + " ";
        }

    }
}

/*
<?xml version="1.0" encoding="utf-8"?>
<games name="HIT-the-Duck" authors="Gil Mor and Anna Strijko">
  <game id="1" gamecode="101" name="יונקים" isPublished="true">
    <question id="100">לחצו רק על בעלי חיים השייכים למשפחת היונקים</question>
    <answer id="101" qType="img" isCorrect="false">butterfly.png</answer>
    <answer id="102" qType="img" isCorrect="true">lion.png</answer>
    <answer id="103" qType="txt" isCorrect="true">dolphin.png</answer>
    <answer id="104" qType="txt" isCorrect="false">זחל</answer>
    <answer id="105" qType="img" isCorrect="false">שקנאי</answer>
    <answer id="106" qType="img" isCorrect="true">לוויתן</answer>
    <answer id="107" qType="txt" isCorrect="false">snake.png</answer>
    <answer id="108" qType="txt" isCorrect="true">cat.png</answer>
    <answer id="109" qType="img" isCorrect="false">כריש</answer>
    <answer id="110" qType="txt" isCorrect="true">כלב</answer>
  </game>
  <game id="2" gamecode="102" name="ערי בירה" isPublished="false">
    <question id="200">לחצו רק על ערי הבירה</question>
    <answer id="202" qType="txt" isCorrect="false">תל אביב</answer>
    <answer id="202" qType="txt" isCorrect="true">ירושלים</answer>
    <answer id="203" qType="txt" isCorrect="true">וושינגטון די.סי.</answer>
    <answer id="204" qType="txt" isCorrect="false">חיפה</answer>
    <answer id="205" qType="txt" isCorrect="false">ניו יורק</answer>
    <answer id="206" qType="txt" isCorrect="true">טוקיו</answer>
    <answer id="207" qType="txt" isCorrect="false">לוס אנג'לס</answer>
    <answer id="208" qType="txt" isCorrect="true">קהיר</answer>
    <answer id="209" qType="txt" isCorrect="false">סידני</answer>
    <answer id="210" qType="txt" isCorrect="true">אנקרה</answer>
  </game>
</games>


*/




