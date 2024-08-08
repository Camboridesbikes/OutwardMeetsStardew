using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Weapon : MonoBehaviour
{

    public Collider hitCollider;
    // Start is called before the first frame update
    void Start()
    {
        hitCollider = GetComponent<SphereCollider>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit Enemy");
            other.gameObject.GetComponent<EmeraldAI.IDamageable>().Damage(10);
        }
    }
}
