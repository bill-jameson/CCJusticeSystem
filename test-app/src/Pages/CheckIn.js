import React from 'react';
import MobileHeader from "../Components/MobileHeader";
import JurorBarcode from "../Components/JurorBarcode";
import Attendance from "../Components/Attendance";
import Check from '../green check mark.jfif';
import "../App.css";

export default class CheckIn extends React.Component{

    render() {
        return(
            <div>
                 <MobileHeader></MobileHeader>
                 <p></p>
                <div className="Center">                        
                    Your jury duty date is XX/XX/XXXX
                </div>
                <div  className="Center">
                    <img  className="Check" src={Check}/>
                    Thank you for filling out your questionairre
                </div>
                <p></p>
                <div className="Center">
                    Your check-in bar code:
                    <JurorBarcode className="Center"></JurorBarcode>
                </div>
                <div className="Center">
                    <Attendance></Attendance>
                </div>
            </div>                
        );
    }
}