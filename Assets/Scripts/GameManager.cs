using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gamerOverText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text recordText;

    public bool isGameOver;

    public int score;
    public int record;

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        record = PlayerPrefs.GetInt("Record", 0);
        Debug.Log("Valor al cargar de record: " + record.ToString());
        recordText.text = "Record: " + record.ToString();
    }

    public void GameOver()
    {
        isGameOver = true;
        gamerOverText.SetActive(true);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score > record)
        {
            PlayerPrefs.SetInt("Record", score);
            Debug.Log("Valor guardado de record: " + score.ToString());
            recordText.text  = "Record: " + score.ToString();
            PlayerPrefs.Save();
        }
    }
}