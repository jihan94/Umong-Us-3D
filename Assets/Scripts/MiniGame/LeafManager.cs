using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafManager : MonoBehaviour
{
    GameObject[] leafs = new GameObject[5];
    [SerializeField] RectTransform[] spawnPos = new RectTransform[5];
    [SerializeField] GameObject leafsPrefab = null;

    public GameObject bg;
    public GameObject canvas;
    static public int leftLeafs;

    void Start()
    {
        for(int i = 0; i < leafs.Length; ++i)
        {
            leafs[i] = Instantiate(leafsPrefab, bg.transform);
            leafs[i].transform.position = spawnPos[i].position;
        }
        leftLeafs = 5;
    }

    private void Update()
    {
        if(leftLeafs <= 0)
        {
            canvas.SetActive(false);
        }
        Debug.Log(leftLeafs);

    }

}
