using UnityEngine;
using System;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
//using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.Networking;

public class DBManager : MonoBehaviour
{
    public static string filePath = "./Messages.json";
    public static string urlPath = "https://script.googleusercontent.com/macros/echo?user_content_key=AehSKLjC2N23zKTk2zHvQI72SanhtBlSo3rgpl0YypmliLhWTXkfH45jHRkZ7tKqmRlrf3NYoa_3Mb8H5XVi9U6rY3v05xrlYovXl-3_tBz1ZUnGLD8g4XwDgHpp1YKxX_-IEt2L0kZqc9_i8U6v-NT5njkcFmRggrdFG6OcU_FWLz3a9i9mqbRiUnFdnVfukWDWshjmuNwMJNcGsG2cPRJX38NxLwQLvrhE8El9oWuF0jp2x7dyKqpNmV4Aa2EAou_Ph-Dx3b7Wwpm8tI339Nc7gierk6gMK3K3N5oNBaGI&lib=M8QIDNzHSpOn5qjacq0ID0H4HDyti9-6M";
    public static bool loaded = false;
    private void Start()
    {
        StartCoroutine(LoadFile(urlPath, filePath));
    }
    public static object[] GetEntryAtRandomIndex()
    {
        return GetEntryAtRandomIndex(filePath);
    }
    public static object[] GetEntryAtIndex(int _index)
    {
        return GetEntryAtIndex(filePath, _index);
    }
    public static object[] GetEntryAtRandomIndex(string filePath)
    {
        if (!loaded) return null;
        string json = File.ReadAllText(filePath);

        var data = JsonConvert.DeserializeObject<List<object[]>>(json);

        int targetIndex = UnityEngine.Random.Range(0, data.Count);

        if (targetIndex >= 0 && targetIndex < data.Count)
        {
            var entry = data[targetIndex];
            return entry;
        }
        return null;
    }
    public static object[] GetEntryAtIndex(string filePath, int targetIndex)
    {
        if (!loaded) return null;

        // Read the JSON file
        string json = File.ReadAllText(filePath);

        // Deserialize JSON into a List of arrays (assuming it's an array of arrays)
        var data = JsonConvert.DeserializeObject<List<object[]>>(json);

        if (targetIndex >= 0 && targetIndex < data.Count)
        {
            var entry = data[targetIndex];
            return entry;
        }


        return null;
    }
    public static IEnumerator LoadFile(string url, string path)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                File.WriteAllText(path, request.downloadHandler.text);
                Debug.Log($"JSON downloaded and saved to: {path}");
                loaded = true;
            }
            else
            {
                Debug.LogError($"Error downloading JSON: {request.error}");
            }
        }

    }
}
