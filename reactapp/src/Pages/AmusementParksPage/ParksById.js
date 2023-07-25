import {Header, Footer} from '../../components/common'
import React, { useState, useEffect } from 'react';
import "./ParksPage.css";


export default function ParksById() {

    const[backendData,setBackendData] = useState([])

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
        console.log(data.attractions)
            
            {backendData && backendData.attractions.map((x,y)=>{
                return(<div key={y}>{x.name}</div>)
            })}
        {/* {backendData.map(details =>(<li key={details.id}>{details.name}</li>))}  */}

        </div>
        <br />
        <br />
        <br />
        <br />
        <Footer />
        </div>
        </>
    )
}