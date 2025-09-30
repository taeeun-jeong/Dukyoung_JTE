using System;
using UnityEditor;
using UnityEngine;

public enum Status
{
    None = 0,
    Poison = 1 << 0,
    Burn = 1 << 1,
    Freeze = 1 << 2,
    Regen = 1 << 3,
}
public class StatusFlag : MonoBehaviour
{
    float hp = 100f;
    Status s = Status.None;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Add(Status.Poison);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Add(Status.Burn);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Add(Status.Freeze);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Add(Status.Regen);
        }

        if(Input.GetKeyDown(KeyCode.H))
            Heal();
        if (Input.GetKeyDown(KeyCode.C))
            ClearAll();

        if (Input.GetKeyDown(KeyCode.T))
            Tick();
        if (Input.anyKeyDown)
            Print();
    }


    private void Print()
    {
        string bin =Convert.ToString((int)s, 2).PadLeft(4,'0');
        Debug.Log($"HP = {hp} Status ={s} bin = {bin}");
    }

    private void Tick()
    {
        if(Has(Status.Burn) && Has(Status.Freeze))
        {
            Remove(Status.Freeze);
            Debug.Log("불이 물을 녹여 냉동 해제");
        }
        if (Has(Status.Poison))
        {
            hp -= 10;
        }
        if (Has(Status.Regen))
        {
            hp += 4;
        }
        hp = Mathf.Clamp(hp, 0, 100);
    }

    private void ClearAll()
    {
        s = Status.None;
    }

    private void Heal()
    {
        if (Has(Status.Poison))
        {
            Remove(Status.Poison);
            Debug.Log("중독해제");
        }
    }

    private void Remove(Status x)
    {
        s = s & x;
    }

    private bool Has(Status x)
    {
        return (s & x) != 0;
    }

    private void Add(Status x)
    {
        s = s | x;
    }
}
