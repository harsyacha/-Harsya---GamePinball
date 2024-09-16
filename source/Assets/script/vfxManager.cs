using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vfxManager : MonoBehaviour
{
    public GameObject vfx;
    public void PlayVFX(Vector3 spawn)
    {
        GameObject.Instantiate(vfx, spawn , Quaternion. identity);
    }
}
