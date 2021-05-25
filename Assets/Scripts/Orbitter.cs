using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbitter : MonoBehaviour
{
    public int electronCount;
    public float maxRadius = 2;
    public float maxHeight = 5;
    public GameObject electronPrefab;

    private void Start()
    {
        CreateSpheres(electronCount, maxRadius, maxHeight);
    }

    public void CreateSpheres(int count, float radius, float height)
    {
        //var elecs = new GameObject[count];
        //var elecsToCopy = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        for (int i = 0; i < count; i++)
        {
            /*Instantiate(electronPrefab, new Vector3(transform.position.x + Random.Range(-radius, radius), 
                                                    transform.position.y + Random.Range(-height, height),
                                                    transform.position.z + Random.Range(-radius, radius)), 
                        Quaternion.identity, parent: transform);*/

            Instantiate(electronPrefab, new Vector3(transform.position.x + maxRadius,
                                                    transform.position.y + maxHeight,
                                                    transform.position.z + maxRadius),
                        Quaternion.identity, parent: transform);

            //electrons[i] = Instantiate(electronPrefab, parent:transform, position:new Vector3(transform.position.x + Random.Range(-maxRadius, maxRadius), transform.position.y + Random.Range(-maxRadius, maxRadius), transform.position.z + Random.Range(-maxRadius, maxRadius)));
        }
    }
}
