using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;             // XML 사용하기 위한
using System.IO;

public class PlayerData                     // 플레이어 데이터 사용
{
    public string playerName;
    public int playerLevel;
    public List<string> items = new List<string>();
}

public class ExXMLData : MonoBehaviour
{
    string filePath;
    void Start()
    {
        filePath = Application.persistentDataPath + "/PlayerData.Xml";
        Debug.Log(filePath);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            PlayerData playerData = new PlayerData();
            playerData.playerName = "playerName";
            playerData.playerLevel = 3;
            playerData.items.Add("Stone");
            playerData.items.Add("Rock");
            SaveData(playerData);                         
      /*< PlayerData xmlns: xsd = "http://www.w3.org/2001/XMLSchema" xmlns: xsi = "http://www.w3.org/2001/XMLSchema-instance" >
        < playerName > playerName </ playerName >
        < playerLevel > 3 </ playerLevel >
        < items >
        < string > Stone </ string >
        < string > Rock </ string >
        </ items >
        </ PlayerData >*/
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            PlayerData playerData = new PlayerData();

            playerData = LoadData();

            Debug.Log(playerData.playerName);
            Debug.Log(playerData.playerLevel);
            for(int i = 0; i < playerData.items.Count; i++)
            {
                Debug.Log(playerData.items[i]);
            }
        }
    }

    void SaveData(PlayerData data)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
        FileStream stream = new FileStream(filePath, FileMode.Create);              // 파일 스트림 함수로 파일 생성
        serializer.Serialize(stream, data);                                         // 클래스 -> XML 변환 후 저장
        stream.Close();                                                             // 꼭 닫아줘야함 (쓰는 중이라 읽을 수 없음)
    }

    PlayerData LoadData()
    {
        if(File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
            FileStream stream = new FileStream(filePath, FileMode.Open);            // 파일 읽기 모드로 파일 열기
            PlayerData data = (PlayerData)serializer.Deserialize(stream);           // XML -> 클래스 읽어서 변환
            stream.Close();                                                         // 다 불러온 후 닫기
            return data;
        }
        else
        {
            return null;
        }

    }

}
