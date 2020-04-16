import React, { Component } from "React";
import { Card, Button } from "antd";
import { connect } from "dva";

const namespace = "puzzlecards";
const mapStateToProps = (state) => {
  const cardList = state[namespace].data;
  return {
    cardList,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    onClickAdd: (newCard) => {
      const action = {
        type: `${namespace}/addNewCard`,
        payload: newCard,
      };
      dispatch(action);
    },
  };
};

@connect(mapStateToProps, mapDispatchToProps)
export default class PuzzleCardsPage extends Component {
  render() {
    return (
      <div>
        {this.props.cardList.map((card) => {
          return (
            <Card key={card.id}>
              <div>Q:{card.setup}</div>
              <div>
                <strong>A:{card.punchline}</strong>
              </div>
            </Card>
          );
        })}
        <br />
        <div>
          <Button
            type="primary"
            onClick={() =>
              this.props.onClickAdd({
                setup:
                  "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                punchline: "here we use dva",
              })
            }
          >
            Add Card
          </Button>
        </div>
      </div>
    );
  }
}
