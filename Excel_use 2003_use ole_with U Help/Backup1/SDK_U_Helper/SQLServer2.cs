using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

/*
 * c1 open conn ->start tran ->exe ->roll / commit ->close conn
 * c2 open conn ->exe ->close conn
 * 
 * s1  new -->open conn ->start tran ->exe ->roll / commit ->close conn
 * s2  new -->open conn ->exe ->close conn
 *   
 * 正常流程
 *s1 ->c1
 * s1->c1->c1
 * s1->c1->c2
 * 
 *s1->c2
 * s1->c2->c2
 * s1->c2->c1
 * 
 *不正常流程
 * open conn沒關,又open conn
 * close conn沒開,又close conn
 * start tran沒結束,又start
 * 沒有start,又commit
 * 沒有start,又roll
 * 
 * ??要不要dispose
 * 
 * 
 */
public class SQLServer2
{
    SqlConnection myConnection;
    SqlTransaction myTrans;
    SqlCommand myCommand = new SqlCommand();

    public SQLServer2(string conn)
    {
        myConnection = new SqlConnection(conn);
        OpenConn();
    }
    public void OpenConn()
    {
        
        try
        {

            //if (myConnection.State == ConnectionState.Close)
            if (myConnection.State == ConnectionState.Closed)
{ 
            myConnection.Open();
            myCommand.Connection = myConnection;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void closeConn()
    {
        try
        {
            if (myConnection.State == ConnectionState.Open )
            {
                myConnection.Close();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void StartTransaction()
    {
        try
        {
            myTrans = myConnection.BeginTransaction();            
            myCommand.Transaction = myTrans;
        }
        catch (Exception ex)
        {
            
        }
    }

    public void ExecCmd(string cmd)
    {
        try
        {
            myCommand.CommandText = cmd;
            myCommand.ExecuteNonQuery();
            
        }
        catch (Exception ex)
        {
 //這裡可能有trancation 要rollback.
            //如果沒有transaction,就沒關係.

        }
    }
    public void CommitTransaction()
    {
        myTrans.Commit();
        myConnection.Close();
    }
    public void RollTrancation()
    {
        myTrans.Rollback();
        myConnection.Close();
    }
}
 

      
     

   
 
