interface Person {
    firstName: string;
    lastName: string;
}

class Student {
    fullName: string;
    constructor(public firstName: string, public middleInitial: string, public lastName: string) {
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
}

function greeter(person: Person) {
    return "Hello," + person.firstName + " " + person.lastName;
}

let user = new Student("三", "", "张");
var aa = greeter(user);
document.body.innerHTML = greeter(user);