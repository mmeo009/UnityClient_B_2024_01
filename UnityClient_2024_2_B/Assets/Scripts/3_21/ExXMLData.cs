using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;             // XML ����ϱ� ����
using System.IO;

public class PlayerData                     // �÷��̾� ������ ���
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
        FileStream stream = new FileStream(filePath, FileMode.Create);              // ���� ��Ʈ�� �Լ��� ���� ����
        serializer.Serialize(stream, data);                                         // Ŭ���� -> XML ��ȯ �� ����
        stream.Close();                                                             // �� �ݾ������ (���� ���̶� ���� �� ����)
    }

    PlayerData LoadData()
    {
        if(File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
            FileStream stream = new FileStream(filePath, FileMode.Open);            // ���� �б� ���� ���� ����
            PlayerData data = (PlayerData)serializer.Deserialize(stream);           // XML -> Ŭ���� �о ��ȯ
            stream.Close();                                                         // �� �ҷ��� �� �ݱ�
            return data;
        }
        else
        {
            return null;
        }

    }

}
