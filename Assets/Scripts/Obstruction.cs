using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.XR;

public class Obstruction : MonoBehaviour
{

    [SerializeField]
    protected Vector2 SpawnBounds;

    [SerializeField]
    private float expireDistance;

    public float speed;

    public ObstructionManager manager;

    private void OnDisable()
    {
        ResetObstruction();
    }


    private void Start()
    {
        transform.position = new Vector3(Random.Range(SpawnBounds.x, SpawnBounds.y), -3.0f, 45.0f);
    }
    private void ReturnToPool()
    {
        manager.obstructionPool.Add(this.gameObject);
    }
    private void ResetObstruction()
    {
        //Reset to start of street

        transform.position = new Vector3(Random.Range(SpawnBounds.x, SpawnBounds.y),-3.0f, 45.0f);
        ReturnToPool();
        
    }

    private void Update()
    {
       SlideAlong();

       if (transform.position.z <= expireDistance)
           gameObject.SetActive(false);
    }

    private void SlideAlong()
    {
        transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            ObstructionHit(other);
            ResetObstruction();
        }
    }

    protected virtual void ObstructionHit(Collider other)
    {
        Debug.Log("Hit car");
        other.GetComponent<PlayerStateHandler>().Carhit();
    }
}
