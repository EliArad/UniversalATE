using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSkinLib
{

    public enum LRF_FIELD
    {
        ONOFF,
        ARM,
        FIRE,
        LAST_TARGET,
        PPS        
    }
    public enum LASER_POINTER_FIELD
    {
        ONOFF,
        ARM,
        FIRE,
        PULSE
    }

    public interface IButtonEx
    {
        void NotifyFunction(BUTTON_NAME btnName, double value1, double value2, double value3);
        void NotifyClick(BUTTON_NAME btnName, double value = 0);
        void NotifyDown(BUTTON_NAME btnName, int value = -1);
        void NotifyUp(BUTTON_NAME btnName, int value = -1);
        void NotifyDoubleClick(BUTTON_NAME btnName, int value = -1);
        void FovScrollCallback(int id, int position, int percentage);
    }

    public interface IJoystickHandler
    {
        void NotifyJoyHandlerRightClick();
        void NotifyJoyHandlerPositionMiddle(Point p);
        void NotifyJoyHandlerStop();
        void NotifyYawPitch(int yaw, int pitch);
        void NotifyYaw(int yaw);
        void NotifyPitch(int pitch);
        void NotifyFastRate();
        void NotifySlowRate();
    }

    public interface IButton
    {
        void NotifyDown(BUTTON_NAME btnName, int value = -1);
        void NotifyEnter(BUTTON_NAME btnName);
        void NotifyUp(BUTTON_NAME btnName);
        void NotifyDoubleClick(BUTTON_NAME btnName);
    }
}





