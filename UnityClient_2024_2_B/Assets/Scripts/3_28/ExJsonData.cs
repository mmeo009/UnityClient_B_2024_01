using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;                          // JSON 직렬화를 위한 패키지
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
        // JSON 직렬화
        string jsonData = JsonConvert.SerializeObject(data);
        // 파일 저장
        File.WriteAllText(filePath, jsonData);
    }
    PlayerData LoadData()
    {
        if(File.Exists(filePath))
        {
            // 파일 안에 데이터 읽기
            string jsonData = File.ReadAllText(filePath);
            // JSON 파일 역 직렬화
            PlayerData data = JsonConvert.DeserializeObject<PlayerData>(jsonData);
            return data;
        }
        else
        {
            return null;
        }
    }
}
