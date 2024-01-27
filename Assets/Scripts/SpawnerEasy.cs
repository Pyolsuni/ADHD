using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEasy : MonoBehaviour
{
    public TextAsset beatMapJson;
    public GameObject arrowPrefab;

    private MapData mapData;

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
            float spawnTime = arrowData._time * 60 / 100; //Remplacer 127 par le bpm de la musique
            StartCoroutine(SpawnArrowRoutine(arrowData, spawnTime));
        }
    }

    private IEnumerator SpawnArrowRoutine(ArrowData arrowData, float spawnTime)
    {
        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < spawnTime)
        {
            elapsedTime = Time.time - startTime;
            yield return null;
        }

        SpawnBlock(arrowData);
    }

    private void SpawnBlock(ArrowData arrowData)
    {
        Vector3 arrowPosition = new Vector3(0, 0, 0);
        GameObject spawnedArrow = Instantiate(arrowPrefab, arrowPosition, Quaternion.identity, transform);

        switch (arrowData._lineIndex)
        {
            case 0:
                spawnedArrow.transform.Rotate(0, 0, 180);
                spawnedArrow.transform.position = new Vector3(-6, -5, 0);
                spawnedArrow.tag = "Down";
                break;
            case 1:
                spawnedArrow.transform.Rotate(0, 0, 0);
                spawnedArrow.transform.position = new Vector3(-4, -5, 0);
                spawnedArrow.tag = "Up";
                break;
            case 2:
                spawnedArrow.transform.Rotate(0, 0, 90);
                spawnedArrow.transform.position = new Vector3(-8, -5, 0);
                spawnedArrow.tag = "Left";
                break;
            case 3:
                spawnedArrow.transform.Rotate(0, 0, -90);
                spawnedArrow.transform.position = new Vector3(-2, -5, 0);
                spawnedArrow.tag = "Right";
                break;
            default:
                Debug.LogWarning($"Invalid arrow type: {arrowData._lineIndex}");
                return;
        }
    }
}