﻿using ProjectMotion;
using ProjectMotion.Feedback;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotionTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        MotionEngine engine;

        private void btnInitEng_Click(object sender, EventArgs e)
        {
            engine = new MotionEngine();
        }

        private void btnListDevices_Click(object sender, EventArgs e)
        {
            var devices = engine.ListDevices();
            foreach(var device in devices)
            {
                var lvItem = new ListViewItem(device.Id);
                lvItem.SubItems.Add(device.Name);
                lvItem.Tag = device;
                lvBTdev.Items.Add(lvItem);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var device = lvBTdev.SelectedItems[0].Tag as MotionDevice;
            engine.ConnectToDevice(device);
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            var intensity = int.Parse(txtF1.Text);
            engine.Vibrate(intensity);
        }

        private void btnI1_Click(object sender, EventArgs e)
        {
            engine.BeginInput();
            var gyroHandler = new ProjectMotion.Input.MotionInputHandler(onGyroUpdateMethod);
            engine.Input.RegisterHandler(0xf001, gyroHandler);
        }

        private void onGyroUpdateMethod(string json)
        {
            var gyro = engine.Input.DecodeInput<ProjectMotion.Input.Gyro>(json);
            
        }

        private void btnI2_Click(object sender, EventArgs e)
        {
            engine.Input.DeregisterHandler(0xf001);
        }
    }
}
