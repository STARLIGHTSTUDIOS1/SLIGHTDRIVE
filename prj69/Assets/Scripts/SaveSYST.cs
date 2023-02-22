using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSYST 
{
    //saving player pos
  public static void savePlayer(PlayerMovement playerMovement)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath+ "/playerdata.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(playerMovement);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static GameData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerdata.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
           GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
           
        }
        else
        {
            Debug.LogError("save file not found in" + path);
            return null;
        }
    }
}
