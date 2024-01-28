using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokesterAnimationSelector : MonoBehaviour
{

    public SpriteRenderer Jester0;
    public SpriteRenderer Jester3;
    public SpriteRenderer Jester5;
    public SpriteRenderer Jester8;

    // Start is called before the first frame update
    void Start()
    {
        SetFrameActive(1);
    }

    public void SetFrameActive(int frameNr)
    {
        Jester0.enabled = (frameNr == 0);
        Jester3.enabled = (frameNr == 1);
        Jester5.enabled = (frameNr == 2);
        Jester8.enabled = (frameNr == 3);
    }
}
