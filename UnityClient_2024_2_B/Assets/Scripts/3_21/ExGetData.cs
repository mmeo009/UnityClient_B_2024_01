using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExGetData : MonoBehaviour
{
    public Entity_Monster monster;

    void Start()
    {
        foreach(Entity_Monster.Param parm in monster.sheets[0].list)
        {
            Debug.Log(parm.index + " - " + parm.name + " - " + parm.hp + " - " + parm.mp);
        }    
    }

    void Update()
    {
        
    }
}
