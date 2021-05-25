using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron : MonoBehaviour
{
    [SerializeField] GameObject baseParent;
    [SerializeField] Orbitter parentObitter;

    [SerializeField] Vector3 direction;
    [SerializeField] Rigidbody rb;
    private void Awake()
    {
        baseParent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
        parentObitter = gameObject.transform.GetComponentInParent<Orbitter>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.position += 1 * Vector3.left;
        float rand = Random.Range(-1, 1);

        direction = new Vector3(Random.Range(transform.position.x - 1, transform.position.x + 1),
                                                                            Random.Range(transform.position.y - 1, transform.position.y + 1),
                                                                            Random.Range(transform.position.z - 1, transform.position.z + 1));
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.RotateAround(baseParent.transform.position, new Vector3(Random.Range(transform.position.x-1, transform.position.x+1), 
                                                                            Random.Range(transform.position.y- 1, transform.position.y+1), 
                                                                            Random.Range(transform.position.z - 1, transform.position.z + 1)), 100*Time.deltaTime);*/
        //transform.RotateAround(baseParent.transform.position, direction, Random.Range(0, 360) * Time.deltaTime);
        rb.AddRelativeForce(direction, ForceMode.Acceleration);
    }
}
