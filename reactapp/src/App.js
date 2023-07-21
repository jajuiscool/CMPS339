<<<<<<< Updated upstream
import React from 'react';
import { Header, Footer } from './components/common'

import './App.css';

function App() {
  return (
    <div className="App">
        <Header />
        <br />
        <br />
       
        <br />
        <br />
        <Footer />
    </div>
  );
}

export default App;
=======
import React, { useState, useEffect } from 'react';

const App =()=> {

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

    return(
        
        <div>
            {
                backendData.amusement-parks.map((parks, i) =>{
                    return(
                        <p key={i}>{parks.Name}</p>
                    )
                })
            }
        </div>
    )
}

export default App
>>>>>>> Stashed changes
