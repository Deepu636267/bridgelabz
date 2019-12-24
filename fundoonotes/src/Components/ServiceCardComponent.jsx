import React, { Component } from "react";
import { withRouter } from "react-router-dom";
import { Card} from "@material-ui/core";

class ServiceCardComponent extends Component {
  constructor(props) {
    super(props)
    this.state = {
      color: "antiquewhite",
      status: "Add to Cart",
      card: ""
    };
  }
 
  basicCardSelected = () => {
    var data = {
      color: "orange",
      status: "Selected",
      card: "basic"
    };
    this.props.history.push("/registration", data);
  };

  advancedCardSelected = () => {
    var data = {
      color: "orange",
      status: "Selected",
      card: "advance"
    };
    this.props.history.push("/registration", data);
  };

  servicemap1 = () => {
    return (
      <div className="secondCard_front_back">
        <div className="firstcard2">
          <Card className="back1" style={{ backgroundColor: "gray" }}></Card>
        </div>
        <div className="secondcard2">
          <Card
            className="front1"
            onClick={this.basicCardSelected}
            style={{
              backgroundColor:
                this.props.card === "basic"
                  ? this.props.color
                  : this.state.color
            }}
          >
            <div className="whole_FirstCard_Div_Content">
              <div className="Card_Content">
                <span
                  style={{
                    color: "black",
                    fontFamily: "TimesNewRoman",
                    fontSize: 25
                  }}
                >
                  price: $49 per month
                </span>
              </div>
              <div className="Card_Content">
                <span
                  style={{
                    color: "blue",
                    fontFamily: "TimesNewRoman",
                    fontSize: 25
                  }}
                >
                  basic
                </span>
              </div>
              <div className="Card_Content">
                <li className="card_Price">$49/month</li>
                <li className="card_Details">
                  Ability to add only title, description
                </li>
              </div>
            </div>
          </Card>
        </div>
      </div>
    );
  };
  serviceMap = () => {
    return (
      <div className="main_Card_Div">
        <div className="firstCard_front_back">
          <div className="firstcard">
            <Card className="back" style={{ backgroundColor: "gray" }}>
              <div>{this.state.status}</div>
            </Card>
          </div>
          <div className="secondcard">
            <Card
              className="front"
              onClick={this.advancedCardSelected}
              style={{
                backgroundColor:
                  this.props.card === "advance"
                    ? this.props.color
                    : this.state.color
              }}
            >
              <div className="whole_FirstCard_Div_Content">
                <div className="Card_Content">
                  <span
                    style={{
                      color: "black",
                      fontFamily: "TimesNewRoman",
                      fontSize: 25
                    }}
                  >
                    price: $99 per month
                  </span>
                </div>
                <div className="Card_Content">
                  <span
                    style={{
                      color: "blue",
                      fontFamily: "TimesNewRoman",
                      fontSize: 25
                    }}
                  >
                    advance
                  </span>
                </div>
                <div className="Card_Content">
                  <li className="card_Price">$99/month</li>
                  <li className="card_Details">
                    Ability to add title, description, images, labels, checklist
                    and colors
                  </li>
                </div>
              </div>
            </Card>
          </div>
        </div>
      </div>
    );
  };

  render() {
    return this.props.cartProps !== true ? (
      <div>
        <div
          style={{
            display: "flex",
            backgroundColor: "orange",
            height: 64,
            alignItems: "center"
          }}
        >
          <span
            style={{ color: "blue", fontFamily: "TimesNewRoman", fontSize: 30 }}
          >
            FundooNotes
          </span>
        </div>
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            height: 64,
            alignItems: "center"
          }}
        >
          <span
            style={{
              color: "black",
              fontFamily: "TimesNewRoman",
              fontSize: 30
            }}
          >
            FundooNotes offered. Choose below service to Register.
          </span>
        </div>
        <div className="CardComponent">
          <div>{this.serviceMap()}</div>
          <div>{this.servicemap1()}</div>
        </div>
      </div>
    ) : (
      <div className="CardComponent1">
        <div>{this.serviceMap()}</div>
        <div>{this.servicemap1()}</div>
      </div>
    );
  }
}
export default withRouter(ServiceCardComponent);
