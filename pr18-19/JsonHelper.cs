using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

public static class JsonHelper
{
    public static void SaveToFile<T>(T obj, string fileName)
    {
        DataContractJsonSerializer serializer =
            new DataContractJsonSerializer(typeof(T));

        using (FileStream fs = new FileStream(
            fileName,
            FileMode.Create,
            FileAccess.Write))
        {
            serializer.WriteObject(fs, obj);
        }
    }

    public static T LoadFromFile<T>(string fileName)
    {
        DataContractJsonSerializer serializer =
            new DataContractJsonSerializer(typeof(T));

        using (FileStream fs = new FileStream(
            fileName,
            FileMode.Open,
            FileAccess.Read))
        {
            return (T)serializer.ReadObject(fs);
        }
    }
}
