using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Inside_Base_Resource : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FixRotation();
    }

    public void FixRotation()
    {
        //Code that fixes the rotation back to the nearest 90 degree angle
        if (transform.rotation.y != 0 && transform.parent == null)
        {
            var CurAngle = transform.eulerAngles;
            CurAngle.y = Mathf.Round(CurAngle.y / 90) * 90;
            transform.eulerAngles = CurAngle;
        }
    }
}
