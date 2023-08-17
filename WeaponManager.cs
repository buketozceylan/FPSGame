using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public enum weaponSelect
    {
        knife,
        bottle,
        cleaver,
        bat,
        axe,
        spray,
        pistol,
        shotgun
    }

    public weaponSelect chosenWeapon;
    public GameObject[] weapons;
    private int weaponID = 0;
    private Animator anim;
    private AudioSource audioPlayer;
    public AudioClip[] weaponSounds;

    void Start()
    {
        weaponID = (int)chosenWeapon;
        anim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        ChangeWeapons();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (weaponID < weapons.Length - 1)
            {
                weaponID++;
                ChangeWeapons();
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (weaponID > 0)
            {
                weaponID--;
                ChangeWeapons();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
            audioPlayer.clip = weaponSounds[weaponID];
            audioPlayer.Play();

        }
    }

    private void ChangeWeapons(){

        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }

        weapons[weaponID].SetActive(true);
        chosenWeapon = (weaponSelect)weaponID; 
        anim.SetInteger("WeaponId",weaponID);
        anim.SetBool("weaponChanged",true);
        Move();
        StartCoroutine(WeaponReset());
    }

    private void Move()
    {
        switch (chosenWeapon)
        {
            case weaponSelect.knife:
                transform.localPosition = new Vector3(0.02f,-0.174f,0.66f);
                break;
            case weaponSelect.bottle:
                transform.localPosition = new Vector3(0.02f,-0.174f,0.66f);
                break;
            case weaponSelect.cleaver:
                transform.localPosition = new Vector3(0.02f,-0.174f,0.66f);
                break;
            case weaponSelect.bat:
                transform.localPosition = new Vector3(0.02f,-0.174f,0.66f);
                break;
            case weaponSelect.axe:
                transform.localPosition = new Vector3(0.02f,-0.174f,0.66f);
                break;
            case weaponSelect.spray:
                transform.localPosition = new Vector3(0.02f,-0.174f,0.66f);
                break;
            case weaponSelect.pistol:
                transform.localPosition = new Vector3(0.02f,-0.174f,0.66f);
                break;
            case weaponSelect.shotgun:
                transform.localPosition = new Vector3(0.02f,-0.174f,0.45f);
                break;    
        }
    }




    IEnumerator WeaponReset(){

        yield return new WaitForSeconds(0.5f);
        anim.SetBool("weaponChanged",false);

    }
}
