using UnityEngine;

public class appearingObstacle : MonoBehaviour
{
    new MeshRenderer renderer;
    new Rigidbody rigidbody;

    [SerializeField]
    float timeToWait = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();
        renderer.enabled = false;
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToWait)
        {
            renderer.enabled = true;
            rigidbody.useGravity = true;
        }
    }
}
