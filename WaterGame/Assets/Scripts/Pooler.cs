using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : Singleton<Pooler>
{
    [SerializeField] private GameObject waterPf;
    [SerializeField] private int waterCount = 20;  
    [SerializeField] private float smoothFactor = 2f;
    [SerializeField] private Vector3 followVec;    
    [SerializeField] private GameObject[] pastWaters;
    [SerializeField] private GameObject camObject;    
    [SerializeField] private float cameraY;
    [SerializeField] private GameObject waterForCamera;
    [SerializeField] private Vector3 finalCamLoc;
    public GameObject spawnPoint;
    public List<GameObject> waterObjects = new List<GameObject>();
    public GameObject cameras;
    
    [System.Obsolete]
    private void Start()
    {
        destroyLastLevelsWater();
        CreateWater();
    }

    private void LateUpdate()
    {       
        if(camObject == null)
        {
            GameManager.Instance.Fail(); //all water objects destroyed.
        }
        else
        {
            cameraY = camObject.transform.position.y;
        }
        

        if(cameraY > -14f && waterForCamera != null)
        {
            followVec = new Vector3(-1.15f, cameraY, 0);
            cameras.transform.position = Vector3.Lerp(cameras.transform.position, followVec, Time.deltaTime * smoothFactor);
        }
        else
        {
            finalCamLoc = new Vector3(-1.15f, -15.5f, 0);
            cameras.transform.position = Vector3.Lerp(cameras.transform.position, finalCamLoc, Time.deltaTime * smoothFactor);
        } 
    }

    private void Update()
    {
        waterForCamera = GameObject.FindGameObjectWithTag("Player");
        if (camObject == null)
        {
            if(waterForCamera == null)
            {
                finalCamLoc = new Vector3(-1.15f, -15.5f, 0);
                cameras.transform.position = Vector3.Lerp(cameras.transform.position, finalCamLoc, Time.deltaTime * smoothFactor);
                GameManager.Instance.Fail();
            }
            else
                camObject = Instantiate(waterPf, waterForCamera.transform.position, Quaternion.identity);
        }
    }

    [System.Obsolete]
    public void CreateWater()
    {
        for (int i = 0; i < waterCount; i++)
        {
            Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y);
            GameObject obj = Instantiate(waterPf, spawnPos, Quaternion.identity) as GameObject;
            waterObjects.Add(obj);
            obj.SetActive(false);
            if (i == 1)
            {
                camObject = obj;
            }
        }
    }

    public void destroyLastLevelsWater()
    {
        pastWaters = GameObject.FindGameObjectsWithTag("Player");

        for(int i= 0;i < pastWaters.Length; i++)
        {
            Destroy(pastWaters[i]);
        }
    }
}
