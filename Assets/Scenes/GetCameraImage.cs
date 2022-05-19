using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCameraImage : MonoBehaviour
{
    public static WebCamTexture webCamTexture;
    // Start is called before the first frame update
    void Start()
    {
        webCamTexture = new WebCamTexture();
        webCamTexture.Play();
        gameObject.GetComponent<Image>().material.mainTexture = webCamTexture;

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
