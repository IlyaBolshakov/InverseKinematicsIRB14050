using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkAngle : MonoBehaviour
{
    public GameObject child, parent;
    public GameObject self;
    Vector3 v1, v2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(CalculateAngle(self));
    }

    float CalculateAngle(GameObject obj)
    {
        float angle;

        if (child != null & parent != null & obj != null)
        {
            v1 = parent.transform.position - obj.transform.position;
            v2 = child.transform.position - obj.transform.position;
            angle = Vector3.Angle(v1, v2);
            return angle;
        }
        else
        {
            return 0;
        }
    }
}
