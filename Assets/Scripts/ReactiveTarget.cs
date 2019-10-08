using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    // Here, 'this' is optional.
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void react_to_hit()
    {
        // If the object is not null, then kill it.
        WanderingAI behaviour = GetComponent<WanderingAI>();
        if (behaviour != null)
        {
            behaviour.setLife(false);
        }
        
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);
        
        yield return new WaitForSeconds(1.5f);
        
        Destroy(this.gameObject);
    }
}
