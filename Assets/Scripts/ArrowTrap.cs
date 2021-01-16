using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class ArrowTrap : MonoBehaviour
{

    public Transform shootPoint;
    public Transform smokePoint;
    public GameObject arrowPrefab;
    public GameObject smokePrefab;
    public float arrowSpeed = 20f;
    public float startDelay = 0f;
    public float shootInterval = 2f;
    
    // Start is called before the first frame update
    void Start()
    {   
        try
        {
            InvokeRepeating("Shoot", startDelay, shootInterval);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }   
    }

    private void Shoot()
    {
        float zRotation = gameObject.transform.rotation.eulerAngles.z % 360;
        GameObject arrowInstance = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);

        Instantiate(smokePrefab, smokePoint.position, smokePoint.rotation);

        switch (zRotation)
        {
            case 180: arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.up * arrowSpeed);
            break;

            case 0: arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.down * arrowSpeed);
            break;

            case 270: arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.left * arrowSpeed);
            break;

            case 90: arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.right * arrowSpeed);
            break;
            
            default: throw new System.Exception("Z value or (Z mod 360) must be 0, 180, 270 or 90: "+ gameObject.name);
        }   
    }
}
