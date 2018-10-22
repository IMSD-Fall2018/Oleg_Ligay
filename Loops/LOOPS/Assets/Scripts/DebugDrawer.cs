using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawer : MonoBehaviour {

    public int numOfCubes;
    public int spacing;

    void OnDrawGizmos() //It is everything on the screen like camera icon or light icon
    {//gives to designers a sense of what is going on in the scene

        int otherinteger = 0;
        int verticalinteger = 0;
        Gizmos.color = Color.green;
        for(int i = 0; i < numOfCubes; i++)
        {
            for (int j = 0; j < numOfCubes; j++)
            {
                Gizmos.DrawCube(new Vector3(otherinteger, verticalinteger, 0), Vector3.one);
                otherinteger += spacing;
            }
            otherinteger = 0;
            verticalinteger += spacing;
        }

        
    }

}
