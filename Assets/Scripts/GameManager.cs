using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("Feinhos")]
    public List<GameObject> feinhos;
    public int numberOfFeinhos;

    List<GameObject> allFeinhos = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < numberOfFeinhos; i++)
        {
            float x = Random.Range(-10f, 10f);
            float y = Random.Range(0, 5);
            Vector3 pos = new Vector3(x, y, 0f);
            int fei = Random.Range(0, feinhos.Count);
            GameObject a = Instantiate(feinhos[fei], pos, Quaternion.identity);
            allFeinhos.Add(a);
        }


    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject feinho in allFeinhos)
        {
            feinho.transform.Rotate(Vector3.forward * Time.deltaTime * 30f);
        }
    }
}
