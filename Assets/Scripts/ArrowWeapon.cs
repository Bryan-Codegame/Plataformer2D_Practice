using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWeapon : MonoBehaviour
{
    public GameObject arrow;

    public Transform startShotPoint;

    public float arrowForce;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 arrPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimerDirection = mousePos - arrPos;
        transform.right = aimerDirection;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, startShotPoint.position, startShotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * arrowForce;
    }
}
