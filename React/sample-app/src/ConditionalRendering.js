import React from "react";
import ReactDOM from "react-dom";

function UserGreeting(props) {
  return <h1>欢迎回来！</h1>;
}

function GuestGreeting(props) {
  return <h1>请登录</h1>;
}

function Greeting(props) {
  const isLoggedIn = props.isLoggedIn;
  if (isLoggedIn) {
    return <UserGreeting></UserGreeting>;
  }
  return <GuestGreeting></GuestGreeting>;
}

function LoginButton(props) {
  return <button onClick={props.onClick}>登录</button>;
}
function LogoutButton(props) {
  return <button onClick={props.onClick}>退出</button>;
}

class LoginControl extends React.Component {
  constructor(props) {
    super(props);
    this.handleLoginClick = this.handleLoginClick.bind(this);
    this.handleLogoutClick = this.handleLogoutClick.bind(this);
    this.state = { isLoggedIn: false };
  }
  handleLoginClick() {
    this.setState({ isLoggedIn: true });
  }
  handleLogoutClick() {
    this.setState({ isLoggedIn: false });
  }
  render() {
    const isLoggedIn = this.state.isLoggedIn;
    let button;
    if (isLoggedIn) {
      button = <LogoutButton onClick={this.handleLogoutClick}></LogoutButton>;
    } else {
      button = <LoginButton onClick={this.handleLoginClick}></LoginButton>;
    }
    return (
      <div>
        <Greeting isLoggedIn={isLoggedIn}></Greeting>
        {button}
      </div>
    );
  }
}
// =============与运算符 &&=============
function Mailbox(props) {
  const unreadMessage = props.unreadMessage;
  return (
    <div>
      <h1>你好！</h1>
      {/* 在 JavaScript 中，true && expression 总是会返回 expression, 而 false && expression 总是会返回 false。 */}
      {unreadMessage.length > 0 && (
        <h2>你有{unreadMessage.length}条未读邮件。</h2>
      )}
    </div>
  );
}

const messages = [
  "你收到一个新的PR",
  "账号登录异常提醒",
  "Issue #1 被张三关闭了"
];

// ==========三目运算符==========

// ==========阻止组件渲染==========
// 在极少数情况下，你可能希望能隐藏组件，即使它已经被其他组件渲染。若要完成此操作，你可以让 render 方法直接返回 null，而不进行任何渲染。
function WarningBanner(props) {
  if (!props.warn) {
    return null;
  }
  return <div className="warning">警告！</div>;
}
class Page extends React.Component {
  constructor(props) {
    super(props);
    this.state = { showWarning: true };
    this.handleToggleClick = this.handleToggleClick.bind(this);
  }

  handleToggleClick() {
    this.setState(state => ({
      showWarning: !state.showWarning
    }));
  }

  render() {
    return (
      <div>
        <WarningBanner warn={this.state.showWarning}></WarningBanner>
        <button onClick={this.handleToggleClick}>
          {this.state.showWarning ? "隐藏" : "显示"}
        </button>
      </div>
    );
  }
}

// ReactDOM.render(<LoginControl></LoginControl>, document.getElementById("root"));

// ReactDOM.render(
//   <Mailbox unreadMessage={messages}></Mailbox>,
//   document.getElementById("root")
// );

ReactDOM.render(<Page></Page>, document.getElementById("root"));
