using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public float lifeSpan = 8;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        Invoke("DeferredDestroy", lifeSpan);
    }
    // Update is called once per frame
    private void Update()
    {
        
    }

    private void DeferredDestroy()
    {
        Destroy(this.gameObject);
    }
}
