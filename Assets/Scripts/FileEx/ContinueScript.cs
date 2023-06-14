using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueScript : MonoBehaviour
{
    public Button btnContinue;
    [SerializeField]
    GameObject prefabCircle;

    public static ContinueScript instance;
    public static bool IsEnter = false;

    public static List<Ball> GetInstance()
    {
        string path = "Assets/Resources/data.dat";
        List<Ball> list = new List<Ball>();
        if (File.Exists(path))
        {

            StreamReader reader = new StreamReader(path, true);

            var line = reader.ReadToEnd();
            reader.Close();

            list = JsonConvert.DeserializeObject<List<Ball>>(line);

            return list;
        }
        else
        {
            return null;
        }
    }
    public void HandleContinueButtonOnClickEvent()
    {
        string path = "Assets/Resources/data.dat";
        List<Ball> list = new List<Ball>();
        if (File.Exists(path))
        {
            IsEnter = true;
            SceneManager.LoadScene("FileExScene");
            //StreamReader reader = new StreamReader(path, true);

            //var line = reader.ReadToEnd();
            //reader.Close();

            //list = JsonConvert.DeserializeObject<List<Ball>>(line);

            //Debug.Log(list.Count);

            //foreach (var item in list)
            //{
            //    GameObject circle = Instantiate(prefabCircle);
            //    circle.transform.position = new Vector3(item.x, item.y, 0f);
            //    circle.tag = "Circle";

            //}
        }
        else
        {
            btnContinue.interactable = false;
            Debug.Log("File does not exist!");
        }

    }
}
