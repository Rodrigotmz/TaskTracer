using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_cli.CLI
{
    public class LoadData<T>
    {
        private string filePath = $@"{Directory.GetCurrentDirectory()}\TaskList.json";
        
        public async Task<List<T>> GetJsonData()
        {
            List<T> collectionJson = new List<T>();
            if (File.Exists(filePath))
            {
                var currentJson = await File.ReadAllTextAsync(filePath);
                if (!string.IsNullOrWhiteSpace(currentJson))
                {
                    collectionJson = JsonConvert.DeserializeObject<List<T>>(currentJson) ?? new List<T>();
                }
            }
            else
            {
                var json = JsonConvert.SerializeObject(collectionJson, Formatting.Indented);
                await File.WriteAllTextAsync(filePath, json); 
            }
            return collectionJson;
        }
        public async Task SaveJsonData(List<T> collectionJson)
        {
            var json = JsonConvert.SerializeObject(collectionJson, Formatting.Indented);
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
