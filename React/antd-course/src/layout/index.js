import { Component } from "react";
import { Layout } from "antd";

// Header, Footer, Sider, Content组件在Layout组件模块下
const { Header, Content, Footer, Sider } = Layout;

class BasicLayout extends Component {
  render() {
    return (
      <Layout>
        <Sider width={256} style={{ minHeight: "100vh", color: "white" }}>
          Sider
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
