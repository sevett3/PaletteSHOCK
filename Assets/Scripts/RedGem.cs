using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().giveRed();
            FindObjectOfType<GameManager>().setActiveGem("red");
            Destroy(gameObject);
        }
    }
}
