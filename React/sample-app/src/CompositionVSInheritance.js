import React from "react";
import ReactDOM from "react-dom";

// 包含关系
function FancyBorder(props) {
  return (
    <div className={"FancyBorder FancyBorder-" + props.color}>
      {props.children}
    </div>
  );
}

function WelcomeDialog() {
  return (
    <FancyBorder color="blue">
      <h1>欢迎</h1>
      <p className="Dialog-Message"></p>
    </FancyBorder>
  );
}

ReactDOM.render(
  <WelcomeDialog></WelcomeDialog>,
  document.getElementById("root")
);
