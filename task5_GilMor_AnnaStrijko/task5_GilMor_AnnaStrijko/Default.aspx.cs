using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("tree/myTree.xml"));

        //טעינת המשחקים כדי ליצור רשימה של קודי משחק
        XmlNodeList dd_a = myDoc.SelectNodes("/games//game");
        foreach (XmlNode b in dd_a)
        {
            ListItem listItem = new ListItem();
            listItem.Text = b.Attributes["gamecode"].InnerXml.ToString();
            listItem.Value = b.Attributes["gamecode"].InnerXml.ToString();
            DropDownList1.Items.Add(listItem);
        }

        DropDownList1.SelectedIndex = 0; //אתחול ערך ברירת מחדל לרשימה
        DropDownList1.DataBind();

        int gamecode = int.Parse(DropDownList1.SelectedItem.Text);
        //טעינת הפריטים לרשימה
        XmlNodeList a = myDoc.SelectNodes("/games/game[@gamecode='" + gamecode + "']//answer");
        int indx = 1;
        foreach (XmlNode b in a)
        {
            ListItem listItem = new ListItem();
            listItem.Text = b.InnerXml.ToString();
            listItem.Value = (gamecode - 100) * 100 + indx + "";
            RadioButtonList1.Items.Add(listItem);
            indx++;
        }
        RadioButtonList1.SelectedIndex = 0; //אתחול ערך ברירת מחדל לרשימה
        RadioButtonList1.DataBind();
        //יצירת פקדים דינאמיים להצגת ועדכון הפריט

        TextBox textBox1 = new TextBox();
        textBox1.Text = RadioButtonList1.SelectedItem.Text;
        textBox1.ID = "itemTB";
        Panel1.Controls.Add(textBox1);

        RadioButtonList ansRBL = new RadioButtonList();
        ansRBL.ID = "ansRBL";

        ListItem listItem1 = new ListItem();
        listItem1.Text = "נכון";
        listItem1.Value = "0";
        ansRBL.Items.Add(listItem1);

        listItem1 = new ListItem();
        listItem1.Text = "לא נכון";
        listItem1.Value = "1";
        ansRBL.Items.Add(listItem1);

        XmlNode BTE = myDoc.SelectNodes("/games/game[@gamecode='" + gamecode + "']/answer[@id='" + RadioButtonList1.SelectedItem.Value + "']").Item(0);
        if (BTE.Attributes["isCorrect"].Value == "true") //עדכון המאפיין של הפריט בהתאם לערכו בעץ
        {
            ansRBL.SelectedIndex = 0; 
        }
        else
        {
            ansRBL.SelectedIndex = 1;
        }
        Panel1.Controls.Add(ansRBL);

        Button editBut = new Button();
        editBut.Click += new EventHandler(ItemEdit);
        editBut.ID = "editBut";
        editBut.Text = "עדכון פריט";
        Panel1.Controls.Add(editBut);

        Panel1.DataBind();
    }

    //טעינת רשימת הפריטים לאחר החלפת קוד משחק
    protected void RblLoad(object sender, EventArgs e)
    {
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("tree/myTree.xml"));
        int gamecode = int.Parse(DropDownList1.SelectedItem.Text);

        RadioButtonList1.Items.Clear(); //הסרת הפריטים הנוכחיים מהרשימה

        XmlNodeList a = myDoc.SelectNodes("/games/game[@gamecode='" + gamecode + "']//answer");
        int indx = 1;
        foreach (XmlNode b in a)
        {
            ListItem listItem = new ListItem();
            listItem.Text = b.InnerXml.ToString();
            listItem.Value = (gamecode - 100) * 100 + indx + "";
            RadioButtonList1.Items.Add(listItem);
            indx++;
        }
        RadioButtonList1.SelectedIndex = 0; //אתחול ערך ברירת מחדל לרשימה
        RadioButtonList1.DataBind();

        RblChange(sender, e); //קריאה לפעולה לטעינת הפריט הנבחר לאחר החלפת המשחק
    }

    //פעולה שמטפלת בשינוי בחירת פריט ברשימה
    protected void RblChange(object sender, EventArgs e)
    {
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("tree/myTree.xml"));
        int gamecode = int.Parse(DropDownList1.SelectedItem.Text);

        TextBox textBox1 = (TextBox)FindControl("itemTB");
        textBox1.Text = RadioButtonList1.SelectedItem.Text;
        RadioButtonList ansRBL = (RadioButtonList)FindControl("ansRBL");

        XmlNode BTE = myDoc.SelectNodes("/games/game[@gamecode=" + gamecode + "]/answer[@id='" + RadioButtonList1.SelectedItem.Value + "']").Item(0);
        if (BTE.Attributes["isCorrect"].Value == "true")
        {
            ansRBL.SelectedIndex = 0;
        }
        else
        {
            ansRBL.SelectedIndex = 1;
        }
    }

    //פעולה שמעכדנת את עץ הXML 
    protected void ItemEdit(object sender, EventArgs e)
    {
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("tree/myTree.xml"));
        int gamecode = int.Parse(DropDownList1.SelectedItem.Text);

        XmlNode BTE = myDoc.SelectNodes("/games/game[@gamecode='" + gamecode + "']/answer[@id='" + RadioButtonList1.SelectedItem.Value + "']").Item(0);
        if (((RadioButtonList)FindControl("ansRBL")).SelectedItem.Text == "נכון") //בדיקה האם נבחר "נכון" או "לא נכון" בעריכת הפריט
        {
            BTE.Attributes["isCorrect"].Value = "true";
        }
        else
        {
            BTE.Attributes["isCorrect"].Value = "false";
        }
        BTE.InnerXml = ((TextBox)FindControl("itemTB")).Text; //עדכון תוכן הפריט
        RadioButtonList1.SelectedItem.Text = ((TextBox)FindControl("itemTB")).Text;

        myDoc.Save(Server.MapPath("tree/myTree.xml"));
        RblChange(sender, e); //קריאה לפעולה לטעינת הפריט מחדש לאחר העדכון
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




