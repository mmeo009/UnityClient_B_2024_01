using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System;
using System.Linq;
using System.Security.Cryptography;

public class ExEncrypt : MonoBehaviour
{
    string filePath;
    string key = "ThisIsASecretKey";        // ��ȣȭ Ű
    void Start()
    {
        filePath = Application.persistentDataPath + "/EncryptPlayerData.json";
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

        // �����͸� ����Ʈ �迭�� ��ȯ
        byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(jsonData);

        // ��ȣȭ
        byte[] encryptedBytes = Encrypt(bytesToEncrypt);

        // ��ȣȭ�� �����͸� Base64 ���ڿ��� ��ȯ
        string encryptedData = Convert.ToBase64String(encryptedBytes);

        // ���� ����
        File.WriteAllText(filePath, encryptedData);
    }
    PlayerData LoadData()
    {
        if (File.Exists(filePath))
        {
            // ���� �ȿ� ������ �б�
            // string jsonData = File.ReadAllText(filePath);

            // ���Ͽ��� ��ȣȭ�� ������ �б�
            string encryptedData = File.ReadAllText(filePath);

            // Base64���ڿ��� ����Ʈ �迭�� ��ȯ
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);

            // ��ȣȭ
            byte[] decryptedBytes = Decrypt(encryptedBytes);

            // byte �迭�� ���ڿ��� ��ȯ
            string jsonData = Encoding.UTF8.GetString(decryptedBytes);

            // JSON ���� �� ����ȭ
            PlayerData data = JsonConvert.DeserializeObject<PlayerData>(jsonData);
            return data;
        }
        else
        {
            return null;
        }
    }

    byte[] Encrypt(byte[] plainBytes)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(key);
            aesAlg.IV = new byte[16];       //IV (intialization Vecter) �������� ����ϰų� �������� ����

            // ��ȣȭ ��ȯ�� ����
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // ��Ʈ�� ����
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                // ��Ʈ���� ��ȣȭ ��ȯ�⸦ �����Ͽ� ��ȣȭ ��Ʈ���� ����
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    // ��ȣȭ ��Ʈ���� ������ ����
                    csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                    csEncrypt.FlushFinalBlock();

                    // ��ȣȭ�� ������ ����Ʈ�� �迭�� ��ȯ
                    return msEncrypt.ToArray();
                }
            }
        }


    }
    byte[] Decrypt(byte[] encryptedBytes)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(key);
            aesAlg.IV = new byte[16];       //IV (intialization Vecter) �������� ����ϰų� �������� ����

            // ��ȣȭ ��ȯ�� ����
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // ��Ʈ�� ����
            using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
            {
                // ��Ʈ���� ��ȣȭ ��ȯ�⸦ ������ ��ȣȭ ��Ʈ�� ����
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    // ��ȣȭ �� �����͸� ���� ����Ʈ �迭 ����
                    byte[] decryptedBytes = new byte[encryptedBytes.Length];

                    // ��ȣȭ ��Ʈ������ �����͸� �б�
                    int decryptedByteCount = csDecrypt.Read(decryptedBytes, 0, decryptedBytes.Length);

                    // ������ ���� ũ�� ��ŭ�� ����Ʈ �迭�� ��ȯ
                    return decryptedBytes.Take(decryptedByteCount).ToArray();
                }
            }
        }
    }
}
