using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[Serializable]
public class InputJson
{
    public Work[] works;
    public Title[] titles;
}

[Serializable]
public class Work
{
    public int id;
    public string name;
    public int publish;
    public int active;
    public string description_1;
    public string description_2;
    public string genre_1;
    public string genre_2;
}

[Serializable]
public class Title
{
    public int id;
    public string name;
    public string particle;
    public int position;
    public int work_id;
    public int active;
}

public class MasterData : MonoBehaviour
{
    InputJson inputJson;

    void Start()
    {
    }

    public void LoadJsonFile()
    {
        string inputString = Resources.Load<TextAsset>("MasterData").ToString();
        inputJson = JsonUtility.FromJson<InputJson>(inputString);
    }

    public Title GetRandomTitle(int position, int ignoreWorkId = 0)
    {
        int i = 0;
        Title title;

        while (true)
        {
            title = GetRandomTitleOne();

            // 無限ループ防止
            i++;
            if (i > 1000)
            {
                break;
            }

            if (title.active == 0)
            {
                continue;
            }

            if (title.work_id == ignoreWorkId)
            {
                continue;
            }

            if (title.position != position)
            {
                continue;
            }

            break;
        }

        return title;
    }

    Title GetRandomTitleOne()
    {
        int index = UnityEngine.Random.Range(0, inputJson.titles.Length);
        return inputJson.titles[index];
    }

    public Work GetWorkByTitle(int workId)
    {
        return inputJson.works.Where(v => v.active == 1).First(v => v.id == workId);
    }
}
