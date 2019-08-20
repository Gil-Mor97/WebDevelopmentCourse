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
    int gamecode;
    if (int.TryParse(code_TB.Text, out gamecode))
    {
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("myTree.xml"));

        XmlNodeList a = myDoc.SelectNodes("/games/game[@gamecode='" + gamecode + "']/@isPublished");
        TextBox1.Text = "";
        foreach (XmlNode b in a)
        {
            TextBox1.Text += b.InnerXml.ToString() + " ";
        }
        bool flag;
        bool.TryParse(TextBox1.Text, out flag);
        if (flag)
        {
            TextBox1.Text = "המשחק מפורסם";
        }
        else
        {
            TextBox1.Text = "המשחק אינו מפורסם";
        }
    }
    else
    {
        TextBox1.Text = "נא להזין קוד משחק העשוי ממספרים בלבד";
    }

}

protected void Button2_Click(object sender, EventArgs e)
{
    int gamecode;
    if (int.TryParse(code_TB.Text, out gamecode))
    {
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("myTree.xml"));

        XmlNodeList a = myDoc.SelectNodes("/games/game[@gamecode='" + gamecode + "']/@name");
        TextBox2.Text = "";
        foreach (XmlNode b in a)
        {
            TextBox2.Text += b.InnerXml.ToString() + " ";
        }
    }
    else
    {
        TextBox2.Text = "נא להזין קוד משחק העשוי ממספרים בלבד";
    }
}

protected void Button3_Click(object sender, EventArgs e)
{
    int gamecode;
    if (int.TryParse(code_TB.Text, out gamecode))
    {
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("myTree.xml"));

        XmlNodeList a = myDoc.SelectNodes("/games/game[@gamecode='" + gamecode + "']/answer");
        TextBox3.Text = "";
        foreach (XmlNode b in a)
        {
            TextBox3.Text += b.InnerXml.ToString() + "\n";
        }
        TextBox3.Text = TextBox3.Text.Substring(0, TextBox3.Text.Length - 1);
    }
    else
    {
        TextBox3.Text = "נא להזין קוד משחק העשוי ממספרים בלבד";
    }
}

protected void Button4_Click(object sender, EventArgs e)
{
    int gamecode;
    if (int.TryParse(code_TB.Text, out gamecode))
    {
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("myTree.xml"));

        XmlNodeList a = myDoc.SelectNodes("/games/game[@gamecode='" + gamecode + "']/answer[1]/@qType");
        TextBox4.Text = "";
        foreach (XmlNode b in a)
        {
            TextBox4.Text += b.InnerXml.ToString() + "\n";
        }
    }
    else
    {
        TextBox4.Text = "נא להזין קוד משחק העשוי ממספרים בלבד";
    }
}

protected void Button5_Click(object sender, EventArgs e)
{
    int gamecode;
    if (int.TryParse(code_TB.Text, out gamecode))
    {
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("myTree.xml"));

        XmlNodeList a = myDoc.SelectNodes("/games/game[@gamecode='" + gamecode + "']/answer");
        TextBox5.Text = "";
        int count = 0;
        foreach (XmlNode b in a)
        {
            count++;
        }
        TextBox5.Text = "במשחק יש " + count + " מסיחים";
    }
    else
    {
        TextBox5.Text = "נא להזין קוד משחק העשוי ממספרים בלבד";
    }        
}

protected void submit_Click(object sender, EventArgs e)
{
    Button1_Click(sender, e);
    Button2_Click(sender, e);
    Button3_Click(sender, e);
    Button4_Click(sender, e);
    Button5_Click(sender, e);
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
    <answer id="211" qType="txt" isCorrect="true">פריז</answer>
    <answer id="212" qType="txt" isCorrect="false">מנצ'סטר</answer>
  </game>
</games>


*/




