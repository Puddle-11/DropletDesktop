using UnityEngine;

public class DBManager : MonoBehaviour
{

    /*
      static async Task Main()
     {
         //string jsonUrl = "https://script.googleusercontent.com/macros/echo?user_content_key=AehSKLjC2N23zKTk2zHvQI72SanhtBlSo3rgpl0YypmliLhWTXkfH45jHRkZ7tKqmRlrf3NYoa_3Mb8H5XVi9U6rY3v05xrlYovXl-3_tBz1ZUnGLD8g4XwDgHpp1YKxX_-IEt2L0kZqc9_i8U6v-NT5njkcFmRggrdFG6OcU_FWLz3a9i9mqbRiUnFdnVfukWDWshjmuNwMJNcGsG2cPRJX38NxLwQLvrhE8El9oWuF0jp2x7dyKqpNmV4Aa2EAou_Ph-Dx3b7Wwpm8tI339Nc7gierk6gMK3K3N5oNBaGI&lib=M8QIDNzHSpOn5qjacq0ID0H4HDyti9-6M"; // Replace with your actual JSON URL
         string outputPath = "largefile.json";

         //await DownloadJsonAsStreamAsync(jsonUrl, outputPath);
         //Console.WriteLine("Download completed!");


        int max = await GetJsonArraySizeAsync(outputPath);
         int targetIndex = 1;

         string message = await GetMessageAtIndexAsync(outputPath, targetIndex);
         Console.WriteLine($"Message at index {targetIndex}: {message}");
     }

     static async Task<int> GetJsonArraySizeAsync(string filePath)
     {
         await using FileStream fs = File.OpenRead(filePath);
         using JsonDocument doc = await JsonDocument.ParseAsync(fs);
         return doc.RootElement.GetArrayLength();
     }

     static async Task DownloadJsonAsStreamAsync(string url, string outputPath)
     {
         using (HttpClient client = new HttpClient())
         using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
         {
             response.EnsureSuccessStatusCode();

             using (Stream stream = await response.Content.ReadAsStreamAsync())
             using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
             {
                 await stream.CopyToAsync(fileStream);
             }
         }
     }

     static async Task<string> GetMessageAtIndexAsync(string filePath, int targetIndex)
     {
         await using FileStream fs = File.OpenRead(filePath);
         using StreamReader sr = new StreamReader(fs);
         using JsonDocument doc = await JsonDocument.ParseAsync(fs);

         int currentIndex = -1; // Track array index

         foreach (JsonElement arrayElement in doc.RootElement.EnumerateArray())
         {
             currentIndex++;

             if (currentIndex == targetIndex)
             {
                 return arrayElement[3].GetString();
             }
         }

         return "Index out of range";
     }
      */

}
