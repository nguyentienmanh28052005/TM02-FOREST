using TMPro;
using UnityEngine;

public class TestSave : MonoBehaviour
{
    private SaveDataPlayer _data;
    public TextMeshProUGUI Text;

    public int value;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _data = GameObject.Find("Data").GetComponent<SaveDataPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "x" + _data.Value(value).ToString();
    }
    
    
}
