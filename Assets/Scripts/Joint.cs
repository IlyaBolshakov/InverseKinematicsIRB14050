using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public Joint m_child;
    public Joint self;
    public Joint m_parent;
    public float pRotationConstraint;
    public float mRotationConstraint;
    float angleCurr=0f;
    bool agree = true;
    //public float zRotationConstraint;
    float zRot;
    public Joint getChild()
    {
        return m_child;
    }
    public Joint getParent()
    {
        return m_parent;
    }

    public float getAngle()
    {
        return angleCurr;
    }
    public float setAngle(float angle)
    {
        angleCurr = angle;
        return angleCurr;
    }

    public bool getAgree()
    {
        return agree;
    }
    public bool setAgree()
    {
        agree = !agree;
        return agree;
    }
    


    
    public void Rotate(float angle)
    {
        //zRot = self.transform.eulerAngles.z;
        //if((zRot > mRotationConstraint) & (zRot <pRotationConstraint))
         //   {
           // transform.Rotate(Vector3.forward * angle);
          //  }
        transform.Rotate(Vector3.forward * angle);
        angleCurr += angle;
        //Debug.Log(angleCurr);
    }
}
