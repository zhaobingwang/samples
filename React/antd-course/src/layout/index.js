import { Component } from "react";
import { Layout, Menu } from "antd";
import { DashboardOutlined, PieChartOutlined } from "@ant-design/icons";

// Header, Footer, Sider, Content组件在Layout组件模块下
const { Header, Content, Footer, Sider } = Layout;

// 引入子菜单组件
const SubMenu = Menu.SubMenu;

class BasicLayout extends Component {
  render() {
    return (
      <Layout>
        <Sider width={256} style={{ minHeight: "100vh", color: "white" }}>
          <div
            style={{
              height: "32px",
              background: "rgba:(255,255,255,.2)",
              margin: "16px",
            }}
          ></div>
          <Menu theme="dark" mode="inline" defaultOpenKeys={["1"]}>
            <Menu.Item key="1">
              <PieChartOutlined />
              <span>HelloWorld</span>
            </Menu.Item>
            <SubMenu
              key="sub1"
              title={
                <span>
                  <DashboardOutlined />
                  <span>Dashboard</span>
                </span>
              }
            >
              <Menu.Item key="2">分析页</Menu.Item>
              <Menu.Item key="3">监控页</Menu.Item>
              <Menu.Item key="4">工作台</Menu.Item>
            </SubMenu>
          </Menu>
        </Sider>
        <Layout>
          <Header
            style={{ background: "#fff", textAlign: "center", padding: 0 }}
          >
            Header
          </Header>
          <Content style={{ margin: "24px 16px 0" }}>
            <div style={{ padding: 24, background: "#fff", minHeight: 360 }}>
              {this.props.children}
            </div>
          </Content>
          <Footer style={{ textAlign: "center" }}>Antd Course</Footer>
        </Layout>
      </Layout>
    );
  }
}
export default BasicLayout;
