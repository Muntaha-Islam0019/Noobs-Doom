using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    // Checking if the object is alive or not.
    private bool _alive;
    private GameObject _fireball;

    [SerializeField] private GameObject fireballPrefab;

    // How far the object will stay from an object.
    public float obstacleRange = 5.0f;

    public float speed = 3.0f;

    // Start is called before the first frame update
    private void Start()
    {
        _alive = true;
    }

    // Update is called once per frame
    private void Update()
    {
        // Update, only if the object is alive.
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            // Generating a ray to forward of the object.
            var ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            /*
             * Casting a ray consisting an area of sphere, as, this will help the object to find out if there
             * is an object in front of it. ScreenPointToRay could be used, though, then it'd cause problem
             * for certain objects.
             */

            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                var hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab);
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward);

                        // Keep rotating in the same direction.
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    /*
                     * If the object finds another object in front of it, it'd move towards
                     * a random angle.
                     */

                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void setLife(bool life)
    {
        _alive = life;
    }
}