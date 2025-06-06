using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Cube cube = other.GetComponent<Cube>();
        if(cube != null )
        {
            if(!cube.IsMainCube && cube.CubeRigidBody.velocity.magnitude < 0.1f)
            {
                EventHandler.OnGameOver.Invoke();
                return;
            }
        }
    }

}
