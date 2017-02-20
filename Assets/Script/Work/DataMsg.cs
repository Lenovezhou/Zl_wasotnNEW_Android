using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System;

public class DataMsg : MonoBehaviour
{
    public GameObject cull;
    public static DataMsg _instand;
   public static string  parentname;
    public GameObject[] UIGroup;
    //模块选择相关
    public string NowModuleName;
    public bool ModuleClick;
    public bool iscanretexture;
    public List<Module> moduleList;
    private Text testtext;
    public List<GameObject> GameObjectPool;
    public GameObject luoding, Suodingban, taoguan;
    public GameObject[] guge;
    //public List<GameObject> Kong;
    //public List<GameObject> Kong2;
    public bool IsShowFinish = false;//是否显示完成
    private GameObject ProductButton;
    public Transform[] parent;
    public List<Product> Data;
    private Transform Parent;
    public GameObject Logo;
    //产品列表相关


    //三维展示相关
    public GameObject NowTarget;
    public string ShowTexturePath;

    void Awake()
    {
        _instand = this;

        //TimeOut("1/25/2017 4:56:05 PM");

    }

    void TimeOut(string path)
    {
        //string temp = OpenFile(path);
        string days = DateDiff(DateTime.Parse(path), DateTime.Now);
        Debug.Log("" + days);
        if (int.Parse(days) <=0)
        {
            Debug.Log("TuiChu");
            Application.Quit();
        }
    }
    /// <summary>
    /// 计算时间间隔
    /// </summary>
    /// <param name="DateTime1">第一个时间（DateTime.Parse()）</param>
    /// <param name="DateTime2">第二个时间</param>
    /// <returns>天数</returns>
    private string DateDiff(DateTime DateTime1, DateTime DateTime2)
    {
        if (DateTime2 >= DateTime1)
        {
            return "-3";
        }
        string dateDiff = null;
        TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
        Debug.Log(ts1+"1111111111");
        TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
        Debug.Log(ts2 + "1111111111");
        TimeSpan ts = ts1.Subtract(ts2).Duration();
        dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
        Debug.Log(ts);
        float nYear = ((float)ts.Days) / 365;//
        return ts.Days.ToString();//dateDiff
    }
    void AddFile(string flieName, string AddTxt)
    {
        FileStream fs = new FileStream(flieName, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        sw.Write(AddTxt.Trim());
        sw.Close();
        fs.Close();
    }

    string OpenFile(string flieName)
    {
        FileStream fs = new FileStream(flieName, FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        string test = sr.ReadLine();
        sr.Close();
        fs.Close();
        return test;
    }


    //切换UI的方法
    public void MenuShow(int ShowId, int HideId)
    {
        UIGroup[HideId].SetActive(false);
        UIGroup[ShowId].SetActive(true);
    }
    void Start()
    {
        //testtext = GameObject.FindGameObjectWithTag("Finish").GetComponent<Text>();
        ProductButton = AddButton._instand.ProductButton2;
        Parent = AddButton._instand.DataMsg.parent[1];
       // StartCoroutine(Load(AddButton._instand.PathURL[0] + "PGYDSDJGB.assetbundle"));

        //Kong = new List<GameObject>();
        //Kong2 = new List<GameObject>();
    }

    public IEnumerator Load(string path)
    {
        WWW bundle = new WWW(path);

        yield return bundle;

        GameObject target = (GameObject)Instantiate(bundle.assetBundle.LoadAsset("PGYDSDJGB"));
        MeshRenderer[] meshs = target.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < meshs.Length; i++)
        {
            meshs[i].material = Resources.Load(i.ToString()) as Material;
            Debug.Log(meshs[i].material);
        }
    }

    /// <summary>
    /// 缓存池用法：不直接销毁旧物体，先设为false，再根据池内的数量重新给物体赋值
    /// </summary>
    /// <param name="productList">这一次将要用到的物体集合（数量）</param>
    public void CreateOBj(List<Product> productList)
    {
        Debug.Log("数量为：" + productList.Count);
        Data = productList;
        foreach (GameObject item in GameObjectPool)
        {
            item.SetActive(false);
        }
        if (GameObjectPool.Count > productList.Count)
        {
            for (int i = 0; i < productList.Count; i++)
            {
                //GameObjectPool[i] 表示第几个prefab
                string path = productList[i].TextureURL;
                InitServerConfig._instance.m_downLoader.StartDownload(AddButton._instand.PathURL, "", path, i + "", null, eDownloadType.Type_Texture, OnLoadUpdateZipComplete, OnLoadFaile, true);

            }
            int DeleteNum = GameObjectPool.Count - productList.Count;
            for (int i = 0; i < DeleteNum; i++)
            {
                GameObjectPool[productList.Count + i].SetActive(false);
            }
        }
        else
        {
            int AddNum = productList.Count - GameObjectPool.Count;
           
            int index = 0;
            if (GameObjectPool.Count != 0)
            {
                for (int i = 0; i < GameObjectPool.Count; i++)
                {
                    //GameObjectPool[i] 表示第几个prefab
                    string path = productList[i].TextureURL;
                    InitServerConfig._instance.m_downLoader.StartDownload(AddButton._instand.PathURL, "", path, i + "", null, eDownloadType.Type_Texture, OnLoadUpdateZipComplete, OnLoadFaile, true);
                    index++;
                }
            }
            for (int i = 0; i < AddNum; i++)
            {
                GameObject Go = (GameObject)Instantiate(ProductButton);
                Go.transform.SetParent(Parent);
                Go.transform.localScale = Vector3.one;
                GameObjectPool.Add(Go);
                string path = productList[index].TextureURL;
                InitServerConfig._instance.m_downLoader.StartDownload(AddButton._instand.PathURL, "", path, index + "", null, eDownloadType.Type_Texture, OnLoadUpdateZipComplete, OnLoadFaile, true);
                index++;
            }

        }
        //if (productList.Count < 4)
        //{
        //    int j = 4 - productList.Count;
        //    for (int i = 0; i < j; i++)
        //    {
        //        Debug.Log("生成了：：" + i);
        //        GameObject Go = (GameObject)Instantiate(ProductButton);
        //        Go.transform.SetParent(Parent);
        //        Go.GetComponent<Button>().enabled = false;
        //        //Kong.Add(Go);
        //    }
        //}
   }




    //根据路径加载模型
    public IEnumerator LoadModel(string path, string Description)
    {
        
        WWW bundle = new WWW(AddButton._instand.PathURL[0] + path);
   //     Debug.Log("-----------"+ AddButton._instand.PathURL[0]+ path + "--------" + Description);
        yield return bundle;

        if (bundle.isDone&& bundle.error == null)
        cull.SetActive(false);
        Debug.Log(bundle.error + "------" + bundle.isDone + "-------" + bundle.assetBundle);
        ////克隆出来的Budul 加载到游戏中
        //GameObject target = (GameObject)Instantiate(bundle.assetBundle.mainAsset);
        ////target.transform.LookAt(Camera.main.transform.position);
        //MeshRenderer[] meshs= target.GetComponentsInChildren<MeshRenderer>();   
        //gameObjectEventClick.modelObj = target;
        //guge = GameObject.FindGameObjectsWithTag("GuGe");
        //luoding = GameObject.FindGameObjectWithTag("LuoDing");
        //Suodingban = GameObject.FindGameObjectWithTag("Suodingban");
        if (Description != "")
        {
            //克隆出来的Budul 加载到游戏中
            GameObject target = (GameObject)Instantiate(bundle.assetBundle.mainAsset);
            //target.transform.LookAt(Camera.main.transform.position);
            MeshRenderer[] meshs = target.GetComponentsInChildren<MeshRenderer>();
            gameObjectEventClick.modelObj = target;
            guge = GameObject.FindGameObjectsWithTag("GuGe");
            luoding = GameObject.FindGameObjectWithTag("LuoDing");
            Suodingban = GameObject.FindGameObjectWithTag("Suodingban");
            if ( GameObject.FindGameObjectWithTag("TaoGuan") != null)
            {
                taoguan = GameObject.FindGameObjectWithTag("TaoGuan");
            }
            if (Description != "")
            {
                StartCoroutine(LoadTexture(AddButton._instand.PathURL[0] + Description));
            }
            AddButton._instand.DeleteGameOBj = target;
            bundle.assetBundle.Unload(false);
        }
        else
        {
            Debug.Log(bundle.error + "------" + bundle.isDone + "-------"+bundle.assetBundle.name);
        }
    }

    //加载图片
    IEnumerator LoadTexture(string path)
    {
       
        WWW www = new WWW(path);
        yield return www;
 //       Debug.Log(www.error+"--------"+www.isDone);
        if (www.error == null)
        {
         
            if (www.texture != null)
            {
                float a = www.texture.width;
                float b = www.texture.height;
                UImanager._instance.productPanel.GetComponent<RectTransform>().localScale = new Vector3(1,b/a,1);
                //UImanager._instance.productPanel.GetComponent<Image>().texture = www.texture;
                //UImanager._instance.productPanel.GetComponent<Image>()
                UImanager._instance.productPanel.GetComponent<Image>().sprite = Sprite.Create(www.texture,
                   new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
                UImanager._instance.ForthP_button();
            }
        }
    }


    //产品列表
    private void OnLoadUpdateZipComplete(object data, string item)
    {
        int i = int.Parse(item);
        Texture t = data as Texture;
        Debug.Log("countpool" + GameObjectPool.Count);
        if (GameObjectPool[i] != null)
        {
            GameObjectPool[i].SetActive(true);
            if (GameObjectPool[i].GetComponent<ProductManager>())
            {
                GameObjectPool[i].GetComponent<ProductManager>().initModule(Data[i]);
            }
            else
            {
                GameObjectPool[i].AddComponent<ProductManager>().initModule(Data[i]);
            }

            GameObjectPool[i].transform.GetChild(1).GetComponent<RawImage>().texture = t;
        }
        for (int j = 0; j < Data.Count; j++)     //为缓存池内的buttons重新分配名字
        {
            GameObjectPool[j].GetComponentInChildren<Text>().text = Data[j].Name;
        }

    }

    private void OnLoadFaile(object data, string item)
    {
        Debug.Log("失败了？？");
    }




}
