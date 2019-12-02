import React, { Component } from "react";
import { withRouter } from "react-router-dom";
import { Card, AppBar } from "@material-ui/core";
class ServiceCardComponent extends Component {
  render() {
    return (
      <div>
        <div style={{display:"flex", backgroundColor: "orange",height:64,alignItems: "center"}}>
        <span style={{ color: 'blue', fontFamily: 'TimesNewRoman', fontSize: 30 }}>FundooNotes</span>
        </div>
        <div style={{display:"flex", justifyContent:"center", height:64,alignItems: "center"}}>
        <span style={{ color: 'black', fontFamily: 'TimesNewRoman',fontSize: 30 }}>FundooNotes offered. Choose below service to Register.</span>
        </div>
        <div className="main_Card_Div">
          <div className='firstCard_front_back'>
            <div class="firstcard">
              <Card class="back"><div>Add To Cart</div></Card>
            </div>
            <div class="secondcard">
              <Card class="front">
                  <div className='whole_FirstCard_Div_Content'>
                    <div className='Card_Content'>
                        <span style={{ color: 'black', fontFamily: 'TimesNewRoman',fontSize: 25 }}>price: $99 per month</span>
                    </div>
                    <div className='Card_Content'>
                    <span style={{ color: 'blue', fontFamily: 'TimesNewRoman',fontSize: 25 }}>advance</span>
                    </div>
                    <div className='Card_Content'>
                        <li className='card_Price'>$99/month</li>
                        <li className='card_Details'>Ability to add title, description, images, labels, checklist and colors</li>
                    </div>
                  </div>
              </Card>
            </div>
          </div>
          <div  className='secondCard_front_back'>
            <div class="firstcard2">
              <Card class="back1"></Card>
            </div>
            <div class="secondcard2">
              <Card class="front1">
              <div className='whole_FirstCard_Div_Content'>
                    <div className='Card_Content'>
                        <span style={{ color: 'black', fontFamily: 'TimesNewRoman',fontSize: 25 }}>price: $49 per month</span>
                    </div>
                    <div className='Card_Content'>
                    <span style={{ color: 'blue', fontFamily: 'TimesNewRoman',fontSize: 25 }}>basic</span>
                    </div>
                    <div className='Card_Content'>
                        <li className='card_Price'>$49/month</li>
                        <li className='card_Details'>Ability to add only title, description</li>
                    </div>
                  </div>
              </Card>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
export default withRouter(ServiceCardComponent);
{
  /* <div>
<div >
  <AppBar style={{height:"59px"}}>
    <div class="service_header">Fundoonotes</div>
  </AppBar>
  <div>fundooNotes offered. Choose below service to Register.</div>
</div>
<div className="service_card_container">
    <Card>
<Card className="outerCard">
<Card className="innerCard">
    
    </Card>
</Card>
</Card>
</div>
</div> */
}
