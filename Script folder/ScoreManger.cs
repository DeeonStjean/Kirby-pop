using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManger : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] Text scoretxt;
    [SerializeField] Text leveltxt;
    [SerializeField] Text nameTxt;
    [SerializeField] int level;
    public static ScoreManger instance;

    // Start is called before the first frame update
    void Start()
    {
        score = PersistentData.Instance.GetScore();
        level = SceneManager.GetActiveScene().buildIndex;
        DisplayLevel();
        DisplayScore();
        DisplayName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        instance=this;
    }
    public void AdvanceLevel()
    {
        SceneManager.LoadScene(level + 1);
    }
    public void DisplayScore()
    {
        scoretxt.text = "Score: " + score;
    }

    public void DisplayLevel()
    {
        leveltxt.text = "Level: " + (level);
    }
    public void DisplayName()
    {
        nameTxt.text = "Hi, " + PersistentData.Instance.GetName();
    }
    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("score " + score);
        DisplayScore();
        PersistentData.Instance.SetScore(score);
    }

}
