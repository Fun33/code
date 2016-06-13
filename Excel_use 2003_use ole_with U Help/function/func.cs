using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
public class func
{

    int lRetCode;
    int lErrCode;

    string sErrMsg;

    //di.doquery
    public static string DoQuery(string cmd, SAPbobsCOM.Company oCompany)
    {
        string ret = "";
        try
        {
            SAPbobsCOM.Recordset recorder = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            recorder.DoQuery(cmd);

            if (recorder.Fields.Count != 0)
            {
                ret = recorder.Fields.Item(0).Value.ToString();

            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }

        return ret;
    }

    public void addUDF(SAPbobsCOM.Company oCompany, string fldTable, string fldName, string fldDesc, SAPbobsCOM.BoFieldTypes sType, int sSize)
    {

        SAPbobsCOM.UserFieldsMD oUserFieldsMD = default(SAPbobsCOM.UserFieldsMD);

        oUserFieldsMD = (SAPbobsCOM.UserFieldsMD)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserFields);

        oUserFieldsMD.TableName = fldTable;
        oUserFieldsMD.Name = fldName;
        oUserFieldsMD.Description = fldDesc;
        oUserFieldsMD.Type = sType;
        oUserFieldsMD.EditSize = sSize;
        try
        {
            lRetCode = oUserFieldsMD.Add();

            //// Check for errors
            if (lRetCode != 0)
            {
                oCompany.GetLastError(out lErrCode,out  sErrMsg);
            }
            else
            {
                //log("Field: '" & oUserFieldsMD.Name & "' was added successfuly to " & oUserFieldsMD.TableName & " Table")
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        oUserFieldsMD = null;
    }
 
    public static void log(  string Message )
        {
            string Path, FileName;
            string Msg = string.Empty;
            Msg +=  DateTime.Now.ToString(); 
            Msg += " " + Message;
            FileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName   + DateTime.Now.ToString("yyyyMMdd") + ".log";
            Path =  "C:\\Log\\" + FileName;
            System.IO.Directory.CreateDirectory("C:\\Log\\");

            System.IO.StreamWriter sw = new System.IO.StreamWriter(Path, true, System.Text.Encoding.GetEncoding("big5"));
            sw.WriteLine(Msg);
            sw.WriteLine("");
            sw.Dispose();
            sw = null;
    }
}
