using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ControlManager
{
    public class ControlMoverOrResizer
    {
        private bool _moving;
        private Point _cursorStartPoint;
        private bool _moveIsInterNal;
        private bool _resizing;
        private Size _currentControlStartSize;
        public bool MouseIsInLeftEdge { get; set; }
        public bool MouseIsInRightEdge { get; set; }
        public bool MouseIsInTopEdge { get; set; }
        public bool MouseIsInBottomEdge { get; set; }

        public enum MoveOrResize
        {
            Move,
            Resize,
            MoveAndResize
        }

        public MoveOrResize WorkType { get; set; }

        ResizeCallback pResizeCallback;
        public void Init(Control control, ResizeCallback p)
        {
            pResizeCallback = p;
            Init(control, control);
        }

        public void Stop()
        {
            _moving = false;
            _resizing = false;
            _moveIsInterNal = false;
            _cursorStartPoint = Point.Empty;
            MouseIsInLeftEdge = false;
            MouseIsInLeftEdge = false;
            MouseIsInRightEdge = false;
            MouseIsInTopEdge = false;
            MouseIsInBottomEdge = false;

            m_control.MouseDown -= StartMovingOrResizing;
            m_control.MouseUp -=  StopDragOrResizing;
            m_control.MouseMove -= MoveControl;

        }
        Control m_control;
        public void Init(Control control, Control container)
        {
            m_control = control;
            _moving = false;
            _resizing = false;
            _moveIsInterNal = false;
            _cursorStartPoint = Point.Empty;
            MouseIsInLeftEdge = false;
            MouseIsInLeftEdge = false;
            MouseIsInRightEdge = false;
            MouseIsInTopEdge = false;
            MouseIsInBottomEdge = false;
            WorkType = MoveOrResize.MoveAndResize;
            control.MouseDown += StartMovingOrResizing; // += (sender, e) => StartMovingOrResizing(control, e);
            control.MouseUp += StopDragOrResizing;
            control.MouseMove += MoveControl;
        }
         


        private void UpdateMouseEdgeProperties(Control control, Point mouseLocationInControl)
        {
            if (WorkType == MoveOrResize.Move)
            {
                return;
            }
            MouseIsInLeftEdge = Math.Abs(mouseLocationInControl.X) <= 2;
            MouseIsInRightEdge = Math.Abs(mouseLocationInControl.X - control.Width) <= 2;
            MouseIsInTopEdge = Math.Abs(mouseLocationInControl.Y ) <= 2;
            MouseIsInBottomEdge = Math.Abs(mouseLocationInControl.Y - control.Height) <= 2;
        }

        private void UpdateMouseCursor(Control control)
        {
            if (WorkType == MoveOrResize.Move)
            {
                return;
            }
            if (MouseIsInLeftEdge )
            {
                if (MouseIsInTopEdge)
                {
                    control.Cursor = Cursors.SizeNWSE;
                }
                else if (MouseIsInBottomEdge)
                {
                    control.Cursor = Cursors.SizeNESW;
                }
                else
                {
                    control.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInRightEdge)
            {
                if (MouseIsInTopEdge)
                {
                    control.Cursor = Cursors.SizeNESW;
                }
                else if (MouseIsInBottomEdge)
                {
                    control.Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    control.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInTopEdge || MouseIsInBottomEdge)
            {
                control.Cursor = Cursors.SizeNS;
            }
            else
            {
                control.Cursor = Cursors.Default;
            }
        }
        
        public delegate void ResizeCallback(Control control, int X, int Y);
        private void StartMovingOrResizing(object sender, MouseEventArgs e)
        {
            if (_moving || _resizing)
            {
                return;
            }
            if (WorkType!=MoveOrResize.Move &&
                (MouseIsInRightEdge ||
                MouseIsInLeftEdge || 
                MouseIsInTopEdge || 
                MouseIsInBottomEdge))
            {
                _resizing = true;
                _currentControlStartSize = m_control.Size;
            }
            else if (WorkType!=MoveOrResize.Resize)
            {
                _moving = true;
                m_control.Cursor = Cursors.Hand;
            }
            _cursorStartPoint = new Point(e.X, e.Y);
            m_control.Capture = true;

        }

        private void MoveControl(object sender, MouseEventArgs e)
        {
            if (!_resizing && ! _moving)
            {
                UpdateMouseEdgeProperties(m_control, new Point(e.X, e.Y));
                UpdateMouseCursor(m_control);
            }
            if (_resizing)
            {
                if (MouseIsInLeftEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        m_control.Width -= (e.X - _cursorStartPoint.X);
                        m_control.Left += (e.X - _cursorStartPoint.X); 
                        m_control.Height -= (e.Y - _cursorStartPoint.Y);
                        m_control.Top += (e.Y - _cursorStartPoint.Y);
                        if (pResizeCallback != null)
                            pResizeCallback(m_control, e.X, e.Y);
                    }
                    else if (MouseIsInBottomEdge)
                    {
                        m_control.Width -= (e.X - _cursorStartPoint.X);
                        m_control.Left += (e.X - _cursorStartPoint.X);
                        m_control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                        if (pResizeCallback != null)
                            pResizeCallback(m_control, e.X, e.Y);
                    }
                    else
                    {
                        m_control.Width -= (e.X - _cursorStartPoint.X);
                        m_control.Left += (e.X - _cursorStartPoint.X) ;
                        if (pResizeCallback != null)
                            pResizeCallback(m_control, e.X, e.Y);
                    }
                }
                else if (MouseIsInRightEdge)
                {
                    if (MouseIsInTopEdge)
                    {
                        m_control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        m_control.Height -= (e.Y - _cursorStartPoint.Y);
                        m_control.Top += (e.Y - _cursorStartPoint.Y);
                        if (pResizeCallback != null)
                            pResizeCallback(m_control, e.X, e.Y);

                    }
                    else if (MouseIsInBottomEdge)
                    {
                        m_control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        m_control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                        if (pResizeCallback != null)
                            pResizeCallback(m_control, e.X, e.Y);
                    }
                    else
                    {
                        m_control.Width = (e.X - _cursorStartPoint.X)+_currentControlStartSize.Width;
                        if (pResizeCallback != null)
                            pResizeCallback(m_control, e.X, e.Y);
                    }
                }
                else if (MouseIsInTopEdge)
                {
                    m_control.Height -= (e.Y - _cursorStartPoint.Y);
                    m_control.Top += (e.Y - _cursorStartPoint.Y);
                    if (pResizeCallback != null)
                        pResizeCallback(m_control, e.X, e.Y);
                }
                else if (MouseIsInBottomEdge)
                {
                    m_control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                    if (pResizeCallback != null)
                        pResizeCallback(m_control, e.X, e.Y);
                }
                else
                {
                     _StopDragOrResizing();
                }
            }
            else if (_moving)
            {
                _moveIsInterNal = !_moveIsInterNal;
                if (!_moveIsInterNal)
                {
                    int x = (e.X - _cursorStartPoint.X) + m_control.Left;
                    int y = (e.Y - _cursorStartPoint.Y) + m_control.Top;
                    m_control.Location = new Point(x, y);
                }
            }
            
        }


        private void _StopDragOrResizing()
        {
            _resizing = false;
            _moving = false;
            m_control.Capture = false;
            UpdateMouseCursor(m_control);
        }

        private void StopDragOrResizing(object sender, MouseEventArgs e)
        {
            _resizing = false;
            _moving = false;
            m_control.Capture = false;
            UpdateMouseCursor(m_control);
        }

        #region Save And Load

        private List<Control> GetAllChildControls(Control control, List<Control> list)
        {
            List<Control> controls = control.Controls.Cast<Control>().ToList();
            list.AddRange(controls);
            return controls.SelectMany(ctrl => GetAllChildControls(ctrl, list)).ToList();
        }

        internal string GetSizeAndPositionOfControlsToString(Control container)
        {
            List<Control> controls = new List<Control>();
            GetAllChildControls(container, controls);
            CultureInfo cultureInfo = new CultureInfo("en");
            string info = string.Empty;
            foreach (Control control in controls)
            {
                info += control.Name + ":" + control.Left.ToString(cultureInfo) + "," + control.Top.ToString(cultureInfo) + "," +
                        control.Width.ToString(cultureInfo) + "," + control.Height.ToString(cultureInfo) + "*";
            }
            return info;
        }
        internal void SetSizeAndPositionOfControlsFromString(Control container, string controlsInfoStr)
        {
            List<Control> controls = new List<Control>();
            GetAllChildControls(container, controls);
            string[] controlsInfo = controlsInfoStr.Split(new []{"*"},StringSplitOptions.RemoveEmptyEntries );
            Dictionary<string, string> controlsInfoDictionary = new Dictionary<string, string>();
            foreach (string controlInfo in controlsInfo)
            {
                string[] info = controlInfo.Split(new [] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                controlsInfoDictionary.Add(info[0], info[1]);
            }
            foreach (Control control in controls)
            {
                string propertiesStr;
                controlsInfoDictionary.TryGetValue(control.Name, out propertiesStr);
                string[] properties = propertiesStr.Split(new [] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (properties.Length == 4)
                {
                    control.Left = int.Parse(properties[0]);
                    control.Top = int.Parse(properties[1]);
                    control.Width = int.Parse(properties[2]);
                    control.Height = int.Parse(properties[3]);
                }
            }
        }

        #endregion
    }
}