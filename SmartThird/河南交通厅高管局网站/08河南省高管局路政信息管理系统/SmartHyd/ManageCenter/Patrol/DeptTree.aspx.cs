﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace SmartHyd.ManageCenter.Patrol
{
    public partial class DeptTree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (null == Request.QueryString["type"] || "" == Request.QueryString["type"])
                {

                }
                else
                {
                    string type = Request.QueryString["type"];//0代表人工巡逻；1代表电子巡逻
                    BindAcceptUnit(type);
                }
            }
        }
        /// <summary>
        /// 绑定单位信息
        /// </summary>
        private void BindAcceptUnit(string type)
        {
            string url = string.Empty;
            if (type == "0")
            {
                url = "ArtificialPatrol.aspx";
            }
            else
            {
                url = "ElectronicPatrol.aspx";
            }
            DataTable dt = new DataTable();
            //获取用户所属单位和下级部门
            BLL.BASE_DEPT dept = new BLL.BASE_DEPT();
            dt = dept.GetAllDep("STATUS=0");

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["PARENTID"].ToString().Equals("0"))
                {
                    TreeNode rootNode = new TreeNode();
                    rootNode.Text = dr["DPTNAME"].ToString();
                    rootNode.Value = dr["DEPTID"].ToString();
                    rootNode.ToolTip = dr["DPTINFO"].ToString();
                    rootNode.ShowCheckBox = false;
                    rootNode.Expanded = true;
                    rootNode.Target = "PatrolFrame";
                    
                    rootNode.NavigateUrl = url+"?deptid=" + dr["DEPTID"].ToString() + "&deptName=" + dr["DPTNAME"].ToString();//设置导航：绑定该部门下巡逻日志


                    //递归子节点
                    RecursiveBindAcceptUnit(rootNode, dt, url);

                    //加入控件
                    TreeViewAcceptUnit.Nodes.Add(rootNode);
                }
            }
        }

        /// <summary>
        /// 填充部门树
        /// </summary>
        /// <param name="node">根节点</param>
        /// <param name="dt">数据源</param>
        private void RecursiveBindAcceptUnit(TreeNode node, DataTable dt, string url)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["PARENTID"].ToString().Equals(node.Value))
                {
                    //添加子节点
                    TreeNode sub = new TreeNode();
                    sub.Text = dr["DPTNAME"].ToString();
                    sub.Value = dr["DEPTID"].ToString();
                    sub.ToolTip = dr["DPTINFO"].ToString();
                    sub.ShowCheckBox = false;
                    sub.Expanded = false;
                    sub.Target = "PatrolFrame";
                    sub.NavigateUrl = url+"?deptid=" + dr["DEPTID"].ToString() + "&deptName=" + dr["DPTNAME"].ToString();//设置导航：绑定该部门下巡逻日志

                    node.ChildNodes.Add(sub);

                    //递归循环
                    RecursiveBindAcceptUnit(sub, dt, url);
                }
            }
        }
       
    }
}