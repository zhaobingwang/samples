import React from "react";
import ReactDOM from "react-dom";

// 受控组件
class NameForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = { value: "" };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({ value: event.target.value.toUpperCase() });
  }

  handleSubmit(event) {
    alert("提交的用户名：" + this.state.value);
    event.preventDefault();
  }

  render() {
    return (
      <form>
        <label>
          用户名：
          <input
            type="text"
            value={this.state.value}
            onChange={this.handleChange}
          ></input>
        </label>
      </form>
    );
  }
}

// textarea 标签
class EasyForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      value: "在此处编写文章..."
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({ value: event.target.value });
  }

  handleSubmit(event) {
    alert("提交的文章：" + this.state.value);
    event.preventDefault();
  }

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <label>
          内容：
          <textarea
            value={this.state.value}
            onChange={this.handleChange}
          ></textarea>
        </label>
        <input type="submit" value="提交"></input>
      </form>
    );
  }
}

// select 标签
class FruitForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = { value: "strawberry" };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  handleChange(event) {
    this.setState({ value: event.target.value });
  }
  handleSubmit(event) {
    alert("你最喜欢的水果是：" + this.state.value);
    event.preventDefault();
  }
  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <label>
          选择你最喜欢的水果：
          <select value={this.state.value} onChange={this.handleChange}>
            <option value="apple">苹果</option>
            <option value="watermelon">西瓜</option>
            <option value="strawberry">草莓</option>
          </select>
        </label>
        <input type="submit" value="提交"></input>
      </form>
    );
  }
}

// TODO:文件 input 标签

// 处理多个输入
class Reservation extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isGoing: true,
      numberOfGuests: 2
    };
    this.handleInputChange = this.handleInputChange.bind(this);
  }

  handleInputChange(event) {
    const target = event.target;
    const value = target.name === "isGoing" ? target.checked : target.value;
    const name = target.name;

    this.setState({
      [name]: value
    });
  }

  render() {
    return (
      <form>
        <label>
          参与：
          <input
            name="isGoing"
            type="checkbox"
            checked={this.state.isGoing}
            onChange={this.handleInputChange}
          ></input>
        </label>
        <br />
        <label>
          来宾人数：
          <input
            name="numberOfGuests"
            type="number"
            value={this.state.numberOfGuests}
            onChange={this.handleInputChange}
          ></input>
        </label>
      </form>
    );
  }
}

// ReactDOM.render(<NameForm></NameForm>, document.getElementById("root"));

// ReactDOM.render(<EasyForm></EasyForm>, document.getElementById("root"));

// ReactDOM.render(<FruitForm></FruitForm>, document.getElementById("root"));

ReactDOM.render(<Reservation></Reservation>, document.getElementById("root"));
