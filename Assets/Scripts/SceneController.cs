using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    /*
     * SerializedField is recommended for private GameObjects,
     * as it ensures that the object won't be changed by other scripts.
     * This stores the prefab and will be called just one time.
     */
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemy == null)
        {
            /*
             * Main concept of this code is the method Instantiate(). It returns a new object of
             * Object type. As, in unity, we need it as GameObject, that's why we've casted it.
             * Also, _enemy just stores the instance, it'd be called again and again.
             */
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(0, 6.25f, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
