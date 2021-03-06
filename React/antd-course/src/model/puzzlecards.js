import reqeust from "../util/request";
import { message } from "antd";

const delay = (millisecond) => {
  return new Promise((resolve) => {
    setTimeout(resolve, millisecond);
  });
};

export default {
  namespace: "puzzlecards",
  state: {
    data: [],
    counter: 0,
  },
  effects: {
    *queryInitCards(_, sagaEffects) {
      const { call, put } = sagaEffects;

      // see more info : https://github.com/15Dkatz/official_joke_api
      const endPointURI = "/dev/random_joke";
      try {
        const puzzle = yield call(reqeust, endPointURI);
        yield put({ type: "addNewCard", payload: puzzle });

        yield call(delay, 3000);

        const puzzle2 = yield call(reqeust, endPointURI);
        yield put({ type: "addNewCard", payload: puzzle2 });

        yield call(delay, 3000);

        const puzzle3 = yield call(reqeust, endPointURI);
        yield put({ type: "addNewCard", payload: puzzle3 });
      } catch (e) {
        message.error("数据获取失败"); // 打印错误信息
      }
    },
  },
  reducers: {
    addNewCard(state, { payload: newCard }) {
      const nextCounter = (state.counter += 1);
      const newCardWithId = { ...newCard, id: nextCounter };
      const nextData = state.data.concat(newCardWithId);
      return {
        data: nextData,
        counter: nextCounter,
      };
    },
  },
};
