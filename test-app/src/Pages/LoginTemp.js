import React from 'react';
import "../App.css";
import MobileHeader from '../Components/MobileHeader';
import { Link } from 'react-router-dom';
import { apiService } from '../Services/summonsAPI';


export default class Login extends React.Component {
    constructor(props){
        super(props);

        this.state = {
            juror: ''
        }
    }
 
authenticate = async () => {
    const data = await apiService.getSummonsRecipientLogin('0001', '1');
    console.log(data);
    this.setState({juror: data})
}
    render(){
        return(
            <div className="Deferment">
                <MobileHeader></MobileHeader>
                <Link to='/checkin' >Login</Link> 
                <p></p>         
                <Link to='/deferment' >Deferment</Link> 
                <p></p>     
                <Link to='/review' >Review</Link> 
                <div>
                    <button onClick={this.authenticate}>Simulate Login</button>
                </div>
                <div>
                    Juror Information: <span>{this.state.juror}</span> 
                </div>
            </div>
        );
    }
}