using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

public class SubManager : MonoBehaviour
{
    public DataMsg datamsg;
    public Material[] mats;
    public List<GameObject> GameObjectPool;
    //public GameObject Logo;
    private Button SelfButton;
    private Text[] SelfText;
    private GameObject ProductButton;
    private Transform Parent;
    private List<string> CreatedOBjs = new List<string>();
    void Start()
    {
        GameObjectPool = new List<GameObject>();        //  用于添加实例出的Buttons
        SelfButton = GetComponent<Button>();            //   控制自己
        SelfText = SelfButton.GetComponentsInChildren<Text>();
        SelfText[0].text = name;
        //SelfText[1].text = englishname;//英语隐藏
        //SelfButton.onClick.AddListener(UImanager._instance.SecondP_button);     //  添加委托绑定
        SelfButton.onClick.AddListener(CreateOBj);
        datamsg = Camera.main.GetComponent<DataMsg>();
        ProductButton = AddButton._instand.ProductButton2;
        //      parent[1]在Addbutton脚本上已挂好
        Parent = AddButton._instand.DataMsg.parent[1];              
    }



    public void CreateOBj()
    {
        string parentname = this.gameObject.transform.GetChild(1).GetComponent<Text>().text;
        Debug.Log(""+parentname);
        if (IsModle)
        {
            UImanager._instance.SecondP_button();
            //      记录当前点击的button的text文本
            //     点击第二页子button时显示在第三页台头的文字
            Parent.transform.parent.parent.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = (DataMsg.parentname + "-" + parentname);
            datamsg.CreateOBj(productList);

            //Logo = datamsg.Logo; 
            //Invoke("LogoActive", 1f);
        }
        else
        {
            if (parentname == "OF系列")
            {
                UImanager._instance.SelectPanel(UImanager._instance.secondpanel3);
            }
            else
            {
                DataMsg._instand.ShowTexturePath = URL;
                UImanager._instance.SelectPanel(UImanager._instance.secondpanel2);
            }
            UImanager._instance.a = 3;
        }
    }
   
    //void LogoActive()
    //{
    //    Logo.SetActive(true);
    //}

    public void initModule(Sub sub)
    {
        Name = sub.Name;
        ENglishname = sub.ENglishname;
        IsModle = sub.IsModle;
        URL = sub.URL;
        ProductList = sub.ProductList;
    }

    public bool IsModle { get; set; }
    public string URL { get; set; }
    private string name;
    private string englishname;
    public string ENglishname 
    {
        get { return englishname; }
        set { englishname = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private List<Product> productList;

    public List<Product> ProductList
    {
        get { return productList; }
        set { productList = value; }
    }
}

public class Sub
{
    public Sub()
    {
        productList = new List<Product>();
    }
     public void initSub(Sub sub)
    {
        Name = sub.name;
        IsModle = sub.IsModle;
        URL = sub.URL;
        ProductList = sub.ProductList;
    }
    private string name;
    private string englishname;
    public string ENglishname
    {
       
        get { return englishname; }
        set { englishname = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private List<Product> productList;

    public List<Product> ProductList
    {
        get { return productList; }
        set { productList = value; }
    }

    public bool IsModle { get; set; }

    public string URL { get; set; }
}
