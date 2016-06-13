//  SAP MANAGE UI API 2007 SDK Sample
//****************************************************************************
//
//  File:      HelloWorld.cs
//
//  Copyright (c) SAP MANAGE
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
//****************************************************************************

// BEFORE STARTING:
// 1. Add reference to the "SAP Business One UI API"
// 2. Insert the development connection string to the "Command line argument"
//-----------------------------------------------------------------
// 1.
//    a. Project->Add Reference...
//    b. select the "SAP Business One UI API 2007" From the COM folder
//
// 2.
//     a. Project->Properties...
//     b. choose Configuration Properties folder (place the arrow on Debugging)
//     c. place the following connection string in the 'Command line arguments' field
// 0030002C0030002C00530041005000420044005F00440061007400650076002C0050004C006F006D0056004900490056
//
//**************************************************************************************************


using System;
using System.Windows.Forms;
using System.Xml;
using System.Threading;

class Menu  { 
    
    //**********************************************************
    // This parameter will use us to manipulate the
    // SAP Business One Application
    //**********************************************************
    
   
    
    private void SetApplication() { 
        
        // *******************************************************************
        // Use an SboGuiApi object to establish connection
        // with the SAP Business One application and return an
        // initialized appliction object
        // *******************************************************************
        
  SubMain. SboGuiApi = null; 
        string sConnectionString = null; 
        
     SubMain.   SboGuiApi = new SAPbouiCOM.SboGuiApi(); 
        
        // by following the steps specified above, the following
        // statment should be suficient for either development or run mode
        
        sConnectionString = System.Convert.ToString( Environment.GetCommandLineArgs().GetValue( 1 ) ); 
        
        // connect to a running SBO Application

        SubMain.SboGuiApi.Connect(sConnectionString); 
        
        // get an initialized application object

        SubMain.SBO_Application = SubMain.SboGuiApi.GetApplication(-1);
        SubMain.oCompany = (SAPbobsCOM.Company ) SubMain.SBO_Application.Company.GetDICompany();
               
    }

    
    public Menu() { 
        
        
        //*************************************************************
        // set SBO_Application with an initialized application object
        //*************************************************************
        
        //連線
        SetApplication();
 
        //load menu
       SubMain. LoadXML("delmenu.xml"); 
       //SubMain.LoadXML("addmenu.xml");
       //SubMain.LoadXML("addmenu.xml");

        //先掛,先跑
        SubMain.SBO_Application.MenuEvent += new SAPbouiCOM._IApplicationEvents_MenuEventEventHandler(SBO_MenuEvent);
        SubMain.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_ItemEvent);
        SubMain.SBO_Application.AppEvent += new SAPbouiCOM._IApplicationEvents_AppEventEventHandler(SBO_AppEvent);

        //fdoc fdoc = new fdoc();

        select f17 = new select();
        //f22 f1 = new f22();
        //f2 f2 = new f2();
        //f2 f2222 = new f2();
        //s22 f22 = new s22();
        //frm2          f3 = new frm2();
        //fdoc f4 = new fdoc();

        //s17 f5 = new s17();


    }

    #region event
    public void SBO_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
    {
        BubbleEvent = true;
        if (pVal.Before_Action == false)
        {
            if (pVal.FormType   == 142)
            {
                if (pVal.ItemUID == "1")
                    if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK)
                    {
                        SAPbouiCOM.Form f1 = SubMain.SBO_Application.Forms.ActiveForm;
                        SaveAsXML(ref f1);
                    }
            }
        }
    }
    public void SBO_MenuEvent(ref SAPbouiCOM. MenuEvent pVal, out bool BubbleEvent)
    {
        BubbleEvent = true;
        if (pVal.BeforeAction == false) return;
        else
        if (pVal.BeforeAction)
        { 
            switch (pVal.MenuUID )
            {
                case "M_testSDK":
                    f2 f1 = new f2();
               break;
        }
        }
    }
    public void SBO_AppEvent(SAPbouiCOM. BoAppEventTypes EventType)
    {

    }
    #endregion 
    private void SaveAsXML(ref SAPbouiCOM.Form Form)
    {

        System.Xml.XmlDocument oXmlDoc = null;
        string sXmlString = null;

        oXmlDoc = new System.Xml.XmlDocument();

        // get the form as an XML string
        sXmlString = Form.GetAsXML();

        // load the form's XML string to the
        // XML document object
        oXmlDoc.LoadXml(sXmlString);
 
 

        // save the XML Document
        oXmlDoc.Save((@"e:\22.xml"));

    } 
} 

