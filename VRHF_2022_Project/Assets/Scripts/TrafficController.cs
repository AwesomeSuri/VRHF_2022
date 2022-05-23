using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class TrafficController : MonoBehaviour
{
    public GameObject Car;
    public WaypointCircuit[] Circuits;
    public float speed = 30f;
    public float SpawnInterval = 2f;
    [Range(0f, 2f)]
    public float timeRandomizer = 1f;
    public int vehicleAmount = 5;
    public int startTarget = 0;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))                                                           //SpawnTraffic() is called when you press the return key in game mode
            SpawnTraffic();
    }

    public void SpawnTraffic()
    {
        for (int circuitCount = 0; circuitCount < Circuits.Length; circuitCount++)
            StartCoroutine(SpawnTraffic(circuitCount));
    }


    private IEnumerator SpawnTraffic(int circuitCount)
    {
        for (int i = 0; i < vehicleAmount; i++)
        {
            GameObject Vehicle = Instantiate(Car);                                                      //instantiate a new vehicle from the prefab
            Vehicle.GetComponent<WaypointProgressTracker>().circuit = Circuits[circuitCount];           //give the new vehicle a waypoint circuit
            Vehicle.GetComponent<WaypointProgressTracker>().lookAheadForTargetOffset = 4;               //give the new vehicle a target offset
            Vehicle.GetComponent<MoveWithTracker>().velocity = speed / 3.6f;                           //give the new vehicle a speed
            Vehicle.GetComponent<Collision>().gameLogic = this.GetComponent<GameLogic>();                 //give the new vehicle the gamelogic for collisons

            Vehicle.transform.position = Circuits[circuitCount].transform.GetChild(startTarget).transform.position; //let the vehicle spawn on the position of the first waypoint (=first child object of waypoint)

            float wait = SpawnInterval + Random.Range(-timeRandomizer, timeRandomizer);
            yield return new WaitForSeconds(Mathf.Max(wait, 0.5f));
        }


    }

}
