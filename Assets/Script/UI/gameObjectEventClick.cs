using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class gameObjectEventClick : MonoBehaviour
{
    public static GameObject modelObj;
    public Toggle toggle0;
    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;//套管

    void Start()
    {

    }
    void OnEnable()
    {
       // skeletonClick();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).GetComponent<Toggle>().isOn = false;

        }
    }
    // 套管控制
    public void BBoltClick(bool ison)
    {

      //  Debug.Log("isON======<color=red>" + ison + taoguan + "</color>");
        if (Camera.main.GetComponent<DataMsg>().taoguan != null)
        {

            Camera.main.GetComponent<DataMsg>().taoguan.SetActive(!ison);
        }

    }
    //点击骨骼，把骨骼显示出来
    public void skeletonClick(bool ison)
    {
        
        //if (this.transform.FindChild("1").GetComponent<Toggle>().isOn == true)
        //{
            if (modelObj)
            {
                Debug.Log("点击骨骼显示/消失");

                foreach (GameObject item in Camera.main.GetComponent<DataMsg>().guge)
                {
                    item.SetActive(!ison);
                }
            }
           

    }


    //点击螺钉隐藏/出现
    public void boltClick(bool ison)
    {
       
            if (modelObj)
            {
                Debug.Log(Camera.main.GetComponent<DataMsg>().luoding==null);
                Camera.main.GetComponent<DataMsg>().luoding.SetActive(!ison);
            }
        
  
        //else
        //{
        //    if (modelObj)
        //    {
        //        Debug.Log("点击螺钉显示骨骼");
        //        modelObj.transform.GetChild(0).gameObject.SetActive(true);
        //        if (modelObj.transform.GetChild(2))
        //        {
        //            modelObj.transform.GetChild(2).gameObject.SetActive(true);
        //        }
        //    }
        //}
        //else
        //{
        //    modelObj.transform.GetChild(0).gameObject.SetActive(true);
        //}
    }
    //模型回位
    public void modelReture(bool ison)
    {
        cameraRotation._instance.cameraRecover();
    }


    void Update()
    {
        if (Camera.main.GetComponent<DataMsg>().taoguan == null)
        {
            toggle0.gameObject.SetActive(false);
        }
        else
        {
            toggle0.gameObject.SetActive(true);
        }

    }

 
}
