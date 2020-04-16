export default {
  singular: true,
  antd: {},
  routes: [
    {
      path: "/",
      component: "../layout",
      routes: [
        {
          path: "/",
          component: "./HelloWorld",
        },
        {
          path: "helloworld",
          component: "./HelloWorld",
        },
        {
          path: "/dashboard",
          routes: [
            { path: "/dashboard/analysis", component: "Dashboard/Analysis" },
            { path: "/dashboard/monitor", component: "Dashboard/Monitor" },
            { path: "/dashboard/workplace", component: "Dashboard/Workplace" },
          ],
        },
      ],
    },
  ],
};
