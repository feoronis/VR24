using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public GameObject Test11;
    public GameObject Test22;
    public int x = 1900;
    public Text MyText;
    public int a, b, c;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void ClickBut()
    {
        a = Random.Range(0, 255);
        b = Random.Range(0, 255);
        c = Random.Range(0, 255);
        this.GetComponent<Renderer>().material.color = new Color32((byte)a, (byte)b, (byte)c, 1);
    }
    

    public void year11()
    {
        x = 2025;
        Test11.gameObject.SetActive(false);
        MyText.text = x.ToString();
        

    }

    void FixedUpdate()
    {
       



    }

    
}

