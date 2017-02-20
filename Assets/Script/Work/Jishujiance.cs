using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Jishujiance : MonoBehaviour 
{
    private DataMsg dataMsg;
    private Transform[] trans;
    private int nmb =0;
    public GameObject ShowGame;
    public void Start()
    {
        dataMsg = Camera.main.GetComponent<DataMsg>();
    }

    public void Update()
    {
        if(dataMsg.IsShowFinish)
        {

            IsShowImage();
            dataMsg.IsShowFinish = false;
        }
    }

    public void IsShowImage()
    {
        trans = GetComponentsInChildren<Transform>();
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                nmb++;
                Debug.Log("Name IS" + child.name );
            }
        }
        if(nmb<8)
        {
            //int Numble = 7 - nmb;
            //for (int i = 0; i < Numble; ++i)
            //{
            //    Debug.Log("生成物体");
            //    //生成几个空物体，放入DataMrg里面Kong2
            //    GameObject go = (GameObject)Instantiate(ShowGame);
            //    go.transform.SetParent(transform);
            //    go.transform.localScale = Vector3.one;
            //    go.GetComponent<Button>().enabled = false;
            //    go.GetComponent<Image>().material.mainTexture = null;
            //    dataMsg.Kong2.Add(go);
            //}

        }
    }
}
