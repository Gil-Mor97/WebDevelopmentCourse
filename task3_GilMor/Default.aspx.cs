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
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("myTree.xml"));

        XmlNodeList a = myDoc.SelectNodes("//title");
        foreach (XmlNode b in a)
        {
            TextBox1.Text += b.InnerXml.ToString() + " ";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("myTree.xml"));

        XmlNodeList a = myDoc.SelectNodes("/catalog/game[@type='casual']/designer");
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
<?xml version="1.0" encoding="utf-8" ?>
<catalog>
  <game type="casual">
    <title rating="everyone">zuma</title>
    <studio>PopCap Games</studio>
    <designer>Jason Kapalka</designer>
    <year>2003</year>
    <price>15.65</price>
  </game>
  <game type="puzzle">
    <title rating="10+">World of Goo</title>
    <studio>2D Boy</studio>
    <designer>Kyle Gabler</designer>
    <designer>Ron Carmel</designer>
    <year>2008</year>
    <price>20.00</price>
  </game>
  <game type="fps">
    <title rating="mature">Far cry</title>
    <studio>Ubisoft</studio>
    <designer>Patrick Redding</designer>
    <designer>Alexandre Amacio</designer>
    <designer>Dominique Guay</designer>
    <designer>Clint Hocking</designer>
    <year>2008</year>
    <price>50.49</price>
  </game>
</catalog>

*/




