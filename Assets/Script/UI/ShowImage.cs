using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ShowImage : MonoBehaviour {
    public GameObject Content;
    public RawImage RawImage;

    void OnEnable()
    {
        StartCoroutine(LoadTexture(DataMsg._instand.ShowTexturePath));
    }
    void OnDisable()
    {
        Content.GetComponent<RectTransform>().anchoredPosition = new Vector2(-240, 0);
        RawImage.texture = null;
    }
	// Use this for initialization
	void Start () 
    {
	
	}
    public IEnumerator LoadTexture(string path)
    {

        WWW www = new WWW(AddButton._instand.PathURL[0]+path);
        Debug.Log(AddButton._instand.PathURL[0] + path);
        yield return www;
        Texture2D temp = www.texture;
        float width = RawImage.GetComponent<RectTransform>().rect.width;
        //Debug.Log("Path::  " + www.error);
        if (www.error == null && www.isDone)
        {
            float newHeight = ((float)temp.height / (float)temp.width) * width;
            Content.GetComponent<RectTransform>().sizeDelta = new Vector2(width, newHeight);
            RawImage.GetComponent<RectTransform>().sizeDelta = new Vector2(width, newHeight );
            RawImage.texture = temp;
        }

    }
	// Update is called once per frame
	void Update () 
    {
	
	}
}
