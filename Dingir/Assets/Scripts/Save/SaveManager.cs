using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager 
{

    //Funciones de guardado para Player
    public static void SavePlayerData(Player player)
    {
        PlayerData playerData = new PlayerData(player);
        string dataPath = Application.persistentDataPath + "/Player.save";
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, playerData);
        fileStream.Close();
    }

    public static PlayerData LoadPlayerData()
    {
        string dataPath = Application.persistentDataPath + "/Player.save";
        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            PlayerData playerData = (PlayerData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return playerData;
        }
        else
        {
            Debug.LogError("No se encontró el archivo");
            return null;
        }
    }

    //Funciones de guardado para Settings
    public static void SaveSettingsData(SliderController settings)
    {
        SettingsData settingsData = new SettingsData(settings);
        string dataPath = Application.persistentDataPath + "/Settings.save";
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, settingsData);
        fileStream.Close();
    }

    public static SettingsData LoadSettingsData()
    {
        string dataPath = Application.persistentDataPath + "/Settings.save";
        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            SettingsData settingsData = (SettingsData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return settingsData;
        }
        else
        {
            Debug.LogError("No se encontró el archivo de guardado");
            return null;
        }
    }
}
