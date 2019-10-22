using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


public partial class _Default : System.Web.UI.Page
{
    XmlDocument myDoc = new XmlDocument();
    string gameid;

    protected void Page_Init(object sender, EventArgs e)
    {

        //string gameid = Session["theItemIdSession"].ToString();
        gameid = "1";

        myDoc.Load(Server.MapPath("/XMLFiles/games.xml"));

        XmlDataSource_Correct.XPath = "/HIT-the-Duck/game[@id='" + gameid + "']/answer[@isCorrect='true']";
        XmlDataSource_Incorrect.XPath = "/HIT-the-Duck/game[@id='" + gameid + "']/answer[@isCorrect='false']";

        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        gamename.Text = myDoc.SelectNodes("/HIT-the-Duck/game[@id='" + gameid + "']")[0].Attributes["name"].Value;
        instructions.Text = myDoc.SelectNodes("/HIT-the-Duck/game[@id='" + gameid + "']/question").Item(0).InnerXml.ToString();

        LoadDLItems(DataListCorrect);
        LoadDLItems(DataListIncorrect);
    }

    protected void LoadDLItems(DataList dl)
    {
        //הפונקציה שאחראית על הצגת התמונות והטקסטים בטבלה של המסיחים הנכונים
        foreach (DataListItem dli in dl.Items)
        {
            //הפנייה בשורה הבאה תיעשה לאחד מהפקדים בגריד וויו שיש להם אפשרות לזהות את האיי-די של המסיח שאליו מתייחסת השורה 
            string myID = ((LinkButton)dli.FindControl("lnkSelect")).Attributes["theItemId"];

            //שליפת הענף שמכיל את השם (בטקסט או בתמונה) של המסיח
            XmlNode myRightQ = myDoc.SelectSingleNode("/HIT-the-Duck/game[@id='" + gameid + "']/answer[@id='" + myID + "']");

            //המאפיין המגדיר האם יש או אין תמונה נמצא בענף ההורה של הענף ששלפנו
            //אם יש תמונה למסיח
            if (myRightQ.Attributes["qType"].Value == "img")
            {
                ((Label)dli.FindControl("NameLabel")).Visible = false;
                //הצגת פקד התמונה
                ((System.Web.UI.WebControls.Image)dli.FindControl("ImageQR")).Visible = true;

                //הצגת התמונה עצמה בתוך הפקד
                ((System.Web.UI.WebControls.Image)dli.FindControl("ImageQR")).ImageUrl = "~/uploadedFiles/" + Server.UrlDecode(myRightQ.InnerXml);
            }
            else
            {
                //הצגת פקד הלייבל
                ((Label)dli.FindControl("NameLabel")).Visible = true;
                ((System.Web.UI.WebControls.Image)dli.FindControl("ImageQR")).Visible = false;


                //הכנסה של שם המסיח לטקסט שבפקד הלייבל
                ((Label)dli.FindControl("NameLabel")).Text = Server.UrlDecode(myRightQ.InnerXml);
            }
        }
    }

    protected void ItemSelect(object sender, EventArgs e)
    {
        {
            myDoc.Load(Server.MapPath("/XMLFiles/games.xml"));
            string gameid = Session["theItemIdSession"].ToString();

            XmlNode BTE = myDoc.SelectNodes("/HIT-the-Duck/game[@id='" + gameid + "']/answer[@id='" + RadioButtonList1.SelectedItem.Value + "']").Item(0);
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

            myDoc.Save(Server.MapPath("/XMLFiles/games.xml"));
        }
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx");
    }

