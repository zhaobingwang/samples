using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace CodeSnippets
{
    public class XmlOperation
    {
        public static XmlDocument BuildXml()
        {
            XmlDocument xmlDocument = new XmlDocument();
            // 1.root
            var root = xmlDocument.CreateElement("root");
            var rootComment = xmlDocument.CreateComment("这是根节点");
            xmlDocument.AppendChild(rootComment);
            xmlDocument.AppendChild(root);

            // 2. 用户信息集合
            var nodeUsers = xmlDocument.CreateElement("Users");
            var nodeUsersComment = xmlDocument.CreateComment("用户信息集合");

            // 2.1 用户1
            // 2.1.1 创建用户节点
            var nodeUser = xmlDocument.CreateElement("User");
            var nodeUserComment = xmlDocument.CreateComment("用户信息");
            var nodeId = xmlDocument.CreateElement("Id");
            var nodeName = xmlDocument.CreateElement("Name");
            var nodeGender = xmlDocument.CreateElement("Gender");
            // 2.1.2 给用户属性赋值并将用户属性节点插入到User节点
            nodeUser.AppendChild(xmlDocument.CreateComment("用户ID"));
            nodeUser.AppendChild(nodeId).InnerText = "0001";
            nodeUser.AppendChild(xmlDocument.CreateComment("用户姓名"));
            nodeUser.AppendChild(nodeName).InnerText = "张三";
            nodeUser.AppendChild(xmlDocument.CreateComment("用户性别"));
            nodeUser.AppendChild(nodeGender).InnerText = "男";
            nodeUser.SetAttribute("index", "1");
            // 2.1.3 用户1的节点插入到Users节点下
            nodeUsers.AppendChild(nodeUserComment);
            nodeUsers.AppendChild(nodeUser);

            // 2.2 用户2
            // 2.2.1 创建用户节点
            var nodeUser2 = xmlDocument.CreateElement("User");
            var nodeUser2Comment = xmlDocument.CreateComment("用户信息");
            var nodeId2 = xmlDocument.CreateElement("Id");
            var nodeName2 = xmlDocument.CreateElement("Name");
            var nodeGender2 = xmlDocument.CreateElement("Gender");
            // 2.2.2 给用户属性赋值并将用户属性节点插入到User节点
            nodeUser2.AppendChild(xmlDocument.CreateComment("用户ID"));
            nodeUser2.AppendChild(nodeId2).InnerText = "0002";
            nodeUser2.AppendChild(xmlDocument.CreateComment("用户姓名"));
            nodeUser2.AppendChild(nodeName2).InnerText = "李四";
            nodeUser2.AppendChild(xmlDocument.CreateComment("用户性别"));
            nodeUser2.AppendChild(nodeGender2).InnerText = "女";
            nodeUser2.SetAttribute("index", "2");
            // 2.2.3 用户2的节点插入到Users节点下
            nodeUsers.AppendChild(nodeUser2Comment);
            nodeUsers.AppendChild(nodeUser2);

            // 2.3 将用户集合节点插入到root节点下
            root.AppendChild(nodeUsersComment);
            root.AppendChild(nodeUsers);

            return xmlDocument;
        }

        public static string FormatXml(object xml)
        {
            XmlDocument xd;
            if (xml is XmlDocument)
            {
                xd = xml as XmlDocument;
            }
            else
            {
                xd = new XmlDocument();
                xd.LoadXml(xml as string);
            }
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            XmlTextWriter xtw = null;
            try
            {
                xtw = new XmlTextWriter(sw);
                xtw.Formatting = Formatting.Indented;
                xtw.Indentation = 4;
                //xtw.IndentChar = '\t';
                xd.WriteTo(xtw);
            }
            finally
            {
                if (xtw != null)
                    xtw.Close();
            }
            return sb.ToString();
        }
    }

    public class XMLModel
    {
        public int InbValue { get; set; }
        public string StringValue { get; set; }
        public DateTime DateTimeValue { get; set; }
        public decimal DecimalValue { get; set; }
        public bool BoolValue { get; set; }
    }
}
