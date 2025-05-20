using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cube : MonoBehaviour
{
    static int staticID = 0;
    [SerializeField] private TMP_Text[] numberText;
    private Rigidbody cubeRigidbody;
    [HideInInspector] public int CubeNumber;
    [HideInInspector] public Color CubeColor;
    [HideInInspector] public bool IsMainCube;
    [HideInInspector] public int CubeID;
    private MeshRenderer cubeMeshRenderer;
    public Rigidbody CubeRigidBody => cubeRigidbody;
    private void Awake()
    {
        CubeID = staticID++;
        cubeMeshRenderer = GetComponent<MeshRenderer>();
        cubeRigidbody = GetComponent<Rigidbody>();
    }
    public void SetColor(Color color)
    {
        CubeColor = color;
        cubeMeshRenderer.material.color = color;
    }
    public void SetNumber(int number)
    {
        CubeNumber = number;
        for(int i=0; i<6; i++)
        {
            numberText[i].text=number.ToString();
        }
    }
}
