using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;                          // JSON ����ȭ�� ���� ��Ű��
using UnityEngine;
using System.IO;

public class ExJsonData : MonoBehaviour
{
    string filePath;
    void Start()
    {
        filePath = Application.persistentDataPath + "/PlayerData.Json";
        Debug.Log(filePath);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerData playerData = new PlayerData();
            playerData.playerName = "playerName";
            playerData.playerLevel = 3;
            playerData.items.Add("Stone");
            playerData.items.Add("Rock");
            SaveData(playerData);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerData playerData = new PlayerData();

            playerData = LoadData();

            Debug.Log(playerData.playerName);
            Debug.Log(playerData.playerLevel);
            for (int i = 0; i < playerData.items.Count; i++)
            {
                Debug.Log(playerData.items[i]);
            }
        }
    }
    void SaveData(PlayerData data)
    {
        // JSON ����ȭ
        string jsonData = JsonConvert.SerializeObject(data);
        // ���� ����
        File.WriteAllText(filePath, jsonData);
    }
    PlayerData LoadData()
    {
        if(File.Exists(filePath))
        {
            // ���� �ȿ� ������ �б�
            string jsonData = File.ReadAllText(filePath);
            // JSON ���� �� ����ȭ
            PlayerData data = JsonConvert.DeserializeObject<PlayerData>(jsonData);
            return data;
        }
        else
        {
            return null;
        }
    }
}
