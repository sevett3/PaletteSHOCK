using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintBlock : MonoBehaviour
{
    public GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            gameObject.transform.LookAt(target.transform);
            gameObject.transform.Rotate(0, 180, 0);
        }   
    }
}
