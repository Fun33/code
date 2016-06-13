using System;
using System.Collections.Generic;
using System.Text;

 
public    class Layout
    {
    int w;
    int h;
   public      int tagH=3;
 
    public Layout(int _w, int _h )
    {
        w = _w;
        h = _h; 
    }
    public void setLocation(ref SAPbouiCOM.Item oItem, int x, int y)
    { 
        oItem.Top = y * h + (y + 1) * tagH;
        oItem.Left = x * w + (x + 1) * 5;
        oItem.Height = h;
        oItem.Width = w;
    }
    public void setLocation(ref SAPbouiCOM.Item oItem, int x, int y, int xPlus, int yPlus)
    {
        oItem.Top = y * h + (y + 1) * tagH;
        oItem.Left = x * w + (x + 1) * 5;
        oItem.Height = h * yPlus;
        oItem.Width = w * xPlus;
    }
    public void setLocation_Left(SAPbouiCOM.Form oForm, ref SAPbouiCOM.Item oItem, int x)
    {
        oItem.Top = oForm.Height - 25 - 50;
        oItem.Left = x * 100 + (x + 1) * 5;
        oItem.Height = 25;
        oItem.Width = 100;
    }

    public void setLocation_Right(SAPbouiCOM.Form oForm, ref SAPbouiCOM.Item oItem, int x)
    {
        oItem.Top = oForm.Height - 25 - 45;
        oItem.Left = oForm.Width - 100 - 30;
        oItem.Height = 25;
        oItem.Width = 100;
    }
    }
 
