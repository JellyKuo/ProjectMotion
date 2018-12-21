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
    public GameObject btnStartRead;
    public GameObject btnStopRead;
    public GameObject ddDevices;
    private List<Dropdown.OptionData> ddOptions;
    private List<MotionDevice> mDevices;
    // Use this for initialization
    void Start()
    {
        UnitySystemConsoleRedirector.Redirect();
        ddOptions = new List<Dropdown.OptionData>();
        mDevices = new List<MotionDevice>();
        engine = new MotionEngine();
        btnScan.GetComponent<Button>().onClick.AddListener(btnScan_Click);
        btnConnect.GetComponent<Button>().onClick.AddListener(btnConnect_Click);
        btnVib.GetComponent<Button>().onClick.AddListener(btnVib_Click);
        btnStartRead.GetComponent<Button>().onClick.AddListener(btnStartRead_Click);
        btnStopRead.GetComponent<Button>().onClick.AddListener(btnStopRead_Click);
    }

    async void btnScan_Click()
    {
        var dropdown = ddDevices.GetComponent<Dropdown>();
        ddOptions.Clear();
        mDevices.Clear();
        dropdown.ClearOptions();
        var devices = engine.BeginListDevices();

        foreach (var dev in await devices)
        {
            Dropdown.OptionData option = new Dropdown.OptionData(string.Format("{0} - {1}", dev.Name, dev.Address));
            ddOptions.Add(option);
            mDevices.Add(dev);
        }
        dropdown.AddOptions(ddOptions);
    }

    async void btnConnect_Click()
    {
        var dropdown = ddDevices.GetComponent<Dropdown>();
        var mDevice = mDevices[dropdown.value];
       var state =  await engine.BeginConnectToDevice(mDevice);
        Debug.Log("Connect result "+state);
    }

    void btnVib_Click()
    {
        engine.Vibrate(5);
    }

    void btnStartRead_Click()
    {
        engine.BeginInput();
        var gyroUpdateDelegate = new ProjectMotion.Input.MotionInputHandler(OnGyroUpdate);
        engine.Input.RegisterHandler(ProjectMotion.Input.Gyro.id, gyroUpdateDelegate);
    }

    void btnStopRead_Click()
    {
        engine.StopInput();
        engine.Input.DeregisterHandler(ProjectMotion.Input.Gyro.id);
    }

    void OnGyroUpdate(string Json)
    {
        var gyro = engine.Input.DecodeInput<ProjectMotion.Input.Gyro>(Json);
        Debug.Log($" X:{gyro.X}, Y:{gyro.Y}, Z:{gyro.Z}");
    }
}
