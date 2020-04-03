import React from "react";
import ReactDOM from "react-dom";

class Toggle extends React.Component {
  constructor(props) {
    super(props);
    this.state = { isToggleOn: true };
    // 为了在回调中使用`this`，这个绑定时必须的
    this.handleClick = this.handleClick.bind(this);
  }

  handleClick() {
    this.setState(state => ({
      isToggleOn: !state.isToggleOn
    }));
  }

  render() {
    return (
      <button onClick={this.handleClick}>
        {this.state.isToggleOn ? "开" : "关"}
      </button>
    );
  }
}

ReactDOM.render(<Toggle></Toggle>, document.getElementById("root"));
