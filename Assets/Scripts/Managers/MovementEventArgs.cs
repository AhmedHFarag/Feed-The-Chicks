using UnityEngine;
using System.Collections;
using System;
namespace Custom
{
    public class MovementEventArgs :EventArgs
    {

        float xAxis;
        float yAxis;
        int joyStickID;
        bool hori;
        public float XAxis
        {
            get
            {
                return xAxis;
            }

            set
            {
                xAxis = value;
            }
        }

        public float YAxis
        {
            get
            {
                return yAxis;
            }

            set
            {
                yAxis = value;
            }
        }

        public int JoyStickID
        {
            get
            {
                return joyStickID;
            }

            set
            {
                joyStickID = value;
            }
        }

        public bool Hori
        {
            get
            {
                return hori;
            }
            set
            {
                hori = value;
            }
        }
    }
}

