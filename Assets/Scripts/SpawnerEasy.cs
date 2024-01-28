using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEasy : MonoBehaviour
{
    public TextAsset beatMapJson;
    public int BPM;

    public GameObject arrowUp;
    public GameObject arrowDown;
    public GameObject arrowLeft;
    public GameObject arrowRight;

    private MapData mapData;

    public float delay;
    
    //private List<Coroutine> spawnerCoroutines = new List<Coroutine>();

    [System.Serializable]
    public class ArrowData
    {
        public float _time;
        public int _lineIndex;
    }

    [System.Serializable]
    public class MapData
    {
        public string _version;
        public List<ArrowData> _notes;
    }


    private void OnEnable()
    {
        mapData = JsonUtility.FromJson<MapData>(beatMapJson.text);

        foreach (ArrowData arrowData in mapData._notes)
        {
            float spawnTime = arrowData._time * 60 / BPM; //Remplacer 127 par le bpm de la musique

            // Calculate travel time based on distance and arrow speed.
            float travelTime = CalculateTravelTime();

            // Adjust spawn time by subtracting travel time.
            float adjustedSpawnTime = spawnTime - travelTime;


            StartCoroutine(SpawnArrowRoutine(arrowData, adjustedSpawnTime));
            //spawnerCoroutines.Add(StartCoroutine(SpawnArrowRoutine(arrowData, spawnTime)));
        }
    }

    private float CalculateTravelTime()
    {
        // Assuming a constant arrow speed, adjust this value based on your game's requirements.
        float arrowSpeed = 3.0f; // Adjust this value according to the speed of your arrows.

        // Assuming the hit zone is at position (0, 0, 0) and the spawner is at position (spawnerX, spawnerY, spawnerZ).
        Vector3 hitZonePosition = new Vector3(0, delay, 0);
        Vector3 spawnerPosition = transform.position; // Assuming the script is attached to the spawner.

        // Calculate the distance between the spawner and the hit zone.
        float distance = Vector3.Distance(spawnerPosition, hitZonePosition);

        // Calculate the travel time based on distance and arrow speed.
        float travelTime = distance / arrowSpeed;

        return travelTime;
    }

    private IEnumerator SpawnArrowRoutine(ArrowData arrowData, float adjustedSpawnTime)
    {
        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < adjustedSpawnTime)
        {
            elapsedTime = Time.time - startTime;
            yield return null;
        }

        SpawnBlock(arrowData);
    }

    private void SpawnBlock(ArrowData arrowData)
    {
        Vector3 arrowPosition = new Vector3(0, 0, 0);
        switch (arrowData._lineIndex)
        {
            case 0:
                GameObject spawnedArrowDown = Instantiate(arrowDown, arrowPosition, Quaternion.identity, transform);
                spawnedArrowDown.transform.position = new Vector3(-6.5f, -5, 0);
                spawnedArrowDown.tag = "Down";
                break;
            case 1:
                GameObject spawnedArrowUp = Instantiate(arrowUp, arrowPosition, Quaternion.identity, transform);
                spawnedArrowUp.transform.position = new Vector3(-4.5f, -5, 0);
                spawnedArrowUp.tag = "Up";
                break;
            case 2:
                GameObject spawnedArrowLeft = Instantiate(arrowLeft, arrowPosition, Quaternion.identity, transform);
                spawnedArrowLeft.transform.position = new Vector3(-8.5f, -5, 0);
                spawnedArrowLeft.tag = "Left";
                break;
            case 3:
                GameObject spawnedArrowRight = Instantiate(arrowRight, arrowPosition, Quaternion.identity, transform);
                spawnedArrowRight.transform.position = new Vector3(-2.5f, -5, 0);
                spawnedArrowRight.tag = "Right";
                break;
            default:
                Debug.LogWarning($"Invalid arrow type: {arrowData._lineIndex}");
                return;
        }
    }

    /*public void StopSpawner()
    {
        spawnerCoroutines.ForEach(coroutine => { if (coroutine != null) { StopCoroutine(coroutine); } });
    }*/
}