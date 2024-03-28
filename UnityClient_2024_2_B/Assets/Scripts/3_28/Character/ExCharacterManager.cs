using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCharacterManager : MonoBehaviour
{
    public List<ExCharacter> exCharacterList = new List<ExCharacter>();

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < exCharacterList.Count; i++)
            {
                exCharacterList[i].DestroyCharacter();
            }
        }
    }
}
