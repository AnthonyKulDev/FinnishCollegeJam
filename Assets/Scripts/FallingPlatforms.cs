using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    private float fallDelay = 1f;
    private float appearDelay = 2f;
    private float destroyDelay = 2f;

    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DisappearAndReappear(1f, 6f));
        }
    }

    private IEnumerator DisappearAndReappear(float timeUntilDisappear, float timeUntilRespawn)
    {
        yield return new WaitForSeconds(timeUntilDisappear);
        //rb.bodyType = RigidbodyType2D.Dynamic;
        gameObject.SetActive(false);
        Debug.Log(timeUntilRespawn);
        yield return new WaitForSeconds(timeUntilRespawn);
        
        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
