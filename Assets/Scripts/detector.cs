using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;
using UnityEngine.AI;

public class detector : MonoBehaviour
{
    public Material Cone_material, Cone_Alert;
    public GameObject cone, cone1, cone2;
    public GameObject Police;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.Find("Audio").GetComponent<AudioSource>();
        cone.GetComponent<MeshRenderer>().material = Cone_material;
        cone1.GetComponent<MeshRenderer>().material = Cone_material;
        cone2.GetComponent<MeshRenderer>().material = Cone_material;




    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("body"))
        {

            cone.GetComponent<MeshRenderer>().material = Cone_Alert;
            cone1.GetComponent<MeshRenderer>().material = Cone_Alert;
            cone2.GetComponent<MeshRenderer>().material = Cone_Alert;
            Police.GetComponent<CapsuleCollider>().enabled = true;
          //  Police.GetComponent<Enemy>().enabled = true;

            Police.GetComponent<Enemy>().angry = true;
            Police.GetComponent<NavMeshAgent>().enabled = true;
            Police.GetComponent<splineMove>().Pause();
            if (!source.isPlaying) {
                source.Play();
            }
        }
    }
}
