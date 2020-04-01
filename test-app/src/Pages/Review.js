import React from 'react';
import "../App.css";
import MobileHeader from '../Components/MobileHeader';
import { Link }  from 'react-router-dom';


export default class Review extends React.Component {
    render(){
        return(
            <div className="Deferment">
                <MobileHeader></MobileHeader>
                
                Thank you for filling out the questionairre. According to your answer(s), your questionnaire is under review for eligibility of Jury Duty. We will send a push notification to your phone once the review in finalized.
                <div>
                    <Link to='/' ><button className="cta_button"> Close</button></Link>
                </div>               
            </div>
        );
    }
}