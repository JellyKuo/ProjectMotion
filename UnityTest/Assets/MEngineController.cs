using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectMotion;
using UnityEngine.UI;
using ProjectMotion.Feedback;

public class MEngineController : MonoBehaviour
{
    public MotionEngine engine;
    public GameObject btnScan;
    public GameObject btnConnect;
    public GameObject btnVib;
    public GameObject ddDevices;
    private List<Dropdown.OptionData> ddOptions;
    private List<MotionDevice> mDevices;
    // Use this for initialization
    void Start()
    {
        ddOptions = new List<Dropdown.OptionData>();
        mDevices = new List<MotionDevice>();
        engine = new MotionEngine();
        btnScan.GetComponent<Button>().onClick.AddListener(btnScan_Click);
        btnConnect.GetComponent<Button>().onClick.AddListener(btnConnect_Click);
        btnVib.GetComponent<Button>().onClick.AddListener(btnVib_Click);
    }

    void btnScan_Click()
    {
        var dropdown = ddDevices.GetComponent<Dropdown>();
        ddOptions.Clear();
        mDevices.Clear();
        dropdown.ClearOptions();
        var devices = engine.ListDevices();

        foreach (var dev in devices)
        {
            Dropdown.OptionData option = new Dropdown.OptionData(string.Format("{0} - {1}", dev.Name, dev.MAC));
            ddOptions.Add(option);
            mDevices.Add(dev);
        }
        dropdown.AddOptions(ddOptions);

        //engine.PickDevice();
    }

    void btnConnect_Click()
    {
        var dropdown = ddDevices.GetComponent<Dropdown>();
        var mDevice = mDevices[dropdown.value];
        engine.ConnectToDevice(mDevice);
    }

    void btnVib_Click()
    {
        engine.Vibrate(5);
    }
}
