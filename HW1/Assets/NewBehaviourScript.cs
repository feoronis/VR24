using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour
{
    public Text nm;
    public Text lvl;
    public Slider dat;
    public string jsonURL;
    public Jsonclass jsnData;
    public Text dat1;

    void Start()
    {
        dat.interactable = false;
        StartCoroutine(getData());
    }
    IEnumerator getData()
    {
        Debug.Log("Loading...");
        var uwr = new UnityWebRequest(jsonURL);
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultFile = Path.Combine(Application.persistentDataPath, "result.json");
        var dh = new DownloadHandlerFile(resultFile);
        dh.removeFileOnAbort = true;
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        if (uwr.result!= UnityWebRequest.Result.Success)
        {
            nm.text = "Error!";
        }
        else
        {
            Debug.Log("File saved at: " + resultFile);
            jsnData = JsonUtility.FromJson<Jsonclass>(File.ReadAllText(Application.persistentDataPath + "/result.json"));
            nm.text = jsnData.Name.ToString();
            lvl.text = jsnData.Level.ToString();
            dat.value= jsnData.TestParam;
            dat1.text= jsnData.TestParam.ToString();
            yield return StartCoroutine(getData());
        }
    }
    [System.Serializable]
    public class Jsonclass
    {
        public string Name;
        public int Level;
        public int TestParam;
    }

}
