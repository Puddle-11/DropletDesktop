using UnityEngine;
using System;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text.Json;
public class DBManager : MonoBehaviour
{


    private void Start()
    {
        UnityEngine.Debug.Log(GetMessageAtIndexAsync("./Messages.json",  0));
    }

    static string GetMessageAtIndexAsync(string filePath, int targetIndex)
    {
          FileStream fs = File.OpenRead(filePath);
         StreamReader sr = new StreamReader(fs);
         JsonDocument doc = JsonDocument.Parse(fs);

        int currentIndex = -1;

        foreach (JsonElement arrayElement in doc.RootElement.EnumerateArray())
        {
            currentIndex++;

            if (currentIndex == targetIndex)
            {
                return arrayElement[3].GetString(); // Extract message (4th element)
            }
        }

        return "Index out of range";
    }

}
