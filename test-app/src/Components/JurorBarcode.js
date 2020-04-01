import React from 'react';
import ReactDOM from "react-dom";
import Barcode from "react-barcode";
import "../App.css";

export default class BarcodeGenerator extends React.Component{

    render(){
        return(
            <div className="Center">
                <Barcode  value="0000001" /> 
            </div>

       );
    }
}