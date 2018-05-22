using UnityEngine;
using System.Collections;


public class AudioSourcePool : MonoBehaviour
{
    PoolObject pool;
    public GameObject Audiosource;
    public AudioClip clip;

    void Awake()
    {
        pool = new PoolObject(Audiosource, "Audiopool");
    }

    private void Update()
    {
        var v3 = Input.mousePosition;
        v3.z = 10.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);

        if (Input.GetMouseButtonDown(0))
        {
           
            var go = pool.RequestObject();
            go.transform.position = v3;
            AudioSource src = go.GetComponent<AudioSource>();
            src.spatialBlend = 1.0f;
            src.clip = clip;
            src.Play();
        }
    }

}
