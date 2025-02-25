using System;
using System.Collections;
using UnityEngine;

public class DataSkill : MonoBehaviour
{
    [SerializeField] private GameObject _bulletFire1;
    [SerializeField] private GameObject _bulletUltiFire;
    [SerializeField] private GameObject _skillWatter1;
    //[SerializeField] private GameObject _skillWatter2;
    [SerializeField] private GameObject _skillBase1;
    [SerializeField] private GameObject _skillBase2;
    [SerializeField] private GameObject _posi;
    private bool isAttacking;

    private Animator _animHood;
    private Animator _animHas;
    private bool OnSkillBase = false;
    private bool OnSkillBase1 = false;
    private bool OnSkillBase2 = false;
    public int SkillBase = 1;
    private void Awake()
    {
        _animHood = GetComponent<Animator>();
    }

    public void bulletFire1()
    {
        Vector3 spon = _posi.transform.position;
        spon.y -= 0.35f;
        GameObject bullet =  Instantiate(this._bulletFire1, spon, _posi.transform.rotation);
        bullet.gameObject.SetActive(true);
    }
    
    public void bulletUltiFire()
    {
        Vector3 spon = _posi.transform.position;
        spon.y -= 1f;
        GameObject bullet =  Instantiate(this._bulletUltiFire, spon, _posi.transform.rotation);
        bullet.gameObject.SetActive(true);
    }

    // public void skillWater2()
    // {
    //     Vector3 spon = _posi.transform.position;
    //     spon.y -= 0.4f;
    //     GameObject bullet =  Instantiate(this._skillWatter2, spon, _posi.transform.rotation);
    //     bullet.gameObject.SetActive(true);
    // }

    public void skillWaterBall()
    {
        Vector3 spon = _posi.transform.position;
        spon.y += 0.2f;
        GameObject bullet =  Instantiate(this._skillWatter1, spon, _posi.transform.rotation);
        bullet.gameObject.SetActive(true);
    }

    public void BaseSkill()
    {
        if (!OnSkillBase)
        {
            _animHood.SetBool("SkillBase", true);
            OnSkillBase = true;
            if(SkillBase == 1)
            {
                _skillBase1.SetActive(true);
                OnSkillBase1 = true;
                SkillBase = 2;
                Invoke("SetSkillBase1False",0.15f);
            }
            else if(SkillBase == 2)
            {
                _skillBase2.SetActive(true);
                OnSkillBase2 = true;
                SkillBase = 1;
                Invoke("SetSkillBase2False",0.15f);
            }
            StartCoroutine(AnimSkillBase());
        }
    }

    IEnumerator AnimSkillBase()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.25f);
        _animHood.SetBool("SkillBase", false);
        isAttacking = false;
        OnSkillBase = false;
    }

    public void SetSkillBase1False()
    {
        OnSkillBase1 = false;
        _skillBase1.SetActive(false);
    }
    
    public void SetSkillBase2False()
    {
        OnSkillBase2 = false;
        _skillBase2.SetActive(false);
    }

    public bool GetStatusSkillBase1()
    {
        return OnSkillBase1;
    }

    public bool GetStatusSkillBase2()
    {
        return OnSkillBase2;
    }


    

    public IEnumerator Skill1Has()
    {
        _animHas.SetTrigger("atk1");
        isAttacking = true;
        yield return new WaitForSeconds(2);
        isAttacking = false;
    }

    public bool GetIsAttacking()
    {
        return isAttacking;
    }
}
