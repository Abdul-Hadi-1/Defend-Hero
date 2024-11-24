using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticShooter : MonoBehaviour
{
    public GameObject SpawnPrefab;
    public float newSpawnDuration = 10000f;
    public float forceMultiplier = 100f;

    private Vector3 SpawnPos;
    private Vector3 SpawnScreenPos;

    private GameObject CurrentSpawn;
    private bool SpawnReady = false;
    private bool kickedBall = false;
    private GameObject SpawnParent;

    private void Start()
    {
        SpawnPos = transform.position;
        SpawnScreenPos = Camera.main.WorldToScreenPoint(SpawnPos);
        SpawnParent = new GameObject("SpawnParent");
        SpawnNewObject();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !kickedBall)
        {
            Debug.Log("Inside Goal");
            kickedBall = true;
            AutoShoot();
        }
    }

    void AutoShoot()
    {
        if (SpawnReady)
        {
            Shoot();
        }
    }

    void SpawnNewObject()
    {
        Debug.Log("Getting new spawns");
        CurrentSpawn = Instantiate(SpawnPrefab, SpawnPos, Quaternion.identity, SpawnParent.transform);
        SpawnReady = true;
    }

    void Shoot()
    {
        Vector3 Force = new Vector3(1f,1f,1f);
        Debug.Log(CurrentSpawn.name);
        //CurrentSpawn.GetComponent<Rigidbody>().AddForce(Force * forceMultiplier);
        //CurrentSpawn.GetComponent<DragAndShoot>().SetShoot();
        SpawnReady = false;
        Rigidbody body = CurrentSpawn.GetComponent<Rigidbody>();
        body.AddForce(Vector3.forward * forceMultiplier, ForceMode.Acceleration);
        //Invoke("SpawnNewObject", newSpawnDuration);
    }
}