using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoStage1 : MonoBehaviour
{

    //ステージの大きさ
    int StageChipSize = 20;

    //ステージの生成数
    int currentChipIndex;

    public Transform character;        // プレイヤー
    public GameObject[] stageChips;    // ステージプレハブ
    public int startChipIndex;         // どこから生成するか
    public int preInstantiate;         // 事前に生成

    // 生成したステージのリスト
    public List<GameObject> generatedStageList = new List<GameObject>();     

    // Start is called before the first frame update
    void Start()
    {
        currentChipIndex = startChipIndex - 1;
        UpdateStage(preInstantiate);
    }

    // Update is called once per frame
    void Update()
    {

        int charaPositionIndex = (int)(character.position.z / StageChipSize);

        if (charaPositionIndex + preInstantiate > currentChipIndex) 
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }

    }

    void UpdateStage(int toChipIndex)
    {
        if(toChipIndex <= currentChipIndex)
        {
            return;
        }

        // ステージの生成
        for (int i = currentChipIndex + 1; i <= toChipIndex; i++)    
        {
            GameObject stageObject = GenerateStage(i);

            // 生成したステージチップを管理リストについか
            generatedStageList.Add(stageObject);

        }

        // 古いステージの削除
        while (generatedStageList.Count> preInstantiate + 2)     
        {
            DestroyOldestStage();
        }
        currentChipIndex = toChipIndex;

    }


    GameObject GenerateStage(int chipIndex)
    {
        int nextStageChip = Random.Range(0, stageChips.Length);

        //ステージの生成
        GameObject stageObject = (GameObject)Instantiate(
            stageChips[nextStageChip],
            new Vector3(0,0,chipIndex * StageChipSize),
            Quaternion.identity
            );

        return stageObject;
    }

    void DestroyOldestStage()
    {
        //ステージの削除
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }

}
