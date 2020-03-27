import React from "react";
import ReactDOM from "react-dom";

// ****************************************Rendering Elements START****************************************
// 元素是React应用程序的最小构件。
// 与浏览器的 DOM 元素不同，React 元素是创建开销极小的普通对象。React DOM 会负责更新 DOM 来与 React 元素保持一致。
// const element = <h1>Hello,World.</h1>;

// 这个例子会在 setInterval() 回调函数，每秒都调用 ReactDOM.render()。
function tick() {
  const element = (
    <div>
      <h1>Hello,World</h1>
      <h2>It is {new Date().toLocaleTimeString()}.</h2>
    </div>
  );
  ReactDOM.render(element, document.getElementById("root"));
}
setInterval(() => {
  tick();
}, 1000);

// ****************************************Rendering Elements END****************************************

// ReactDOM.render(element, document.getElementById("root"));
