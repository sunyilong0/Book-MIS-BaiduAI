﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class DBHelper
    {
        private static String ConStr = "Data Source=HAINUXG-B7CDF23;Initial Catalog=Library;User ID=sa;Password=sa";
        private static SqlConnection conn;

        public static SqlConnection Conn
        {
            get
            {
                if (conn == null)
                {
                    conn = new SqlConnection(ConStr);
                    conn.Open();
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Broken)
                {
                    conn.Close();
                    conn.Open();
                }
                return conn;
            }
        }

        /// <summary>
        /// 执行SQL语句的方法,返回受影响行数
        /// </summary>
        /// <param name="CommandText"></param>
        /// <returns></returns>
        public static int ExecuteCommand(string CommandText)
        {
            SqlCommand cmd = new SqlCommand(CommandText, Conn);
            int k = cmd.ExecuteNonQuery();
            conn.Close();
            return k;
        }


        /// <summary>
        /// 表
        /// </summary>
        /// <param name="CommandText"></param>
        /// <param name="SqlName"></param>
        /// <returns></returns>
        public static DataSet ExecuteReTable(String CommandText,string SqlName)
        {
            SqlDataAdapter Adapter = new SqlDataAdapter(CommandText, Conn);
            //实例化DataSet对象
            DataSet ds = new DataSet();
            Adapter.Fill(ds, SqlName);
            Conn.Close();
            return ds;
        }

        /// <summary>
        /// 执行查询命令并返回值
        /// </summary>
        /// <param name="CommandText"></param>
        /// <returns></returns>
        public static int ExecuteSelect(String CommandText)
        {
            SqlCommand cmd = new SqlCommand(CommandText, Conn);
            int k = (int)cmd.ExecuteScalar();
            conn.Close();
            return k;
        }


        public static ArrayList ExecuteReArrList(String CommandText)
        {
            ArrayList arr = new ArrayList();           
            //实例化一个SqlCommand对象来执行SQL命令
            SqlCommand cmd = new SqlCommand(CommandText, Conn);
            try
            {
                //声明SqlDataReader对象读取SQL命令返回的数据
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())        //逐行读取数据
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        arr.Add(reader[i]);
                }
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                Conn.Close();
            }
            return arr;
        }
    }
}
