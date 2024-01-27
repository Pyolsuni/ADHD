using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    //public GameObject upArrow;
    /*public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;*/

    private GameObject arrowin;

    public AudioClip PerfectSound;
    public AudioClip GoodSound;
    public AudioClip OkSound;

    public float DistancePerfect;
    public float DistanceGood;
    public float DistanceOk;

    public KeyCode keyCode;

    // Start is called before the first frame update
    void Start()
    {
        //Lorsque je lance le jeu
        /*upArrow.SetActive(false);
        downArrow.SetActive(false);
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode) && arrowin != null)
        {
            Vector3 posA = arrowin.transform.position;
            Debug.Log(posA);
            Vector3 posB = transform.position;
            Debug.Log(posB);
            float distance = Vector3.Distance(posA, posB);
            Debug.Log(distance);

            if(distance < DistancePerfect)
            {
                arrowin.GetComponent<ArrowMovement>().Delete(PerfectSound);
                Debug.Log("Perfect Distance");
            }
            else if (distance < DistanceGood)
            {
                arrowin.GetComponent<ArrowMovement>().Delete(GoodSound);
                Debug.Log("Good Distance");
            }
            else
            {
                arrowin.GetComponent<ArrowMovement>().Delete(OkSound);
                Debug.Log("Ok Distance");
            }
            


            //Debug.Log(Input.GetKeyDown(KeyCode.UpArrow));
        }
        //upArrow.SetActive(Input.GetKeyDown(KeyCode.UpArrow));
        /*downArrow.SetActive(Input.GetKeyDown(KeyCode.DownArrow));
        leftArrow.SetActive(Input.GetKeyDown(KeyCode.LeftArrow));
        rightArrow.SetActive(Input.GetKeyDown(KeyCode.RightArrow));*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        arrowin = other.gameObject;
        Debug.Log("Cube entered hitbox");
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        arrowin = null;
        Debug.Log("Cube left hitbox");
    }
}