using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderObstacle : MonoBehaviour
{

    void Update()
    {
            transform.Rotate(new Vector3(0f,0f,45f)*Time.deltaTime*3f);
    }


}
