using UnityEngine;

public class bitlightDemo : MonoBehaviour
{
    uint light = 0;
    public GameObject[] Cubes;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            light = light ^ (1 << 0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            light = light ^ (1 << 1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            light = light ^ (1 << 2);

        if (Input.GetKeyDown(KeyCode.R))
            light = 0;

        for(int i = 0; i< Cubes.Length; i++)
        {
            bool on = (light & (1 << i)) != 0;
            Cubes[i].GetComponent<Renderer>().material.color = on ?
                Color.yellow : Color.gray;
        }
        if (Input.anyKeyDown)
        {
            string bin = System.Convert.ToString(light,2).PadLeft(4, '0');
            Debug.Log($"light(bin) = {bin} int{light}");
        }
    }
}
