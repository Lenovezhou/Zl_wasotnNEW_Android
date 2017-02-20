using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Logint : MonoBehaviour
{
    private InputField _inputFieldPassword;
    private GameObject _erroGameObject;
	// Use this for initialization
	void Start ()
	{
	    _inputFieldPassword = transform.Find("RawImage/InputField").GetComponent<InputField>();
        _erroGameObject = transform.Find("RawImage/Text").gameObject;
        transform.Find("RawImage/Button").GetComponent<Button>().onClick.AddListener(() =>
        {
            if (_inputFieldPassword.text == "waston2017")
            {
                gameObject.SetActive(false);

                _erroGameObject.SetActive(false);
            }
            else
            {
                _erroGameObject.SetActive(true);
            }
        });
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
