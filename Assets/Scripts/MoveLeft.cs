using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime / 5;
        transform.Translate(Vector3.left * (speed * Time.deltaTime));
    }
}
