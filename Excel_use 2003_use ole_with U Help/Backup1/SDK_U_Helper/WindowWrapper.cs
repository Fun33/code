using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

public class WindowWrapper : System.Windows.Forms.IWin32Window
{

    private IntPtr _hwnd;
    public virtual IntPtr Handle
    {
        get { return _hwnd; }
    }

    public WindowWrapper(IntPtr handle)
    {
        _hwnd = handle;
    }
}
