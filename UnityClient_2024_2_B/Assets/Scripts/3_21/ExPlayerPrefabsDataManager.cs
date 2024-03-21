using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExPlayerPrefabsDataManager : MonoBehaviour
{
    public int scorePoint;
    private void SaveData(int score)
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    private int LoadData()
    {
        return PlayerPrefs.GetInt("Score");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveData(scorePoint);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Score : " + LoadData());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteKey("Score");
        }
    }
}
