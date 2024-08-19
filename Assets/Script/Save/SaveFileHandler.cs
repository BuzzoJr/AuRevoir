using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveFileHandler
{
    const string ENCRYPTION_KEY = "*2G%OE0swYTAnmTs31pgtJ7LhpqBldjZ";

    public string DirPath { get; private set; }
    private bool UseEncryption { get; set; }

    public SaveFileHandler(string dirPath, bool useEncryption = true)
    {
        DirPath = dirPath;
        UseEncryption = useEncryption;

        if (!Directory.Exists(dirPath))
            Directory.CreateDirectory(dirPath);
    }

    public List<string> ListFiles()
    {
        return Directory.GetFiles(DirPath).ToList();
    }

    public SaveData LoadFile(string saveName)
    {
        string fileName = Path.Combine(DirPath, saveName);

        if (!File.Exists(fileName))
            return null;

        try
        {
            string dataJson = ""; // Read file
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    dataJson = reader.ReadToEnd();
                }
            }

            if (UseEncryption)
                dataJson = Decrypt(dataJson);

            SaveData data = JsonUtility.FromJson<SaveData>(dataJson);

            return data;
        }
        catch (Exception e)
        {
            Debug.LogError("Error while loading file: " + fileName + "\n" + e);
        }

        return null;
    }

    public void SaveFile(SaveData data, string saveName)
    {
        string fileName = Path.Combine(DirPath, saveName);
        try
        {
            string dataJson = JsonUtility.ToJson(data);

            if (UseEncryption)
                dataJson = Encrypt(dataJson);

            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataJson);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error while saving file: " + fileName + "\n" + e);
        }
    }

    // XOR Encryption

    private string Encrypt(string text)
    {
        string encrypted = "";

        for (int i = 0; i < text.Length; i++)
            encrypted += (char)(text[i] ^ ENCRYPTION_KEY[i % ENCRYPTION_KEY.Length]);

        return encrypted;
    }

    private string Decrypt(string text)
    {
        string decrypted = "";

        for (int i = 0; i < text.Length; i++)
            decrypted += (char)(text[i] ^ ENCRYPTION_KEY[i % ENCRYPTION_KEY.Length]);

        return decrypted;
    }
}
