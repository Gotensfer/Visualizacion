using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarutoFloating : MonoBehaviour
{

        public float speed = 1f;  // adjust this to change the speed of the movement
        public float amplitude = 1f;  // adjust this to change the height of the movement
        private float startY;

        void Start()
        {
            startY = transform.position.y;  // record the object's starting Y position
        }

        void Update()
        {
            float newY = startY + amplitude * Mathf.Sin(speed * Time.time);  // calculate the new Y position
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);  // move the object to the new position
        }

}
