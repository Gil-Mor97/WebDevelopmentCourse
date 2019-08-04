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

        //String c = "<?xml version='1.0' encoding='utf-8'?><catalog><game type=‘casual’><title rating='everyone'>zuma</title><studio>PopCap Games</studio><designer>Jason Kapalka</designer><year>2003</year><price>15.65</price></game></catalog>";
        //XmlDocument myDoc = new XmlDocument();
        //myDoc.LoadXml(c);
        //XmlNode my_node;

        //my_node = myDoc.SelectNodes("/catalog/game").Item(0);
        //TextBox1.Text = my_node.OuterXml.ToString();
        //TextBox2.Text = Convert.ToString(myDoc.SelectNodes("/catalog/game").Count);

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




