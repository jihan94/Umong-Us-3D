using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidManager : MonoBehaviour
{
    GameObject[] asteroid = new GameObject[5];
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] RectTransform[] srcSpot = new RectTransform [5];
    bool isOver = false;

    static public int score = 0;
    private int srcIndex;
    public GameObject bg;
    public Text scoreText;
    public GameObject shootingMiniGame;

    void Start()
    {
        StartCoroutine(RegenAsteroid());
        score = 0;
    }

    IEnumerator RegenAsteroid()
    {
        while(score < 20)
        {
            Debug.Log(score);
            for (int i = 0; i < 5; ++i)
            {
                srcIndex = Random.Range(0, 5);
                asteroid[i] = Instantiate(asteroidPrefab, bg.transform);
                asteroid[i].SetActive(true);
                asteroid[i].transform.position = srcSpot[srcIndex].position;
            }
            
            yield return new WaitForSeconds(2.15f);
        }

    }
    private void Update()
    {
        scoreText.text = score.ToString();
        if (score >= 20) shootingMiniGame.SetActive(false);
    }

    public void IncreaseScore()
    {
        score++;
    }

}


