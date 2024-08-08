using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectionHandoff : MonoBehaviour
{

    private HitDetection[] hitDetection;

    // Start is called before the first frame update
    void Start()
    {
        Transform player = transform.parent;
        

        hitDetection = player.GetComponentsInChildren<HitDetection>();

        Debug.Log("player:"  + player.name + " hitDetection: " + hitDetection.Length);
    }

    public void OpenHitbox()
    {

        Debug.Log("Opening Hitbox");

        foreach (HitDetection hd in hitDetection)
        {
            hd.OpenHitbox();
        }
    }

    public void CloseHitbox()
    {
        foreach (HitDetection hd in hitDetection)
        {
            hd.CloseHitbox();
        }
    }
}
