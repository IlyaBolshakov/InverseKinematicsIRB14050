using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField x_cord,y_cord,z_cord;
    public Text text1, text2, text3;
    float x_cordf,y_cordf,z_cordf;
    public GameObject spawnObj, point;
    public Joint _joint;
    public Joint l2_joint;
    public GradientManagerIK grad;
    public GameObject _base,m_end;
    Vector3 transformVector, p_middle;
    GameObject p_intermediate = null, point_t, point_z;
    bool agree = true;
    int a = 0;
   
    public void ButtonClicked(GameObject point)
    {
        x_cordf = float.Parse(x_cord.text);
        y_cordf = float.Parse(y_cord.text);
        z_cordf = float.Parse(z_cord.text);
        if((((x_cordf*x_cordf) + ((y_cordf-3.6f)*(y_cordf-3.6f)) + (z_cordf*z_cordf))<(5.59*5.59))&(((x_cordf * x_cordf) + ((y_cordf -3.6f) * (y_cordf-3.6f)) + (z_cordf * z_cordf)) > (1.26 * 1.26)))
        {
            if (y_cordf < 2.5f)
            {
                if((x_cordf * x_cordf) + (z_cordf * z_cordf) > 1.6f * 1.6f)
                {
                    
                    transformVector = new Vector3(x_cordf, y_cordf, z_cordf);
                    point_t = Instantiate(point, transformVector, Quaternion.identity);
                    p_middle = posPoint(point,point_t,_base);
                    p_intermediate = Instantiate(spawnObj, p_middle, Quaternion.identity);
                    grad.setTarget(p_intermediate);
                    point.transform.position = transformVector;



                }

            }
            else
            {
                transformVector = new Vector3(x_cordf, y_cordf, z_cordf);
                point_t = Instantiate(point, transformVector, Quaternion.identity);
                p_middle = posPoint(point, point_t, _base);
                p_intermediate = Instantiate(spawnObj, p_middle, Quaternion.identity);
                grad.setTarget(p_intermediate);
                point.transform.position = transformVector;
            }
            
        }
    }
    void Update()
    {
        if(p_intermediate != null)
        {
            Debug.Log(getDistancetoEnd(p_intermediate.transform.position, m_end.transform.position));
            float r = getDistancetoEnd(p_intermediate.transform.position, m_end.transform.position);
            if ((r < 0.1f)& agree)
            {
                grad.setTarget(point_t);
                agree = false;
            }
            else
            {
                agree = true;
            }
        }
        
                
        
        

        
    }

    public Vector3 posPoint(GameObject _pStart, GameObject _pFinish,GameObject _base)
    {
        Vector3 v_middle, v_intermediate, v_obr, v_norm1, v_norm2, p_norm1, p_norm2;
        v_middle = (_pFinish.transform.position - _pStart.transform.position)/2;
        v_intermediate = _pStart.transform.position + v_middle; ;
        v_obr = new Vector3(_pFinish.transform.position.x - v_intermediate.x,0f, _pFinish.transform.position.z - v_intermediate.z);
        v_norm1 = new Vector3(v_obr.z, 0f, -v_obr.x);
        v_norm2 = new Vector3(-v_obr.z, 0f, v_obr.x);
        p_norm1 = v_norm1 + v_intermediate;
        p_norm2 = v_norm2 + v_intermediate;
        if (getDistancetoBase(p_norm1, _base.transform.position) >+ getDistancetoBase(p_norm2, _base.transform.position))
        {
            return p_norm1;
        }
        else
        {
            return p_norm2;
        }
        //return p_norm1;
    }
    float getDistancetoBase(Vector3 _point, Vector3 _base)
    {
        return Vector3.Distance(_point, _base);
    }
    float getDistancetoEnd(Vector3 _point, Vector3 _end)
    {
        return Vector3.Distance(_point, _end);
    }

}
