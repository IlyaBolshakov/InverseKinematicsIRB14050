using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientManagerIK : MonoBehaviour
{
   
    public Joint m_root;
    public Joint m_end;
    public GameObject m_target;
    public Joint l2_joint;
    public float treshhold = 1;
    public float m_speed = 10.0f;
    public float m_steps = 24;
    Joint m_current;
    int i = 0;
    Vector3 v1, v2;
    private void Start()
    {
        m_current = m_root;
        
    }

    float calculateSlope(Joint _joint)
    {
        float delta = 0.01f;
        float distance1 = getDistance(m_end.transform.position, m_target.transform.position);
        float pR = _joint.pRotationConstraint;
        float mR = _joint.mRotationConstraint;
        _joint.Rotate(delta);
        float distance2 = getDistance(m_end.transform.position, m_target.transform.position);
        _joint.Rotate(-delta);
        float turn = (distance2 - distance1) / delta;

        if((_joint.getAngle() - turn > mR) & (_joint.getAngle() - turn< pR))
        {
            //Debug.Log(_joint.getAngle());
            return turn;
        }
        return 0;
    }
    void Update()
    {
        
        for(i = 0; i < m_steps; i++)
        {
            if (m_current == null)
            {
                m_current = m_root;
            }
            if (getDistance(m_end.transform.position, m_target.transform.position) > treshhold)
            {
                float slope = calculateSlope(m_current);
                if (slope * slope > 0.0000000001f & m_current == m_root)
                {
                    m_current.Rotate(-slope * m_speed);
                }
                else
                {
                    m_current.Rotate(-slope * m_speed);
                    m_current = m_current.getChild();
                    

                }
                        
                while (m_current != null)
                {
                    slope = calculateSlope(m_current);
                    m_current.Rotate(-slope * m_speed);
                    m_current = m_current.getChild();
                }
                
                
            }
            else
            {
                m_current = m_root;

            }
        }
        i = 0;
        



            

        
    }

    float getDistance(Vector3 _end, Vector3 _target)
    {
        return Vector3.Distance( _end,  _target);
    }

    public bool targetAchieved()
    {
        bool targetAchieved;
        if(getDistance(m_end.transform.position, m_target.transform.position) > treshhold)
        {
            targetAchieved = false;
        }
        else
        {
            targetAchieved = true;
        }
        return targetAchieved;
    }

    public GameObject setTarget(GameObject _target)
    {
        m_target = _target;
        return m_target;
    }

    public GameObject getTarget()
    {
        return m_target;
    }

}




