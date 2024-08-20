using System.Collections;
using System.Collections.Generic;
using Assets.Script;
using UnityEngine;

public class ChangeNPCByStep : MonoBehaviour
{
    public PlayerData playerData;
    public List<GameSteps> conditionList;
    public List<GameObject> npcList;
    void Start()
    {
        int highestStepIndex = -1;

        for (int i = 0; i < conditionList.Count; i++)
        {
            if (playerData.HasStep(conditionList[i]))
            {
                highestStepIndex = i;
            }
        }

        for (int i = 0; i < npcList.Count; i++)
        {
            npcList[i].SetActive(i == highestStepIndex);
        }
    }

    void Update()
    {
        
    }
}