    //טעינת רשימת הפריטים לאחר החלפת קוד משחק
    protected void RblLoad(object sender, EventArgs e)
    {
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load(Server.MapPath("/XMLFiles/games.xml"));
        string gameid = Session["theItemIdSession"].ToString();

        RadioButtonList1.Items.Clear(); //הסרת הפריטים הנוכחיים מהרשימה

        XmlNodeList a = myDoc.SelectNodes("/HIT-the-Duck/game[@id='" + gameid + "']//answer");
        int indx = 1;
        foreach (XmlNode b in a)
        {
            ListItem listItem = new ListItem();
            listItem.Text = b.InnerXml.ToString();
            listItem.Value = b.Attributes["id"].Value;
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
        myDoc.Load(Server.MapPath("/XMLFiles/games.xml"));
        string gameid = Session["theItemIdSession"].ToString();

        TextBox textBox1 = (TextBox)FindControl("itemTB");
        textBox1.Text = RadioButtonList1.SelectedItem.Text;
        RadioButtonList ansRBL = (RadioButtonList)FindControl("ansRBL");

        XmlNode BTE = myDoc.SelectNodes("/HIT-the-Duck/game[@id=" + gameid + "]/answer[@id='" + RadioButtonList1.SelectedItem.Value + "']").Item(0);
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
        myDoc.Load(Server.MapPath("/XMLFiles/games.xml"));
        string gameid = Session["theItemIdSession"].ToString();

        XmlNode BTE = myDoc.SelectNodes("/HIT-the-Duck/game[@id='" + gameid + "']/answer[@id='" + RadioButtonList1.SelectedItem.Value + "']").Item(0);
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

        myDoc.Save(Server.MapPath("/XMLFiles/games.xml"));
        RblChange(sender, e); //קריאה לפעולה לטעינת הפריט מחדש לאחר העדכון
    }




}

//INIT

//        //טעינת הפריטים לרשימה
//        XmlNodeList a = myDoc.SelectNodes("/HIT-the-Duck/game[@id='" + gameid + "']//answer");
//        int indx = 1;
//        foreach (XmlNode b in a)
//        {
//            ListItem listItem = new ListItem();
//listItem.Text = b.InnerXml.ToString();
//            //listItem.Value = (gamecode - 100) * 100 + indx + "";
//            listItem.Value = b.Attributes["id"].Value;
//            RadioButtonList1.Items.Add(listItem);
//            indx++;
//        }
//        RadioButtonList1.SelectedIndex = 0; //אתחול ערך ברירת מחדל לרשימה
//        RadioButtonList1.DataBind();
//        //יצירת פקדים דינאמיים להצגת ועדכון הפריט
//        if (RadioButtonList1.Items.Count > 0) //בדיקה שמונעת נסיון טעינה של מסיחים ריקים
//        {
//            TextBox textBox1 = new TextBox();
//textBox1.Text = RadioButtonList1.SelectedItem.Text;
//            textBox1.ID = "itemTB";
//            Panel1.Controls.Add(textBox1);

//            RadioButtonList ansRBL = new RadioButtonList();
//ansRBL.ID = "ansRBL";

//            ListItem listItem1 = new ListItem();
//listItem1.Text = "נכון";
//            listItem1.Value = "0";
//            ansRBL.Items.Add(listItem1);

//            listItem1 = new ListItem();
//listItem1.Text = "לא נכון";
//            listItem1.Value = "1";
//            ansRBL.Items.Add(listItem1);

//            XmlNode BTE = myDoc.SelectNodes("/HIT-the-Duck/game[@id='" + gameid + "']/answer[@id='" + RadioButtonList1.SelectedItem.Value + "']").Item(0);
//            if (BTE.Attributes["isCorrect"].Value == "true") //עדכון המאפיין של הפריט בהתאם לערכו בעץ
//            {
//                ansRBL.SelectedIndex = 0;
//            }
//            else
//            {
//                ansRBL.SelectedIndex = 1;
//            }
//            Panel1.Controls.Add(ansRBL);

//            Button editBut = new Button();
//editBut.Click += new EventHandler(ItemEdit);
//editBut.ID = "editBut";
//            editBut.Text = "עדכון פריט";
//            Panel1.Controls.Add(editBut);

//            Panel1.DataBind();
//        }
//        else
//        {
//            Label label = new Label();
//label.Text = "לא קיימים מסיחים במשחק זה";
//            label.ID = "label1";
//            Panel1.Controls.Add(label);
//        }

//        a = myDoc.SelectNodes("/HIT-the-Duck/game[@id='" + gameid + "']/answer[@isCorrect='true']");
//        indx = 1;
//        foreach (XmlNode b in a)
//        {
//            ListItem listItem = new ListItem();
//listItem.Text = b.InnerXml.ToString();
//            //listItem.Value = (gamecode - 100) * 100 + indx + "";
//            listItem.Value = b.Attributes["id"].Value;
//            CorrectRBL.Items.Add(listItem);
//            indx++;
//        }
//        CorrectRBL.SelectedIndex = 0; //אתחול ערך ברירת מחדל לרשימה
//        CorrectRBL.DataBind();

//        a = myDoc.SelectNodes("/HIT-the-Duck/game[@id='" + gameid + "']/answer[@isCorrect='false']");
//        indx = 1;
//        foreach (XmlNode b in a)
//        {
//            ListItem listItem = new ListItem();
//listItem.Text = b.InnerXml.ToString();
//            //listItem.Value = (gamecode - 100) * 100 + indx + "";
//            listItem.Value = b.Attributes["id"].Value;
//            IncorrectRBL.Items.Add(listItem);
//            indx++;
//        }
//        IncorrectRBL.SelectedIndex = 0; //אתחול ערך ברירת מחדל לרשימה
//        IncorrectRBL.DataBind();

//        RadioButtonList1.Visible = false;