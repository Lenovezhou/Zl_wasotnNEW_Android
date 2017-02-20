using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class ProductManager : MonoBehaviour
{
    public Material[] mats;
    private Button SelfButton;
    private Text SelfText,forthtext;
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("forthtext") != null)
            forthtext = GameObject.FindGameObjectWithTag("forthtext").GetComponent<Text>();
        SelfButton = GetComponent<Button>();
        SelfText = SelfButton.GetComponentInChildren<Text>();
        SelfText.text = name;
       // Debug.Log(name);
       // SelfButton.onClick.AddListener(UImanager._instance.ForthP_button);
        SelfButton.onClick.AddListener(Click);
    }

    void Click()
    {
        if (IsModle)
        {
           forthtext.text = SelfText.text;
           Camera.main.GetComponent<DataMsg>().cull.SetActive(true);
            StartCoroutine(Camera.main.GetComponent<DataMsg>().LoadModel(ModleURL, description));
        }
        else
        {
            DataMsg._instand.ShowTexturePath = ModleURL;
            UImanager._instance.SelectPanel(UImanager._instance.secondpanel2);
            UImanager._instance.a = 4;
        }
        Debug.Log("disige ");
    }

   
    public void initModule(Product module)
    {
        Name = module.Name;
        ModleURL = module.ModleURL;
        TextureURL = module.TextureURL;
        Description = module.Description;
        IsModle = module.IsModle;
    }


    private string description;
    public string Description
    {
        set { description = value; }
        get { return description; }
    }
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private bool isModle;

    public bool IsModle
    {
        get { return isModle; }
        set { isModle = value; }
    }
    private string modleURL;
    public string ModleURL
    {
        get { return modleURL; }
        set { modleURL = value; }
    }

    private string textureURL;
    public string TextureURL
    {
        get { return textureURL; }
        set { textureURL = value; }
    }
}

public class Product
{

    private string description;
    public string Description
    {
        set { description = value; }
        get { return description; }
    }
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private bool isModle;

    public bool IsModle
    {
        get { return isModle; }
        set { isModle = value; }
    }
    private string modleURL;
    public string ModleURL
    {
        get { return modleURL; }
        set { modleURL = value; }
    }

    private string textureURL;
    public string TextureURL
    {
        get { return textureURL; }
        set { textureURL = value; }
    }
}
