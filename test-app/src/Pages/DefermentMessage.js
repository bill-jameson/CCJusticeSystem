import React from 'react';
import "../App.css";
import MobileHeader from '../Components/MobileHeader';
import { Link } from 'react-router-dom';


export default class Deferment extends React.Component {
    render(){
        return(
            <div className="Deferment">
                <MobileHeader></MobileHeader>
                Thank you for filling out the questionairre. Based on your answers, we have determined that you qualify for Deferment and are no longer needed for Jury Duty.
                <div>
                    <Link to='/'><button className="cta_button"> Close</button></Link>
                </div>               
            </div>
        );
    }
}