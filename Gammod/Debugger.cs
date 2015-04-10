using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Gammod
{
    class Debugger
    {
        private Control _outputControl;

        public Debugger()
        {

        }
        public Debugger(Control outputControl)
        {
            if ((outputControl != null) && (outputControl.GetType() == typeof(RichTextBox)))
                this._outputControl = outputControl;
            else
                throw new Exception("The output must be a control of type: RichTextBox");
        }

        [DefaultValue(false)]
        public bool DebugEnabled { get; set; }

        public void AssignControl(Control outputControl)
        {
            _outputControl = outputControl;
        }

        public void WriteText(String exception, String method, int level, String text)
        {
            if (!DebugEnabled)
                return;
            if (_outputControl == null)
                return;
            if (method.Equals(""))
            {
                StackFrame frame = new StackFrame(1);
                method = frame.GetMethod().Name;
            }
            String tabs = " ";
            for (int i = 0; i < level; i++)
                tabs += "\t";
            var box = (_outputControl as RichTextBox);
            box.AppendText("[");
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = Color.DarkGray;
            box.SelectionFont = new Font(box.SelectionFont, FontStyle.Bold);
            box.AppendText(method);
            box.SelectionColor = box.ForeColor;
            box.SelectionFont = new Font(box.SelectionFont, FontStyle.Regular);
            box.AppendText("]" + tabs +" [");
            if (!exception.Equals(""))
            {
                box.SelectionStart = box.TextLength + 1;
                box.SelectionLength= exception.Length;
                box.SelectionColor = Color.DarkRed;
                box.SelectionFont = new Font(box.SelectionFont, FontStyle.Bold);
                box.AppendText(exception);
            }
            box.SelectionFont = new Font(box.SelectionFont, FontStyle.Regular);
            box.AppendText(text + "]" + Environment.NewLine);
            box.ScrollToCaret();
        }

        public void WriteText(String method, int level, String text)
        {
            if (!DebugEnabled)
                return;
            if (method.Equals(""))
            {
                var frame = new StackFrame(1);
                method = frame.GetMethod().Name;
            }
            WriteText("", method, level, text);
        }

        public void WriteText(String method, String text)
        {
            if (!DebugEnabled)
                return;
            if (method.Equals(""))
            {
                var frame = new StackFrame(1);
                method = frame.GetMethod().Name;
            }
            WriteText("", method, 0, text);
        }

        public void WriteText(String text)
        {
            if (!DebugEnabled)
                return;
            var frame = new StackFrame(1);
            WriteText("", frame.GetMethod().Name, 0, text);
        }

        public void WriteText(String exception, String text, int level)
        {
            if (!DebugEnabled)
                return;
            var frame = new StackFrame(1);
            WriteText(exception, frame.GetMethod().Name, level, text);
        }

        public void WriteText(String text, int level)
        {
            if (!DebugEnabled)
                return;
            var frame = new StackFrame(1);
            WriteText("", frame.GetMethod().Name, level, text);
        }

        public void Enter()
        {
            if (!DebugEnabled)
                return;
            var frame = new StackFrame(1);
            WriteText("", frame.GetMethod().Name, 0, "Entering >>>");
        }

        public void Exit()
        {
            if (!DebugEnabled)
                return;
            var frame = new StackFrame(1);
            WriteText("", frame.GetMethod().Name, 0, "<<< Exiting");
        }

    }
}
