import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';

// JSX
const name = '叶文洁';
const element1 = <h1>Hello,{name}!</h1>

const user = {
    firstName: '淼',
    lastName: '汪'
}
function formatCnName(user) {
    return user.lastName + ' ' + user.firstName;
}
const element2 = (
    <h1>
        Hello,{formatCnName(user)}!
    </h1>
)

// ========================================

ReactDOM.render(
    // element1,
    element2,
    document.getElementById('root'),
);
