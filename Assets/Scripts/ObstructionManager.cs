using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.XR;

public class ObstructionManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> obstructionPrefabs;

    public List<GameObject> obstructionPool;


    public float spawnFrequency;

    public float spawnTimer;

    private void Start()
    {
        spawnTimer = spawnFrequency;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0.0f)
        {
            PlaceObstruction();
            spawnTimer = spawnFrequency;
        }

    }


    private void PlaceObstruction()
    {

        GameObject newRef = null;

       if (obstructionPool.Count == 0)
        {
            newRef = Instantiate(obstructionPrefabs[Random.Range(0, obstructionPrefabs.Count - 1)]);
            newRef.GetComponent<Obstruction>().manager = this;
        }
       else
       {
            newRef = obstructionPool[0];
            newRef.SetActive(true);

            //unneccessary, i think
            newRef.GetComponent<Obstruction>().manager = this;


            obstructionPool.Remove(newRef);
        }

    }

  
}
