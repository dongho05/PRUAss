
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ActionWithFile : MonoBehaviour
{

    private List<Ball> list = new List<Ball>();
    public void Save()
    {
        GameObject[] listObject = GameObject.FindGameObjectsWithTag("Circle");
        string path = "Assets/Resources/data.dat";
        File.WriteAllText(path, "");
        for (int i = 0; i < listObject.Length; i++)
        {
            list.Add(new Ball
            {
                x = listObject[i].transform.position.x,
                y = listObject[i].transform.position.y
            });
            Debug.Log(list.Count);
        }
        string result = JsonConvert.SerializeObject(list, Formatting.Indented);
        File.WriteAllText(path, result);
        HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        float score = hud.GetPoints();
        PlayerPrefs.SetString("Score", score.ToString());
    }
}
