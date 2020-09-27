using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    MasterData masterData;
    TitleTextController titleTextController;
    ScoreTextController scoreTextController;

    Title title1;
    Title title2;
    Work work1;
    Work work2;

    int score;
    string scoreText;
    int MAX_SCORE = 40;
    int MAX_POW = 4;

    // Start is called before the first frame update
    void Start()
    {
        FadeManager.FadeIn(0.5f);
        SetInstances();
        masterData.LoadJsonFile();
        SetNewTitle();
    }

    void SetInstances()
    {
        masterData = GameObject.Find("MasterData").GetComponent<MasterData>();
        titleTextController = GameObject.Find("TitleText").GetComponent<TitleTextController>();
        scoreTextController = GameObject.Find("ScoreText").GetComponent<ScoreTextController>();
    }

    void SetNewTitle()
    {
        ChoiceNewTitle();
        FixRandomSeed();

        string title = GetTitleName(title1, title2);
        titleTextController.SetSText(title);
        Data.currentTitleName = RmoveNewLineText(title);

        SetScore();
        scoreTextController.SetSText(scoreText);

        ResetRandomSeed();
    }

    void ChoiceNewTitle()
    {
        title1 = masterData.GetRandomTitle(1);
        title2 = masterData.GetRandomTitle(2, title1.work_id);

        work1 = masterData.GetWorkByTitle(title1.work_id);
        work2 = masterData.GetWorkByTitle(title2.work_id);
    }

    string GetTitleName(Title title1, Title title2)
    {
        string particle = ChoiceParticle(title1.particle, title2.particle);

        string title = "";
        title += title1.name + particle;
        if (IsNeedNewLine(title1.name, title2.name))
        {
            title += "\n";
        }
        title += title2.name;

        return title;
    }

    bool IsNeedNewLine(string name1, string name2)
    {
        int border = 5;

        return (name1.Length > border || name2.Length > border);
    }

    string ChoiceParticle(string particle1, string particle2)
    {
        if (particle1 == "NONE" || particle2 == "NONE")
        {
            return "";
        }

        if (particle1 != "")
        {
            return particle1;
        }

        if (particle2 != "")
        {
            return particle2;
        }

        return "";
    }

    string GetTitleDescription(Work work1, Work work2)
    {
        string description = work1.description_1 + work2.description_2;
        string genre = work1.genre_1 + work2.genre_2;
        return description + "、" + genre + "漫画。";
    }

    string RmoveNewLineText(string baseText)
    {
        return baseText.Replace("\n", "");
    }

    void FixRandomSeed()
    {
        int seed = title1.id + title2.id * 1000;
        UnityEngine.Random.InitState(seed);
    }

    void ResetRandomSeed()
    {
        DateTime now = DateTime.Now;
        DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        int time = (int)(now - UnixEpoch).TotalSeconds;
        UnityEngine.Random.InitState(time);
    }

    void SetScore()
    {
        score = CalcScore();
        scoreText = GetScoreText(score);
        Data.currentScoreText = scoreText;
    }

    int CalcScore()
    {
        // 結果が均等にならないように、乱数を乗算して使う
        int tmp = UnityEngine.Random.Range(1, MAX_SCORE);
        int pow = UnityEngine.Random.Range(1, MAX_POW + 1);
        float tmp2 = Mathf.Pow(tmp, pow);

        int tmp3 = (int)(tmp2 * UnityEngine.Random.Range(0.5f, 1.2f));
        if (tmp3 <= 0)
        {
            tmp3 = 1;
        }

        return tmp3 * 100;
    }

    string GetScoreText(int score)
    {
        string text = "";

        int OKU = 100000000;
        int MAN = 10000;

        int oku = score / OKU;
        if (oku > 0)
        {
            text += oku.ToString() + "億";
            score = score % OKU;
        }

        int man = score / MAN;
        if (man > 0)
        {
            text += man.ToString() + "万";
            score = score % MAN;
        }

        if (oku == 0 && man < 100 && score > 0)
        {
            text += score.ToString();
        }

        return "通算売上: " + text + "部";
    }
}
