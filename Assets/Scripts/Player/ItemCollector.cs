using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int pic = 0; 
    private int canon = 0; 
    [SerializeField] private GameObject picItemPrefab; 
    [SerializeField] private GameObject canonItemPrefab;
    private HealthBar healthBar;



    private bool m_picHasBeenUsed;
    private bool m_canonHasBeenUsed;


    void Start()
    {
        m_picHasBeenUsed = false;
        m_canonHasBeenUsed = false;
        healthBar = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthBar>();
    }

    private void OnTriggerEnter2D(Collider2D collision){

            if (pic + canon < 5)
        {
            if (collision.gameObject.CompareTag("Pic"))
            { //récupère le type d'obstacle
                pic += 1;
                healthBar.resetLife();
               
                GameObject picObject = Instantiate(picItemPrefab) as GameObject;

                 /*if (collision.transform.gameObject.layer == 6)
                {
                    //récupère le parent parent (pike = children, children)
                    collision.gameObject.transform.parent.gameObject.SetActive(false);
                }*/
            }
            if (collision.gameObject.CompareTag("Canon"))
            {
                canon += 1;
                healthBar.resetLife();
              

                GameObject canonObject = Instantiate(canonItemPrefab) as GameObject;


                if (collision.transform.gameObject.layer == 6)
                {

                    //récupère le parent parent (bullet = children, children)

                    if (collision.gameObject.name == "Bullet"){
                        ///collision.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Animator>
                        Destroy(collision.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject); 
            
                    }/*else{
                        collision.gameObject.transform.parent.gameObject.SetActive(false);
                    }*/
                    
                }
            }
             
        }

        
    }

    public void UseItem(string _item)
    {
        if (_item.Equals("pic"))
        {
            GameObject[] smallPics = GameObject.FindGameObjectsWithTag("PicItem");
            Destroy((GameObject)smallPics.GetValue(0));
            m_picHasBeenUsed = true;
            pic -= 1;
            healthBar.degat();
            if(healthBar.getIsDead()){
                //healthBar.resetLife();
            }
        }
        else if (_item.Equals("canon"))
        {
            GameObject[] smallCanons = GameObject.FindGameObjectsWithTag("CanonItem");
            Destroy(smallCanons[0]);
            m_canonHasBeenUsed = true;
            canon -= 1;
            healthBar.degat();
            if(healthBar.getIsDead()){
                //healthBar.resetLife();
            }
        }
    }

    public bool CanUseItem(string _item)
    {
        if(_item.Equals("pic"))
        {
            return pic >= 1;
        }
        if (_item.Equals("canon"))
        {
            return canon >= 1;
        }
        return false;
    }

    public bool IsItemUsed(string _item)
    {
        if (_item.Equals("pic"))
        {
            return m_picHasBeenUsed;

        }
        if (_item.Equals("canon"))
        {
            return m_canonHasBeenUsed;
        }
        return false;
    }

    public void ChangeUsedItem(string _item)
    {
        if (_item.Equals("pic"))
        {
            m_picHasBeenUsed = false;
            
        }
        if (_item.Equals("canon"))
        {
            m_canonHasBeenUsed = false;
        }
    }
}