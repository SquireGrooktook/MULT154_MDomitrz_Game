using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;


[System.Serializable]
public class Score
{
    public Score(string n, int s)
    {
        name = n;
        score = s;
    }
    public string name;
    public int score;
}

public class ScoreList : MonoBehaviour
{
    public List<Score> scores = new List<Score>();
    public string fileName;
    public int scoreTransfer = 0;
    public GameObject input;
    GameManager Game_Manager;

    public GameObject finalPanel;
    public GameObject scorePanel;

    public GameObject entryPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Game_Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        int score_x = Game_Manager.score; //this is where it needs to go
        //DontDestroyOnLoad(gameObject);
        if (File.Exists(fileName))
        {
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                while (true)
                {
                    try
                    {
                        
                        string name = reader.ReadString();

                        int score = (int)reader.ReadSingle();
                        scores.Add(new Score(name, score));
                        
                    }
                    catch (EndOfStreamException e)
                    {
                        break;
                    }

                }
            }
        }
    }


    public void NewEntry()
    {
        string name = input.GetComponent<TMP_InputField>().text;
        Game_Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //scoreTransfer = Game_Manager.score;
        int score_x = Game_Manager.score; //this is where it needs to go

        scores.Add(new Score(name, score_x));

        scores.Insert(0, new Score(name, score_x));
        int offset = 0;
        foreach (Score score2 in scores)
        {
            GameObject temp = Instantiate(entryPrefab);
            Transform[] children = temp.GetComponentsInChildren<Transform>();
            children[1].GetComponent<TextMeshProUGUI>().text = score2.name;
            children[2].GetComponent<TextMeshProUGUI>().text = score2.score.ToString();

            temp.transform.SetParent(scorePanel.transform);
            RectTransform rtrans = temp.GetComponent<RectTransform>();
            rtrans.anchorMin = new Vector2(0.5f, 0.5f);
            rtrans.anchorMax = new Vector2(0.5f, 0.5f);
            rtrans.pivot = new Vector2(0.5f, 0.5f);
            rtrans.localPosition = new Vector3(0, offset, 0);

            offset -= 35;
        }

        finalPanel.SetActive(false);
        scorePanel.SetActive(true);
    }

    private void OnDestroy()
    {
        using (BinaryWriter write = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
        {
            foreach (Score score2 in scores)
            {
                write.Write(score2.name);
                write.Write((float)score2.score);
                //Debug.Log("why " + score2.score)
            }
        }
    }
}
