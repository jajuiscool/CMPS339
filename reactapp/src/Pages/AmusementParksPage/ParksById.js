import {Header, Footer} from '../../components/common'
import React, { useState, useEffect } from 'react';
import "./ParksPage.css";


export default function ParksById() {

    const[backendData,setBackendData] = useState([{}])

    useEffect(() =>{
        fetch("https://localhost:7085/api/amusement-parks/park-attractions?id=1").then(
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
         {backendData.map(park =>(<li key={park.id}>{park.name}</li>))} 
         
        <br />
        <br />
        <Footer />
        </div>
        </>
    )
}