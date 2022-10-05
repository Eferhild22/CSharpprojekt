using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRange : MonoBehaviour
{
    //These next serialized fields are for limiting player movement range
    [SerializeField] private int rightBoundary = 0;
    [SerializeField] private int leftBoundary = 0;
    [SerializeField] private int ceilingBoundary = 0;
    [SerializeField] private int floorBoundary = 0;
    [SerializeField] private UnitPlayer character1;
    [SerializeField] private UnitPlayer character2;
    [SerializeField] GameObject rangePrefab;
    
    void Update()
    {
        {
            //if (transform.position.x >= rightBoundary)
            //{
            //    transform.position = new Vector3(rightBoundary, transform.position.y, -0.5f);
            //}
            //else if (transform.position.x <= leftBoundary)
            //{
            //    transform.position = new Vector3(leftBoundary, transform.position.y, -0.5f);
            //}
            //if (transform.position.y >= ceilingBoundary)
            //{
            //    transform.position = new Vector3(transform.position.x, ceilingBoundary, -0.5f);
            //}
            //else if (transform.position.y <= floorBoundary)
            //{
            //    transform.position = new Vector3(transform.position.x, floorBoundary, -0.5f);
            //}

            if (Input.GetKeyDown(KeyCode.Return))
            {
                LimitRange();
            }
            void LimitRange()
            {

                if (transform.localPosition.x >= rightBoundary)
                {
                    transform.localPosition = new Vector3(rightBoundary, transform.localPosition.y, -0.5f);
                }
                else if (transform.localPosition.x <= leftBoundary)
                {
                    transform.localPosition = new Vector3(-leftBoundary, transform.localPosition.y, -0.5f);
                }
                if (transform.localPosition.y >= ceilingBoundary)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, ceilingBoundary, -0.5f);
                }
                else if (transform.localPosition.y <= floorBoundary)
                {
                    transform.localPosition = new Vector3(-transform.localPosition.x, floorBoundary, -0.5f);
                }
            }
        }
    }
}
