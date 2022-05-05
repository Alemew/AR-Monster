using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{
    private int currentLifePoints;
    public TextMeshProUGUI textLifePoints;
    public int maxLifePoints = 100;
    public Image redLifeBar;
    private bool invulnerability = false;
    private float invulnerabilityTime = 1f;
    private float destroyTime = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        currentLifePoints = 100;
        //textLifePoints.text = "Life: " + currentLifePoints;
        UpdateUI();
    }

    // Update is called once per frame
    public void UpdateLifePoints(int pointsDamage)
    {
        if (!invulnerability)
        {
            currentLifePoints -= pointsDamage;
            if (currentLifePoints <= 0)
            {
                currentLifePoints = 0;
                GetComponent<Animator>().SetBool("IsDying",true);
                StartCoroutine(DestroyTimer());
            }
            else
            {
                GetComponent<Animator>().SetBool("IsDamaging",true);
                StartCoroutine(InvulnerabilityTimer());
            }

            //textLifePoints.text = "Life: " + currentLifePoints;
            UpdateUI();
        }
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

    IEnumerator InvulnerabilityTimer()
    {
        invulnerability = true;
        yield return new WaitForSeconds(invulnerabilityTime);
        invulnerability = false;
    }

    private void UpdateUI()
    {
        textLifePoints.text = currentLifePoints + "/100";
        
        float lifePointsRedBar = (float) currentLifePoints / maxLifePoints;
        redLifeBar.transform.localScale = new Vector3(lifePointsRedBar,
            redLifeBar.transform.localScale.y, redLifeBar.transform.localScale.z);
    }
}
