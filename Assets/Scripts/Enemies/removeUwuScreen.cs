using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeUwuScreen : MonoBehaviour
{
    public GameObject player;
    private GameObject arrow;

    [SerializeField] private GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Fire1") > 0)
        {
            /*GameObject bg = GameObject.Find("BackgroundMusic");
            bg.SetActive(true);*/
            gameObject.SetActive(false);
            AudioSource bg = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
            bg.Play();

            arrow = Instantiate(item) as GameObject;
            arrow.transform.SetParent(player.transform);
            arrow.transform.position = new Vector3(player.transform.position.x + 0.4f, player.transform.position.y - 0.5f, player.transform.position.z);

            Destroy(arrow.gameObject, 2);
        }
    }

}
