import React from "react";
import ReactDOM from "react-dom";

// 组件 & Props
// 组件允许你将 UI 拆分为独立可复用的代码片段，并对每个片段进行独立构思。
// 组件，从概念上类似于 JavaScript 函数。它接受任意的入参（即 “props”），并返回用于描述页面展示内容的 React 元素。

// 该函数是一个有效的 React 组件，因为它接收唯一带有数据的 “props”（代表属性）对象与并返回一个 React 元素。
// 这类组件被称为“函数组件”，因为它本质上就是 JavaScript 函数。
function Welcome(props) {
  return <h1>Hello,{props.name}</h1>;
}

// 你同时还可以使用 ES6 的 class 来定义组件：
// class Welcome2 extends React.Component {
//   render() {
//     return <h1>Hello,{this.props.name}</h1>;
//   }
// }

// 上述两个组件在 React 里是等效的。

// 之前，我们遇到的 React 元素都只是 DOM 标签：
// const element = <div />;
// 不过，React 元素也可以是用户自定义的组件：
const element = <Welcome name="史强" />;

// 当 React 元素为用户自定义组件时，
// 它会将 JSX 所接收的属性（attributes）以及子组件（children）转换为单个对象传递给组件，
// 这个对象被称之为 “props”。

// 注意： 组件名称必须以大写字母开头。
// React 会将以小写字母开头的组件视为原生 DOM 标签。
// 例如，<div /> 代表 HTML 的 div 标签，而 <Welcome /> 则代表一个组件，并且需在作用域内使用 Welcome。

// 组合组件
// 组件可以在其输出中引用其他组件。
// 这就可以让我们用同一组件来抽象出任意层次的细节。
// 按钮，表单，对话框，甚至整个屏幕的内容：在 React 应用程序中，这些通常都会以组件的形式表示。
// 例如，我们可以创建一个可以多次渲染 Welcome 组件的 App 组件：
function App() {
  return (
    <div>
      <Welcome name="史强" />
      <Welcome name="史小明" />
      <Welcome name="罗辑" />
    </div>
  );
}

// 提取组件
function Comment(props) {
  return (
    <div className="Comment">
      <div className="UserInfo">
        <img
          className="Avatar"
          src={props.author.avatarUrl}
          alt={props.author.name}
        />
        <div className="UserInfo-name">{props.author.name}</div>
      </div>
      <div className="Comment-text">{props.text}</div>
      <div className="Comment-date">{formatDate(props.date)}</div>
    </div>
  );
}

function Avatar(props) {
  return (
    <img className="Avatar" src={props.user.avatarUrl} alt={props.user.name} />
  );
}

function UserInfo(props) {
  return (
    <div className="UserInfo">
      <Avatar user={props.user} />
      <div className="UserInfo-name">{props.user.name}</div>
    </div>
  );
}

function Comment2(props) {
  return (
    <div className="Comment">
      <UserInfo user={props.author} />
      <div className="Comment-text">{props.text}</div>
      <div className="Comment-date">{formatDate(props.date)}</div>
    </div>
  );
}

function formatDate(date) {
  return date.toLocaleDateString();
}

// Props 的只读性

ReactDOM.render(<App />, document.getElementById("root"));
