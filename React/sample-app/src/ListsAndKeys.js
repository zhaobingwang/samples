import React from "react";
import ReactDOM from "react-dom";

function ListItem(props) {
  const value = props.value;
  return <li>{value}</li>;
}

function NumberList(props) {
  const numbers = props.numbers;
  const listItems = numbers.map(number => (
    <ListItem key={number.toString()} value={number}></ListItem>
  ));
  return <ul>{listItems}</ul>;
}

const numbers = [1, 2, 3, 4, 5];

function Blog(props) {
  const sidebar = (
    <ul>
      {props.posts.map(post => (
        <li key={post.id}>{post.title}</li>
      ))}
    </ul>
  );
  const content = props.posts.map(post => (
    <div key={post.id}>
      <h3>{post.title}</h3>
      <p>{post.content}</p>
    </div>
  ));
  return (
    <div>
      {sidebar}
      <hr />
      {content}
    </div>
  );
}

const posts = [
  { id: 1, title: ".NET", content: ".NET微服务应用" },
  { id: 2, title: "React", content: "React基础" }
];

// ReactDOM.render(
//   <NumberList numbers={numbers}></NumberList>,
//   document.getElementById("root")
// );

ReactDOM.render(<Blog posts={posts}></Blog>, document.getElementById("root"));
