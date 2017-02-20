using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ModuleManager : MonoBehaviour 
{
    private Button SelfButton;
    private Text[] SelfText;
    private bool IsOn;
    private Color buttoncolor;
    private ColorBlock cb;
    private Image buttonimage;
    private static List<Button> bu;
    void Start()
    {
        SelfButton = GetComponent<Button>();
        SelfText = SelfButton.GetComponentsInChildren<Text>();
        SelfText[0].text = name;
       // SelfText[1].text = englishname;//英语显示
        SelfButton.onClick.AddListener(changeState);
        bu=new List<Button>();

        buttonimage = GetComponent<Image>();
        buttonimage.color = Color.white;
    }

    private void changeState()  //  第二页button调用
    {
        if (buttonimage.color == Color.white)
        {
            buttonimage.color = new Color(0.95F, 0.95F, 0.95F);
            bu.Remove(this.gameObject.GetComponent<Button>());
            //      将之前的button的image的color都改为白色
            for (int i = 0; i < bu.Count; i++)
            {
                bu[i].image.color = Color.white;
            }
            //  将改变颜色的button都记录下来
            bu.Add(this.gameObject.GetComponent<Button>());
        }
        else {
            buttonimage.color = Color.white;
        }

       DataMsg.parentname=this.transform.GetChild(0).GetComponent<Text>().text;     // 记录当前被按下按钮的文字
       if (IsModle)
       {
           if (IsOn)
           {
               foreach (GameObject item in subObj)
               {
                   item.SetActive(false);
               }
               IsOn = false;

           }
           else
           {
               foreach (GameObject item in subObj)
               {
                   item.SetActive(true);
               }
               IsOn = true;

           }
       }
       else
       {
           DataMsg._instand.ShowTexturePath = URL;
           UImanager._instance.SelectPanel(UImanager._instance.secondpanel2);
           UImanager._instance.a = 3;
       }
      //  AddButton._instand.ChackActiveCount(AddButton._instand.image1);      //  展开子菜单时检查子button的数量决定
    }

    public void initModule(Module module)
    {
        Name = module.Name;
      //  Totlname = module.Totlname;
        //Totlenglishname = module.Totlenglishname;
        Englishname = module.Englishname;
        SubList = module.SubList;
        ID = module.ID;
        IsModle = module.IsModle;
        URL = module.URL;
    }

   

    private string englishname;
    public string Englishname
    {
        get { return englishname; }
        set { englishname = value; }
    }

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string id;
    public string ID
    {
        set { id = value; }
        get { return id; }
    }

    public bool IsModle { get; set; }

    public string URL { get; set; }
    private List<Sub> subList;

    public List<Sub> SubList
    {
        get { return subList; }
        set { subList = value; }
    }

    private List<GameObject> subObj=new List<GameObject> ();

    public List<GameObject> SubObj
    {
        get { return subObj; }
        set { subObj = value; }
    }
}

public class Module
{
    public Module()
    {
        subList = new List<Sub>();
        subObj = new List<GameObject>();
    }

    public void initModule(Module module)
    {
        Name = module.name;
        IsModle = module.IsModle;
        URL = module.URL;
        SubList = module.SubList;
    }

    private string name;
    private string englishname;
    
    public string Englishname
    {
        get { return englishname; }
        set { englishname = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private string id;
    public string ID
    {
        set { id = value; }
        get { return id; }
    }

    private List<Sub> subList;

    public List<Sub> SubList
    {
        get { return subList; }
        set { subList = value; }
    }

    private List<GameObject> subObj;

    public List<GameObject> SubObj
    {
        get { return subObj; }
        set { subObj = value; }
    }

    public bool IsModle { get; set; }

    public string URL { get; set; }
}
