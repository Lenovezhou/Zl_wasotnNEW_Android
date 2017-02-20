using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ProductButtonClick : MonoBehaviour
{
    private GameObject product;

    public GameObject Product
    {
        get { return product; }
        set { product = value; }
    }

    private Texture MainTexture;

    public Texture MainTexture1
    {
        get { return MainTexture; }
        set { this.GetComponent<RawImage>().texture = MainTexture = value; }
    }


    DataMsg DataMsg;
    // Use this for initialization
    void Start()
    {
        DataMsg = Camera.main.GetComponent<DataMsg>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickThis()
    {
        if (DataMsg.NowTarget)
        {
            Destroy(DataMsg.NowTarget);
        }

        DataMsg.NowTarget = Product;

        //Instantiate(DataMsg.NowTarget);

        DataMsg.MenuShow(3, 2);
    }
}
