using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlanePlayer : MonoBehaviour
{
    Camera _camera;
    private byte _health = 12;

    public Action<int> OnHealthChanged;

    public byte Health {
        get { 
            return _health; 
        }
        private set { 
            _health = value;
            if (_health > 12) _health = 12;
            if (OnHealthChanged != null) OnHealthChanged.Invoke(_health);
        }
    }
    
    void Start()
    {
        _camera = Camera.main;
        ScoreData.Score = 0;
    }

    void Update()
    {
        SetPlayerPosByVector3(GetFingerPosition());
    }

    Vector3 GetFingerPosition()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider != null)
                return hit.point;
        }

        return Vector3.zero;
    }

    void SetPlayerPosByVector3(Vector3 inputPos)
    {
        Vector3 newPosition = transform.position;
        newPosition.x = inputPos.x;
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.CompareTag("Enemy")){
            DealDamage();
        }
        else if (collision.gameObject.CompareTag("SmallHeal")){
            Heal(2);
        }
        else if (collision.gameObject.CompareTag("BigHeal")){
            Heal(12);
        }
    }

    void DealDamage()
    {   
        Health--;

        if(_health == 0)
        {
            GetComponent<AppNavigationTool>().LoadScene(2);// плохо что значение захардкожено, но для проекта такого масштаба думаю это приемлемо
        }
    }

    void Heal(byte value)
    {
        Health += value;
    }
}

