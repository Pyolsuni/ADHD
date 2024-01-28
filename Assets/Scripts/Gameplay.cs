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
    private int combo = 1;

    public AudioClip PerfectSound;
    public AudioClip GoodSound;
    public AudioClip MissSound;

    public float DistancePerfect;
    public float DistanceGood;

    public int PerfectPoint;
    public int GoodPoint;
    public int MissPoint = -5;

    public KeyCode keyCode;

    public JokesterAnimationSelector animSelector;
    public int frameNr;

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
        if (Input.GetKeyDown(keyCode) && arrowin != null && Time.timeScale > float.Epsilon)
        {
            animSelector.SetFrameActive(frameNr);

            Vector3 posA = arrowin.transform.position;
            Debug.Log(posA);
            Vector3 posB = transform.position;
            Debug.Log(posB);
            float distance = Vector3.Distance(posA, posB);
            Debug.Log(distance);

            if(distance < DistancePerfect)
            {
                arrowin.GetComponent<ArrowMovement>().Delete(PerfectSound, PerfectPoint, combo);
                Debug.Log("Perfect Distance");
            }
            else if (distance < DistanceGood)
            {
                arrowin.GetComponent<ArrowMovement>().Delete(GoodSound, GoodPoint, combo);
                Debug.Log("Good Distance");
            }
            else
            {
                arrowin.GetComponent<ArrowMovement>().Delete(MissSound, MissPoint, 0);
                Debug.Log("Ok Distance");
                Counter.Instance.Combo = 0;
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
        Debug.Log("Arrow entered hitbox");
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        arrowin = null;
        Debug.Log("Arrow left hitbox");
    }
}