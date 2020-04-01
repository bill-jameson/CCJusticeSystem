import React from "react";
import logo from "../CCLogo_Black.jpg";
import "../App.css";
import { Link } from 'react-router-dom';

export default class MobileHeader extends React.Component {

    render() {
        return(
            <div className="mobile-header">
                <Link to="/"><img className="Header-logo" src={logo}/></Link>
                    <div className="Header-welcome">
                        <label >Welcome, </label>
                    </div> 
           </div>
        )
    } 
};

