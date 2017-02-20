using UnityEngine;
using System;
using UnityEngine.UI;
using System.Xml;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;



public class UImanager : MonoBehaviour
{
    public int a;
    public static UImanager _instance;
    public string teliphonenumber;
    public GameObject homepanel, secondpanel, secondpanel2, secondpanel3, bottompanel, toppanel, forthpanel, productPanel,secondpanel4;
    public GameObject currentpanel;
    private bool _isaddbutton;
    DataMsg DataMsg;        //  数据中心

    public bool isShowImagePanal;
    void Start()
    {
        bottompanel.SetActive(false);
        _isaddbutton = false;
        _instance = this;
        currentpanel = homepanel;
        DataMsg = Camera.main.GetComponent<DataMsg>();
    }


    public void Teliphone()
    {
        //Debug.Log(" Application.OpenURL(tel://;" + teliphonenumber);
        //Application.OpenURL("tel://" + teliphonenumber);
        DataMsg._instand.ShowTexturePath = "AboutTexture/lianxi.jpg";
        secondpanel4.SetActive(true);
    }

    void Update()
    {
        //当前在主界面时点击退出键
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackLastPanel();
        }
    }
    public void HomeP_butten1(string Name)      //  首页button
    {
        a = 2;      //当前panel为secondpanel
        bottompanel.SetActive(true);
        switch (Name)       //  下一panel台头显示的文字
        {
            case "A":
                isShowImagePanal = true;
                DataMsg.ShowTexturePath = "AboutTexture/About.jpg";
                break;
            case "G":
                isShowImagePanal = false;
                secondpanel.transform.GetChild(2).GetComponent<Text>().text = "骨科";
                DataMsg.ModuleClick = true;
                break;
            case "X":
                isShowImagePanal = false;
                secondpanel.transform.GetChild(2).GetComponent<Text>().text = "心胸外科";
                DataMsg.ModuleClick = true;
                break;
            case "W":
                isShowImagePanal = false;
                secondpanel.transform.GetChild(2).GetComponent<Text>().text = "吻合器";
                DataMsg.ModuleClick = true;
                break;
            case "S":
                isShowImagePanal = true;
                DataMsg.ShowTexturePath = "AboutTexture/SanweiDayin.jpg";

                break;
            case "C":
                isShowImagePanal = true;
                DataMsg.ShowTexturePath = "AboutTexture/CIFO.jpg";

                break;
                
        }
        DataMsg.NowModuleName = Name;
        if (!isShowImagePanal)
            SelectPanel(secondpanel);
        else
            SelectPanel(secondpanel2);
        //Product product = new Product();



    }
    public void SecondP_button()        //  第二页button
    {
        a = 3;
        SelectPanel(forthpanel);
    }

    public void ForthP_button()         //  第三页button
    {

        Debug.Log("跳转：  ");
        a = 4;
        SelectPanel(toppanel);
        cameraRotation._instance.cameraRecover();
    }

    public void ProductP_button()       //  产品介绍Toggle
    {

        a = 5;
        Debug.Log("调用产品介绍");
        productPanel.SetActive(true);
        //SelectPanel(productPanel);
        if (toppanel.transform.GetChild(3).GetComponent<Toggle>().isOn == true)
        {
            a = 5;
            currentpanel = productPanel;

            //currentpanel = productPanel;
        }
        else
        {
            Debug.Log("False");
            a = 4;
            productPanel.SetActive(false);

        }

    }






    public void BackLastPanel()         //  返回按钮
    {
        if (secondpanel4.activeInHierarchy)
        {
            secondpanel4.SetActive(false);
            return;
        }

        a = a - 1;
        if (a <0)
        {
            Application.Quit();
        }
        else
            if (a == 0)
            { 
                
            }
        Debug.Log("当前a为" + a);
        switch (a)
        {
            case 1:
                //      清空上次事例出的buttons
                for (int i = 0; i < AddButton._instand.GameObjectPool.Count; i++)
                {

                    Destroy(AddButton._instand.GameObjectPool[i]);
                }
                SelectPanel(homepanel);
                bottompanel.SetActive(false);       //  panel减小后退到主页时，bottompanel=false，a=2时为true
                DataMsg.iscanretexture = false;      // 可以再次加载forthpanel的图片
                toppanel.SetActive(false);
                break;
            case 2:
                //if (currentpanel == secondpanel4)
                //{
                //    SelectPanel(secondpanel2);
                //}
                //else
                {
                    SelectPanel(secondpanel);
                    bottompanel.SetActive(true);
                }

                //for (int i = 0; i < DataMsg.Kong.Count;++i )
                //{
                //    Debug.Log("删除元素几个" + i + ":::"+ DataMsg.Kong.Count);
                //    Destroy(DataMsg.Kong[i]);
                //}
                //DataMsg.Logo.SetActive(false);
                //DataMsg.Kong.RemoveRange(0,DataMsg.Kong.Count);

                    //for (int i = 0; i < AddButton._instand.forthpanelbutton.Count; i++)
                    //{
                    //    DestroyImmediate(AddButton._instand.forthpanelbutton[i]);
                    //}
                    break;
            case 3:

                    //if (currentpanel == secondpanel4)
                    //{
                    //    SelectPanel(secondpanel3);
                    //}
                    //else
                    { 
                        Destroy(AddButton._instand.DeleteGameOBj);
                        SelectPanel(forthpanel);
                    }
                    break;

            case 4:
                {
                    productPanel.SetActive(false);
                    toppanel.transform.GetChild(3).GetComponent<Toggle>().isOn = false;
                    //if (secondpanel4.activeInHierarchy)
                    //{
                    //    secondpanel4.SetActive(false);
                    //}
                    Debug.Log(toppanel.transform.GetChild(3).GetComponent<Toggle>().isOn);
                    SelectPanel(toppanel);
                    a = 4;
                    break;
                }
            //case 5:
            //    if (secondpanel4.activeInHierarchy)
            //    {
            //        secondpanel4.SetActive(false);
            //    }
            //    break;


        }
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

    public void HomeButton()        //  主页按钮
    {
        a = 0;
        DataMsg.iscanretexture = false;  // 可以再次加载forthpanel的图片
        if (AddButton._instand.DeleteGameOBj)
        {
            Destroy(AddButton._instand.DeleteGameOBj);
        }
        productPanel.SetActive(false);
        SelectPanel(homepanel);
        bottompanel.SetActive(false);
        toppanel.SetActive(false);
        //      清空上次实例出的buttons
        for (int i = 0; i < AddButton._instand.GameObjectPool.Count; i++)
        {
            Destroy(AddButton._instand.GameObjectPool[i]);
        }
        //for (int i = 0; i < AddButton._instand.forthpanelbutton.Count; i++)
        //{
        //   DestroyImmediate(AddButton._instand.forthpanelbutton[i]);
        //}
    }

    public void SelectPanel(GameObject newobj)      //  切换panel使用
    {

        //  newobj.transform.GetChild(1).GetComponent<Text>().text = newobj.GetComponent<Text>().ToString();
        currentpanel.SetActive(false);
        newobj.SetActive(true);
        currentpanel = newobj;
    }


}
