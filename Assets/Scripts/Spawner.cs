using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public TextAsset beatMapJson;
    public GameObject arrowPrefab;
    public float spacingX = 0.75f;
    public float offsetX = 1.125f;

    private MapData mapData;

    [System.Serializable]
    public class ArrowData
    {
        public float _time;
        public int _lineIndex;
        public int _cutDirection;
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
        Debug.Log(startTime);
        Debug.Log(elapsedTime);
        Debug.Log(spawnTime);
    }

    private void SpawnBlock(ArrowData arrowData)
    {
        float xPosition = -(arrowData._lineIndex * spacingX - offsetX); //Added offset so that it is centered
        Vector3 arrowPosition = new Vector3(xPosition, 0, 0);

        GameObject spawnedArrow = Instantiate(arrowPrefab, arrowPosition, Quaternion.identity, transform);


        switch (arrowData._cutDirection)
        {
            case 0:
                spawnedArrow.transform.Rotate(0, 0, 180);
                break;
            case 1:
                spawnedArrow.transform.Rotate(0, 0, 0);
                break;
            case 2:
                spawnedArrow.transform.Rotate(0, 0, 90);
                break;
            case 3:
                spawnedArrow.transform.Rotate(0, 0, -90);
                break;
            default:
                Debug.LogWarning($"Invalid arrow type: {arrowData._cutDirection}");
                return;
        }


    }
}