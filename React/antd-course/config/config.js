export default {
  singular: true,
  antd: {},
  routes: [
    {
      path: "/",
      component: "../layout",
      routes: [
        {
          path: "helloworld",
          component: "./HelloWorld",
        },
        {
          path: "/",
          component: "./HelloWorld",
        },
      ],
    },
  ],
};
