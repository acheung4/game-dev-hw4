using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMotion : MonoBehaviour
{
    new Rigidbody rigidbody;
    [SerializeField] float rocketThrust = 1000f;
    [SerializeField] float rocketRotation = 200f;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update() {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.W)) {
            rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * rocketThrust);
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        }
        else {
            audioSource.Stop();
        }
    }
    
    void ProcessRotation() {
        if (Input.GetKey(KeyCode.J)) {
            transform.Rotate(Vector3.forward * Time.deltaTime * rocketRotation);
        }
        else if (Input.GetKey(KeyCode.L)) {
            transform.Rotate(Vector3.back * Time.deltaTime * rocketRotation);
        }
    }
}
