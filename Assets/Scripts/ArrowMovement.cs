using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 Arrow_Movement;
    public AudioClip MissSound;
    public Transform Destruction;
    public string TagName;

    void Update()
    {
        transform.position += (Arrow_Movement * Time.deltaTime * speed);
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Perfect"))
        {
            Delete(CorrectSound);
        }
        if (other.gameObject.CompareTag("Good"))
        {
            Delete(CorrectSound);
        }
        if (other.gameObject.CompareTag("Ok"))
        {
            Delete(CorrectSound);
        }
        else
        {
            Debug.Log("Collision not doing anything");
        }
    }*/

    private void OnBecameInvisible()
    {
        Delete(MissSound);
    }

    public void Delete(AudioClip Sound)
    {
        AudioSource.PlayClipAtPoint(Sound, transform.position);
        //GameObject DestructionParticles = ((Transform)Instantiate(Destruction, this.transform.position, this.transform.rotation)).gameObject;
        //Destroy(DestructionParticles, 3.0f);
        GameObject.Destroy(gameObject);
    }
}