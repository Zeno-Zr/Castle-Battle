using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveAchievements
{
    public static void SavePlayer (PlayerAchievements player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/achievements.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        AchievementsBinary data = new AchievementsBinary(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static AchievementsBinary LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/achievements.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            AchievementsBinary data = formatter.Deserialize(stream) as AchievementsBinary;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
