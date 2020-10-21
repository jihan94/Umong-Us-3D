using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateAsteroid : MonoBehaviour
{
    [SerializeField] Sprite[] asteroidType = null;
    [SerializeField] Sprite[] destroyedAsteroid = null;
    [SerializeField] GameObject DestroyEffect = null;

    private Image icon;
    private RectTransform tr;
    private int nowIndex;
    private float angle;
    private float velocity;
    private float upDown;

    public bool isHit { get; set; }
    bool isClick = false;

    void Awake()
    {
        icon = GetComponent<Image>();
        tr = GetComponent<RectTransform>();
        DestroyEffect.SetActive(false);
    }

    private void Start()
    {
        nowIndex = Random.Range(0, 5);
        icon.sprite = asteroidType[nowIndex];
        StartCoroutine(Move());
        velocity = Random.Range(150, 300);
        upDown = Random.Range(-1, 1);
    }

    public void IsClick()
    {
        if(!isHit)AsteroidManager.score += 1;
        isClick = true;
        isHit = true;
        icon.sprite = destroyedAsteroid[nowIndex];
        DestroyEffect.SetActive(true);
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Goal") Destroy(gameObject);
    }


    public IEnumerator Move()
    {
        while (!isClick)
        {
            tr.transform.Translate(-transform.right * velocity * Time.deltaTime);
            tr.transform.Translate(transform.up * 150 * upDown * Time.deltaTime);
            yield return null;
        }
    }
}
