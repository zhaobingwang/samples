import { Component } from "react";
import { Layout, Menu } from "antd";
import {
  DashboardOutlined,
  PieChartOutlined,
  QuestionCircleOutlined,
} from "@ant-design/icons";
import { Link } from "umi";

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
              <Link to="/helloworld">
                <PieChartOutlined />
                <span>HelloWorld</span>
              </Link>
            </Menu.Item>
            <Menu.Item key="2">
              <Link to="/puzzlecards">
                <QuestionCircleOutlined />
                <span>Puzzle Card</span>
              </Link>
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
              <Menu.Item key="12">
                <Link to="/dashboard/analysis">分析页</Link>
              </Menu.Item>
              <Menu.Item key="13">
                <Link to="/dashboard/monitor">监控页</Link>
              </Menu.Item>
              <Menu.Item key="14">
                <Link to="/dashboard/workplace">工作台</Link>
              </Menu.Item>
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
