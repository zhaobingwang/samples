import React from "react";
import ReactDOM from "react-dom";

// function Clock(props) {
//   return (
//     <div>
//       <h1>Hello,World</h1>
//       <h2>现在是 {props.date.toLocaleTimeString()}</h2>
//     </div>
//   );
// }

// function tick() {
//   ReactDOM.render(<Clock date={new Date()} />, document.getElementById("root"));
// }
// setInterval(() => {
//   tick();
// }, 1000);

// 将函数组件转换成 class 组件
class Clock extends React.Component {
  constructor(props) {
    super(props);
    this.state = { date: new Date() };
  }

  componentDidMount() {
    this.timerID = setInterval(() => this.tick(), 1000);
  }
  
  componentWillUnmount() {
    clearInterval(this.timerID);
  }

  tick() {
    this.setState({
      date: new Date()
    });
  }

  render() {
    return (
      <div>
        <h2>现在是 {this.state.date.toLocaleTimeString()}</h2>
      </div>
    );
  }
}

ReactDOM.render(<Clock></Clock>, document.getElementById("root"));
