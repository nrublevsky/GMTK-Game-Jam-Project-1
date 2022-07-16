using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagement
{
  
    public class CubeController : MonoBehaviour
    {
        protected enum MoveDirection {
            Forward,
            Left,
            Backward,
            Right
        }

        #region Initialization 
        protected virtual void Awake()
        {
         
        }
        protected virtual void Init()
        {
            transform.localScale = Vector3.zero;
        }
        protected virtual void OnEnable()
        {
          
        }
        protected virtual void OnDisable()
        {
           
        }
        #endregion

        #region Fields
        public Transform View;
        protected bool _isMoving;
        
        #endregion

     
        #region Actions
        public Action<float> LevelProgressChanged;
        #endregion

        private void ResetCube()
        {
   
           
            _isMoving = false;
            StopAllCoroutines();
      
        }


        private void Update()
        {
            if (!_isMoving)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    MoveCube(MoveDirection.Forward);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    MoveCube(MoveDirection.Backward);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    MoveCube(MoveDirection.Right);
                }  if (Input.GetKey(KeyCode.A))
                {
                    MoveCube(MoveDirection.Left);
                }
            }
        }


        #region Cube Movement
       
        protected bool MoveCube(MoveDirection direction)
        {
            if (!_isMoving)
            {
                
                float halfScale = 1f/ 2f;  // cube size devided by two to find  the connecting edge to rotate aroun
                Vector3 moveAroundPoint = new Vector3(transform.position.x, transform.position.y+halfScale, transform.position.z);
                Vector3 moveDirection = Vector3.zero;
     
                switch (direction)
                {
                    case MoveDirection.Forward:
                         moveAroundPoint = new Vector3(0, -halfScale + moveAroundPoint.y, halfScale + moveAroundPoint.z);
                        moveDirection = Vector3.right;
                        break;
                    case MoveDirection.Backward:
                         moveAroundPoint = new Vector3(0, -halfScale + moveAroundPoint.y, -halfScale + moveAroundPoint.z);
                        moveDirection = -Vector3.right;
                        break;
                    case MoveDirection.Left:
                         moveAroundPoint = new Vector3(-halfScale + moveAroundPoint.x, -halfScale + moveAroundPoint.y, 0);
                        moveDirection = Vector3.forward;
                        break;
                    case MoveDirection.Right:
                         moveAroundPoint = new Vector3(halfScale + moveAroundPoint.x, -halfScale + moveAroundPoint.y, 0);
                        moveDirection = -Vector3.forward;
                        break;
                }
               
                   
                    StartCoroutine(MoveAnimation(moveAroundPoint, moveDirection,0.1f));
                    return true;
                
            }

            return false;
        }

        
        protected IEnumerator MoveAnimation(Vector3 moveAround, Vector3 moveDirection, float time)
        {
            _isMoving = true;
            float currentTime = 0;
            float lastFrameAngle = 0;
            while (currentTime < time)
            {
                currentTime += Time.deltaTime;
                if (currentTime > time)
                {
                    currentTime = time;
                }
                float x = currentTime / time;
                float frameAngle = x * 90f;
                float angleDelta = frameAngle - lastFrameAngle;
                lastFrameAngle = frameAngle;
                View.RotateAround(moveAround, moveDirection, angleDelta);
                transform.position = new Vector3(View.position.x, transform.position.y, View.position.z);
                View.localPosition = new Vector3(0, View.localPosition.y, 0);
                
                yield return null;
            }
            StopCubeMovement();
        }

        protected virtual void StopCubeMovement() {
            _isMoving = false;
        }
        #endregion
    }
}
