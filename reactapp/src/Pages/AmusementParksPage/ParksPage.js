import {Header, Footer} from '../../components/common'
import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom'
import "./ParksPage.css";


export default function Parks() {

    const[backendData,setBackendData] = useState([{}])

    useEffect(() =>{
        fetch("https://localhost:7085/api/amusement-parks").then(
            response => response.json()
        ).then(
            data => {
                setBackendData(data)
            }
        ) 
    },[])
    return (
        <>
    <div className="App">
        <Header />

        <div>
        
        </div>
        <br />
        <br />

         <Link to='/parks-by-id'>{backendData.map(park =>(<li key={park.id}>{park.name}</li>))}</Link>

        <br />
        <br />
        <Footer />
        </div>
        </>
    )
}